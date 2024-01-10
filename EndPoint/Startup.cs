using Application.Interface;
using Application.Interface.FacadPattern;
using Application.Services.FacadPattern;
using Application.Services.QuartzTasks.EmailSender;
using Application.Services.QuartzTasks.GetBlogPosts;
using Application.Services.QuartzTasks.RemoveLogs;
using Common;
using EndPoint.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistance.Context;
using Quartz;
using System;

namespace EndPoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //get app seting data
            GetAppSettingData Data = new GetAppSettingData(Configuration);

            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
            }).AddGoogle(options =>
            {
                options.ClientId = Data.GetGoogleOAuthClientId();
                options.ClientSecret = Data.GetGoogleOAuthClientSecret();
                options.Scope.Add("https://www.googleapis.com/auth/drive");
                options.Scope.Add("https://www.googleapis.com/auth/drive.readonly");
            });
            services.Configure<GoogleCaptchaConfigModel>(Configuration.GetSection("GoogleRecaptcha"));

            services.AddRouting(options =>
            {
                options.AppendTrailingSlash = true;
            });

            #region Quartz
            services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionScopedJobFactory();

                // Create "key" for job
                var RemoveLogs = new JobKey("RemoveLogs");
                q.AddJob<RemoveLog>(opts => opts.WithIdentity(RemoveLogs));
                // Create a trigger for job
                q.AddTrigger(opts => opts
                    .ForJob(RemoveLogs)
                    .WithIdentity("RemoveLogs-trigger") // give the trigger a unique name
                    .WithCronSchedule("0 0 2 */2 * ?")); //Every 2 days at 2am  0 0 2 */2 * ?  //  5 secend for test --> 0/5 * * * * ?  

                var RemoveFiles = new JobKey("RemoveFiles");
                q.AddJob<RemoveInputFiles>(opts => opts.WithIdentity(RemoveFiles));
                q.AddTrigger(opts => opts
                    .ForJob(RemoveFiles)
                    .WithIdentity("RemoveFiles-trigger")
                    .WithCronSchedule("0 0 0/2 ? * *")); //Every even hour --> 0 0 0/2 ? * *

                var DatabaseBackup = new JobKey("DatabaseBackup");
                q.AddJob<DatabaseBackup>(opts => opts.WithIdentity(DatabaseBackup));
                q.AddTrigger(opts => opts
                    .ForJob(DatabaseBackup)
                    .WithIdentity("DatabaseBackup-trigger")
                    .WithCronSchedule("0 0 4 15 * ?")); //Every month on the 15th, at 4am --> 0 0 4 15 * ?

                var EmailFileSender = new JobKey("EmailFileSender");
                q.AddJob<EmailFileSender>(opts => opts.WithIdentity(EmailFileSender));
                q.AddTrigger(opts => opts
                    .ForJob(EmailFileSender)
                    .WithIdentity("EmailFileSender-trigger")
                    .WithCronSchedule("0 */3 * ? * *")); //Every 3 minutes --> 0 */3 * ? * *
                                                         
                var GetBlogPosts = new JobKey("GetBlogPostsQuartz");
                q.AddJob<GetBlogPostsQuartz>(opts => opts.WithIdentity(GetBlogPosts));
                q.AddTrigger(opts => opts
                    .ForJob(GetBlogPosts)
                    .WithIdentity("GetBlogPostsQuartz-trigger")
                    .WithCronSchedule("0 15 10 ? * *")); //10:15am every day --> 0 15 10 ? * *
               
            });

            services.AddQuartzServer(options =>
            {
                // when shutting down jobs to complete gracefully
                options.WaitForJobsToComplete = true;
            });

            #endregion

            #region Facad
            services.AddScoped<IAncillaryServicesFacad, AncillaryServicesFacad>();
            services.AddScoped<IConvertersFromPdfFacad, ConvertersFromPdfFacad>();
            services.AddScoped<IConvertLogFacad, ConvertLogFacad>();
            services.AddScoped<IQuartzServicesFacad, QuartzServicesFacad>();
            services.AddScoped<IFeaturesDetailsFacad, FeaturesDetailsFacad>();
            services.AddScoped<IConvertersToPdfFacad, ConvertersToPdfFacad>();
            services.AddScoped<IOrganizersLogFacad, OrganizersLogFacad>();
            services.AddScoped<IOptimizersLogFacad, OptimizersLogFacad>();
            services.AddScoped<ISecurityLogFacad, SecurityLogFacad>();
            services.AddScoped<IOtherFeaturesLogService, OtherFeaturesLogService>();
            services.AddScoped<IViewContextFacad, ViewContextFacad>();
            services.AddScoped<ISecurityFacad, SecurityFacad>();
            services.AddScoped<IOrganizersFacad, OrganizersFacad>();
            services.AddScoped<IOtherFeaturesService, OtherFeaturesService>();
            services.AddScoped<IOptimizersFacad, OptimizersFacad>();
            services.AddScoped<IInitialDataFacad, InitialDataFacad>();
            services.AddScoped<ISeoFacad, SeoFacad>();
            #endregion

            #region Admin Facad
            services.AddScoped<IAdminFacad, AdminFacad>();
            #endregion

            #region Context
            services.AddScoped<IPdfConverterContext, PdfConverterContext>();
            services.AddEntityFrameworkSqlServer().AddDbContext<PdfConverterContext>(option => option.UseSqlServer(Data.GetConnection()));
            #endregion

            services.AddControllersWithViews();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error/NotFound");
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            /*var options = new RewriteOptions() //add / to end of url
.AddRedirect("(.*[^/])$", "$1/")
.AddRedirectToHttpsPermanent();
            app.UseRewriter(options);*/


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "posting",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                   name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
