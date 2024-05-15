using DotNetTask.DTOs.Request;
using DotNetTask.Models;
using System.Collections.Generic;
using static DotNetTask.Const.ConstEnums;

namespace DotNetTask.Mappers
{
    public static class ProgramDataMappers
    {

        /* Map request from user to programs(Table)
         * @params programRequest
         */
        public static ProgramData ToProgramsDataModel(this ProgramDataRequestDTO programRequest)
        {
            Guid Id = Guid.NewGuid();
            return new ProgramData
            {
                Id = Id.ToString(),
                ProgramId = Id.ToString(),
                Name = programRequest.Name.ToString(),
                Description = programRequest.Description.ToString(),
                PersonalInformation = new PersonalInfo()
                {
                    FirstName = new Fields
                    {
                        Internal = false,
                        Hide = false,
                    },
                    LastName = new Fields
                    {
                        Internal = false,
                        Hide = false,
                    },
                    Email = new Fields
                    {
                        Internal = false,
                        Hide = false,
                    },
                    Phone = new Fields
                    {
                        Internal = programRequest.PersonalInformation.Phone.Internal,
                        Hide = programRequest.PersonalInformation.Phone.Hide,
                    },
                    Nationality = new Fields
                    {
                        Internal = programRequest.PersonalInformation.Nationality.Internal,
                        Hide = programRequest.PersonalInformation.Nationality.Hide,
                    },
                    CurrentResidence = new Fields
                    {
                        Internal = programRequest.PersonalInformation.CurrentResidence.Internal,
                        Hide = programRequest.PersonalInformation.CurrentResidence.Hide,
                    },
                    IDNumber = new Fields
                    {
                        Internal = programRequest.PersonalInformation.IDNumber.Internal,
                        Hide = programRequest.PersonalInformation.IDNumber.Hide,
                    },
                    DateOfBirth = new Fields
                    {
                        Internal = programRequest.PersonalInformation.DateOfBirth.Internal,
                        Hide = programRequest.PersonalInformation.DateOfBirth.Hide,
                    },
                    Gender = new Fields
                    {
                        Internal = programRequest.PersonalInformation.Gender.Internal,
                        Hide = programRequest.PersonalInformation.Gender.Hide,
                    }

                },
                QuestionData = MapQuestionRequest(programRequest.QuestionData),
                CreatedAt = DateTime.Now

            };
        }


        /* Map question list
         * @params questionList
         */
        public static List<QuestionData> MapQuestionRequest(List<QuestionDataDTO> questionList)
        {
            List<QuestionData> list = new List<QuestionData>();

            foreach (var question in questionList)
            {
                var quiz = MapEachQuestion(question);
                list.Add(quiz);
            }

            return list;
        }


        /* Map question by type one by one
         * @params question
         */
        public static QuestionData MapEachQuestion(this QuestionDataDTO question)
        {


            if(question.QuestionType == QuestionTypes.YesNoQuestion || question.QuestionType == QuestionTypes.ParagraphQuestion || question.QuestionType == QuestionTypes.DateQuestions || question.QuestionType == QuestionTypes.NumericQuestion)
            {
                return new QuestionData
                {
                    QuestionId = Guid.NewGuid().ToString(),
                    QuestionType = question.QuestionType,
                    Question = question.Question
                };
            }


            if (question.QuestionType == QuestionTypes.DropdownsQuestion)
            {
                return new QuestionData
                {
                    QuestionId = Guid.NewGuid().ToString(),
                    QuestionType = question.QuestionType,
                    Question = question.Question,
                    Choices = question.Choices,
                    IsMultipleChoice = question.IsMultipleChoice,
                    EnableOtherOption = question.EnableOtherOption,
                };
            }


            if (question.QuestionType == QuestionTypes.MultipleChoiceQuestion)
            {
                return new QuestionData
                {
                    QuestionId = Guid.NewGuid().ToString(),
                    QuestionType = question.QuestionType,
                    Question = question.Question,
                    Choices = question.Choices,
                    IsMultipleChoice = question.IsMultipleChoice,
                    EnableOtherOption = question.EnableOtherOption,
                    MaxChoicesAllowed = question.MaxChoicesAllowed
                };
            }

            return null;
        }

    }
}
