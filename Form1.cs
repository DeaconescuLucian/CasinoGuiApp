using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Data.OleDb;

namespace TheGame
{
    public partial class Form1 : Form
    {

        public double Sold;
        string player;
        double Miza=1;
        public double CASTIG;
        string auto = "off";
        Random rnd = new Random();
        Image[] imagini = new Image[] { global::TheGame.Properties.Resources.lamaie, global::TheGame.Properties.Resources.seven, global::TheGame.Properties.Resources.banana, global::TheGame.Properties.Resources.cherry, global::TheGame.Properties.Resources.grapes, global::TheGame.Properties.Resources.melon, global::TheGame.Properties.Resources.orange, global::TheGame.Properties.Resources.plum, global::TheGame.Properties.Resources.star };
                                                                                         //lamaie-0 seven-1 banana-2 cherry-3 grapes-4 melon-5 orange-6 plum-7 star-8
        
        public Form1(int s,string nume)
        {
            Sold = s;
            player = nume;
            InitializeComponent();
            tb_sold.Text = Convert.ToString(Sold);
            tb_miza.Text = Convert.ToString(Miza);
            this.pictureBox1.Image = imagini[1];
            //lamaie-0 seven-1 banana-2 cherry-3 grapes-4 melon-5 orange-6 plum-7 star-8
            this.pictureBox2.Image = imagini[4];
            this.pictureBox3.Image = imagini[8];
            this.pictureBox4.Image = imagini[6];
            this.pictureBox5.Image = imagini[3];
            this.pictureBox6.Image = imagini[2];
            this.pictureBox7.Image = imagini[6];
            this.pictureBox8.Image = imagini[5];
            this.pictureBox9.Image = imagini[7];
            this.pictureBox10.Image = imagini[0];
            this.pictureBox11.Image = imagini[1];
            this.pictureBox12.Image = imagini[1];
            this.pictureBox13.Image = imagini[1];
            this.pictureBox14.Image = imagini[1];
            this.pictureBox15.Image = imagini[1];


        }

        private void tb_miza_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            double Castig = 0;
            CASTIG = 0;
            Miza = Convert.ToInt32(tb_miza.Text);
            if(Miza>20)
            {
                Miza = 20;
                tb_miza.Text = Miza.ToString();
            }
            //lamaie-0 seven-1 banana-2 cherry-3 grapes-4 melon-5 orange-6 plum-7 star-8
            int[] vector = new int[1000];
            for (int i = 0; i < 150; i++)
                vector[i] = 0;
            for (int i = 150; i < 300; i++)
                vector[i] = 3;
            for (int i = 300; i < 450; i++)
                vector[i] = 6;
            for (int i = 450; i < 600; i++)
                vector[i] = 7;
            for (int i = 600; i < 700; i++)
                vector[i] = 4;
            for (int i = 700; i < 800; i++)
                vector[i] = 5;
            for (int i = 800; i < 880; i++)
                vector[i] = 2;
            for (int i = 880; i < 950; i++)
                vector[i] = 1;
            for (int i = 950; i < 1000; i++)
                vector[i] = 8;
            int[] vector2 = new int[] { 8,8,8,8,0,0,0,8,0,0,0,0,0,0,0 };
             for (int i = 0; i < 15; i++)
              vector2[i] = vector[rnd.Next(1000)]; 
             
