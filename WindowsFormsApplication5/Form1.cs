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
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Užpildo gridview su knygų informacija ir Combobox su kategoriju informacija.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // string connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Vartotojas\Desktop\WindowsFormsApplication5\WindowsFormsApplication5\knygos.mdf";
        connection newcon = new connection();
  SqlCommand comn = new SqlCommand();
        private void Form1_Load(object sender, EventArgs e)
        {
            newcon.connectionString();




          
            //comn.Connection = connection.conn;
            SqlCommand cmd = new SqlCommand("select Knygos.id,Pavadinimas, Autorius,Kiekis, Kategorjospav from Knygos,Kategorijos where Knygos.KategorijosID=Kategorijos.id", connection.conn);
            try
            {
                //conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

              
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                //newcon.CloseCnn();
            }
         
            SqlCommand cmd1 = new SqlCommand("SELECT kategorjospav from Kategorijos", connection.conn);
          

            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                Kategorija.Items.Add(dr["kategorjospav"]);
            }


            newcon.CloseCnn();
        }
        
        
     

       

     /// <summary>
     /// Pasirinkta kategorija iš combobox parodo tik tas knygas kurios atitinka pasirinkta kategorija.
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>

        private void Kategorija_SelectedIndexChanged(object sender, EventArgs e)
        {

            //string connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Kompiuteris\Desktop\WindowsFormsApplication5\WindowsFormsApplication5\knygos.mdf; Integrated Security = True; Connect Timeout = 30";
            comn.Connection = connection.conn;
            //SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("select Knygos.id,Pavadinimas, Autorius,Kiekis, Kategorjospav from Knygos,Kategorijos where Knygos.KategorijosID=Kategorijos.id", connection.conn);
            try
            {
                //conn.Open();
                DataView dv = new DataView(dt);
                if (Kategorija.SelectedItem.ToString() == "Visos knygos")
                {
                    dt.Clear();
                    SqlDataAdapter pp = new SqlDataAdapter();
                    pp.SelectCommand = cmd;
                    dataGridView1.DataSource = dt;
                    pp.Fill(dt);
                    dataGridView1.DataSource = null;
                    dataGridView1.Refresh();
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    dv.RowFilter = string.Format("Kategorjospav like '%{0}%'", Kategorija.SelectedItem);
                    dataGridView1.DataSource = dv;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                newcon.CloseCnn();
            }

        }

        /// <summary>
        /// Paieska pagal knygos pavadinima TextBox1.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            //string connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Kompiuteris\Desktop\WindowsFormsApplication5\WindowsFormsApplication5\knygos.mdf; Integrated Security = True; Connect Timeout = 30";
           
            SqlCommand cmd = new SqlCommand("select Knygos.id,Pavadinimas, Autorius,Kiekis, Kategorjospav from Knygos,Kategorijos where Knygos.KategorijosID=Kategorijos.id AND Pavadinimas like '" + textBox1.Text + "%'", comn.Connection = connection.conn);
            DataTable td = new DataTable();
            try
            {
               
                SqlDataAdapter adapter = new SqlDataAdapter();


                adapter.SelectCommand = cmd;
                adapter.Fill(td);
                dataGridView1.DataSource = td;

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {

                newcon.CloseCnn();
            }
            /*SqlDataAdapter sda = new SqlDataAdapter("SELECT Knygos.id,Pavadinimas, Autorius,Kiekis, KategorijosID from Knygos,Kategorijos where Knygos.KategorijosID=Kategorijos.id AND Pavadinimas like '" + textBox1.Text +"%'",conn);
            DataTable td = new DataTable();
            conn.Open();
            sda.Fill(td);
            dataGridView1.DataSource = td;

            conn.Close();*/



        }
        /// <summary>
        /// Paieska pagal autoriaus varda TextBox2.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //string connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Kompiuteris\Desktop\WindowsFormsApplication5\WindowsFormsApplication5\knygos.mdf; Integrated Security = True; Connect Timeout = 30";
            //SqlConnection conn = new SqlConnection(connString);
            //SqlDataAdapter sda = new SqlDataAdapter("SELECT Knygos.id,Pavadinimas, Autorius,Kiekis, KategorijosID from Knygos,Kategorijos where Knygos.KategorijosID=Kategorijos.id AND Autorius like '" + textBox2.Text + "%'", conn);
            DataTable vv = new DataTable();
            SqlCommand cmd = new SqlCommand("select Knygos.id,Pavadinimas, Autorius,Kiekis, Kategorjospav from Knygos,Kategorijos where Knygos.KategorijosID=Kategorijos.id AND Autorius like '" + textBox2.Text + "%'", comn.Connection = connection.conn);
            
            try
            {
     
                SqlDataAdapter adapter = new SqlDataAdapter();


                adapter.SelectCommand = cmd;
                adapter.Fill(vv);
                dataGridView1.DataSource = vv;

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {

                newcon.CloseCnn();
            }
            /*conn.Open();
            sda.Fill(vv);
            dataGridView1.DataSource = vv;
            conn.Close();*/

        }
        /// <summary>
        /// Išmeta nauja Forma kurioje administratorius gali prisijungti.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 ss = new Form2();
            ss.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }

