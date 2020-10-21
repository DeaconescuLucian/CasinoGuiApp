using System;
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
    public partial class Withdraw : Form
    {
        double Sold;
        string player;
        public Withdraw(int s,string p)
        {
            Sold = s;
            player = p;
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new Home((int)Sold, player);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void tb_suma_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlayersDB.accdb");
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;
                if (tb_suma.Text != "")
                {
                    if (Convert.ToInt32(tb_suma.Text) <= Sold)
                    {
                        comanda.CommandText = "UPDATE [Players] SET [Sold]=" + (Sold - Convert.ToInt32(tb_suma.Text) * 0.98) + " where [Player]='" + player + "'";
                        Sold = Sold - Convert.ToInt32(tb_suma.Text) * 0.98;


                        if (tb_nr.Text != "" && tb_tit.Text != "")
                        {
                            if (Convert.ToInt32(tb_suma.Text) > 20)
                            {
                                comanda.ExecuteNonQuery();
                                MessageBox.Show("Retragere efectuata cu succes!");

                            }
                            else
                                MessageBox.Show("Suma minima este de 20.");
                        }
                        else
                            MessageBox.Show("Completati toate campurile");
                    }
                    else
                        MessageBox.Show("Sold insuficient!");
                }
                else
                    MessageBox.Show("Suma minima este de 20.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
                tb_suma.Clear();
                tb_tit.Clear();
                tb_nr.Clear();
            }
        }
    }
}
