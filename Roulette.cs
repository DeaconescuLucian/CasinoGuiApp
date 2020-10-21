using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace TheGame
{
    public partial class Roulette: Form
    {
        string player;
        public int Sold = 500;
        int Castig = 0;
        int[] numere = new int[15];
        int Miza = 0;
        ArrayList buttonList = new ArrayList();
        int viteza;
        int waiting = 200;
        string sens = "dreapta";
        Random rnd = new Random();
        int i = 0;
        Image[] imagini = new Image[15] { TheGame.Properties.Resources._0, TheGame.Properties.Resources._1,
        TheGame.Properties.Resources._2,TheGame.Properties.Resources._3,TheGame.Properties.Resources._4,TheGame.Properties.Resources._5
        ,TheGame.Properties.Resources._6,TheGame.Properties.Resources.SAPTE,TheGame.Properties.Resources._8,TheGame.Properties.Resources._9
        ,TheGame.Properties.Resources._10,TheGame.Properties.Resources._11,TheGame.Properties.Resources._12,TheGame.Properties.Resources._13
        ,TheGame.Properties.Resources._14};
        PictureBox[] picturi = new PictureBox[14];

        public Roulette(string p,int s)
        {

            player = p;
            Sold = s;
            InitializeComponent();
            buttonList.Add(button4);
            buttonList.Add(button5);
            buttonList.Add(button6);
            buttonList.Add(button7);
            buttonList.Add(button8);
            buttonList.Add(button9);
            buttonList.Add(button10);
            buttonList.Add(button11);
            buttonList.Add(button12);
            buttonList.Add(button13);
            buttonList.Add(button14);
            buttonList.Add(button15);
            buttonList.Add(button16);
            buttonList.Add(button17);
            picturi[0] = pictureBox1;
            picturi[1] = pictureBox2;
            picturi[2] = pictureBox3;
            picturi[3] = pictureBox5;
            picturi[4] = pictureBox6;
            picturi[5] = pictureBox7;
            picturi[6] = pictureBox8;
            picturi[7] = pictureBox9;
            picturi[8] = pictureBox10;
            picturi[9] = pictureBox11;
            picturi[10] = pictureBox12;
            picturi[11] = pictureBox13;
            picturi[12] = pictureBox14;
            picturi[13] = pictureBox15;
            for (int i = 0; i < 15; i++)
                numere[i] = 0;
            viteza = rnd.Next(5, 70);
            timer1.Start();
            label3.Text = pictureBox4.Location.X.ToString();
            label8.Text = Sold.ToString();
            for (int i = 0; i < 14; i++)
                ((Button)buttonList[i]).Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            textBox1.Text = 0.ToString();

        }
        public void update_imagini()
        {
            for (int i = 13; i > 0; i--)
                picturi[i].BackgroundImage = picturi[i - 1].BackgroundImage;
            picturi[0].BackgroundImage = imagini[Convert.ToInt32(label4.Text)];
        }
        public void click_pe_numar(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {
                Miza = Convert.ToInt32(textBox1.Text);
                if (Miza <= Sold)
                {
                    numere[Convert.ToInt32(((Button)sender).Text)] += Miza * 14;
                    Sold = Sold - Miza;
                    label8.Text = Sold.ToString();
                    OleDbConnection conexiune = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlayersDB.accdb");
                    conexiune.Open();
                    OleDbCommand comanda = new OleDbCommand();
                    comanda.Connection = conexiune;
                    comanda.CommandText = "UPDATE Players set Sold=" + Sold + " where Player='" + player + "'";
                    comanda.ExecuteNonQuery();
                    conexiune.Close();
                }
                else
                {
                    MessageBox.Show("Sold Insuficient.");
                }
            }
            else
            {
                MessageBox.Show("Intorduceti miza.");
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            int latime = this.Width;
            if (i == 6*waiting+1)
            {
                i = 0;
                label1.Text = "Rolling...";
                viteza = rnd.Next(5, 70);
                for (int i = 0; i < 14; i++)
                    ((Button)buttonList[i]).Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;

            }

            if (i < waiting)
            {
                if (i > 120 && i < 150 && viteza > 10)
                    viteza = 10;
                if (i > 150 && i < 197 && viteza > 5)
                    viteza = 5;
                if (i > 197)
                    viteza = 1;
                if (pictureBox4.Location.X <= -3652 && sens == "stanga")
                {
                    sens = "dreapta";
                    pictureBox4.Location = new Point(pictureBox4.Location.X + viteza, pictureBox4.Location.Y);

                }
                if (pictureBox4.Location.X > -3652 && sens == "stanga")
                {
                    pictureBox4.Location = new Point(pictureBox4.Location.X - viteza, pictureBox4.Location.Y);
                }
                if (sens == "dreapta" && pictureBox4.Location.X < -187)
                {
                    pictureBox4.Location = new Point(pictureBox4.Location.X + viteza, pictureBox4.Location.Y);

                }
                if (sens == "dreapta" && pictureBox4.Location.X >= -187)
                {
                    sens = "stanga";
                    pictureBox4.Location = new Point(pictureBox4.Location.X - viteza, pictureBox4.Location.Y);
                }
                i++;
            }

            if (i > waiting-1)
            {
                i++;
                if (i == waiting+1)
                {
                    label1.Text = "Roll in 10";



                    if (pictureBox4.Location.X <= -3575 && pictureBox4.Location.X >= -3652 || pictureBox4.Location.X <= -2411 && pictureBox4.Location.X > -2489 || pictureBox4.Location.X <= -1260 && pictureBox4.Location.X > -1339)
                        label4.Text = "4";
                    if (pictureBox4.Location.X <= -3497 && pictureBox4.Location.X > -3575 || pictureBox4.Location.X <= -2333 && pictureBox4.Location.X > -2411 || pictureBox4.Location.X <= -1183 && pictureBox4.Location.X > -1260)
                        label4.Text = "12";
                    if (pictureBox4.Location.X <= -3422 && pictureBox4.Location.X > -3497 || pictureBox4.Location.X <= -2257 && pictureBox4.Location.X > -2333 || pictureBox4.Location.X <= -1109 && pictureBox4.Location.X > -1183)
                        label4.Text = "3";
                    if (pictureBox4.Location.X <= -3345 && pictureBox4.Location.X > -3422 || pictureBox4.Location.X <= -2182 && pictureBox4.Location.X > -2257 || pictureBox4.Location.X <= -1031 && pictureBox4.Location.X > -1109)
                        label4.Text = "13";
                    if (pictureBox4.Location.X <= -3268 && pictureBox4.Location.X > -3345 || pictureBox4.Location.X <= -2103 && pictureBox4.Location.X > -2182 || pictureBox4.Location.X <= -953 && pictureBox4.Location.X > -1031)
                        label4.Text = "2";
                    if (pictureBox4.Location.X <= -3189 && pictureBox4.Location.X > -3268 || pictureBox4.Location.X <= -2027 && pictureBox4.Location.X > -2103 || pictureBox4.Location.X <= -874 && pictureBox4.Location.X > -953)
                        label4.Text = "14";
                    if (pictureBox4.Location.X <= -3115 && pictureBox4.Location.X > -3189 || pictureBox4.Location.X <= -1953 && pictureBox4.Location.X > -2027 || pictureBox4.Location.X <= -800 && pictureBox4.Location.X > -874)
                        label4.Text = "1";
                    if (pictureBox4.Location.X <= -3037 && pictureBox4.Location.X > -3115 || pictureBox4.Location.X <= -1884 && pictureBox4.Location.X > -1953 || pictureBox4.Location.X <= -721 && pictureBox4.Location.X > -800)
                        label4.Text = "8";
                    if (pictureBox4.Location.X <= -2958 && pictureBox4.Location.X > -3037 || pictureBox4.Location.X <= -1804 && pictureBox4.Location.X > -1884 || pictureBox4.Location.X <= -641 && pictureBox4.Location.X > -722)
                        label4.Text = "7";
                    if (pictureBox4.Location.X <= -2881 && pictureBox4.Location.X > -2958 || pictureBox4.Location.X <= -1730 && pictureBox4.Location.X > -1804 || pictureBox4.Location.X <= -565 && pictureBox4.Location.X > -641)
                        label4.Text = "9";
                    if (pictureBox4.Location.X <= -2802 && pictureBox4.Location.X > -2881 || pictureBox4.Location.X <= -1652 && pictureBox4.Location.X > -1730 || pictureBox4.Location.X <= -488 && pictureBox4.Location.X > -565)
                        label4.Text = "6";
                    if (pictureBox4.Location.X <= -2724 && pictureBox4.Location.X > -2802 || pictureBox4.Location.X <= -1574 && pictureBox4.Location.X > -1652 || pictureBox4.Location.X <= -410 && pictureBox4.Location.X > -488)
                        label4.Text = "10";
                    if (pictureBox4.Location.X <= -2646 && pictureBox4.Location.X > -2724 || pictureBox4.Location.X <= -1495 && pictureBox4.Location.X > -1574 || pictureBox4.Location.X <= -331 && pictureBox4.Location.X > -410)
                        label4.Text = "5";
                    if (pictureBox4.Location.X <= -2567 && pictureBox4.Location.X > -2646 || pictureBox4.Location.X <= -1419 && pictureBox4.Location.X > -1495 || pictureBox4.Location.X <= -253 && pictureBox4.Location.X > -331)
                        label4.Text = "11";
                    if (pictureBox4.Location.X <= -2489 && pictureBox4.Location.X > -2567 || pictureBox4.Location.X <= -1339 && pictureBox4.Location.X > -1419 || pictureBox4.Location.X <= -187 && pictureBox4.Location.X > -253)
                        label4.Text = "0";
                    update_imagini();
                    for (int j = 0; j < 15; j++)
                    {
                        if (j == Convert.ToInt32(label4.Text))
                        {
                            Castig = Castig + numere[j];
                            label10.Text = Castig.ToString();
                            Sold = Sold + numere[j];
                            label8.Text = Sold.ToString();
                            OleDbConnection conexiune = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlayersDB.accdb");
                            conexiune.Open();
                            OleDbCommand comanda = new OleDbCommand();
                            comanda.Connection = conexiune;
                            comanda.CommandText = "UPDATE Players set Sold=" + Sold + " where Player='" + player + "'";
                            comanda.ExecuteNonQuery();
                            conexiune.Close();
                        }
                    }

                    for (int j = 0; j < 14; j++)
                    {
                        ((Button)buttonList[j]).Enabled = true;


                    }
                    for (int j = 0; j < 15; j++)
                    {
                        numere[j] = 0;
                    }
                    Castig = 0;
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;

                    label3.Text = pictureBox4.Location.X.ToString();
                }
                if (i == waiting+waiting/2)
                {
                    label1.Text = "Roll in 9";

                }
                if (i == 2*waiting)
                    label1.Text = "Roll in 8";
                if (i == 2*waiting+waiting/2)
                    label1.Text = "Roll in 7";
                if (i == 3*waiting)
                    label1.Text = "Roll in 6";
                if (i == 3*waiting+waiting/2)
                    label1.Text = "Roll in 5";
                if (i == 4*waiting)
                    label1.Text = "Roll in 4";
                if (i == 4*waiting+waiting/2)
                    label1.Text = "Roll in 3";
                if (i == 5*waiting)
                    label1.Text = "Roll in 2";
                if (i == 5*waiting+waiting/2)
                    label1.Text = "Roll in 1";
                if (i == 6*waiting)
                    label1.Text = "Roll in 0";

            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            click_pe_numar(sender, e);
        }

       
        private void tb_miza_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {
                Miza = Convert.ToInt32(textBox1.Text);
                if (Miza <= Sold)
                {
                    for (int i = 8; i < 15; i++)
                    { numere[i] += Miza * 2; }
                    Sold = Sold - Miza;
                    label8.Text = Sold.ToString();
                    OleDbConnection conexiune = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlayersDB.accdb");
                    conexiune.Open();
                    OleDbCommand comanda = new OleDbCommand();
                    comanda.Connection = conexiune;
                    comanda.CommandText = "UPDATE Players set Sold=" + Sold + " where Player='" + player + "'";
                    comanda.ExecuteNonQuery();
                    conexiune.Close();
                }
                else
                {
                    MessageBox.Show("Sold Insuficient.");
                }
            }
            else
            {
                MessageBox.Show("Intorduceti miza.");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Miza = Convert.ToInt32(textBox1.Text);
                if (Miza <= Sold)
                {
                    for (int i = 1; i < 8; i++)
                    { numere[i] += Miza * 2; }
                    Sold = Sold - Miza;
                    label8.Text = Sold.ToString();
                    OleDbConnection conexiune = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlayersDB.accdb");
                    conexiune.Open();
                    OleDbCommand comanda = new OleDbCommand();
                    comanda.Connection = conexiune;
                    comanda.CommandText = "UPDATE Players set Sold=" + Sold + " where Player='" + player + "'";
                    comanda.ExecuteNonQuery();
                    conexiune.Close();
                }
                else
                {
                    MessageBox.Show("Sold Insuficient.");
                }
            }
            else
            {
                MessageBox.Show("Intorduceti miza.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Miza = Convert.ToInt32(textBox1.Text);
                if (Miza <= Sold)
                {

                    numere[0] += Miza * 14;
                    Sold = Sold - Miza;
                    label8.Text = Sold.ToString();
                }
                else
                {
                    MessageBox.Show("Sold Insuficient.");
                }
            }
            else
            {
                MessageBox.Show("Intorduceti miza.");
            }
        }
    }
}