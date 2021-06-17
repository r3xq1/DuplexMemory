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

            // Чтение текста из файла.
            string FileText_result = Encoding.UTF8.GetString(FileManipulation.GetData("test.txt", "Text").ToArray());
            Console.WriteLine(FileText_result);
            /* Создаём папку внутри архива и записываем туда файл, создаём архив. */
            // dev - имя папки.
            // test.txt - файл который добавляем в папку.
            byte[] zippedBytes = Log.ZipFile("test.txt", "dev"); 
            // Создаём архив и записываем все данные в него.
            File.WriteAllBytes("Sample.zip", zippedBytes); 

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
