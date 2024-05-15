using DotNetTask.Data;
using DotNetTask.DTOs.Request;
using DotNetTask.Interfaces;
using DotNetTask.Mappers;
using DotNetTask.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Azure.Cosmos.Serialization.HybridRow;
using Microsoft.EntityFrameworkCore;

namespace DotNetTask.Repositories
{
    public class ProgramDataRepository : IProgramDataRepository
    {

        private readonly ApplicationDBContext _context;

        public ProgramDataRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        /* 
         * Create programData
         * @param program
         */
        public async Task<ProgramData> CreateProgramDataAsync(ProgramData program)
        {
            await _context.ProgramDatas.AddAsync(program);
            await _context.SaveChangesAsync();
            return program;
        }


        /* 
         * Update Question
         * @param questionData, programId, questionId
         */
        public async Task<ProgramData> UpdateQuestionsAsync(QuestionDataDTO questionData, string programId, string questionId)
        {
            var program = await _context.ProgramDatas.Where(p => p.Id == programId && p.ProgramId == programId).SingleOrDefaultAsync();
            if (program != null)
            {
                // check is QuestionData empty
                if (program.QuestionData != null)
                {
                    var questionResult = program.QuestionData.Where(q => q.QuestionId == questionId).SingleOrDefault();
                    if (questionResult != null)
                    {
                        // update question
                        questionResult = questionData.MapEachQuestion();
                        questionResult.QuestionId = questionId;

                        List<QuestionData> updatedQuiz = new List<QuestionData>();

                        foreach (var quiz in program.QuestionData)
                        {
                            if (quiz.QuestionId == questionId)
                            {
                                updatedQuiz.Add(questionResult);
                                continue;
                            }
                            updatedQuiz.Add(quiz);
                        }
                        program.QuestionData = updatedQuiz;
                        await _context.SaveChangesAsync();
                    }
                }
                
                else
                {
                    if (program.QuestionData == null)
                    {
                        program.QuestionData = new List<QuestionData>();
                    }
                    
                    program.QuestionData.Add(questionData.MapEachQuestion());
                    await _context.SaveChangesAsync();
                }
                return program;
            }
            return null;
        }


        /* 
         * Delete Question
         * @param programId, questionId
         */

        public async Task<ProgramData> DeleteQuestionsAsync(string programId, string questionId)
        {
            var program = await _context.ProgramDatas.Where(p => p.Id == programId && p.ProgramId == programId).SingleOrDefaultAsync();
            if (program != null)
            {

                var questionResult = program.QuestionData.Where(q => q.QuestionId == questionId).SingleOrDefault();
                if (questionResult != null)
                {
                    program.QuestionData.Remove(questionResult);
                    _context.SaveChanges();
                    return program;
                }
            }
            return null;
        }



        /* 
         * Get program data
         * @param programId
         */

        public async Task<ProgramData> GetProgramAsync(string programId)
        {
            var program = await _context.ProgramDatas.Where(p => p.Id == programId && p.ProgramId == programId).FirstOrDefaultAsync();
            if (program != null)
            {
                return program;
            }
            return null;
        }

        /* 
         * check is question exist
         * @param programId, questionId
         */
        public async Task<bool> IsQuestionExist(string programId, string questionId)
        {
            var program = await _context.ProgramDatas.Where(p => p.Id == programId && p.ProgramId == programId).SingleOrDefaultAsync();
            if (program != null)
            {

                var questionResult = program.QuestionData.Where(q => q.QuestionId == questionId).SingleOrDefault();
                if (questionResult != null)
                {
                    return true;
                }
            }
            return false;
        }

        /* 
         * check is program exist
         * @param programId
         */
        public async Task<bool> IsProgramExist(string programId)
        {
            var program = await _context.ProgramDatas.Where(p => p.Id == programId && p.ProgramId == programId).FirstOrDefaultAsync();
            if (program != null)
            {
                return true;
            }
            return false;
        }
    }
}
