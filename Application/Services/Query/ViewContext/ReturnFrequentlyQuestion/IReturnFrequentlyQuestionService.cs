using Application.Interface;
using Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//https://localhost:44304/Downloader/DownloadLink?OutFileName=PdfToConverter.com-AllPages-ModifiedToJpg_5-22-2022_4-52-20_PM-902.zip&Id=18&LogService=ConverterLog
namespace Application.Services.Query.ViewContext.ReturnFrequentlyQuestion
{
    public interface IReturnFrequentlyQuestionService
    {
        ResultMessage<ResultReturnFrequentlyQuestionDto> ReturnAllForAdmin(RequestReturnFrequentlyQuestionDto request);
        ResultMessage<FrequentlyQuestions> FindQuestion(long Id);
        Task<ResultMessage<List<FrequentlyQuestions>>> ReturnAllAsync(long? Service, int? Count);
    }
    public class RequestReturnFrequentlyQuestionDto
    {
        public string Filter { set; get; }
        public int PageIndex { set; get; }
        public int PageSize { set; get; }
        public long? Service { set; get; }
    }
    public class ResultReturnFrequentlyQuestionDto
    {
        public int TotalRow { set; get; }
        public int PageIndex { set; get; }
        public int Pagesize { set; get; }
        public string Filter { set; get; }

        public List<FrequentlyQuestions> Questions { set; get; }
    }
    public class FrequentlyQuestions
    {
        public long Id { set; get; }
        public string Title { set; get; }
        public string Question { set; get; }
        public string Answer { set; get; }
        public DateTime? LastUpdate { set; get; }
        public DateTime InsertTime { set; get; }
        public bool IsRemoved { set; get; }

    }
    public class ReturnFrequentlyQuestionService : IReturnFrequentlyQuestionService
    {
        private readonly IPdfConverterContext _Context;
        public ReturnFrequentlyQuestionService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<ResultReturnFrequentlyQuestionDto> IReturnFrequentlyQuestionService.ReturnAllForAdmin(RequestReturnFrequentlyQuestionDto request)
        {

            int totalrow = 0;
            var questions = _Context.FrequentlyQuestions.IgnoreQueryFilters().AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.Filter))
                questions = questions.Where(p => p.Title.Contains(request.Filter) || p.Question.Contains(request.Filter)).AsQueryable();
            if (request.Service != null && request.Service > 0)
                questions = questions.Where(p => p.Service == request.Service).AsQueryable();
            else
                questions = questions.Where(p => p.Service == null || p.Service == 0).AsQueryable();
            var result = questions.ToPaged(request.PageIndex, request.PageSize, out totalrow);

            if (result != null)
            {
                return new ResultMessage<ResultReturnFrequentlyQuestionDto>
                {
                    Success = true,
                    Enything = new ResultReturnFrequentlyQuestionDto
                    {
                        Filter = request.Filter,
                        PageIndex = request.PageIndex,
                        Pagesize = request.PageSize,
                        TotalRow = totalrow,
                        Questions = result.Select(o => new FrequentlyQuestions
                        {
                            Id = o.Id,
                            Answer = o.Answer,
                            Question = o.Question,
                            LastUpdate = o.LastUpdate,
                            InsertTime = o.InsertTime,
                            Title = o.Title,
                            IsRemoved = o.IsRemoved,
                        }).ToList(),
                    }
                };
            }
            return new ResultMessage<ResultReturnFrequentlyQuestionDto>
            {
                Success = false,
                Message = "No Question Found!"
            };
        }
        ResultMessage<FrequentlyQuestions> IReturnFrequentlyQuestionService.FindQuestion(long Id)
        {
            var result = _Context.FrequentlyQuestions.IgnoreQueryFilters().Where(p => p.Id == Id).FirstOrDefault();
            if (result != null)
            {
                return new ResultMessage<FrequentlyQuestions>
                {
                    Success = true,
                    Enything = new FrequentlyQuestions
                    {
                        Id = result.Id,
                        Answer = result.Answer,
                        Question = result.Question,
                        InsertTime = result.InsertTime,
                        LastUpdate = result.LastUpdate,
                        IsRemoved = result.IsRemoved,
                    }
                };
            }
            return new ResultMessage<FrequentlyQuestions>
            {
                Success = false,
                Message = "Question Not Found"
            };
        }
        async Task<ResultMessage<List<FrequentlyQuestions>>> IReturnFrequentlyQuestionService.ReturnAllAsync(long? Service, int? Count)
        {
            var result = _Context.FrequentlyQuestions.Where(p => p.IsRemoved == false && p.Service == Service).Select(o => new FrequentlyQuestions
            {
                Answer = o.Answer,
                Question = o.Question,
                Title = o.Title
            }).ToList();
            if (result != null)
            {

                if (Count != null && Count > 0)
                {
                    int _Count = (int)Count;
                    result.Take(_Count);
                }
                return new ResultMessage<List<FrequentlyQuestions>>
                {
                    Success = true,
                    Enything = result
                };
            }
            return new ResultMessage<List<FrequentlyQuestions>>
            {
                Success = false,
                Message = "No Item Found!"
            };
        }
    }
}
