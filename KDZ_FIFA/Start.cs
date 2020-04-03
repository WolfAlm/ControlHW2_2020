using System;
using System.Drawing;
using System.Windows.Forms;
using KDZLibrary;
using System.IO;
using System.Xml;

namespace KDZ_FIFA
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Установливает положение формы ровно по центру для удобства.
        /// </summary>
        private void Start_Load(object sender, EventArgs e)
        {
            Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - (Width / 2),
                Screen.PrimaryScreen.Bounds.Height / 2 - Height / 2);
        }

        /// <summary>
        /// Вызывается новая форма, где будет написана общая информация о этой игре.
        /// Потом, чтобы ее закрыть, нужно предварительно нажать на кнопку закрытия, иначе
        /// невозможно будет вернуться к первой форме из-за параметра диалогового окна.
        /// </summary>
        private void helpButton_Click(object sender, EventArgs e)
        {
            new Information().ShowDialog();
        }

        /// <summary>
        /// Вызывается новая форма для продолжения игры. Передается в качестве параметра эту форму,
        /// чтобы ее можно было скрыть с помощью новой формы.
        /// </summary>
        private void playButton_Click(object sender, EventArgs e)
        {
            new ChoiceOfPlayer(this).Show();
        }

        /// <summary>
        /// При нажатии продолжить мы будем проверять на наличие сохранения, если все будет хорошо,
        /// то будем считывать с файла всю нужную информацию. Потом мы эту информацию будем передавать
        /// в форму игры, по которой уже пойдет процесс.
        /// </summary>
        private void continueButton_Click(object sender, EventArgs e)
        {
            string path = "saveGame.xml";

            if (File.Exists(path))
            {
                Player firstPlayer = null, secondPlayer = null;

                try
                {
                    WorkWithXml.ReadFromFile(ref firstPlayer, ref secondPlayer, out uint round, out string log);
                    new Fight(this, firstPlayer, secondPlayer, round, log).Show();
                    Hide();
                }
                catch (Utilites.ErrorException error)
                {
                    Program.MessageShow(error.Message);
                }
                catch (IOException)
                {
                    Program.MessageShow("Что-то не так с файлом...");
                }
                catch (XmlException)
                {
                    Program.MessageShow("Чего-то не хватило... Пустой файл или элемент...");
                }
                catch (Exception error)
                {
                    Program.MessageShow(error.Message);
                }
            }
            else
            {
                Program.MessageShow("К сожалению, у Вас нет сохранения!");
            }
        }
    }
}
