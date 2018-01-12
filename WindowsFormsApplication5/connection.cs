using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApplication5
{
    class connection
    {
        public static SqlConnection conn = null;

        public void connectionString()
        {
            conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = knygos.mdf vieta čia");

            conn.Open();
        }

        public void CloseCnn()
        {

            conn.Close();
        }
        public SqlConnection Connection { get { return conn; } }
    }
}
