using DotNetTask.DTOs.Request;
using DotNetTask.Models;
using static DotNetTask.Const.ConstEnums;

namespace DotNetTask.Mappers
{
    public static class CandidateMapper
    {
        /* Map candidate
         * @params candidateDTO
         */
        public static Candidate MapCandidateRequest(CandidateDTO candidateDTO)
        {
            return new Candidate
            {
                Id = Guid.NewGuid().ToString(),
                ProgramId = candidateDTO.ProgramId,
                FirstName = candidateDTO.FirstName,
                LastName = candidateDTO.LastName,
                Email = candidateDTO.Email,
                Phone = candidateDTO.Phone,
                Nationality = candidateDTO.Nationality,
                CurrentResidence = candidateDTO.CurrentResidence,
                IDNumber = candidateDTO.IDNumber,
                DateOfBirth = candidateDTO.DateOfBirth,
                Gender = candidateDTO.Gender,
                Answers = MapAnswers(candidateDTO.Answers),
            };
         
        }

        public static List<Answers> MapAnswers(List<AnswersDTO> answerList)
        {
            List<Answers> list = new List<Answers>();

            foreach (var answer in answerList)
            {
                var ans = MapEachAnswer(answer);
                list.Add(ans);
            }

            return list;
        }


        /* Map answers by type one by one
         * @params ans
        */
        public static Answers MapEachAnswer(this AnswersDTO ans)
        {

            if (ans.QuestionType == QuestionTypes.YesNoQuestion || ans.QuestionType == QuestionTypes.ParagraphQuestion || ans.QuestionType == QuestionTypes.DateQuestions || ans.QuestionType == QuestionTypes.NumericQuestion)
            {
                return new Answers
                {
                    QuestionID = ans.QuestionID,
                    QuestionType = ans.QuestionType,
                    Answer = ans.Answer,
                };
            }


            if (ans.QuestionType == QuestionTypes.DropdownsQuestion)
            {
                return new Answers
                {
                    QuestionID = ans.QuestionID,
                    QuestionType = ans.QuestionType,
                    Answer = ans.Answer,
                    Choices = ans.Choices,
                    EnableOtherOption = ans.EnableOtherOption,
                    SpecifyOther = ans.SpecifyOther
                };
            }


            if (ans.QuestionType == QuestionTypes.MultipleChoiceQuestion)
            {
                return new Answers
                {
                    QuestionID = ans.QuestionID,
                    QuestionType = ans.QuestionType,
                    Answer = ans.Answer,
                    Choices = ans.Choices,
                    EnableOtherOption = ans.EnableOtherOption,
                    SpecifyOther = ans.SpecifyOther,
                    MaxChoicesAllowed = ans.MaxChoicesAllowed
                };
            }

            return null;
        }


    }
}
