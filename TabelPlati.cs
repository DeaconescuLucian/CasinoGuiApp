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
    public partial class TabelPlati : Form
    {
        double Miza2;
        public TabelPlati(string m1)
        {

            Miza2 = Convert.ToInt32(m1);
            InitializeComponent();
            label4.Text= Convert.ToString(20 * Miza2);
            label5.Text = Convert.ToString(200 * Miza2);
            label6.Text = Convert.ToString(1000 * Miza2);
            label10.Text = Convert.ToString(2 * Miza2);
            label11.Text = Convert.ToString(10 * Miza2);
            label12.Text = Convert.ToString(50 * Miza2);
            label16.Text = Convert.ToString(10 * Miza2);
            label17.Text = Convert.ToString(50 * Miza2);
            label18.Text = Convert.ToString(250 * Miza2);
            label28.Text = Convert.ToString(4 * Miza2);
            label29.Text = Convert.ToString(10 * Miza2);
            label30.Text = Convert.ToString(40 * Miza2);
            label38.Text = Convert.ToString(Miza2);
            label31.Text = Convert.ToString(10 * Miza2);
            label32.Text = Convert.ToString(40 * Miza2);
            label33.Text = Convert.ToString(100 * Miza2);
            label34.Text = Convert.ToString(4 * Miza2);
            label35.Text = Convert.ToString(10 * Miza2);
            label36.Text = Convert.ToString(40 * Miza2);
            label48.Text = Convert.ToString(10 * Miza2);
            label49.Text = Convert.ToString(40 * Miza2);
            label50.Text = Convert.ToString(100 * Miza2);
            label51.Text = Convert.ToString(4 * Miza2);
            label52.Text = Convert.ToString(10 * Miza2);
            label53.Text = Convert.ToString(40 * Miza2);
            label54.Text = Convert.ToString(4 * Miza2);
            label55.Text = Convert.ToString(10 * Miza2);
            label56.Text = Convert.ToString(40 * Miza2);
        }


    }
}
