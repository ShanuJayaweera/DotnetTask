using static DotNetTask.Const.ConstEnums;

namespace DotNetTask.Models
{
    public class Candidate
    {
        public string Id { get; set; }
        public string ProgramId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string CurrentResidence { get; set; }
        public string IDNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public List<Answers> Answers { get; set; }

    }

    public class Answers
    {
        public string QuestionID { get; set; }
        public string Answer { get; set; }
        public QuestionTypes QuestionType { get; set; }
        public List<string> Choices { get; set; }
        public bool IsMultipleChoice { get; set; }
        public bool EnableOtherOption { get; set; }
        public string SpecifyOther { get; set; }
        public int MaxChoicesAllowed { get; set; }
    }
}
