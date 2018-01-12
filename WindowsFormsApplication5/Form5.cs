using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication5
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        connection newcon = new connection();
        SqlCommand comn = new SqlCommand();
        private void button1_Click(object sender, EventArgs e)
        {
          
          
            SqlDataAdapter sqa = new SqlDataAdapter("select Pavadinimas,Autorius,Kiekis from Knygos where Pavadinimas= '" + textBox1.Text + "' and Autorius= '" + textBox2.Text + "'", connection.conn);
            DataTable xd = new DataTable();
            sqa.Fill(xd);
            if (xd.Rows.Count == 1)
            {
                
                MessageBox.Show("Papildyta");
                
            }
            else
            {
             MessageBox.Show("Tokios knygos nera");
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            newcon.connectionString();
        }
    }
}