            this.pictureBox1.Image = imagini[vector2[0]];
            this.pictureBox2.Image = imagini[vector2[1]];
            this.pictureBox3.Image = imagini[vector2[2]];
            this.pictureBox4.Image = imagini[vector2[3]];
            this.pictureBox5.Image = imagini[vector2[4]];
            this.pictureBox6.Image = imagini[vector2[5]];
            this.pictureBox7.Image = imagini[vector2[6]];
            this.pictureBox8.Image = imagini[vector2[7]];
            this.pictureBox9.Image = imagini[vector2[8]];
            this.pictureBox10.Image = imagini[vector2[9]];
            this.pictureBox11.Image = imagini[vector2[10]];
            this.pictureBox12.Image = imagini[vector2[11]];
            this.pictureBox13.Image = imagini[vector2[12]];
            this.pictureBox14.Image = imagini[vector2[13]];
            this.pictureBox15.Image = imagini[vector2[14]];
            if (Miza <= Sold)
            {
                //lamaie-0 seven-1 banana-2 cherry-3 grapes-4 melon-5 orange-6 plum-7 star-8
                Sold = Sold - Miza;
                //lamai
                //linia1
                if (vector2[0] == 0 && vector2[1] == 0 && vector2[2] == 0)
                {
                    double multiplier=1;
                    multiplier= multiplier*Miza * 4;
                    if (vector2[3] == 0)
                    {
                        multiplier = multiplier * 2.5;
                        if (vector2[4] == 0)
                            multiplier = multiplier * 4;
                    }
                    Castig = Castig +multiplier;
                }
                //linia2
                if (vector2[5] == 0 && vector2[6] == 0 && vector2[7] == 0)
                {
                    double multiplier=1;
                    multiplier = multiplier*Miza * 4;
                    if (vector2[8] == 0)
                    {
                        multiplier = multiplier * 2.5;
                        if (vector2[9] == 0)
                            multiplier = multiplier * 4;
                    }
                    Castig = Castig + multiplier;
                }
                //linia3
                if (vector2[10] == 0 && vector2[11] == 0 && vector2[12] == 0)
                {
                    double multiplier=1;
                    multiplier = multiplier*Miza * 4;
                    if (vector2[13] == 0)
                    {
                        multiplier = multiplier * 2.5;
                        if (vector2[14]== 0)
                            multiplier = multiplier* 4;
                    }
                    Castig = Castig +  multiplier;
                }
                //linia4
                if (vector2[0] == 0 && vector2[6] == 0 && vector2[12] == 0)
                {
                    double multiplier=1;
                    multiplier = multiplier*Miza * 4;
                    if (vector2[8] == 0)
                    {
                        multiplier = multiplier * 2.5;
                        if (vector2[4] == 0)
                            multiplier = multiplier * 4;
                    }
                    Castig = Castig + multiplier;
                }
                //linia5
                if (vector2[10] == 0 && vector2[6] == 0 && vector2[2] == 0)
                {
                    double multiplier=1;
                    multiplier = multiplier*Miza * 4;
                    if (vector2[8] == 0)
                    {
                        multiplier = multiplier * 2.5;
                        if (vector2[14] == 0)
                            multiplier = multiplier* 4;
                    }
                    Castig = Castig + multiplier;
                }
                //cherry
                //linia1
                if (vector2[0] == 3 && vector2[1] == 3 )
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza;
                    if (vector2[2] == 3)
                    {
                        multiplier = multiplier  * 4;
                        if (vector2[3] == 3)
                        {
                            multiplier = multiplier * 2.5;
                            if (vector2[4] == 3)
                                multiplier = multiplier * 4;
                        }
                    }
                    Castig = Castig + multiplier;
                }
                //linia2
                if (vector2[5] == 3 && vector2[6] == 3)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza;
                    if (vector2[7] == 3)
                    {
                        multiplier = multiplier * 4;
                        if (vector2[8] == 3)
                        {
                            multiplier = multiplier * 2.5;
                            if (vector2[9] == 3)
                                multiplier = multiplier * 4;
                        }
                    }
                    Castig = Castig + multiplier;
                }
                //linia3
                if (vector2[10] == 3 && vector2[11] == 3)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza;
                    if (vector2[12] == 3)
                    {
                        multiplier = multiplier * 4;
                        if (vector2[13] == 3)
                        {
                            multiplier = multiplier * 2.5;
                            if (vector2[14] == 3)
                                multiplier = multiplier * 4;
                        }
                    }
                    Castig = Castig + multiplier;
                }
                //linia4
                if (vector2[0] == 3 && vector2[6] == 3)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza;
                    if (vector2[12] == 3)
                    {
                        multiplier = multiplier * 4;
                        if (vector2[8] == 3)
                        {
                            multiplier = multiplier * 2.5;
                            if (vector2[4] == 3)
                                multiplier = multiplier * 4;
                        }
                    }
                    Castig = Castig + multiplier;
                }
                //linia5
                if (vector2[10] == 3 && vector2[6] == 3)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza;
                    if (vector2[2] == 3)
                    {
                        multiplier = multiplier * 4;
                        if (vector2[8] == 3)
                        {
                            multiplier = multiplier * 2.5;
                            if (vector2[14] == 3)
                                multiplier = multiplier * 4;
                        }
                    }
                    Castig = Castig + multiplier;
                }
                //seven
                //linia1
                if (vector2[0] == 1 && vector2[1] == 1 && vector2[2] == 1)
                {
                    double multiplier=1;
                    multiplier = multiplier*Miza * 20;
                    if (vector2[3] == 1)
                    {
                        multiplier = multiplier* 10;
                        if (vector2[4] == 1)
                            multiplier = multiplier * 5;
                    }
                    Castig = Castig + multiplier;
                }
                //linia2
                if (vector2[5] == 1 && vector2[6] == 1 && vector2[7] == 1)
                {
                    double multiplier=1;
                    multiplier = multiplier*Miza * 20;
                    if (vector2[8] == 1)
                    {
                        multiplier = multiplier * 10;
                        if (vector2[9] == 1)
                            multiplier = multiplier * 5;
                    }
                    Castig = Castig + multiplier;
                }
                //linia3
                if (vector2[10] == 1 && vector2[11] == 1 && vector2[12] == 1)
                {
                    double multiplier=1;
                    multiplier = multiplier*Miza * 20;
                    if (vector2[13] == 1)
                    {
                        multiplier = multiplier * 10;
                        if (vector2[14] == 1)
                            multiplier = multiplier * 5;
                    }
                    Castig = Castig +  multiplier;
                }
                //linia4
                if (vector2[0] == 1 && vector2[6] == 1 && vector2[12] == 1)
                {
                    double multiplier=1;
                    multiplier = multiplier*Miza * 20;
                    if (vector2[8] == 1)
                    {
                        multiplier = multiplier * 10;
                        if (vector2[4] == 1)
                            multiplier = multiplier * 5;
                    }
                    Castig = Castig +multiplier;
                }
                //linia5
                if (vector2[10] == 1 && vector2[6] == 1 && vector2[2] == 1)
                {
                    double multiplier=1;
                    multiplier = multiplier*Miza * 20;
                    if (vector2[8] == 1)
                    {
                        multiplier = multiplier * 10;
                        if (vector2[14] == 1)
                            multiplier = multiplier* 5;
                    }
                    Castig = Castig +multiplier;
                }
                //banana
                //linia1
                if (vector2[0] == 2 && vector2[1] == 2 && vector2[2] == 2)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza * 10;
                    if (vector2[3] == 2)
                    {
                        multiplier = multiplier * 5;
                        if (vector2[4] == 2)
                            multiplier = multiplier * 5;
                    }
                    Castig = Castig + multiplier;
                }
                //linia2
                if (vector2[5] == 2 && vector2[6] == 2 && vector2[7] == 2)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza * 10;
                    if (vector2[8] == 2)
                    {
                        multiplier = multiplier * 5;
                        if (vector2[9] == 2)
                            multiplier = multiplier * 5;
                    }
                    Castig = Castig + multiplier;
                }
                //linia3
                if (vector2[10] == 2 && vector2[11] == 2 && vector2[12] == 2)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza * 10;
                    if (vector2[13] == 2)
                    {
                        multiplier = multiplier * 5;
                        if (vector2[14] == 2)
                            multiplier = multiplier * 5;
                    }
                    Castig = Castig + multiplier;
                }
                //linia4
                if (vector2[0] == 2 && vector2[6] == 2 && vector2[12] == 2)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza * 10;
                    if (vector2[8] == 2)
                    {
                        multiplier = multiplier * 5;
                        if (vector2[4] == 2)
                            multiplier = multiplier * 5;
                    }
                    Castig = Castig + multiplier;
                }
                //linia5
                if (vector2[10] == 2 && vector2[6] == 2 && vector2[2] == 2)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza * 10;
                    if (vector2[8] == 2)
                    { 
                        multiplier = multiplier * 5;
                        if (vector2[14] == 2)
                            multiplier = multiplier * 5;
                    }
                    Castig = Castig + multiplier;
                }
                //melon
                //linia1
                if (vector2[0] == 5 && vector2[1] == 5 && vector2[2] == 5)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza * 10;
                    if (vector2[3] == 5)
                    {
                        multiplier = multiplier * 4;
                        if (vector2[4] == 5)
                            multiplier = multiplier * 2.5;
                    }
                    Castig = Castig + multiplier;
                }
                //linia2
                if (vector2[5] == 5 && vector2[6] == 5 && vector2[7] == 5)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza * 10;
                    if (vector2[8] == 5)
                    {
                        multiplier = multiplier * 4;
                        if (vector2[9] == 5)
                            multiplier = multiplier * 2.5;
                    }
                    Castig = Castig + multiplier;
                }
                //linia3
                if (vector2[10] == 5 && vector2[11] == 5 && vector2[12] == 5)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza * 10;
                    if (vector2[13] == 5)
                    {
                        multiplier = multiplier * 4;
                        if (vector2[14] == 5)
                            multiplier = multiplier * 2.5;
                    }
                    Castig = Castig + multiplier;
                }
                //linia4
                if (vector2[0] == 5 && vector2[6] == 5 && vector2[12] == 5)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza * 10;
                    if (vector2[8] == 5)
                    {
                        multiplier = multiplier * 4;
                        if (vector2[4] == 5)
                            multiplier = multiplier * 2.5;
                    }
                    Castig = Castig + multiplier;
                }
                //linia5
                if (vector2[10] == 5 && vector2[6] == 5 && vector2[2] == 5)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza * 10;
                    if (vector2[8] == 5)
                    {
                        multiplier = multiplier * 4;
                        if (vector2[14] == 5)
                            multiplier = multiplier * 2.5;
                    }
                    Castig = Castig + multiplier;
                }
                //grapes
                //linia1
                if (vector2[0] == 4 && vector2[1] == 4 && vector2[2] == 4)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza * 10;
                    if (vector2[3] == 4)
                    {
                        multiplier = multiplier * 4;
                        if (vector2[4] == 4)
                            multiplier = multiplier * 2.5;
                    }
                    Castig = Castig + multiplier;
                }
                //linia2
                if (vector2[5] == 4 && vector2[6] == 4 && vector2[7] == 4)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza * 10;
                    if (vector2[8] == 4)
                    {
                        multiplier = multiplier * 4;
                        if (vector2[9] == 4)
                            multiplier = multiplier * 2.5;
                    }
                    Castig = Castig + multiplier;
                }
                //linia3
                if (vector2[10] == 4 && vector2[11] == 4 && vector2[12] == 4)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza * 10;
                    if (vector2[13] == 4)
                    {
                        multiplier = multiplier * 4;
                        if (vector2[14] == 4)
                            multiplier = multiplier * 2.5;
                    }
                    Castig = Castig + multiplier;
                }
                //linia4
                if (vector2[0] == 4 && vector2[6] == 4 && vector2[12] == 4)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza * 10;
                    if (vector2[8] == 4)
                    {
                        multiplier = multiplier * 4;
                        if (vector2[4] == 4)
                            multiplier = multiplier * 2.5;
                    }
                    Castig = Castig + multiplier;
                }
                //linia5
                if (vector2[10] == 4 && vector2[6] == 4 && vector2[2] == 4)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza * 10;
                    if (vector2[8] == 4)
                    {
                        multiplier = multiplier * 4;
                        if (vector2[14] == 4)
                            multiplier = multiplier * 2.5;
                    }
                    Castig = Castig + multiplier;
                }
                //orange
                //linia1
                if (vector2[0] == 6 && vector2[1] == 6 && vector2[2] == 6)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza * 4;
                    if (vector2[3] == 6)
                    {
                        multiplier = multiplier * 2.5;
                        if (vector2[4] == 6)
                            multiplier = multiplier * 4;
                    }
                    Castig = Castig + multiplier;
                }
                //linia2
                if (vector2[5] == 6 && vector2[6] == 6 && vector2[7] == 6)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza * 4;
                    if (vector2[8] == 6)
                    {
                        multiplier = multiplier * 2.5;
                        if (vector2[9] == 6)
                            multiplier = multiplier * 4;
                    }
                    Castig = Castig + multiplier;
                }
                //linia3
                if (vector2[10] == 6 && vector2[11] == 6 && vector2[12] == 6)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza * 4;
                    if (vector2[13] == 6)
                    {
                        multiplier = multiplier * 2.5;
                        if (vector2[14] == 6)
                            multiplier = multiplier * 4;
                    }
                    Castig = Castig + multiplier;
                }
                //linia4
                if (vector2[0] == 6 && vector2[6] == 6 && vector2[12] == 6)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza * 4;
                    if (vector2[8] == 6)
                    {
                        multiplier = multiplier * 2.5;
                        if (vector2[4] == 6)
                            multiplier = multiplier * 4;
                    }
                    Castig = Castig + multiplier;
                }
                //linia5
                if (vector2[10] == 6 && vector2[6] == 6 && vector2[2] == 6)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza * 4;
                    if (vector2[8] == 6)
                    {
                        multiplier = multiplier * 2.5;
                        if (vector2[14] == 6)
                            multiplier = multiplier * 4;
                    }
                    Castig = Castig + multiplier;
                }
                //plums
                //linia1
                if (vector2[0] == 7 && vector2[1] == 7 && vector2[2] == 7)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza * 4;
                    if (vector2[3] == 7)
                    {
                        multiplier = multiplier * 2.5;
                        if (vector2[4] == 7)
                            multiplier = multiplier * 4;
                    }
                    Castig = Castig + multiplier;
                }
                //linia2
                if (vector2[5] == 7 && vector2[6] == 7 && vector2[7] == 7)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza * 4;
                    if (vector2[8] == 7)
                    {
                        multiplier = multiplier * 2.5;
                        if (vector2[9] == 7)
                            multiplier = multiplier * 4;
                    }
                    Castig = Castig + multiplier;
                }
                //linia3
                if (vector2[10] == 7 && vector2[11] == 7 && vector2[12] == 7)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza * 4;
                    if (vector2[13] == 7)
                    {
                        multiplier = multiplier * 2.5;
                        if (vector2[14] == 7)
                            multiplier = multiplier * 4;
                    }
                    Castig = Castig + multiplier;
                }
                //linia4
                if (vector2[0] == 7 && vector2[6] == 7 && vector2[12] == 7)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza * 4;
                    if (vector2[8] == 7)
                    {
                        multiplier = multiplier * 2.5;
                        if (vector2[4] == 7)
                            multiplier = multiplier * 4;
                    }
                    Castig = Castig + multiplier;
                }
                //linia5
                if (vector2[10] == 7 && vector2[6] == 7 && vector2[2] == 7)
                {
                    double multiplier = 1;
                    multiplier = multiplier * Miza * 4;
                    if (vector2[8] == 7)
                    {
                        multiplier = multiplier * 2.5;
                        if (vector2[14] == 7)
                            multiplier = multiplier * 4;
                    }
                    Castig = Castig + multiplier;
                }
                //stars
                int nr = 0;
                for (int i = 0; i < 15; i++)
                    if (vector2[i] == 8)
                        nr++;
                if (nr >= 5)
                    Castig = Castig + Miza * 50;
                else if (nr == 4)
                    Castig = Castig + Miza * 10;
                else if (nr == 3)
                    Castig = Castig + Miza * 2;

                Sold = Sold + Castig;
                CASTIG = Castig;
                tb_sold.Clear();
                tb_sold.Text = Convert.ToString(Sold);
                tb_castig.Clear();
                tb_castig.Text= Convert.ToString(Castig);
            }
            else
            {
                
                MessageBox.Show("Sold insuficient");
            }

            // string docPath =
            //   Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            // using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Sold.txt")))
            //{
            //  outputFile.WriteLine(Sold);

            //  }
            OleDbConnection conexiune = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlayersDB.accdb");
            conexiune.Open();
            OleDbCommand comanda = new OleDbCommand();
            int sold = Convert.ToInt32(Sold);
            comanda.Connection = conexiune;
            comanda.CommandText = "UPDATE Players SET Sold="+sold+" where Player='"+player+"'";
            comanda.ExecuteNonQuery();
            conexiune.Close();
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            TabelPlati tb = new TabelPlati(tb_miza.Text);
            tb.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CASTIG > 0)
            {
                Sold = Convert.ToInt32(tb_sold.Text) - Convert.ToInt32(tb_castig.Text);
                tb_sold.Text = Convert.ToString(Sold);
                Dublaj db = new Dublaj(tb_castig.Text);
                db.ShowDialog();
                CASTIG = db.suma;
                tb_castig.Text = CASTIG.ToString();
                Sold = Sold + CASTIG;
                tb_sold.Text = Sold.ToString();
                OleDbConnection conexiune = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlayersDB.accdb");
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                int sold = Convert.ToInt32(Sold);
                comanda.Connection = conexiune;
                comanda.CommandText = "UPDATE Players SET Sold=" + sold + " where Player='" + player + "'";
                comanda.ExecuteNonQuery();
                conexiune.Close();
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {

            button1.PerformClick();

        }

        private void tb_miza_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1_Click(sender, e);
            if (Miza > Sold)
            {
                auto = "off";
                timer1.Stop();
                button1.Enabled = true;
                button3.Enabled = true;
                tb_miza.Enabled = true;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (auto == "off")
            {
                auto = "on";
                timer1.Start();
                button1.Enabled = false;
                button3.Enabled = false;
                tb_miza.Enabled = false;
                
            }
            else
            {
                auto = "off";
                button1.Enabled = true;
                button3.Enabled = true;
                tb_miza.Enabled = true;
                timer1.Stop();
                
            }
        }
    }
}
