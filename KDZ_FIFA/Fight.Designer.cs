namespace KDZ_FIFA
{
    partial class Fight
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fight));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listPlayer2 = new System.Windows.Forms.ListView();
            this.listPlayer1 = new System.Windows.Forms.ListView();
            this.moveLabel = new System.Windows.Forms.Label();
            this.yourTeamLabel = new System.Windows.Forms.Label();
            this.enemyTeamLabel = new System.Windows.Forms.Label();
            this.accountLabel = new System.Windows.Forms.Label();
            this.logGameBox = new System.Windows.Forms.RichTextBox();
            this.picturePlayer1 = new System.Windows.Forms.PictureBox();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.infoLabel1 = new System.Windows.Forms.Label();
            this.picturePlayer2 = new System.Windows.Forms.PictureBox();
            this.infoLabel2 = new System.Windows.Forms.Label();
            this.goButton = new System.Windows.Forms.Button();
            this.finalLabel = new System.Windows.Forms.Label();
            this.restartButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picturePlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePlayer2)).BeginInit();
            this.SuspendLayout();
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
            this.listPlayer2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.listPlayer2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listPlayer2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPlayer2.ForeColor = System.Drawing.Color.Khaki;
            this.listPlayer2.HideSelection = false;
            this.listPlayer2.LargeImageList = this.imageList1;
            this.listPlayer2.Location = new System.Drawing.Point(942, 98);
            this.listPlayer2.MultiSelect = false;
            this.listPlayer2.Name = "listPlayer2";
            this.listPlayer2.ShowItemToolTips = true;
            this.listPlayer2.Size = new System.Drawing.Size(480, 544);
            this.listPlayer2.SmallImageList = this.imageList1;
            this.listPlayer2.TabIndex = 21;
            this.listPlayer2.UseCompatibleStateImageBehavior = false;
            this.listPlayer2.Click += new System.EventHandler(this.listPlayer2_Click);
            // 
            // listPlayer1
            // 
            this.listPlayer1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.listPlayer1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listPlayer1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPlayer1.ForeColor = System.Drawing.Color.Khaki;
            this.listPlayer1.HideSelection = false;
            this.listPlayer1.LargeImageList = this.imageList1;
            this.listPlayer1.Location = new System.Drawing.Point(362, 98);
            this.listPlayer1.MultiSelect = false;
            this.listPlayer1.Name = "listPlayer1";
            this.listPlayer1.ShowItemToolTips = true;
            this.listPlayer1.Size = new System.Drawing.Size(480, 544);
            this.listPlayer1.SmallImageList = this.imageList1;
            this.listPlayer1.TabIndex = 23;
            this.listPlayer1.UseCompatibleStateImageBehavior = false;
            this.listPlayer1.DoubleClick += new System.EventHandler(this.listPlayer1_DoubleClick);
            // 
            // moveLabel
            // 
            this.moveLabel.AutoSize = true;
            this.moveLabel.BackColor = System.Drawing.Color.Transparent;
            this.moveLabel.Font = new System.Drawing.Font("Algerian", 44F);
            this.moveLabel.ForeColor = System.Drawing.Color.Cornsilk;
            this.moveLabel.Location = new System.Drawing.Point(86, 655);
            this.moveLabel.Name = "moveLabel";
            this.moveLabel.Size = new System.Drawing.Size(1230, 83);
            this.moveLabel.TabIndex = 24;
            this.moveLabel.Text = "ROUND 1. First player attacks.";
            this.moveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yourTeamLabel
            // 
            this.yourTeamLabel.AutoSize = true;
            this.yourTeamLabel.BackColor = System.Drawing.Color.Transparent;
            this.yourTeamLabel.Font = new System.Drawing.Font("Algerian", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yourTeamLabel.ForeColor = System.Drawing.Color.Cornsilk;
            this.yourTeamLabel.Location = new System.Drawing.Point(410, 24);
            this.yourTeamLabel.Name = "yourTeamLabel";
            this.yourTeamLabel.Size = new System.Drawing.Size(353, 66);
            this.yourTeamLabel.TabIndex = 25;
            this.yourTeamLabel.Text = "Your team";
            // 
            // enemyTeamLabel
            // 
            this.enemyTeamLabel.AutoSize = true;
            this.enemyTeamLabel.BackColor = System.Drawing.Color.Transparent;
            this.enemyTeamLabel.Font = new System.Drawing.Font("Algerian", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enemyTeamLabel.ForeColor = System.Drawing.Color.Cornsilk;
            this.enemyTeamLabel.Location = new System.Drawing.Point(1003, 24);
            this.enemyTeamLabel.Name = "enemyTeamLabel";
            this.enemyTeamLabel.Size = new System.Drawing.Size(396, 66);
            this.enemyTeamLabel.TabIndex = 26;
            this.enemyTeamLabel.Text = "Enemy team";
            // 
            // accountLabel
            // 
            this.accountLabel.AutoSize = true;
            this.accountLabel.BackColor = System.Drawing.Color.Transparent;
            this.accountLabel.Font = new System.Drawing.Font("Algerian", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountLabel.ForeColor = System.Drawing.Color.Cornsilk;
            this.accountLabel.Location = new System.Drawing.Point(828, 24);
            this.accountLabel.Name = "accountLabel";
            this.accountLabel.Size = new System.Drawing.Size(144, 66);
            this.accountLabel.TabIndex = 27;
            this.accountLabel.Text = "0 : 0";
            // 
            // logGameBox
            // 
            this.logGameBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.logGameBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.logGameBox.ForeColor = System.Drawing.Color.Khaki;
            this.logGameBox.Location = new System.Drawing.Point(30, 98);
            this.logGameBox.Name = "logGameBox";
            this.logGameBox.ReadOnly = true;
            this.logGameBox.Size = new System.Drawing.Size(309, 544);
            this.logGameBox.TabIndex = 28;
            this.logGameBox.Text = "";
            // 
            // picturePlayer1
            // 
            this.picturePlayer1.BackColor = System.Drawing.Color.Transparent;
            this.picturePlayer1.Image = global::KDZ_FIFA.Properties.Resources._1;
            this.picturePlayer1.Location = new System.Drawing.Point(421, 84);
            this.picturePlayer1.Name = "picturePlayer1";
            this.picturePlayer1.Size = new System.Drawing.Size(316, 305);
            this.picturePlayer1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturePlayer1.TabIndex = 29;
            this.picturePlayer1.TabStop = false;
            this.picturePlayer1.Visible = false;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "1.png");
            this.imageList2.Images.SetKeyName(1, "2.png");
            this.imageList2.Images.SetKeyName(2, "3.png");
            this.imageList2.Images.SetKeyName(3, "4.png");
            this.imageList2.Images.SetKeyName(4, "5.png");
            this.imageList2.Images.SetKeyName(5, "6.png");
            this.imageList2.Images.SetKeyName(6, "7.png");
            this.imageList2.Images.SetKeyName(7, "8.png");
            this.imageList2.Images.SetKeyName(8, "9.png");
            this.imageList2.Images.SetKeyName(9, "10.png");
            this.imageList2.Images.SetKeyName(10, "11.png");
            // 
            // infoLabel1
            // 
            this.infoLabel1.AutoSize = true;
            this.infoLabel1.BackColor = System.Drawing.Color.Transparent;
            this.infoLabel1.Font = new System.Drawing.Font("Algerian", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLabel1.ForeColor = System.Drawing.Color.Cornsilk;
            this.infoLabel1.Location = new System.Drawing.Point(368, 399);
            this.infoLabel1.Name = "infoLabel1";
            this.infoLabel1.Size = new System.Drawing.Size(474, 210);
            this.infoLabel1.TabIndex = 30;
            this.infoLabel1.Text = "Name: {Name}\r\nHeight_cm: {Height_cm}\r\nWeight_kg: {Weight_kg\r\nOverall: {Overall}\r\n" +
    "Potential: {Potential}";
            this.infoLabel1.Visible = false;
            // 
            // picturePlayer2
            // 
            this.picturePlayer2.BackColor = System.Drawing.Color.Transparent;
            this.picturePlayer2.Image = global::KDZ_FIFA.Properties.Resources._1;
            this.picturePlayer2.Location = new System.Drawing.Point(1035, 84);
            this.picturePlayer2.Name = "picturePlayer2";
            this.picturePlayer2.Size = new System.Drawing.Size(316, 305);
            this.picturePlayer2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturePlayer2.TabIndex = 31;
            this.picturePlayer2.TabStop = false;
            this.picturePlayer2.Visible = false;
            // 
            // infoLabel2
            // 
            this.infoLabel2.AutoSize = true;
            this.infoLabel2.BackColor = System.Drawing.Color.Transparent;
            this.infoLabel2.Font = new System.Drawing.Font("Algerian", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLabel2.ForeColor = System.Drawing.Color.Cornsilk;
            this.infoLabel2.Location = new System.Drawing.Point(967, 399);
            this.infoLabel2.Name = "infoLabel2";
            this.infoLabel2.Size = new System.Drawing.Size(474, 210);
            this.infoLabel2.TabIndex = 32;
            this.infoLabel2.Text = "Name: {Name}\r\nHeight_cm: {Height_cm}\r\nWeight_kg: {Weight_kg\r\nOverall: {Overall}\r\n" +
    "Potential: {Potential}";
            this.infoLabel2.Visible = false;
            // 
            // goButton
            // 
            this.goButton.AutoSize = true;
            this.goButton.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.goButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goButton.Font = new System.Drawing.Font("Algerian", 30F);
            this.goButton.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.goButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.goButton.Location = new System.Drawing.Point(812, 252);
            this.goButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.goButton.Name = "goButton";
            this.goButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.goButton.Size = new System.Drawing.Size(194, 67);
            this.goButton.TabIndex = 33;
            this.goButton.Text = "GOOOO";
            this.goButton.UseVisualStyleBackColor = false;
            this.goButton.Visible = false;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // finalLabel
            // 
            this.finalLabel.AutoSize = true;
            this.finalLabel.BackColor = System.Drawing.Color.Transparent;
            this.finalLabel.Font = new System.Drawing.Font("Algerian", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finalLabel.ForeColor = System.Drawing.Color.Cornsilk;
            this.finalLabel.Location = new System.Drawing.Point(12, 9);
            this.finalLabel.Name = "finalLabel";
            this.finalLabel.Size = new System.Drawing.Size(820, 268);
            this.finalLabel.TabIndex = 34;
            this.finalLabel.Text = "Hooray! You\r\nwin!";
            this.finalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.finalLabel.Visible = false;
            // 
            // restartButton
            // 
            this.restartButton.AutoSize = true;
            this.restartButton.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.restartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restartButton.Font = new System.Drawing.Font("Algerian", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restartButton.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.restartButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.restartButton.Location = new System.Drawing.Point(486, 529);
            this.restartButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.restartButton.Name = "restartButton";
            this.restartButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.restartButton.Size = new System.Drawing.Size(555, 158);
            this.restartButton.TabIndex = 35;
            this.restartButton.Text = "PLAY AGAIN";
            this.restartButton.UseVisualStyleBackColor = false;
            this.restartButton.Visible = false;
            this.restartButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Algerian", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cornsilk;
            this.label1.Location = new System.Drawing.Point(36, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 66);
            this.label1.TabIndex = 36;
            this.label1.Text = "Your log";
            // 
            // Fight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::KDZ_FIFA.Properties.Resources.fon_stadion1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1521, 781);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.finalLabel);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.infoLabel2);
            this.Controls.Add(this.picturePlayer2);
            this.Controls.Add(this.infoLabel1);
            this.Controls.Add(this.picturePlayer1);
            this.Controls.Add(this.logGameBox);
            this.Controls.Add(this.accountLabel);
            this.Controls.Add(this.enemyTeamLabel);
            this.Controls.Add(this.yourTeamLabel);
            this.Controls.Add(this.moveLabel);
            this.Controls.Add(this.listPlayer1);
            this.Controls.Add(this.listPlayer2);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1539, 828);
            this.Name = "Fight";
            this.Text = "Fight";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picturePlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePlayer2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listPlayer2;
        private System.Windows.Forms.ListView listPlayer1;
        private System.Windows.Forms.Label moveLabel;
        private System.Windows.Forms.Label yourTeamLabel;
        private System.Windows.Forms.Label enemyTeamLabel;
        private System.Windows.Forms.Label accountLabel;
        private System.Windows.Forms.RichTextBox logGameBox;
        private System.Windows.Forms.PictureBox picturePlayer1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Label infoLabel1;
        private System.Windows.Forms.PictureBox picturePlayer2;
        private System.Windows.Forms.Label infoLabel2;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Label finalLabel;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Label label1;
    }
}