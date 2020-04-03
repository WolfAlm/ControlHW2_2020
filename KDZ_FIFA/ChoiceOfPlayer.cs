using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using KDZLibrary;

namespace KDZ_FIFA
{
    public partial class ChoiceOfPlayer : Form
    {
        static Random random = new Random();
        string path;
        // Переменная, чтобы сохранять предыдущее значение.
        static object temp;
        // Переменные, которые будут нужны для фильтрации.
        bool nationalityBoxActivated, overallBoxActivated, potentialBoxActivated;
        string nationalityInfo = String.Empty, overallInfo = String.Empty, potentialInfo = String.Empty;

        // Мы создаем переменные, где будем создавать команду, футболистов и также отслеживать
        // каждый шаг.
        int step = 0;
        Player firstPlayer, secondPlayer;
        Footballer[] team = new Footballer[11];

        // Сохраняем форму.
        Start start;

        public ChoiceOfPlayer(Start start)
        {
            this.start = start;
            start.Hide();
            InitializeComponent();

            overallBoxActivated = potentialBoxActivated = nationalityBoxActivated = false;
        }

        /// <summary>
        /// По нажатии кнопки программа считывает данные с файла, после чего отображает все в таблицу.
        /// Паралелльно проверяется на правильное количество строк(оно должно быть не менее 23,
        /// чтобы иметь возможность собрать команду из 22 человек. Как и на количество столбцов.
        /// Оно должно быть всегда 12, а потом проверяется на названия столбцов.
        /// 
        /// Также одновременно он влияет на видимость кнопок и фильтра, чтобы они появлялись именно
        /// тогда, когда парсинг прошел успешно.
        /// </summary>
        private void parsedFromFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog1.FileName;
                }

                // До парсинга мы выключаем все ненужные элементы, которые так или иначе влияют
                // на работу, связанную с таблицой.
                saveToFileButton.Visible = overallBox.Visible = nationalityBox.Visible =
                    potentialBox.Visible = labelNationality.Visible = labelOverall.Visible =
                    labelPotential.Visible = tablePlayer.Visible = false;

                // Переменная для отслеживания количества некорректных данных.
                int quantityErrors = 0;

                // Будет очищена вся таблица, чтобы при повторе парсинга не расширялась бесконечно
                // таблица. 
                tablePlayer.Rows.Clear();
                tablePlayer.Columns.Clear();

                // Считываем с файла.
                string[] table = File.ReadAllText(path).Replace("\r", "").Split('\n');
                // С помощью цикла вытаскиваем нужные элементы и добавляем столбцы, строки.
                for (int i = 0; i < table.Length - 1; i++)
                {
                    // Создаем заголовки.
                    if (i == 0)
                    {
                        // Проверяем на корректное количество столбцов.
                        string[] row = table[i].Split(';');
                        if (row.Length != 12 || table.Length < 24)
                        {
                            throw new Utilites.ErrorException("На вход была подана некорректная " +
                                "таблица! Возможно, Вы специально ломали табличку... В любом случае," +
                                " не то количество столбцов/строк.");
                        }

                        // А если количество верное, то проверяем на правильные заголовки.
                        for (int j = 0; j < 12; j++)
                        {
                            string[] rowTest = {"sofifa_id", "player_url","short_name", "long_name",
                                "age", "dob", "height_cm", "weight_kg", "nationality", "club",
                                "overall", "potential" };

                            if (row[j] != rowTest[j])
                            {
                                throw new Utilites.ErrorException("Несоотвествие названий столбцов! " +
                                    "Вы ломаете таблицу, да?");
                            }

                            tablePlayer.Columns.Add(row[j], row[j]);
                        }
                        continue;
                    }
                    // Мы проверяем в каждой строке на корректность каждой ячейки, а потом уже
                    // после проверки добавляется строка.
                    tablePlayer.Rows.Add((new CSVParser()).CheckOnCorrect(table[i].Split(';'),
                        out int errorsParsed));
                    // Добавляем ошибки в счетчик.
                    if (errorsParsed > 0)
                    {
                        quantityErrors += errorsParsed;
                    }
                }

