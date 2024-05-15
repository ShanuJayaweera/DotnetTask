using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static DotNetTask.Const.ConstEnums;

namespace DotNetTask.DTOs.Request
{
    public class CandidateDTO
    {
        [Required]
        public string ProgramId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string CurrentResidence { get; set; }
        public string IDNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public List<AnswersDTO> Answers { get; set;}
    }

    public class AnswersDTO

    {
        [Required]
        public string QuestionID { get; set; }

        [Required]
        public string Answer { get; set; }
        
        [Required]
        public QuestionTypes QuestionType { get; set; }

        [Required]
        public List<string> Choices { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsMultipleChoice { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool EnableOtherOption { get; set; }

        public string SpecifyOther { get; set; }
        [Required]
        public int MaxChoicesAllowed { get; set; }
    }
}
