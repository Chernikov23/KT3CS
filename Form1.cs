using System;
using System.Windows.Forms;

namespace TestApp
{
    public class Form1 : Form  
    {
        private readonly TestManager _testManager;
        private readonly TabControl _tabControl;

        public Form1()
        {            
            this.Text = "KT ООП на с#";
            this.Size = new System.Drawing.Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            _testManager = new TestManager();
            _tabControl = new TabControl { Dock = DockStyle.Fill };
            
            CreateTabs();
            this.Controls.Add(_tabControl);
        }

        private void CreateTabs()
        {
            // вопрос 1
            _tabControl.TabPages.Add(CreateSingleChoiceTab(0, new[] { "Земля", "Меркурий", "Венера" }));

            // вопрос 2
            _tabControl.TabPages.Add(CreateMultipleChoiceTab(1, new[] { "Яблоко", "Морковь", "Банан", "Картофель" }));

            // вопрос 3
            _tabControl.TabPages.Add(CreateTextTab(3));
        }
        // вкладка с радиобаттон
        private TabPage CreateSingleChoiceTab(int index, string[] options)
        {
            var page = new TabPage($"Вопрос {index + 1}");
            var panel = new Panel { Dock = DockStyle.Fill };
            var question = _testManager.GetQuestion(index);

            panel.Controls.Add(new Label
            {
                Text = question.Text,
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(400, 30)
            });

            int y = 60;
            var radioButtons = new List<RadioButton>();
            foreach (string option in options)
            {
                var rb = new RadioButton
                {
                    Text = option,
                    Location = new System.Drawing.Point(40, y),
                    Tag = option
                };
                panel.Controls.Add(rb);
                radioButtons.Add(rb);
                y += 30;
            }

            var btn = new Button
            {
                Text = "проверка",
                Location = new System.Drawing.Point(40, y + 10)
            };
            btn.Click += (s, e) =>
            {
                var selected = radioButtons.Find(r => r.Checked)?.Tag?.ToString();
                if (selected == null)
                {
                    MessageBox.Show("Выбери ответ");
                    return;
                }

                question.CheckAnswer(selected);
                MessageBox.Show(question.IsAnsweredCorrectly ? "Правильно" : "Неправильно");
            };

            panel.Controls.Add(btn);
            page.Controls.Add(panel);
            return page;
        }

        // вкладка с чекбоксом
        private TabPage CreateMultipleChoiceTab(int index, string[] options)
        {
            var page = new TabPage($"Вопрос {index + 1}");
            var panel = new Panel { Dock = DockStyle.Fill };
            var question = _testManager.GetQuestion(index);

            panel.Controls.Add(new Label
            {
                Text = question.Text,
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(200, 30)
            });

            var checkBoxes = new Dictionary<string, CheckBox>();
            int y = 60;
            foreach (string option in options)
            {
                var cb = new CheckBox
                {
                    Text = option,
                    Location = new System.Drawing.Point(40, y)
                };
                panel.Controls.Add(cb);
                checkBoxes[option] = cb;
                y += 30;
            }

            var btn = new Button
            {
                Text = "Проверка",
                Location = new System.Drawing.Point(40, y + 10)
            };
            btn.Click += (s, e) =>
            {
                var selected = new List<string>();
                foreach (var kvp in checkBoxes)
                {
                    if (kvp.Value.Checked)
                        selected.Add(kvp.Key);
                }

                question.CheckAnswer(selected);
                MessageBox.Show(question.IsAnsweredCorrectly ? "Правильно" : "Неправильно, правильные ответы: Яблоко, Банан.");
            };

            panel.Controls.Add(btn);
            page.Controls.Add(panel);
            return page;
        }

        // влкдака текстбокс
        private TabPage CreateTextTab(int index)
        {
            index = 2; 
            var page = new TabPage("Вопрос 3");
            var panel = new Panel { Dock = DockStyle.Fill };
            var question = _testManager.GetQuestion(index);

            panel.Controls.Add(new Label
            {
                Text = question.Text,
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(300, 30)
            });

            var textBox = new TextBox
            {
                Location = new System.Drawing.Point(40, 60),
                Width = 200
            };
            panel.Controls.Add(textBox);

            var btn = new Button
            {
                Text = "Проверка",
                Location = new System.Drawing.Point(40, 100)
            };
            btn.Click += (s, e) =>
            {
                question.CheckAnswer(textBox.Text);
                MessageBox.Show(question.IsAnsweredCorrectly ? "Правильно" : "Неправильно, столица Франции : Париж");
            };

            panel.Controls.Add(btn);
            page.Controls.Add(panel);
            return page;
        }

        // отчёт при закрытии
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            MessageBox.Show(_testManager.GenerateReport(), "Результат теста");
            base.OnFormClosed(e);
        }
    }
}
