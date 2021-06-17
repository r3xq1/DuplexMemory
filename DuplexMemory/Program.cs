namespace DuplexMemory
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    internal static class Program
    {
        [STAThread]
        public static void Main()
        {
            // Вывод результата сбора данных из памяти на консоль.
            string Str_result = Encoding.UTF8.GetString(BufferEx.GetData().ToArray());
            Console.WriteLine(Str_result);

            // чтение текста из файла
            string FileText_result = Encoding.UTF8.GetString(FileManipulation.GetData("test.txt", "Text").ToArray());
            Console.WriteLine(FileText_result);

            // Вывод результата сохранения скриншота из памяти в PictureBox на форме
            using var FormView = Task.Factory.StartNew(() =>
            {
                Application.Run(new ScreenViewer());
                //var form = new ScreenViewer(); form.Show();
            });
            FormView.Wait();

            Console.Read();
        }
    }
}