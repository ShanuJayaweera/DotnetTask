using static DotNetTask.Const.ConstEnums;

namespace DotNetTask.Models
{
    public class ProgramData
    {
        public string Id { get; set; }
        public string ProgramId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PersonalInfo PersonalInformation { get; set; }
        public List<QuestionData> QuestionData { get; set; }
        public DateTime CreatedAt { get; set; }
    }


    public class PersonalInfo
    {
        public Fields FirstName { get; set; }
        public Fields LastName { get; set; }
        public Fields Email { get; set; }
        public Fields Phone { get; set; }
        public Fields Nationality { get; set; }
        public Fields CurrentResidence { get; set; }
        public Fields IDNumber { get; set; }
        public Fields DateOfBirth { get; set; }
        public Fields Gender { get; set; }
    }
    public class Fields
    {
        public bool Internal { get; set; }
        public bool Hide { get; set; }
    }


    public class QuestionData
    {
        public string QuestionId { get; set; }
        public QuestionTypes QuestionType { get; set; }
        public string Question { get; set; }
        public List<string> Choices { get; set; }
        public bool IsMultipleChoice { get; set; }
        public bool EnableOtherOption { get; set; }
        public int MaxChoicesAllowed { get; set; }

        public static implicit operator List<object>(QuestionData v)
        {
            throw new NotImplementedException();
        }
    }
}
