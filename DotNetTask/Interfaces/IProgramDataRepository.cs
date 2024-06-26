﻿using DotNetTask.DTOs.Request;
using DotNetTask.Models;

namespace DotNetTask.Interfaces
{
    public interface IProgramDataRepository
    {
        Task<ProgramData> CreateProgramDataAsync(ProgramData program);
        Task<ProgramData> UpdateQuestionsAsync(QuestionDataDTO questionData, string programId, string questionId);
        Task<ProgramData> DeleteQuestionsAsync(string programId, string questionId);
        Task<ProgramData> GetProgramAsync(string programId);

        Task<bool> IsQuestionExist(string programId, string questionId);

        Task<bool> IsProgramExist(string programId);
    }
}
