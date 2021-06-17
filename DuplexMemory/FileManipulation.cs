namespace DuplexMemory
{
    using System.IO;
    using System.Text;

    public static class FileManipulation
    {
        /*
          В этом классе мы создадим какой-то текст.
          Запишем созданный текст в файл.
          Загрузим файл и прочитаем текст в памяти
        */

        /// <summary>
        /// Метод для записи данных в файл
        /// </summary>
        /// <param name="filename">Имя файла</param>
        /// <param name="text">Текст для записи и вывода</param>
        /// <returns></returns>
        public static byte[] GetData(string filename, string text) 
        {
            try
            {
                // Конвертируем текст в массив байт
                byte[] byteArray = Encoding.ASCII.GetBytes(text ?? "This is my Text");
                // Добавляем массив в память
                using var outStream = new MemoryStream(byteArray);
                // Создаём новый файл для записи
                using var fileStream = new FileStream(filename, FileMode.OpenOrCreate);
                // Устанавливаем позицию потока в начале
                outStream.Position = 0;
                // Записываем из потока данные в файл
                //outStream.WriteTo(fileStream);
                outStream.CopyTo(fileStream);
                return outStream?.ToArray() ?? null;
            }
            catch { return null; } 
        }
    }
}