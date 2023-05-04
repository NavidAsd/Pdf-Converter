using Application.Interface;
using Common;
using Common.Schema;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Application.Services.Command.ViewContext.UpdateFrequentlyQuestion
{
    public interface IUpdateFrequentlyQuestionService
    {
        ResultMessage ChangeRemoveState(long Id, bool State);
        ResultMessage UpdateData(RequestUpdateFrequentlyQuestionDto request);
    }
    public class RequestUpdateFrequentlyQuestionDto
    {
        public long Id { set; get; }
        public string Question { set; get; }
        public string Answer { set; get; }
    }
    public class UpdateFrequentlyQuestionService : IUpdateFrequentlyQuestionService
    {
        private readonly IPdfConverterContext _Context;
        public UpdateFrequentlyQuestionService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IUpdateFrequentlyQuestionService.ChangeRemoveState(long Id, bool State)
        {
            var result = _Context.FrequentlyQuestions.IgnoreQueryFilters().Where(p => p.Id == Id).FirstOrDefault();
            if (result != null)
            {
                try
                {
                    if (result.IsRemoved != State)
                        result.IsRemoved = State;
                    result.LastUpdate = System.DateTime.Now;
                    _Context.SaveChanges();
                    long Service = result.Service == null ? 0 : (long)result.Service;
                    /*GenerateSchema(_Context.FrequentlyQuestions.Where(p => result.Service == p.Service && p.IsRemoved == false).Select(o => new Common.Schema.RequestSchemaGenerator
                    {
                        Answer = Regex.Replace(o.Answer, "<.*?>", String.Empty),
                        Questoin = Regex.Replace(o.Question, "<.*?>", String.Empty)
                    }).ToList(), Service*/

                    return new ResultMessage { Success = true, Message = "Item State Successfully Changed" };
                }
                catch { return new ResultMessage { Success = false, Message = "Something Wrong Please Try Again" }; }
            }
            return new ResultMessage { Success = true, Message = "Item Not Found" };
        }
        ResultMessage IUpdateFrequentlyQuestionService.UpdateData(RequestUpdateFrequentlyQuestionDto request)
        {
            var uniqeQuestion = _Context.FrequentlyQuestions.IgnoreQueryFilters().Where(p => p.Question == request.Question && p.Id != request.Id).FirstOrDefault();
            if (uniqeQuestion != null)
            {
                return new ResultMessage
                {
                    Success = false,
                    Message = "You have asked the same question before"
                };
            }
            var result = _Context.FrequentlyQuestions.IgnoreQueryFilters().Where(p => p.Id == request.Id).FirstOrDefault();
            if (result != null)
            {
                try
                {
                    result.Question = request.Question;
                    result.Answer = request.Answer;
                    result.LastUpdate = System.DateTime.Now;
                    _Context.SaveChanges();
                    long Service = result.Service == null ? 0 : (long)result.Service;
                   /*GenerateSchema(_Context.FrequentlyQuestions.Where(p => result.Service == p.Service && p.IsRemoved == false).Select(o => new Common.Schema.RequestSchemaGenerator
                    {
                        Answer = Regex.Replace(o.Answer, "<.*?>", String.Empty),
                        Questoin = Regex.Replace(o.Question, "<.*?>", String.Empty)
                    }).ToList(), Service*/

                    return new ResultMessage
                    {
                        Success = true,
                        Message = "Item Successfully Updated"
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
            return new ResultMessage
            {
                Success = false,
                Message = "Item Not Found"
            };
        }
        private ResultMessage<ResultSchemaGenerator> GenerateSchema(List<Common.Schema.RequestSchemaGenerator> frequentlyQuestions, long Service)
        {
            SchemaGenerator generator = new SchemaGenerator();
            return generator.Generate(frequentlyQuestions, GetPath.GetSchemaFaqJsonPath(), Service);
        }

    }
}
