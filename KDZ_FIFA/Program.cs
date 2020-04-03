using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KDZ_FIFA
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Start());
        }

        internal static void MessageShow(string error)
        {
            MessageBox.Show(error, "ОШИБКА ПРИЛОЖЕНИЯ!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Безопасная запись в файл.
        /// </summary>
        /// <param name="path">Путь, по которой записывается в файл.</param>
        /// <param name="result">Что нужуно записывать в файл.</param>
        internal static void WriteToFile(string path, string result)
        {
            try
            {
                File.WriteAllText(path, result);
                MessageBox.Show("Запись в файл прошла успешно!", "ИНФОРМАЦИЯ", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (IOException)
            {
                MessageShow("Ошибка ввода-вывода, возможно файл занят чужим процессом.");
            }
            catch (System.Security.SecurityException)
            {
                MessageShow("Ошибка безопасности.");
            }
            catch (UnauthorizedAccessException)
            {
                MessageShow("У вас нет разрешения на создание файла!");
            }
            catch (Exception)
            {
                MessageShow("Произошел конец света...");
            }
        }
    }
}
