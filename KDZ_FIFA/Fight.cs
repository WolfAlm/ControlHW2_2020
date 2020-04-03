using System;
using System.Drawing;
using System.Windows.Forms;
using KDZLibrary;
using System.Linq;
using System.IO;

namespace KDZ_FIFA
{
    public partial class Fight : Form
    {
        static Random random = new Random();
        Player firstPlayer, secondPlayer;
        uint round = 1, tempRoundForSave = 1, stepRound = 1;
        Footballer footballer1, footballer2;
        bool win = false;
        Start start;

        /// <summary>
        /// Мы передаем первую форму, чтобы была возможность открыть ее. Также игроков для того, чтобы
        /// оперировать их командами и именами.
        /// </summary>
        /// <param name="start">Первая форма.</param>
        /// <param name="firstPlayer">Первый игрок.</param>
        /// <param name="secondPlayer">Второй игрок.</param>
        public Fight(Start start, Player firstPlayer, Player secondPlayer)
        {
            InitializeComponent();
            this.start = start;
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
            accountLabel.Text = $"{firstPlayer.Point} : {secondPlayer.Point}";
            FillingList(firstPlayer, listPlayer1);
            FillingList(secondPlayer, listPlayer2);
        }

        /// <summary>
        /// Мы передаем первую форму, чтобы была возможность открыть ее. Также игроков для того, чтобы
        /// оперировать их командами и именами.
        /// </summary>
        /// <param name="start">Форма стартовая.</param>
        /// <param name="firstPlayer">Первый игрок.</param>
        /// <param name="secondPlayer">Второй игрок.</param>
        /// <param name="round">Какой раунд сейчас по счету.</param>
        /// <param name="log">Логи игры.</param>
        public Fight(Start start, Player firstPlayer, Player secondPlayer, uint round, string log) :
            this(start, firstPlayer, secondPlayer)
        {
            this.tempRoundForSave = this.round = round;
            logGameBox.Text = log;
            WhoseMove();
        }

        /// <summary>
        /// Здесь будет определяться, кто ходит и выводить нужную информацию на экран.
        /// Также, именно здесь будет обрабатываться финал игры.
        /// </summary>
        private void WhoseMove()
        {
            goButton.Visible = false;

            if (round < 31)
            {
                try
                {
                    if (tempRoundForSave != round)
                    {
                        WorkWithXml.AutoSaveToXml(firstPlayer, secondPlayer, round, logGameBox.Text);

                        tempRoundForSave = round;
                    }

                    if (round % 2 == 1)
                    {
                        listPlayer1.Visible = listPlayer2.Visible = true;
                        infoLabel1.Visible = infoLabel2.Visible = picturePlayer1.Visible =
                            picturePlayer2.Visible = false;

                        moveLabel.Text = $"ROUND {round}. First player attacks.";
                    }
                    else if (round % 2 == 0)
                    {
                        CreateRandomFootballer();

                        listPlayer2.Visible = infoLabel1.Visible = picturePlayer1.Visible = false;
                        infoLabel2.Visible = picturePlayer2.Visible = listPlayer1.Visible = true;

                        moveLabel.Text = $"ROUND {round}. Second player attacks.";
                    }
                }
                catch (IOException)
                {
                    ErrorMessageAfterXml("Ошибка ввода-вывода, возможно файл занят чужим процессом." +
                        "Игра будет закрыта.");
                }
                catch (System.Security.SecurityException)
                {
                    ErrorMessageAfterXml("Ошибка безопасности. Игра будет закрыта.");
                }
                catch (UnauthorizedAccessException)
                {
                    ErrorMessageAfterXml("У вас нет разрешения на создание файла! Игра будет закрыта.");
                }
                catch (Exception)
                {
                    ErrorMessageAfterXml("Произошел конец света(ошибка программы)... Игра будет закрыта.");
                }
            }
            else
            {
                Final();
            }
        }

