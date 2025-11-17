using System;

namespace TestApp
{
    public class TextQuestion : Question
    {
        private readonly string _correctAnswer;

        public TextQuestion(string text, string correctAnswer) 
            : base(text)
        {
            _correctAnswer = correctAnswer.ToLower().Trim();
        }

        public override bool CheckAnswer(object userAnswer)
        {
            string answer = userAnswer?.ToString().ToLower().Trim() ?? "";
            IsAnsweredCorrectly = answer == _correctAnswer;
            return IsAnsweredCorrectly;
        }
    }
}
