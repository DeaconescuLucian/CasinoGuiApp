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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlayersDB.accdb");
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;
                comanda.CommandText = "SELECT Player from Players";
                OleDbDataReader reader = comanda.ExecuteReader();
                int ok = 0;
                while(reader.Read())
                {
                    string Player = reader["Player"].ToString();
                    if (Player == textBox3.Text)
                        ok = 1;
                }
                reader.Close();
                if (ok == 1)
                    MessageBox.Show("Acest jucator exista deja.");
                else if (textBox4.Text == textBox5.Text && ok == 0)
                {
                    comanda.CommandText = "INSERT INTO Players values(?,?,?)";
                    comanda.Parameters.Add("Password", OleDbType.Char).Value = textBox4.Text;
                    comanda.Parameters.Add("Player", OleDbType.Char).Value = textBox3.Text;
                    comanda.Parameters.Add("Sold", OleDbType.Integer).Value = 500;
                    comanda.ExecuteNonQuery();
                    MessageBox.Show("Contul a fost creat cu succes");
                }
                else
                {
                    MessageBox.Show("Parolele nu corespund");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conexiune.Close();
                textBox4.Clear();
                textBox3.Clear();
                textBox5.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PlayersDB.accdb");
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;
                comanda.CommandText = "SELECT * from Players";
                OleDbDataReader reader = comanda.ExecuteReader();
                int ok = 1;
                while (reader.Read())
                {
                    if (reader["Player"].ToString() == textBox1.Text)
                        if (reader["Password"].ToString() == textBox2.Text)
                        {
                            MessageBox.Show("Login succesfull");
                            ok = 0;
                            this.Hide();
                            int ss = Convert.ToInt32(reader["Sold"]);
                            string nume = reader["Player"].ToString();
                            var form2 = new Home(ss,nume);
                            form2.Closed += (s, args) => this.Close();
                            form2.Show();
                        }
                }
                if(ok==1)
                    MessageBox.Show("Utilizatorul nu exista sau parola este gresita.");
                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                textBox1.Clear();
                textBox2.Clear();
                conexiune.Close();
            }
         
        }
    }
}