        /// <summary>
        /// Это подушка безопасности на случай, если будет неудачная запись автосохранения игры
        /// в файл. Будет выведено сообщение и закрываться игра после этого.
        /// </summary>
        /// <param name="messageError">Сообщение ошибки.</param>
        private void ErrorMessageAfterXml(string messageError)
        {
            DialogResult resultMessage = MessageBox.Show(messageError);

            if (resultMessage == DialogResult.OK || resultMessage == DialogResult.Cancel)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Будет выводиться информация о том, как закончился финал.
        /// </summary>
        private void Final()
        {
            // Скрываем все элементы.
            Controls.Cast<Control>().Select(elements => elements.Visible = false).ToArray();

            restartButton.Visible = finalLabel.Visible = true;

            if (firstPlayer.Point > secondPlayer.Point)
            {
                finalLabel.Text = "HOOORAY!\nYOU WIN!";
            }
            else if (firstPlayer.Point < secondPlayer.Point)
            {
                finalLabel.Text = "Wooow :(\nYou have lost...\nThe PC is smarter\nTHAN you";
            }
            else
            {
                finalLabel.Text = "BOOOOM!\nDRAW!";
            }
        }

        /// <summary>
        /// Мы реагируем на то, когда пользователь выберет себе футболиста и отображаем информацию 
        /// о нем в полной мере.
        /// </summary>
        private void listPlayer1_DoubleClick(object sender, EventArgs e)
        {
            if (listPlayer1.SelectedItems.Count > 0)
            {
                footballer1 = firstPlayer.Team[listPlayer1.SelectedIndices[0]];
                picturePlayer1.Image = imageList2.Images[listPlayer1.SelectedIndices[0]];
                infoLabel1.Text = footballer1.ToString();

                if (round % 2 == 1)
                {
                    CreateRandomFootballer();
                }

                listPlayer1.Visible = listPlayer2.Visible = false;
                infoLabel1.Visible = infoLabel2.Visible = picturePlayer1.Visible =
                    picturePlayer2.Visible = goButton.Visible = true;
            }
        }

        /// <summary>
        /// При нажатии GO будет передаваться нужные параметры в метод процесса боя. После этого
        /// будет обновляться счетчик в зависимости от победы.
        /// </summary>
        private void goButton_Click(object sender, EventArgs e)
        {
            if (round % 2 == 1)
            {
                ProcessFight2(footballer1, footballer2, firstPlayer, secondPlayer);

                if (win)
                {
                    accountLabel.Text = $"{++firstPlayer.Point} : {secondPlayer.Point}";
                    win = false;
                }
            }
            else
            {
                ProcessFight2(footballer2, footballer1, secondPlayer, firstPlayer);

                if (win)
                {
                    accountLabel.Text = $"{firstPlayer.Point} : {++secondPlayer.Point}";
                    win = false;
                }
            }
        }

        /// <summary>
        /// Проходит процесс боя. Мы сравниваем характеристики футболистов, а потом исходя из них
        /// решаем, как пойдет дальше игра. Либо будет пенальти из 4 голов, либо передается ход,
        /// либо победа обеспечена при достижении 4 победы подряд. Также мы обновляем постоянно лог.
        /// Мы передаем игроков, чтобы вытаскивать имена для корректного отображения в логе.
        /// </summary>
        /// <param name="footballer1">Атакующий футболист.</param>
        /// <param name="footballer2">Обороняющий футболист.</param>
        /// <param name="player1">Атакующий игрок.</param>
        /// <param name="player2">Обороняющий игрок.</param>
        private void ProcessFight2(Footballer footballer1, Footballer footballer2, Player player1,
            Player player2)
        {
            if ((new Player()).Fight(footballer1, footballer2) && stepRound <= 4)
            {
                logGameBox.Text += $"Round: {round}. {player1.Name} win in step: {stepRound}.\n" +
                    $"Attack stats: {footballer1.Stats}\nDefend stats: {footballer2.Stats}\n";
                stepRound++;
            }
            else if (!(new Player()).Fight(footballer1, footballer2))
            {
                stepRound = 1;
                logGameBox.Text += $"Round: {round++}. {player2.Name} win!\n" +
                    $"Attack stats: {footballer1.Stats}\nDefend stats: {footballer2.Stats}\n";
            }

            if (stepRound == 5)
            {
                stepRound = 1;
                win = true;
                logGameBox.Text += $"Round: {round++}. {player1.Name} win!\n";
            }

            // Автоматическая прокрутка лога до конца.
            logGameBox.SelectionStart = logGameBox.Text.Length;
            logGameBox.ScrollToCaret();

            // После успешного хода будет еще раз проверяться, кто ходит в этот раз.
            WhoseMove();
        }

        /// <summary>
        /// Мы выбираем случайного футболиста в команде компьютера. После чего, все данные передаем
        /// на экран, чтобы пользователь был в курсе, какой футболист был выбран.
        /// </summary>
        private void CreateRandomFootballer()
        {
            int randomFootballer = random.Next(11);
            footballer2 = secondPlayer.Team[randomFootballer];
            picturePlayer2.Image = imageList2.Images[randomFootballer];
            infoLabel2.Text = footballer2.ToString();
        }

        /// <summary>
        /// Заполняем список футболистов для каждого игрока.
        /// </summary>
        /// <param name="player">Чей список будем заполнять.</param>
        /// <param name="listView">Список, где будем заполнять футболистами.</param>
        public void FillingList(Player player, ListView listView)
        {
            ListViewItem footballerProfile;
            for (int i = 0; i < 11; i++)
            {
                footballerProfile = new ListViewItem(player.Team[i].Name, i);
                // В качестве подсказки мы будем выводить стату футболиста.
                footballerProfile.ToolTipText = player.Team[i].ToString();
                listView.Items.Add(footballerProfile);
            }
        }

        bool closeFormMyself = false;

        /// <summary>
        /// При нажатии на кнопку мы перезапускаем игру заново, т.е. открываем первую форму и
        /// запускаем все новые.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            closeFormMyself = true;
            Close();
            start.Show();
        }

        /// <summary>
        /// Убираем автоматически выделение. Зачем? Захотелось.
        /// </summary>
        private void listPlayer2_Click(object sender, EventArgs e)
        {
            listPlayer2.SelectedItems.Clear();
        }

        /// <summary>
        /// Установливает положение формы ровно по центру для удобства.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - (Width / 2),
            Screen.PrimaryScreen.Bounds.Height / 2 - Height / 2);
        }

        /// <summary>
        /// Закрывает форму принудительно полностью и целиком. В случае неудачного закрытия вызовет
        /// окошко ошибки.
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closeFormMyself)
            {
                try
                {
                    Application.Exit();
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Произошла ошибка закрытия программы!");
                }
            }
        }
    }
}
