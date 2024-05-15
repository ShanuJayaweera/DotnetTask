namespace DotNetTask.Const
{
    public class ConstEnums
    {
        [Flags]
        public enum QuestionTypes
        {
            ParagraphQuestion = 0,
            NumericQuestion = 1,
            DropdownsQuestion = 2,
            MultipleChoiceQuestion = 3,
            YesNoQuestion = 4,
            DateQuestions = 5

        }
    }
}
