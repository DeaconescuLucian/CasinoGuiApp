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
    public partial class Tower : Form
    {
        public int Sold;
        int Miza;
        string player;
        int mod;
        Random rnd = new Random();
        ArrayList buttonList = new ArrayList();
        ArrayList list = new ArrayList();
        Image[] imagini = new Image[2] { global::TheGame.Properties.Resources.TheCoin, global::TheGame.Properties.Resources.NoCoin };
        int[] pozitii = new int[40];
        public Tower(int s, string p,int m)
        {
            player = p;
            Sold = s;
            mod = m;
            InitializeComponent();
            label5.Text = Sold.ToString();
            buttonList.Add(button41);
            buttonList.Add(button42);
            buttonList.Add(button43);
            buttonList.Add(button44);
            buttonList.Add(button45);
            buttonList.Add(button46);
            buttonList.Add(button47);
            buttonList.Add(button48);
            list.Add(button1);
            list.Add(button2);
            list.Add(button3);
            list.Add(button4);
            list.Add(button5);
            list.Add(button6);
            list.Add(button7);
            list.Add(button8);
            list.Add(button9);
            list.Add(button10);
            list.Add(button11);
            list.Add(button12);
            list.Add(button13);
            list.Add(button14);
            list.Add(button15);
            list.Add(button16);
            list.Add(button17);
            list.Add(button18);
            list.Add(button19);
            list.Add(button20);
            list.Add(button21);
            list.Add(button22);
            list.Add(button23);
            list.Add(button24);
            list.Add(button25);
            list.Add(button26);
            list.Add(button27);
            list.Add(button28);
            list.Add(button29);
            list.Add(button30);
            list.Add(button31);
            list.Add(button32);
            list.Add(button33);
            list.Add(button34);
            list.Add(button35);
            list.Add(button36);
            list.Add(button37);
            list.Add(button38);
            list.Add(button39);
            list.Add(button40);
            for (int i = 0; i < list.Count; i++)
            {
                ((Button)list[i]).Enabled = false;
                ((Button)list[i]).Text = "0";
                pozitii[i] = 0;
            }
        }
        private void button49_Click(object sender, EventArgs e)
        {
            buttonList_enable();
            button49.Enabled = false;
            Sold = Sold + Convert.ToInt32(label2.Text);
            label5.Text = Sold.ToString();
            label2.Text = 0.ToString();
            checkBox1.Enabled = true;
            for (int i = 0; i < list.Count; i++)
            {
                ((Button)list[i]).Enabled = false;
                ((Button)list[i]).BackgroundImage = global::TheGame.Properties.Resources.brick;
                ((Button)list[i]).Text = "0";
                pozitii[i] = 0;
            }
            OleDbConnection conexiune = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlayersDB.accdb");
            conexiune.Open();
            OleDbCommand comanda = new OleDbCommand();
            comanda.Connection = conexiune;
            comanda.CommandText = "UPDATE Players set Sold=" + Sold + " where Player='" + player + "'";
            comanda.ExecuteNonQuery();
            conexiune.Close();
        }
        public void generare_noua(object sender,EventArgs e)
        {
            if (checkBox1.Checked == true)
                mod = 1;
            else
                mod = 0;
            for(int i=0;i<list.Count;i++)
            {
                ((Button)list[i]).BackgroundImage = global::TheGame.Properties.Resources.brick;
            }
            buttonList_disable();
            button49.Enabled = true;
            Miza = Convert.ToInt32(((Button)sender).Text);
            ((Button)sender).BackColor = Color.Gold;
            ((Button)sender).ForeColor = Color.Maroon;
            Sold = Sold - Convert.ToInt32(((Button)sender).Text);
            OleDbConnection conexiune = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlayersDB.accdb");
            conexiune.Open();
            OleDbCommand comanda = new OleDbCommand();
            comanda.Connection = conexiune;
            comanda.CommandText = "UPDATE Players set Sold=" + Sold + " where Player='" + player + "'";
            comanda.ExecuteNonQuery();
            conexiune.Close();
            label5.Text = Sold.ToString();
            label2.Text = ((Button)sender).Text;
            genereaza_Pozitii();
            genereza_castiguri();
            first_Line_enable();
            checkBox1.Enabled = false;
        }
        private void button41_Click(object sender, EventArgs e)
        {
            generare_noua(button41, e);
        }

        private void button42_Click(object sender, EventArgs e)
        {
            generare_noua(button42, e);
        }

        private void button43_Click(object sender, EventArgs e)
        {
            generare_noua(button43, e);
        }

        private void button44_Click(object sender, EventArgs e)
        {
            generare_noua(button44, e);
        }

        private void button45_Click(object sender, EventArgs e)
        {
            generare_noua(button45, e);
        }

        private void button46_Click(object sender, EventArgs e)
        {
            generare_noua(button46, e);
        }

        private void button47_Click(object sender, EventArgs e)
        {
            generare_noua(button47, e);
        }

        private void button48_Click(object sender, EventArgs e)
        {
            generare_noua(button48, e);
        }
        public void genereaza_Pozitii()
        {
            if (mod == 0)
            {
                for (int i = 0; i < pozitii.Length; i = i + 4)
                {
                    int nr1 = rnd.Next(4);
                    int nr2 = rnd.Next(4);
                    while (nr1 == nr2)
                        nr2 = rnd.Next(4);
                    pozitii[i + nr1] = 1;
                    pozitii[i + nr2] = 1;

                }
            }
            if (mod == 1)
            {
                for (int i = 0; i < pozitii.Length; i = i + 4)
                {
                    int nr1 = rnd.Next(4);
 
                    pozitii[i + nr1] = 1;


                }
            }
        }
        public void genereza_castiguri()
        {
            if (mod == 0)
            {
                for (int i = 0; i < list.Count; i = i + 4)
                {
                    ((Button)list[i]).Text = (Miza * 2 * Math.Pow(2, i / 4)).ToString();
                    ((Button)list[i + 1]).Text = (Miza * 2 * Math.Pow(2, i / 4)).ToString();
                    ((Button)list[i + 2]).Text = (Miza * 2 * Math.Pow(2, i / 4)).ToString();
                    ((Button)list[i + 3]).Text = (Miza * 2 * Math.Pow(2, i / 4)).ToString();
                }
            }
            else
            {
                for (int i = 0; i < list.Count; i = i + 4)
                {
                    ((Button)list[i]).Text = (Miza * 4 * Math.Pow(4, i / 4)).ToString();
                    ((Button)list[i + 1]).Text = (Miza * 4 * Math.Pow(4, i / 4)).ToString();
                    ((Button)list[i + 2]).Text = (Miza * 4 * Math.Pow(4, i / 4)).ToString();
                    ((Button)list[i + 3]).Text = (Miza * 4 * Math.Pow(4, i / 4)).ToString();
                }
            }
        }
        public void buttonList_enable()
        {
            for (int i = 0; i < buttonList.Count; i++)
            {
                ((Button)buttonList[i]).Enabled = true;
                ((Button)buttonList[i]).BackColor = Color.Maroon;
                ((Button)buttonList[i]).ForeColor = Color.Gold;
            }
        }
        public void buttonList_disable()
        {
            for (int i = 0; i < buttonList.Count; i++)
            {
                ((Button)buttonList[i]).Enabled = false;
                ((Button)buttonList[i]).BackColor = Color.Maroon;
                ((Button)buttonList[i]).ForeColor = Color.Gold;
            }
        }
        public void first_Line_enable()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }
        public void first_Line_disable()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }
        public void first_Line_win()
        {
            if(mod==0)
                label2.Text = (Convert.ToInt32(label2.Text) * 2).ToString();
            else
                label2.Text = (Convert.ToInt32(label2.Text) * 4).ToString();
            first_Line_disable();
            second_Line_enable();
        }
        public void Line_lose()
        {
            label2.Text = 0.ToString();
            for (int i = 0; i < list.Count; i++)
            {
                ((Button)list[i]).Enabled = false;
                button49.Enabled = false;
                if(pozitii[i]==1)
                {
                    ((Button)list[i]).BackgroundImage = imagini[0];
                    ((Button)list[i]).Text = "";
                }
                else
                {
                    ((Button)list[i]).BackgroundImage = imagini[1];
                    ((Button)list[i]).Text = "";
                }
                pozitii[i] = 0;
            }
            buttonList_enable();
            checkBox1.Enabled = true;
        }
        public void second_Line_enable()
        {
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
        }
        public void second_Line_disable()
        {
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
        }
        public void second_Line_win()
        {
            if (mod == 0)
                label2.Text = (Convert.ToInt32(label2.Text) * 2).ToString();
            else
                label2.Text = (Convert.ToInt32(label2.Text) * 4).ToString();
            second_Line_disable();
            third_Line_enable();
        }
        public void third_Line_enable()
        {
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
        }
        public void third_Line_disable()
        {
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = false;
        }
        public void third_Line_win()
        {
            if (mod == 0)
                label2.Text = (Convert.ToInt32(label2.Text) * 2).ToString();
            else
                label2.Text = (Convert.ToInt32(label2.Text) * 4).ToString();
            third_Line_disable();
            fourth_Line_enable();
        }
        public void fourth_Line_enable()
        {
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
        }
        public void fourth_Line_disable()
        {
            button13.Enabled = false;
            button14.Enabled = false;
            button15.Enabled = false;
            button16.Enabled = false;
        }
        public void fourth_Line_win()
        {
            if (mod == 0)
                label2.Text = (Convert.ToInt32(label2.Text) * 2).ToString();
            else
                label2.Text = (Convert.ToInt32(label2.Text) * 4).ToString();
            fourth_Line_disable();
            fifth_Line_enable();
        }
        public void fifth_Line_enable()
        {
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;
        }
        public void fifth_Line_disable()
        {
            button17.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;
            button20.Enabled = false;
        }
        public void fifth_Line_win()
        {
            if (mod == 0)
                label2.Text = (Convert.ToInt32(label2.Text) * 2).ToString();
            else
                label2.Text = (Convert.ToInt32(label2.Text) * 4).ToString();
            fifth_Line_disable();
            sixth_Line_enable();
        }
        public void sixth_Line_enable()
        {
            button21.Enabled = true;
            button22.Enabled = true;
            button23.Enabled = true;
            button24.Enabled = true;
        }
        public void sixth_Line_disable()
        {
            button21.Enabled = false;
            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
        }
        public void sixth_Line_win()
        {
            if (mod == 0)
                label2.Text = (Convert.ToInt32(label2.Text) * 2).ToString();
            else
                label2.Text = (Convert.ToInt32(label2.Text) * 4).ToString();
            sixth_Line_disable();
            seventh_Line_enable();
        }
        public void seventh_Line_enable()
        {
            button25.Enabled = true;
            button26.Enabled = true;
            button27.Enabled = true;
            button28.Enabled = true;
        }
        public void seventh_Line_disable()
        {
            button25.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;
        }
        public void seventh_Line_win()
        {
            if (mod == 0)
                label2.Text = (Convert.ToInt32(label2.Text) * 2).ToString();
            else
                label2.Text = (Convert.ToInt32(label2.Text) * 4).ToString();
            seventh_Line_disable();
            eighth_Line_enable();
        }
        public void eighth_Line_enable()
        {
            button29.Enabled = true;
            button30.Enabled = true;
            button31.Enabled = true;
            button32.Enabled = true;
        }
        public void eighth_Line_disable()
        {
            button29.Enabled = false;
            button30.Enabled = false;
            button31.Enabled = false;
            button32.Enabled = false;
        }
        public void eighth_Line_win()
        {
            if (mod == 0)
                label2.Text = (Convert.ToInt32(label2.Text) * 2).ToString();
            else
                label2.Text = (Convert.ToInt32(label2.Text) * 4).ToString();
            eighth_Line_disable();
            nineth_Line_enable();
        }
        public void nineth_Line_enable()
        {
            button33.Enabled = true;
            button34.Enabled = true;
            button35.Enabled = true;
            button36.Enabled = true;
        }
        public void nineth_Line_disable()
        {
            button33.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
        }
        public void nineth_Line_win()
        {
            if (mod == 0)
                label2.Text = (Convert.ToInt32(label2.Text) * 2).ToString();
            else
                label2.Text = (Convert.ToInt32(label2.Text) * 4).ToString();
            nineth_Line_disable();
            tenth_Line_enable();
        }
        public void tenth_Line_enable()
        {
            button37.Enabled = true;
            button38.Enabled = true;
            button39.Enabled = true;
            button40.Enabled = true;
        }
        public void tenth_Line_disable()
        {
            button37.Enabled = false;
            button38.Enabled = false;
            button39.Enabled = false;
            button40.Enabled = false;
        }
        public void tenth_Line_win()
        {
            if (mod == 0)
                label2.Text = (Convert.ToInt32(label2.Text) * 2).ToString();
            else
                label2.Text = (Convert.ToInt32(label2.Text) * 4).ToString();
            tenth_Line_disable();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (pozitii[0] == 1)
            {
                first_Line_win();
                button1.BackgroundImage = imagini[0];
                button1.Text = "";
            }
            else
                Line_lose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pozitii[1] == 1)
            { first_Line_win(); button2.BackgroundImage = imagini[0];
                button2.Text = "";
            }
            else
                Line_lose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pozitii[2] == 1)
            { first_Line_win(); button3.BackgroundImage = imagini[0];
                button3.Text = "";
            }
            else
                Line_lose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pozitii[3] == 1)
            { first_Line_win(); button4.BackgroundImage = imagini[0]; 
                button4.Text = "";
            }
            else
                Line_lose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (pozitii[4] == 1)
            { second_Line_win();
                button5.BackgroundImage = imagini[0];
                button5.Text = "";
            }
            else
                Line_lose();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (pozitii[5] == 1)
            {
                second_Line_win();
                button6.BackgroundImage = imagini[0];
                button6.Text = "";
            }
            else
                Line_lose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (pozitii[6] == 1)
            {
                second_Line_win();
                button7.BackgroundImage = imagini[0];
                button7.Text = "";
            }
            else
                Line_lose();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (pozitii[7] == 1)
            {
                second_Line_win();
                button8.BackgroundImage = imagini[0];
                button8.Text = "";
            }
            else
                Line_lose();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (pozitii[8] == 1)
            {
                third_Line_win();
                button9.BackgroundImage = imagini[0];
                button9.Text = "";
            }
            else
                Line_lose();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (pozitii[9] == 1)
            {
                third_Line_win();
                button10.BackgroundImage = imagini[0];
                button10.Text = "";
            }
            else
                Line_lose();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (pozitii[10] == 1)
            {
                third_Line_win();
                button11.BackgroundImage = imagini[0];
                button11.Text = "";
            }
            else
                Line_lose();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (pozitii[11] == 1)
            {
                third_Line_win();
                button12.BackgroundImage = imagini[0];
                button12.Text = "";
            }
            else
                Line_lose();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (pozitii[12] == 1)
            {
                fourth_Line_win();
                button13.BackgroundImage = imagini[0];
                button13.Text = "";
            }
            else
                Line_lose();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (pozitii[13] == 1)
            {
                fourth_Line_win();
                button14.BackgroundImage = imagini[0];
                button14.Text = "";
            }
            else
                Line_lose();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (pozitii[14] == 1)
            {
                fourth_Line_win();
                button15.BackgroundImage = imagini[0];
                button15.Text = "";
            }
            else
                Line_lose();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (pozitii[15] == 1)
            {
                fourth_Line_win();
                button16.BackgroundImage = imagini[0];
                button16.Text = "";
            }
            else
                Line_lose();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (pozitii[16] == 1)
            {
                fifth_Line_win();
                button17.BackgroundImage = imagini[0];
                button17.Text = "";
            }
            else
                Line_lose();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (pozitii[17] == 1)
            {
                fifth_Line_win();
                button18.BackgroundImage = imagini[0];
                button18.Text = "";
            }
            else
                Line_lose();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (pozitii[18] == 1)
            {
                fifth_Line_win();
                button19.BackgroundImage = imagini[0];
                button19.Text = "";
            }
            else
                Line_lose();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (pozitii[19] == 1)
            {
                fifth_Line_win();
                button20.BackgroundImage = imagini[0];
                button20.Text = "";
            }
            else
                Line_lose();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (pozitii[20] == 1)
            {
                sixth_Line_win();
                button21.BackgroundImage = imagini[0];
                button21.Text = "";
            }
            else
                Line_lose();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (pozitii[21] == 1)
            {
                sixth_Line_win();
                button22.BackgroundImage = imagini[0];
                button22.Text = "";
            }
            else
                Line_lose();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (pozitii[22] == 1)
            {
                sixth_Line_win();
                button23.BackgroundImage = imagini[0];
                button23.Text = "";
            }
            else
                Line_lose();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (pozitii[23] == 1)
            {
                sixth_Line_win();
                button24.BackgroundImage = imagini[0];
                button24.Text = "";
            }
            else
                Line_lose();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (pozitii[24] == 1)
            {
                seventh_Line_win();
                button25.BackgroundImage = imagini[0];
                button25.Text = "";
            }
            else
                Line_lose();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (pozitii[25] == 1)
            {
                seventh_Line_win();
                button26.BackgroundImage = imagini[0];
                button26.Text = "";
            }
            else
                Line_lose();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (pozitii[26] == 1)
            {
                seventh_Line_win();
                button27.BackgroundImage = imagini[0];
                button27.Text = "";
            }
            else
                Line_lose();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (pozitii[27] == 1)
            {
                seventh_Line_win();
                button28.BackgroundImage = imagini[0];
                button28.Text = "";
            }
            else
                Line_lose();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (pozitii[28] == 1)
            {
                eighth_Line_win();
                button29.BackgroundImage = imagini[0];
                button29.Text = "";
            }
            else
                Line_lose();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (pozitii[29] == 1)
            {
                eighth_Line_win();
                button30.BackgroundImage = imagini[0];
                button30.Text = "";
            }
            else
                Line_lose();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (pozitii[30] == 1)
            {
                eighth_Line_win();
                button31.BackgroundImage = imagini[0];
                button31.Text = "";
            }
            else
                Line_lose();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (pozitii[31] == 1)
            {
                eighth_Line_win();
                button32.BackgroundImage = imagini[0];
                button32.Text = "";
            }
            else
                Line_lose();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            if (pozitii[32] == 1)
            {
                nineth_Line_win();
                button33.BackgroundImage = imagini[0];
                button33.Text = "";
            }
            else
                Line_lose();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (pozitii[33] == 1)
            {
                nineth_Line_win();
                button34.BackgroundImage = imagini[0];
                button34.Text = "";
            }
            else
                Line_lose();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (pozitii[34] == 1)
            {
                nineth_Line_win();
                button35.BackgroundImage = imagini[0];
                button35.Text = "";
            }
            else
                Line_lose();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (pozitii[35] == 1)
            {
                nineth_Line_win();
                button36.BackgroundImage = imagini[0];
                button36.Text = "";
            }
            else
                Line_lose();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (pozitii[36] == 1)
            {
                tenth_Line_win();
                button37.BackgroundImage = imagini[0];
                button37.Text = "";
            }
            else
                Line_lose();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            if (pozitii[37] == 1)
            {
                tenth_Line_win();
                button38.BackgroundImage = imagini[0];
                button38.Text = "";
            }
            else
                Line_lose();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            if (pozitii[38] == 1)
            {
                tenth_Line_win();
                button39.BackgroundImage = imagini[0];
                button39.Text = "";
            }
            else
                Line_lose();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            if (pozitii[39] == 1)
            {
                tenth_Line_win();
                button40.BackgroundImage = imagini[0];
                button40.Text = "";
            }
            else
                Line_lose();
        }
    }
}    
    
    
    

