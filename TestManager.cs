using System.Collections.Generic;
using System.Linq;

namespace TestApp
{
    public class TestManager
    {
        private readonly List<Question> _questions;

        public int TotalQuestions => _questions.Count;
        public int CorrectCount => _questions.Count(q => q.IsAnsweredCorrectly);

        public double SuccessPercentage => TotalQuestions > 0 
            ? (CorrectCount * 100.0) / TotalQuestions 
            : 0;

        public TestManager()
        {
            _questions = new List<Question>
            {
                new SingleChoiceQuestion(
                    "Какая планета ближе всего к Солнцу?",
                    "Меркурий"
                ),
                new MultipleChoiceQuestion(
                    "Найди фрукты:",
                    new[] { "Яблоко", "Банан" }
                ),
                new TextQuestion(
                    "Столица Франции:",
                    "Париж"
                )
            };
        }

        public Question GetQuestion(int index)
        {
            return index >= 0 && index < _questions.Count 
                ? _questions[index] 
                : null;
        }

        public string GenerateReport()
        {
            string result = $"Всего вопросов: {TotalQuestions}\n" +
                            $"Правильных ответов: {CorrectCount}\n" +
                            $"Успешность: {SuccessPercentage:F1}%\n\n";

            if (CorrectCount == TotalQuestions)
                result += "найс результат";
            else if (CorrectCount >= TotalQuestions / 2.0)
                result += "хорошая работа";
            else
                result += "попрбуй ещё раз";

            return result;
        }
    }
}
