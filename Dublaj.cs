using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TheGame
{
    public partial class Dublaj : Form
    {
        public double suma;
        Random rand = new Random();
        int nr;
        int culoare;
        public Dublaj(string castig)
        {
            nr = 0;
            suma = Convert.ToInt32(castig);
            culoare = rand.Next(2);
            InitializeComponent();
            textBox1.Text = castig;
            textBox2.Text = "Alegeti o culoare";
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            if (culoare == 0)
            {
                suma = suma * 2;
                textBox1.Text = Convert.ToString(suma);
                MessageBox.Show("Felicitari!");
                nr++;
                culoare = rand.Next(2);
            }
            else
            {
                suma = 0;
                textBox1.Text = Convert.ToString(suma);
                nr = 3;
                MessageBox.Show("Ghinion,Mai mult noroc data viitoare");

            }
            if (nr == 3)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (culoare == 1)
            {
                suma = suma * 2;
                textBox1.Text = Convert.ToString(suma);
                MessageBox.Show("Felicitari!");
                nr++;
                culoare = rand.Next(2);
            }
            else
            {
                suma = 0;
                textBox1.Text = Convert.ToString(suma);
                nr = 3;
                MessageBox.Show("Ghinion,Mai mult noroc data viitoare");
                
            }
            if (nr == 3)
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
