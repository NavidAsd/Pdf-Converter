using Application.Interface;
using Common;
using Common.Schema;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Services.Command.ViewContext.AddNewFrequntlyQuestion
{
    public interface IAddNewFrequentlyQuestionService
    {
        ResultMessage Execut(RequestAddNewFrequntlyQuestionDto request);
        Task<ResultMessage> AddWithJsonFile(RequestAddNewFrequentlyQuestionUsingJsonFileDto request);
    }
    public class RequestAddNewFrequentlyQuestionUsingJsonFileDto
    {
        public string FileName { set; get; }
        public string FilePath { set; get; }
        public long? Service { set; get; }

    }
    public class RequestAddNewFrequntlyQuestionDto
    {
        public string Title { set; get; }
        public string Question { set; get; }
        public string Answer { set; get; }
        public long? Service { set; get; }

    }
    public class AddNewFrequentlyQuestionService : IAddNewFrequentlyQuestionService
    {
        private readonly IPdfConverterContext _Context;
        private readonly IConfiguration _Config;
        public AddNewFrequentlyQuestionService(IPdfConverterContext context, IConfiguration config)
        {
            _Context = context;
            _Config = config;
        }
        ResultMessage IAddNewFrequentlyQuestionService.Execut(RequestAddNewFrequntlyQuestionDto request)
        {
            try
            {
                Domain.Entities.OtherContext.FrequentlyQuestions question = new Domain.Entities.OtherContext.FrequentlyQuestions()
                {
                    Title = request.Title,
                    Question = request.Question,
                    Answer = request.Answer,
                    InsertTime = System.DateTime.Now,
                    IsRemoved = false,
                    Service = request.Service,
                };
                _Context.FrequentlyQuestions.Add(question);
                _Context.SaveChanges();
                long Service = request.Service == null ? 0 : (long)request.Service;
               /* GenerateSchema(_Context.FrequentlyQuestions.Where(p => request.Service == p.Service && p.IsRemoved == false).Select(o => new Common.Schema.RequestSchemaGenerator
                {
                    Answer = Regex.Replace(o.Answer, "<.*?>", String.Empty),
                    Questoin = Regex.Replace(o.Question, "<.*?>", String.Empty)
                }).ToList(), Service);*/

                return new ResultMessage
                {
                    Success = true,
                    Message = "New Item SuccessFully Added"
                };
            }
            catch
            {
                return new ResultMessage
                {
                    Success = false,
                    Message = "Something Wrong Please Try Again"
                };
            }
        }
        async Task<ResultMessage> IAddNewFrequentlyQuestionService.AddWithJsonFile(RequestAddNewFrequentlyQuestionUsingJsonFileDto request)
        {
            var DataExtractedResult = ExtractAllFaqQuestions(request);
            //AppliedMethodes.DeleteFile($"{request.FilePath}/{request.FileName}");
            //if (!DataExtractedResult.Success) { return new ResultMessage { Success = false, Message = DataExtractedResult.Message }; }
            var oldQuestions = _Context.FrequentlyQuestions.Where(p => p.Service == request.Service).ToList();
            List<Domain.Entities.OtherContext.FrequentlyQuestions> CopyDataExtractedResult = new List<Domain.Entities.OtherContext.FrequentlyQuestions>();
            CopyDataExtractedResult.AddRange(DataExtractedResult.Enything);
            foreach (var olddata in oldQuestions)
            {
                foreach (var newdata in DataExtractedResult.Enything)
                {
                    if (olddata.Question.Equals(newdata.Question))
                        CopyDataExtractedResult.Remove(newdata);
                }
            }
            /*if (CopyDataExtractedResult.Count < 1)
                return new ResultMessage { Success = false, Message = "All uploaded questions are already there" };*/
            try
            {
                if (CopyDataExtractedResult.Count >= 1)
                {
                    await _Context.FrequentlyQuestions.AddRangeAsync(CopyDataExtractedResult);
                    await _Context.SaveChangesAsync();
                    long Service = request.Service == null ? 0 : (long)request.Service;
                }
               /* GenerateSchema(_Context.FrequentlyQuestions.Where(p => request.Service == p.Service && p.IsRemoved == false).Select(o => new Common.Schema.RequestSchemaGenerator
                {
                    Answer = o.Answer,
                    Questoin = o.Question
                }).ToList(), Service);*/
                return new ResultMessage { Success = true, Message = "New frequently questions have been saved successfully" };
            }
            catch { return new ResultMessage { Success = false, Message = "Something worng please try again" }; }

        }
        private ResultMessage<List<Domain.Entities.OtherContext.FrequentlyQuestions>> ExtractAllFaqQuestions(RequestAddNewFrequentlyQuestionUsingJsonFileDto input)
        {
            string FullPath = input.FilePath + "\\" + input.FileName;
            if (!System.IO.File.Exists(FullPath))
            {
                return new ResultMessage<List<Domain.Entities.OtherContext.FrequentlyQuestions>>
                {
                    Success = false,
                    Message = "File Not Exist"
                };
            }
            GetItemsListFromSchema ItemsListFromSchema = new GetItemsListFromSchema(FullPath);
            var extractResult = ItemsListFromSchema.GetFaqList();
            if (!extractResult.Success)
            {
                return new ResultMessage<List<Domain.Entities.OtherContext.FrequentlyQuestions>>
                {
                    Success = false,
                    Message = extractResult.Message
                };
            }
            List<Domain.Entities.OtherContext.FrequentlyQuestions> FaqList = new List<Domain.Entities.OtherContext.FrequentlyQuestions>();
            foreach (var item in extractResult.Enything)
            {
                Domain.Entities.OtherContext.FrequentlyQuestions newFaq = new Domain.Entities.OtherContext.FrequentlyQuestions();
                newFaq.Question = item.Question;
                newFaq.Answer = item.Answer;
                newFaq.Service = input.Service;
                newFaq.Title = null;
                FaqList.Add(newFaq);
            }
            return new ResultMessage<List<Domain.Entities.OtherContext.FrequentlyQuestions>> { Success = true, Enything = FaqList };

        }
        private ResultMessage<ResultSchemaGenerator> GenerateSchema(List<Common.Schema.RequestSchemaGenerator> frequentlyQuestions, long Service)
        {
            SchemaGenerator generator = new SchemaGenerator();
            return generator.Generate(frequentlyQuestions, GetPath.GetSchemaFaqJsonPath(), Service);
        }
    }
}
