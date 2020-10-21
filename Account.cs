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
    public partial class Account : Form
    {
        string player;
        int Sold;
        public Account(string p,int s)
            
        {
            player = p;
            Sold = s;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlayersDB.accdb");
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;
                comanda.CommandText = "SELECT * from Players where Player='" + player + "'";
                OleDbDataReader reader = comanda.ExecuteReader();
                reader.Read();
                    if (cp.Text == (reader["Password"]).ToString())
                    {
                        reader.Close();
                        if (np.Text == rnp.Text)
                        {
                        string s = "'" + np.Text + "'";
                            comanda.CommandText = "UPDATE [Players] SET [Password]="+s +" where [Player]='" + player + "'";
                            comanda.ExecuteNonQuery();
                            MessageBox.Show("Parola a fost schimbata cu succes");
                        }
                    }
                    else
                    {
                        reader.Close();
                    }
               
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
                cp.Clear();
                np.Clear();
                rnp.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new Home(Sold,player);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlayersDB.accdb");
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;
                string s = "'" + nn.Text + "'";
                comanda.CommandText = "UPDATE [Players] SET [Player]=" + s + " where [Player]='" + player + "'";
                comanda.ExecuteNonQuery();
                MessageBox.Show("Numele a fost schimbat cu succes");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
                nn.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlayersDB.accdb");
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;
                comanda.CommandText = "SELECT * from Players where Player='" + player + "'";
                OleDbDataReader reader = comanda.ExecuteReader();
                reader.Read();
                if (p.Text == reader["Password"].ToString())
                {
                    reader.Close();
                    string s = "'" + player + "'";
                    comanda.CommandText = "DELETE FROM [Players] where [Player]=" + s;
                    comanda.ExecuteNonQuery();
                    MessageBox.Show("Contul a fost sters definitiv.");
                    this.Hide();
                    var form2 = new Login();
                    form2.Closed += (ceva, args) => this.Close();
                    form2.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
                
            }
        }
    }
}