                // После успешного парсинга, мы показываем все кнопки, чтобы было корректное
                // взаимодействие. 
                saveToFileButton.Visible = overallBox.Visible = nationalityBox.Visible =
                    potentialBox.Visible = labelNationality.Visible = labelOverall.Visible =
                    labelPotential.Visible = selectButton.Visible = tablePlayer.Visible = true;

                // Будет предупреждено пользователя о том, что в его таблице были изменения. 
                if (quantityErrors > 0)
                {
                    throw new Utilites.ErrorException("В процессе считывания с таблицы были " +
                        $"найдены некорректности({quantityErrors}) и заменены на случайные числа.");
                }
            }
            catch (Utilites.ErrorException error)
            {
                Program.MessageShow(error.Message);
            }
            catch (IOException)
            {
                Program.MessageShow("Ошибка ввода-вывода, возможно файл занят чужим процессом.");
            }
            catch (System.Security.SecurityException)
            {
                Program.MessageShow("Ошибка безопасности.");
            }
            catch (UnauthorizedAccessException)
            {
                Program.MessageShow("У вас нет разрешения на создание файла!");
            }
            catch (Exception error)
            {
                Program.MessageShow(error.Message);
            }

            // После успешной считывания с файла и проверки всех элементов, мы заполняем выбор для фильтра.
            FillingList();
        }

        /// <summary>
        /// Сохраняет всю таблицу DataGridView в файл обратно, но это происходит только тогда, когда
        /// пользователь нажимает на кнопку "Сохранить результат".
        /// </summary>
        private void saveToFileButton_Click(object sender, EventArgs e)
        {
            string table = string.Empty;

            // Мы взяли i=-1, так как, к сожалению, Rows не включают заголовки. Поэтому мы будем их
            // рассматривать отдельно. 
            for (int i = -1; i < tablePlayer.RowCount - 1; i++)
            {
                for (int j = 0; j < tablePlayer.ColumnCount; j++)
                {
                    // Как говорилось выше,  -1 позволило нам добавить в строку заголовки.
                    if (i == -1)
                    {
                        table += tablePlayer.Columns[j].HeaderText;
                    }
                    else
                    {
                        table += tablePlayer.Rows[i].Cells[j].Value;
                    }
                    // Добавляем дополнительно разделители для корректного отображения в Excel.
                    if (j != tablePlayer.ColumnCount - 1)
                    {
                        table += ';';
                    }
                    else
                    {
                        table += Environment.NewLine;
                    }
                }
            }

            // Записываем в файл.
            Program.WriteToFile(path, table);
        }

        /// <summary>
        /// Метод обрабатывает редактирования любой ячейки, и не допускает некорректного значения
        /// от пользователя, если такой случай происходит, то с помощью метода CellEnter возвращается
        /// старое значение.
        /// </summary>
        private void tablePlayer_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Введем переменную для отслеживания действительности ошибки.
            bool error = false;
            // В case прописаны номера столбцов, где именно числовые значения, так как для каждого
            // случая нужно подбирать разные проверки на корректность.
            switch (e.ColumnIndex)
            {
                case 0:
                case 4:
                case 6:
                case 7:
                case 10:
                case 11:
                    if ((tablePlayer[e.ColumnIndex, e.RowIndex].Value == null) ||
                    (!uint.TryParse(tablePlayer[e.ColumnIndex, e.RowIndex].Value.ToString(),
                    out uint result)))
                    {
                        error = true;
                    }
                    break;
                default:
                    if ((tablePlayer[e.ColumnIndex, e.RowIndex].Value == null) ||
                        ((tablePlayer[e.ColumnIndex, e.RowIndex].Value.ToString().Replace(" ", "")
                        == string.Empty || (int.TryParse(tablePlayer[e.ColumnIndex, e.RowIndex].
                        Value.ToString(), out int result1)) ||
                        tablePlayer[e.ColumnIndex, e.RowIndex].Value.ToString().Length >= 21 ||
                        tablePlayer[e.ColumnIndex, e.RowIndex].Value.ToString().Contains(";")) &&
                        tablePlayer[e.ColumnIndex, e.RowIndex].Value.ToString() != temp))
                    {
                        error = true;
                    }
                    break;
            }

            // Если ошибка имеет место быть, то возвращается старое значение и выводится сообщение
            // о ошибке.
            if (error)
            {
                tablePlayer[e.ColumnIndex, e.RowIndex].Value = temp;

                Program.MessageShow("Упсссс... Вы некоректно ввели данные! Нельзя делать пустые строки," +
                    " также количество букв в названиях/именах не должно превышать 20 символов. " +
                    "В числовых данных нужно вводить только целые числа. Поэтому было возвращено " +
                    "старое значение!");
            }
            else
            {
                // Обновляем список выбора параметров.
                FillingList();

                // Также вызываем этот метод для обновления списка игроков в таблице в фильтрации.
                overallBoxActivated = potentialBoxActivated = nationalityBoxActivated = false;

                BeginInvoke(new MethodInvoker(() =>
                {
                    Filtred();
                }
                ));
            }
        }

        /// <summary>
        /// Всегда будет сохраняться значение при каждой выделенной ячейке, чтобы потом был
        /// передан параметр в метод CellEndEdit для восстановления старого значения при
        /// некорректном вводе. Также мы активируем кнопку выбора футболистов, если было выделено.
        /// </summary>
        /// <param name="e">Текущая ячейка в табличке.</param>
        private void tablePlayer_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (tablePlayer[e.ColumnIndex, e.RowIndex].Value != null)
            {
                temp = tablePlayer[e.ColumnIndex, e.RowIndex].Value.ToString();
                // Активировать кнопку на выбор футболиста.
                selectButton.Enabled = true;
            }
            else
            {
                selectButton.Enabled = false;
            }
        }

        /// <summary>
        /// Метод будет заполнять коллекцию для комбобоксов трех разных параметров.
        /// Для этого будет предварительная очистка списка во избежания случайного дублирования.
        /// После чего создаются листы, в которых всегда будет произвольная проверка на существующихся
        /// элементов. Потом добавляется в каждый комбобокс.
        /// </summary>
        private void FillingList()
        {
            List<string> nationalityList = new List<string>();
            List<string> potentialList = new List<string>();
            List<string> overallList = new List<string>();

            // Очистка списка.
            nationalityBox.Items.Clear();
            potentialBox.Items.Clear();
            overallBox.Items.Clear();
            // Добавим пустой элемент к каждому, чтобы была возможность сбросить фильтр.
            nationalityBox.Items.Add("");
            potentialBox.Items.Add("");
            overallBox.Items.Add("");

            // Заполнение списка.
            for (int i = 0; i < tablePlayer.Rows.Count; i++)
            {
                if (nationalityList.IndexOf(tablePlayer[8, i].Value.ToString()) < 0)
                {
                    nationalityList.Add(tablePlayer[8, i].Value.ToString());
                    nationalityBox.Items.Add(nationalityList.Last());
                }

                if (overallList.IndexOf(tablePlayer[10, i].Value.ToString()) < 0)
                {
                    overallList.Add(tablePlayer[10, i].Value.ToString());
                    overallBox.Items.Add(overallList.Last());
                }

                if (potentialList.IndexOf(tablePlayer[11, i].Value.ToString()) < 0)
                {
                    potentialList.Add(tablePlayer[11, i].Value.ToString());
                    potentialBox.Items.Add(potentialList.Last());
                }
            }
        }

        /// <summary>
        /// Собирает команду из футболистов, ведет отсчетчик в виде step, чтобы
        /// при достижении 11 футболистов кнопка исчезла и активировался автоматический выбор
        /// со стороны компьютера. Также, отключает все ненужные кнопки во избежании непредвиденных
        /// ситуаций. При выборе футболиста -- удаляет строку насовсем.
        /// </summary>
        private void selectButton_Click(object sender, EventArgs e)
        {
            // Мы отключаем возможность парсить с файла, как и редактировать табличку.
            parsedFromFileButton.Visible = false;
            listPlayer1.Visible = tablePlayer.ReadOnly = true;
            selectButton.Enabled = false;

            ListViewItem footballerProfile;
            // Создаем выбранного футболиста, одновременно вытаскивая все его данные.

            team[step] = new Footballer(tablePlayer.CurrentRow.Cells[2].Value.ToString(),
            uint.Parse(tablePlayer.CurrentRow.Cells[6].Value.ToString()),
            uint.Parse(tablePlayer.CurrentRow.Cells[7].Value.ToString()),
            uint.Parse(tablePlayer.CurrentRow.Cells[10].Value.ToString()),
            uint.Parse(tablePlayer.CurrentRow.Cells[11].Value.ToString()));

            // Мы добавляем футболиста в список, при этом, прописывая в элемент про его данные через
            // подсказку(tooltiptext).
            footballerProfile = new ListViewItem(tablePlayer.CurrentRow.Cells[2].Value.ToString(), step);
            footballerProfile.ToolTipText = team[step].ToString();
            listPlayer1.Items.Add(footballerProfile);

            // Удаляем все строки, где уже был выбран футболист.
            tablePlayer.Rows.Remove(tablePlayer.CurrentRow);
            step++;

            // Ход при достижении 11 передается компьютеру и также создаются сразу два класса игрокам.
            if (step == 11)
            {
                firstPlayer = new Player("Player_1", team);
                Footballer[] team1 = new Footballer[11];
                for (int i = 0; i < 11; i++)
                {
                    int randomRow = random.Next(0, tablePlayer.Rows.Count);
                    team1[i] = new Footballer(tablePlayer.Rows[randomRow].Cells[2].Value.ToString(),
                                 uint.Parse(tablePlayer.Rows[randomRow].Cells[6].Value.ToString()),
                                 uint.Parse(tablePlayer.Rows[randomRow].Cells[7].Value.ToString()),
                                 uint.Parse(tablePlayer.Rows[randomRow].Cells[10].Value.ToString()),
                                 uint.Parse(tablePlayer.Rows[randomRow].Cells[11].Value.ToString()));

                    footballerProfile = new ListViewItem(tablePlayer.Rows[randomRow].Cells[2].Value.ToString(), i);
                    footballerProfile.ToolTipText = team1[i].ToString();
                    listPlayer2.Items.Add(footballerProfile);
                    tablePlayer.Rows.Remove(tablePlayer.Rows[randomRow]);
                }

                secondPlayer = new Player("Player_2", team1);

                // Деактивируем все кнопки и данные, которые были связаны с табличкой. Включаем те
                // которые будут сообщать некоторую информацию игроку для продолжения игры.
                listPlayer2.Visible = infoLabel.Visible = playButton.Visible = true;
                tablePlayer.Visible = labelNationality.Visible = labelOverall.Visible =
                    labelPotential.Visible = potentialBox.Visible = nationalityBox.Visible
                    = overallBox.Visible = saveToFileButton.Visible = selectButton.Visible = false;

                // Для удобства отображения перед пользователем, мы расположим информацию о обеих
                // командах по обе стороны.
                listPlayer1.Location = new Point(listPlayer1.Location.X - 770, listPlayer1.Location.Y);
                listPlayer1.Anchor = (AnchorStyles.Left | AnchorStyles.Top);
            }
        }

        /// <summary>
        /// При выборе конкретного элемента в potentialBox мы проверяем, какой выбор именно был
        /// совершен, если был выбран пустой элемент, то это сброс фильтра. Если же какой-то
        /// конкретный параметр, то мы сохраняем переменную для дальнейшего фильтра.
        /// </summary>
        private void potentialBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (potentialBox.SelectedIndex >= 0)
            {
                potentialBoxActivated = (potentialBox.SelectedIndex != 0);
                potentialInfo = potentialBox.SelectedItem.ToString();
                Filtred();
            }
        }

        /// <summary>
        /// При выборе конкретного элемента в overallBox мы проверяем, какой выбор именно был
        /// совершен, если был выбран пустой элемент, то это сброс фильтра. Если же какой-то
        /// конкретный параметр, то мы сохраняем переменную для дальнейшего фильтра.
        /// </summary>
        private void overallBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (overallBox.SelectedIndex >= 0)
            {
                overallBoxActivated = (overallBox.SelectedIndex != 0);
                overallInfo = overallBox.SelectedItem.ToString();
                Filtred();
            }
        }

        /// <summary>
        /// При выборе конкретного элемента в nationalBox мы проверяем, какой выбор именно был
        /// совершен, если был выбран пустой элемент, то это сброс фильтра. Если же какой-то
        /// конкретный параметр, то мы сохраняем переменную для дальнейшего фильтра.
        /// </summary>
        private void nationalityBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (nationalityBox.SelectedIndex >= 0)
            {
                nationalityBoxActivated = (nationalityBox.SelectedIndex != 0);
                nationalityInfo = nationalityBox.SelectedItem.ToString();
                Filtred();
            }
        }

        /// <summary>
        /// Фильтрует по выбранным параметрам в вышеперечисленных комбобоксах, а именно, мы проверяем
        /// где и что было выбрано, чтобы потом делать нужные строки видимыми в таблице и убирать 
        /// ненужное(делаем их невидимыми). Всегда обновляется, если происходят изменения в таблице
        /// или изменяются параметры в комбобоксах.
        /// 
        /// Да, тут говнокод, просмотрите быстро и забудьте о том, что видели, вы ничего не знаете.
        /// Мы не знаем что это такое, если бы мы знали что это такое, но мы не знаем что это такое.
        /// Нам очень-очень страшно.
        /// </summary>
        private void Filtred()
        {
            for (int i = 0; i < tablePlayer.Rows.Count; i++)
            {
                // Это будет нужно для корректного выбора футболиста. Так как после фильтра
                // пропадает выделенная строка, поэтому очищаем ее и делаем невидимым кнопку.
                selectButton.Enabled = false;
                tablePlayer.ClearSelection();

                // Мы делаем деактивными все строки. Чтобы отображать те, которые удотвелтворяют
                // условию.
                tablePlayer.Rows[i].Visible = false;

                // Ура, великая фильтрация!
                if (overallBoxActivated && nationalityBoxActivated && potentialBoxActivated)
                {
                    if (tablePlayer[10, i].Value.ToString() == overallInfo &&
                        tablePlayer[8, i].Value.ToString() == nationalityInfo &&
                        tablePlayer[11, i].Value.ToString() == potentialInfo)
                    {
                        tablePlayer.Rows[i].Visible = true;
                    }
                }
                else if (overallBoxActivated && nationalityBoxActivated)
                {
                    if (tablePlayer[10, i].Value.ToString() == overallInfo &&
                        tablePlayer[8, i].Value.ToString() == nationalityInfo)
                    {
                        tablePlayer.Rows[i].Visible = true;
                    }
                }
                else if (nationalityBoxActivated && potentialBoxActivated)
                {
                    if (tablePlayer[8, i].Value.ToString() == nationalityInfo &&
                        tablePlayer[11, i].Value.ToString() == potentialInfo)
                    {
                        tablePlayer.Rows[i].Visible = true;
                    }
                }
                else if (overallBoxActivated && potentialBoxActivated)
                {
                    if (tablePlayer[10, i].Value.ToString() == overallInfo &&
                        tablePlayer[11, i].Value.ToString() == potentialInfo)
                    {
                        tablePlayer.Rows[i].Visible = true;
                    }
                }
                else if (overallBoxActivated)
                {
                    if (tablePlayer[10, i].Value.ToString() == overallInfo)
                    {
                        tablePlayer.Rows[i].Visible = true;
                    }
                }
                else if (potentialBoxActivated)
                {
                    if (tablePlayer[11, i].Value.ToString() == potentialInfo)
                    {
                        tablePlayer.Rows[i].Visible = true;
                    }
                }
                else if (nationalityBoxActivated)
                {
                    if (tablePlayer[8, i].Value.ToString() == nationalityInfo)
                    {
                        tablePlayer.Rows[i].Visible = true;
                    }
                }
                else
                {
                    tablePlayer.Rows[i].Visible = true;
                }
            }
        }

        bool closeFormMyself = false;

        /// <summary>
        /// Мы создаем новую форму, где уже будет процесс битвы.
        /// </summary>
        private void playButton_Click(object sender, EventArgs e)
        {
            new Fight(start, firstPlayer, secondPlayer).Show();
            closeFormMyself = true;
            Close();
        }

        /// <summary>
        /// Убираем автоматически выделение. Зачем? Захотелось.
        /// </summary>
        private void listPlayer1_Click(object sender, EventArgs e)
        {
            listPlayer1.SelectedItems.Clear();
        }

        /// <summary>
        /// Убираем автоматически выделение. Зачем? Захотелось.
        /// </summary>
        private void listPlayer2_MouseClick(object sender, MouseEventArgs e)
        {
            listPlayer2.SelectedItems.Clear();
        }

        /// <summary>
        /// Установливает положение формы ровно по центру для удобства. Отключаем возможность
        /// расширить форму на весь экран.
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