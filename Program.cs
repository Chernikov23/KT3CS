// Program.cs
using System;
using System.Windows.Forms;

namespace TestApp
{
    internal static class Program
    {
        ///<summary>
        // точка входа
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); // запуск
        }
    }
}
