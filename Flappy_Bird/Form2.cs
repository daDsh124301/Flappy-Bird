using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // Клавиша Exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Клавиша Play
        private void PlayGame()
        {
            this.Hide();
            Form1 newForm = new Form1(this);
            newForm.Show();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            PlayGame();
        }

        public Form2(Form1 f)
        {
            InitializeComponent();
        }
    }
}
