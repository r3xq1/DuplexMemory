namespace DuplexMemory
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public static class Log
    {
        /// <summary>
        /// <br>Метод для добавления файла в архив</br>
        /// <br><b>Пример использования:</b></br>
        /// <br><b></b>byte[] zippedBytes = ZipFile(FileName, "");</br>
        /// <br>File.WriteAllBytes("Sample.zip", zippedBytes);</br>
        /// </summary>
        /// <param name="FullPath">Полный путь к файлу</param>
        /// <param name="DirName"><br>Имя папки</br><br>Для создания подпапок используйте косую черту <b>/</b></br></param>
        /// <returns>Архив с данными</returns>
        public static byte[] ZipFile(string FullPath, string DirName)
        {
            try
            {
                using FileStream csvStream = File.Open(FullPath, FileMode.Open, FileAccess.Read);
                using var zipToCreate = new MemoryStream { Position = 0 };
                using (var archive = new ZipArchive(zipToCreate, ZipArchiveMode.Create, true))
                {
                    ZipArchiveEntry fileEntry = archive.CreateEntry(Path.Combine(DirName.Replace("/", @"\"), Path.GetFileName(FullPath)), CompressionLevel.Optimal);
                    using var entryStream = fileEntry.Open();
                    csvStream.CopyTo(entryStream);
                }

                return zipToCreate?.ToArray() ?? null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex}\r\n");
                return null;
            }
        }
    }
}
