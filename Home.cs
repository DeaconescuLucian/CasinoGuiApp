using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheGame
{
    public partial class Home : Form
    {
        double Sold;
        string player;
        public Home(int s,string n)
        {
            Sold = s;
            player = n;
            InitializeComponent();
            label4.Text = player;
            label6.Text = Sold.ToString();
            timer1.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1((int)Sold, player);
            frm.ShowDialog();
            Sold = frm.Sold;
            label6.Text = Sold.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Tower tower = new Tower((int)Sold, player,0);
            tower.ShowDialog();
            Sold = tower.Sold;
            label6.Text = Sold.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new Login();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new Account(player,(int)Sold);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new Deposit((int)Sold,player);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new Withdraw((int)Sold, player);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label10.Text = DateTime.Now.ToShortDateString();
            this.label11.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Roulette ruleta = new Roulette(player, (int)Sold);
            ruleta.ShowDialog();
            Sold = ruleta.Sold;
            label6.Text = Sold.ToString();
        }
    }
}
