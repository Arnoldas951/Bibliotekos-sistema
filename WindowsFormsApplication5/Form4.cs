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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        connection newcon = new connection();
        SqlCommand comn = new SqlCommand();

        private void label2_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// papildo duomenų bazę.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
              

                SqlCommand cmd = new SqlCommand("insert into PaimtosKnygos(KnygosID,VardasPavarde,pdata) values (@KnygosID,@VardasPavarde,@pdata)", connection.conn);

                cmd.Parameters.AddWithValue("@KnygosID", textBox1.Text);
                cmd.Parameters.AddWithValue("@VardasPavarde", textBox2.Text);
                cmd.Parameters.AddWithValue("@pdata", SqlDbType.Date).Value = textBox3.Text;





                cmd.ExecuteNonQuery();
                MessageBox.Show("Informacija įrašyta");
                this.Close();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                newcon.CloseCnn();
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            newcon.connectionString();
        }
    }
}
