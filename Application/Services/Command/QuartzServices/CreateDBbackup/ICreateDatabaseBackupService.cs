using Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Application.Services.Command.QuartzServices.CreateDBbackup
{
    public interface ICreateDatabaseBackupService
    {
        ResultMessage Execute();
    }
    public class CreateDatabaseBackupService : ICreateDatabaseBackupService
    {
        private readonly IConfiguration _Configuration;
        public CreateDatabaseBackupService(IConfiguration configuration)
        {
            _Configuration = configuration;
        }
        ResultMessage ICreateDatabaseBackupService.Execute()
        {
            GetAppSettingData Data = new GetAppSettingData(_Configuration);
            try
            {
                if (!Directory.Exists(GetPath.GetBackupPath()))
                    Directory.CreateDirectory(GetPath.GetBackupPath());

                using (var connection = new SqlConnection(Data.GetConnection()))
                {
                    var query = String.Format($"BACKUP DATABASE [{Data.GetDbName()}] TO DISK='{GetPath.GetBackupPath()}'");

                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                return new ResultMessage { Success = true };
            }
            catch(Exception ex)
            {
                return new ResultMessage { Success = false, Message = ex.Message };
            }
        }
    }
}
