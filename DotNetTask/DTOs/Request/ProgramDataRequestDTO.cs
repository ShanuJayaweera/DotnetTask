using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static DotNetTask.Const.ConstEnums;

namespace DotNetTask.DTOs.Request
{
    public class ProgramDataRequestDTO
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name should within 100 characters")]
        public string Name { get; set; }

        [Required]
        [MaxLength(2000, ErrorMessage = "Description should within 2000 characters")]
        public string Description { get; set; }

        [Required]
        public PersonalInfoDTO PersonalInformation { get; set; }
        [Required]
        public List<QuestionDataDTO> QuestionData { get; set; }
        public DateTime CreatedAt { get; set; }

        
    }

    public class PersonalInfoDTO
    {
        public FieldsDTO Phone { get; set; }
        public FieldsDTO Nationality { get; set; }
        public FieldsDTO CurrentResidence { get; set; }
        public FieldsDTO IDNumber { get; set; }
        public FieldsDTO DateOfBirth { get; set; }
        public FieldsDTO Gender { get; set; }
        
    }

    public class FieldsDTO
    {
        [DefaultValue(false)]
        public bool Internal { get; set; }
        [DefaultValue(false)]
        public bool Hide { get; set; }
    }


    public class QuestionDataDTO
    {
      
        [DefaultValue(QuestionTypes.YesNoQuestion)]
        public QuestionTypes QuestionType { get; set; }
        public string Question { get; set; }
        public List<string> Choices { get; set; }
        [DefaultValue(false)]
        public bool IsMultipleChoice { get; set; }
        [DefaultValue(false)]
        public bool EnableOtherOption { get; set; }
        public int MaxChoicesAllowed { get; set; }
    }
}
