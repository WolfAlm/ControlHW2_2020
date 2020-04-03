namespace KDZ_FIFA
{
    partial class ChoiceOfPlayer
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChoiceOfPlayer));
            this.tablePlayer = new System.Windows.Forms.DataGridView();
            this.nationalityBox = new System.Windows.Forms.ComboBox();
            this.overallBox = new System.Windows.Forms.ComboBox();
            this.potentialBox = new System.Windows.Forms.ComboBox();
            this.labelNationality = new System.Windows.Forms.Label();
            this.parsedFromFileButton = new System.Windows.Forms.Button();
            this.saveToFileButton = new System.Windows.Forms.Button();
            this.labelPotential = new System.Windows.Forms.Label();
            this.labelOverall = new System.Windows.Forms.Label();
            this.selectButton = new System.Windows.Forms.Button();
            this.listPlayer1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listPlayer2 = new System.Windows.Forms.ListView();
            this.infoLabel = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.tablePlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePlayer
            // 
            this.tablePlayer.AllowUserToAddRows = false;
            this.tablePlayer.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tablePlayer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablePlayer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tablePlayer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablePlayer.DefaultCellStyle = dataGridViewCellStyle2;
            this.tablePlayer.EnableHeadersVisualStyles = false;
            this.tablePlayer.Location = new System.Drawing.Point(12, 60);
            this.tablePlayer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tablePlayer.MultiSelect = false;
            this.tablePlayer.Name = "tablePlayer";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablePlayer.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tablePlayer.RowHeadersWidth = 51;
            this.tablePlayer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tablePlayer.RowTemplate.Height = 24;
            this.tablePlayer.Size = new System.Drawing.Size(1048, 524);
            this.tablePlayer.TabIndex = 3;
            this.tablePlayer.Visible = false;
            this.tablePlayer.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablePlayer_CellEndEdit);
            this.tablePlayer.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablePlayer_CellEnter);
            // 
            // nationalityBox
            // 
            this.nationalityBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.nationalityBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.nationalityBox.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.nationalityBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nationalityBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.nationalityBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nationalityBox.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.nationalityBox.FormattingEnabled = true;
            this.nationalityBox.Location = new System.Drawing.Point(390, 15);
            this.nationalityBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nationalityBox.Name = "nationalityBox";
            this.nationalityBox.Size = new System.Drawing.Size(149, 31);
            this.nationalityBox.Sorted = true;
            this.nationalityBox.TabIndex = 5;
            this.nationalityBox.Visible = false;
            this.nationalityBox.SelectedIndexChanged += new System.EventHandler(this.nationalityBox_SelectedIndexChanged);
            // 
            // overallBox
            // 
            this.overallBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.overallBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.overallBox.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.overallBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.overallBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.overallBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overallBox.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.overallBox.FormattingEnabled = true;
            this.overallBox.Location = new System.Drawing.Point(958, 15);
            this.overallBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.overallBox.Name = "overallBox";
            this.overallBox.Size = new System.Drawing.Size(149, 31);
            this.overallBox.Sorted = true;
            this.overallBox.TabIndex = 7;
            this.overallBox.Visible = false;
            this.overallBox.SelectedIndexChanged += new System.EventHandler(this.overallBox_SelectedIndexChanged);
            // 
            // potentialBox
            // 
            this.potentialBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.potentialBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.potentialBox.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.potentialBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.potentialBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.potentialBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.potentialBox.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.potentialBox.FormattingEnabled = true;
            this.potentialBox.Location = new System.Drawing.Point(678, 15);
            this.potentialBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.potentialBox.Name = "potentialBox";
            this.potentialBox.Size = new System.Drawing.Size(149, 31);
            this.potentialBox.Sorted = true;
            this.potentialBox.TabIndex = 8;
            this.potentialBox.Visible = false;
            this.potentialBox.SelectedIndexChanged += new System.EventHandler(this.potentialBox_SelectedIndexChanged);
            // 
            // labelNationality
            // 
            this.labelNationality.AutoSize = true;
            this.labelNationality.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.labelNationality.Font = new System.Drawing.Font("Algerian", 12F);
            this.labelNationality.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.labelNationality.Location = new System.Drawing.Point(228, 21);
            this.labelNationality.Name = "labelNationality";
            this.labelNationality.Size = new System.Drawing.Size(141, 22);
            this.labelNationality.TabIndex = 9;
            this.labelNationality.Text = "Nationality:";
            this.labelNationality.Visible = false;
            // 
            // parsedFromFileButton
            // 
            this.parsedFromFileButton.AutoSize = true;
            this.parsedFromFileButton.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.parsedFromFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.parsedFromFileButton.Font = new System.Drawing.Font("Algerian", 12F);
            this.parsedFromFileButton.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.parsedFromFileButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.parsedFromFileButton.Location = new System.Drawing.Point(15, 14);
            this.parsedFromFileButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.parsedFromFileButton.Name = "parsedFromFileButton";
            this.parsedFromFileButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.parsedFromFileButton.Size = new System.Drawing.Size(201, 39);
            this.parsedFromFileButton.TabIndex = 12;
            this.parsedFromFileButton.Text = "Parse from .CSV";
            this.parsedFromFileButton.UseVisualStyleBackColor = false;
            this.parsedFromFileButton.Click += new System.EventHandler(this.parsedFromFileButton_Click);
            // 
            // saveToFileButton
            // 
            this.saveToFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveToFileButton.AutoSize = true;
            this.saveToFileButton.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.saveToFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveToFileButton.Font = new System.Drawing.Font("Algerian", 12F);
            this.saveToFileButton.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.saveToFileButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveToFileButton.Location = new System.Drawing.Point(12, 593);
            this.saveToFileButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveToFileButton.Name = "saveToFileButton";
            this.saveToFileButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.saveToFileButton.Size = new System.Drawing.Size(160, 39);
            this.saveToFileButton.TabIndex = 13;
            this.saveToFileButton.Text = "Save to .CSV";
            this.saveToFileButton.UseVisualStyleBackColor = false;
            this.saveToFileButton.Visible = false;
            this.saveToFileButton.Click += new System.EventHandler(this.saveToFileButton_Click);
            // 
            // labelPotential
            // 
            this.labelPotential.AutoSize = true;
            this.labelPotential.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.labelPotential.Font = new System.Drawing.Font("Algerian", 12F);
            this.labelPotential.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.labelPotential.Location = new System.Drawing.Point(545, 21);
            this.labelPotential.Name = "labelPotential";
            this.labelPotential.Size = new System.Drawing.Size(119, 22);
            this.labelPotential.TabIndex = 14;
            this.labelPotential.Text = "Potential:";
            this.labelPotential.Visible = false;
            // 
            // labelOverall
            // 
            this.labelOverall.AutoSize = true;
            this.labelOverall.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.labelOverall.Font = new System.Drawing.Font("Algerian", 12F);
            this.labelOverall.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.labelOverall.Location = new System.Drawing.Point(833, 18);
            this.labelOverall.Name = "labelOverall";
            this.labelOverall.Size = new System.Drawing.Size(101, 22);
            this.labelOverall.TabIndex = 15;
            this.labelOverall.Text = "Overall:";
            this.labelOverall.Visible = false;
            // 
            // selectButton
            // 
            this.selectButton.AutoSize = true;
            this.selectButton.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.selectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectButton.Font = new System.Drawing.Font("Algerian", 12F);
            this.selectButton.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.selectButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.selectButton.Location = new System.Drawing.Point(811, 593);
            this.selectButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selectButton.Name = "selectButton";
            this.selectButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.selectButton.Size = new System.Drawing.Size(239, 39);
            this.selectButton.TabIndex = 16;
            this.selectButton.Text = "Select a footballer";
            this.selectButton.UseVisualStyleBackColor = false;
            this.selectButton.Visible = false;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // listPlayer1
            // 
            this.listPlayer1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.listPlayer1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPlayer1.ForeColor = System.Drawing.SystemColors.Window;
            this.listPlayer1.HideSelection = false;
            this.listPlayer1.LargeImageList = this.imageList1;
            this.listPlayer1.Location = new System.Drawing.Point(1067, 60);
            this.listPlayer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listPlayer1.Name = "listPlayer1";
            this.listPlayer1.ShowItemToolTips = true;
            this.listPlayer1.Size = new System.Drawing.Size(416, 523);
            this.listPlayer1.SmallImageList = this.imageList1;
            this.listPlayer1.TabIndex = 19;
            this.listPlayer1.UseCompatibleStateImageBehavior = false;
            this.listPlayer1.Visible = false;
            this.listPlayer1.Click += new System.EventHandler(this.listPlayer1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1.png");
            this.imageList1.Images.SetKeyName(1, "2.png");
            this.imageList1.Images.SetKeyName(2, "3.png");
            this.imageList1.Images.SetKeyName(3, "4.png");
            this.imageList1.Images.SetKeyName(4, "5.png");
            this.imageList1.Images.SetKeyName(5, "6.png");
            this.imageList1.Images.SetKeyName(6, "7.png");
            this.imageList1.Images.SetKeyName(7, "8.png");
            this.imageList1.Images.SetKeyName(8, "9.png");
            this.imageList1.Images.SetKeyName(9, "10.png");
            this.imageList1.Images.SetKeyName(10, "11.png");
            // 
            // listPlayer2
            // 
            this.listPlayer2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.listPlayer2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPlayer2.ForeColor = System.Drawing.SystemColors.Window;
            this.listPlayer2.HideSelection = false;
            this.listPlayer2.LargeImageList = this.imageList1;
            this.listPlayer2.Location = new System.Drawing.Point(1067, 60);
            this.listPlayer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listPlayer2.Name = "listPlayer2";
            this.listPlayer2.ShowItemToolTips = true;
            this.listPlayer2.Size = new System.Drawing.Size(416, 523);
            this.listPlayer2.SmallImageList = this.imageList1;
            this.listPlayer2.TabIndex = 20;
            this.listPlayer2.UseCompatibleStateImageBehavior = false;
            this.listPlayer2.Visible = false;
            this.listPlayer2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listPlayer2_MouseClick);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.infoLabel.Font = new System.Drawing.Font("Algerian", 16.2F);
            this.infoLabel.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.infoLabel.Location = new System.Drawing.Point(497, 94);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(497, 186);
            this.infoLabel.TabIndex = 21;
            this.infoLabel.Text = "<-- YOUR TEAM            ENEMY TEAM -->\r\nYOU CAN MOVE THE CURSOR\r\nTO PROFILE FOR " +
    "MORE \r\nINFORMATION ABOUT FOOTBALLER.\r\nIN THE GAME YOU HAVE TO DOUBLE\r\nCLICK TO S" +
    "ELECT A FOOTBALLER.";
            this.infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.infoLabel.Visible = false;
            // 
            // playButton
            // 
            this.playButton.AutoSize = true;
            this.playButton.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.Font = new System.Drawing.Font("Algerian", 30F);
            this.playButton.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.playButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.playButton.Location = new System.Drawing.Point(520, 351);
            this.playButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.playButton.Name = "playButton";
            this.playButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.playButton.Size = new System.Drawing.Size(459, 84);
            this.playButton.TabIndex = 22;
            this.playButton.Text = "PLAY A GAME";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Visible = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "FIFA.csv";
            this.openFileDialog1.Filter = "CSV files (*.csv)|*.csv";
            // 
            // ChoiceOfPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::KDZ_FIFA.Properties.Resources.emptyBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1593, 642);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.listPlayer2);
            this.Controls.Add(this.listPlayer1);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.labelOverall);
            this.Controls.Add(this.labelPotential);
            this.Controls.Add(this.saveToFileButton);
            this.Controls.Add(this.parsedFromFileButton);
            this.Controls.Add(this.labelNationality);
            this.Controls.Add(this.potentialBox);
            this.Controls.Add(this.overallBox);
            this.Controls.Add(this.nationalityBox);
            this.Controls.Add(this.tablePlayer);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1999, 689);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1499, 689);
            this.Name = "ChoiceOfPlayer";
            this.Text = "FIFA GAME";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablePlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView tablePlayer;
        private System.Windows.Forms.ComboBox nationalityBox;
        private System.Windows.Forms.ComboBox overallBox;
        private System.Windows.Forms.ComboBox potentialBox;
        private System.Windows.Forms.Label labelNationality;
        private System.Windows.Forms.Button parsedFromFileButton;
        private System.Windows.Forms.Button saveToFileButton;
        private System.Windows.Forms.Label labelPotential;
        private System.Windows.Forms.Label labelOverall;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.ListView listPlayer1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listPlayer2;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

