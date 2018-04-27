using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace League_planner
{
    public partial class Interfaz : Form
    {
        public Interfaz()
        {
            InitializeComponent();
            textBox1.Text = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox1.Text = monthCalendar1.SelectionStart.ToString();
            
        }

        private void formacion1(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("futbol/01.png");
        }

        private void formacion2(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("futbol/02.png");
        }

        private void formacion3(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("futbol/03.png");
        }

        private void formacion4(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("futbol/04.png");
        }
    }
}
