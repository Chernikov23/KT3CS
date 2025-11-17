namespace TestApp
{
    public class SingleChoiceQuestion : Question
    {
        private readonly string _correctAnswer;

        public SingleChoiceQuestion(string text, string correctAnswer) 
            : base(text)
        {
            _correctAnswer = correctAnswer;
        }

        public override bool CheckAnswer(object userAnswer)
        {
            string answer = userAnswer?.ToString() ?? "";
            IsAnsweredCorrectly = answer == _correctAnswer;
            return IsAnsweredCorrectly;
        }
    }
}
