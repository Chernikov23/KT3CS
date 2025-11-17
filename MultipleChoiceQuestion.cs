using System.Collections.Generic;
using System.Linq;

namespace TestApp
{
    public class MultipleChoiceQuestion : Question
    {
        private readonly HashSet<string> _correctAnswers;

        public MultipleChoiceQuestion(string text, string[] correctAnswers) 
            : base(text)
        {
            _correctAnswers = new HashSet<string>(correctAnswers);
        }

        public override bool CheckAnswer(object userAnswer)
        {
            // useranswer это выбранные чексбоксы
            if (userAnswer is List<string> selected)
            {
                var selectedSet = new HashSet<string>(selected);
                IsAnsweredCorrectly = selectedSet.SetEquals(_correctAnswers);
            }
            else
            {
                IsAnsweredCorrectly = false;
            }
            return IsAnsweredCorrectly;
        }
    }
}
