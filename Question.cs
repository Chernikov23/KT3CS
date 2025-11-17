namespace TestApp
{
    public abstract class Question
    {
        public string Text { get; protected set; } // инкапсляция для чтения снаружи
        public bool IsAnsweredCorrectly { get; protected set; }

        protected Question(string text)
        {
            Text = text;
            IsAnsweredCorrectly = false;
        }

        public abstract bool CheckAnswer(object userAnswer);
    }
}
