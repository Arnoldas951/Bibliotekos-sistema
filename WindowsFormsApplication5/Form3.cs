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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        BindingSource bindingSource1 = new BindingSource();
        SqlDataAdapter adapter = new SqlDataAdapter();
 DataTable kk = new DataTable();
        connection newcon = new connection();
        SqlCommand comn = new SqlCommand();
        /// <summary>
        /// uzpildo 2 gridview ir kategoriju lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Form3_Load(object sender, EventArgs e)
        {
            newcon.connectionString();
            //Skolininku sarasas
            SqlCommandBuilder cmd;
            
            
            adapter.SelectCommand = new SqlCommand("select id,KnygosID,VardasPavarde, pdata,gdata from PaimtosKnygos", connection.conn);
            cmd = new SqlCommandBuilder(adapter);
            adapter.Fill(kk);
            newcon.CloseCnn();
 //Kategoriju sarasas
            bindingSource1.DataSource = kk;
            dataGridView1.DataSource = bindingSource1;

            SqlCommand cmd1 = new SqlCommand("select id, Kategorjospav from Kategorijos ", connection.conn);
             BindingSource source = new BindingSource();
          
            SqlDataAdapter dapter = new SqlDataAdapter();
            dapter.SelectCommand = cmd1;
            DataTable zz = new DataTable();
            dapter.Fill(zz);
            source.DataSource = zz;
            listBox1.DataSource = source;
            listBox1.ValueMember = "id";
            listBox1.DisplayMember = "Kategorjospav";
            listBox2.DataSource = source;
            listBox2.DisplayMember = "id";
            listBox2.ValueMember = "id";
            newcon.CloseCnn();
            //Leidyklos



            
            SqlDataAdapter ad = new SqlDataAdapter();
            DataTable z = new DataTable();
            BindingSource bindingSource2 = new BindingSource();
            ad.SelectCommand = new SqlCommand("select Leidyklosid, Email,Telefonas, Adresas from Leidyklos", connection.conn);
            cmd = new SqlCommandBuilder(ad);
            ad.Fill(z);
            newcon.CloseCnn();
            bindingSource2.DataSource = z;
            dataGridView2.DataSource = bindingSource2;


        }

        /// <summary>
        /// Papildo knygų duomenų bazę, jeigu įvedama nauja knyga
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

           
            SqlDataAdapter sqa = new SqlDataAdapter("select * from Knygos where Pavadinimas= '" + textBox1.Text + "' and Autorius= '" + textBox2.Text + "'", connection.conn);
            DataTable xd = new DataTable();
            sqa.Fill(xd);
            if (xd.Rows.Count == 1)
            {
                MessageBox.Show("Tokia knyga jau yra");
            }
            else
            {

               try
               {


                   SqlCommand cmd = new SqlCommand("insert into Knygos(Pavadinimas,Autorius,Kiekis,KategorijosID) values (@Pavadinimas,@Autorius,@Kiekis,@KategorijosID)", connection.conn);

                   cmd.Parameters.AddWithValue("@Pavadinimas", textBox1.Text);
                   cmd.Parameters.AddWithValue("@Autorius", textBox2.Text);
                   cmd.Parameters.AddWithValue("@Kiekis", int.Parse(textBox3.Text));
                     cmd.Parameters.AddWithValue("@KategorijosID", textBox4.Text);
                   // cmd.Parameters.AddWithValue("@KategorijosID",listBox1.SelectedItem);
                    cmd.ExecuteNonQuery();                                             
                   MessageBox.Show("Informacija įrašyta");
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

             
              
        }

        /// <summary>
        /// Atidaro nauja langa kuriame uzpildoma kliento informacija
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {


            //string connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Kompiuteris\Desktop\WindowsFormsApplication5\WindowsFormsApplication5\knygos.mdf; Integrated Security = True; Connect Timeout = 30";
           
            SqlCommand cmd = new SqlCommand("select id,KnygosID,VardasPavarde, pdata,gdata from PaimtosKnygos", connection.conn);
            
            kk.Clear();
           SqlDataAdapter pp = new SqlDataAdapter();
pp.SelectCommand = cmd;
                dataGridView1.DataSource = kk;
            pp.Fill(kk);
            dataGridView1.DataSource = null;
dataGridView1.Refresh();
            dataGridView1.DataSource = kk;
            newcon.CloseCnn();
            
        }
        /// <summary>
        /// atidaro nauja forma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            Form4 o = new Form4();
            o.Show();
        }
        /// <summary>
        /// atnaujina duomenu baze
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {

            adapter.Update((DataTable)bindingSource1.DataSource);
            MessageBox.Show("Grazinimo data įrašyta");
            //ins.ExecuteNonQuery();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 fo = new Form5();
            fo.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //string connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Kompiuteris\Desktop\WindowsFormsApplication5\WindowsFormsApplication5\knygos.mdf; Integrated Security = True; Connect Timeout = 30";
          
            SqlCommand cmd = new SqlCommand("select KnygosID,VardasPavarde,pdata,gdata,id from PaimtosKnygos where VardasPavarde like '" + textBox5.Text + "%'", connection.conn);
            DataTable d = new DataTable();
            try
            {
               
                SqlDataAdapter adapter = new SqlDataAdapter();


                adapter.SelectCommand = cmd;
                adapter.Fill(d);
                dataGridView1.DataSource = d;

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
    }
}
