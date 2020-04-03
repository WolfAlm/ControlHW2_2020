using System;
using System.Drawing;
using System.Windows.Forms;

namespace KDZ_FIFA
{
    public partial class Information : Form
    {
        public Information()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Установливает положение формы ровно по центру для удобства.
        /// </summary>
        private void Information_Load(object sender, EventArgs e)
        {
            Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - (Width / 2),
            Screen.PrimaryScreen.Bounds.Height / 2 - Height / 2);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
