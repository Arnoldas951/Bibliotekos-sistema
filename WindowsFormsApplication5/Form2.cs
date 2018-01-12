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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Uždaro mygtuka
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        connection newcon = new connection();
        SqlCommand comn = new SqlCommand();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Patikrina ar Vardas ir slaptažodis yra duomenų bazėje.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void button1_Click(object sender, EventArgs e)
        {

            //string connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Kompiuteris\Desktop\WindowsFormsApplication5\WindowsFormsApplication5\knygos.mdf; Integrated Security = True; Connect Timeout = 30";
          
            SqlDataAdapter sqa = new SqlDataAdapter("select * from Adminai where username= '" + textBox1.Text + "' and password= '" + textBox2.Text + "'", connection.conn);
            DataTable tw = new DataTable();
            sqa.Fill(tw);
            if (tw.Rows.Count == 1)
            {
                this.Hide();
               
                Form3 dd = new Form3();
                dd.Show();

            }
            else
            {
                MessageBox.Show("Bloga prisijungimo informacija");
            }
            newcon.CloseCnn();

          
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            newcon.connectionString();
        }
    }
}
