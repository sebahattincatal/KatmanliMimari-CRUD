using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Data
{
    public class Baglan
    {
        SqlConnection con = new SqlConnection(@"Server = DESKTOP-DQVSGE0\SQLEXPRESS; Database = Personel; Trusted_Connection=True;");

        public SqlConnection baglantiAc()
        { 
            con.Open();
            return con;
        }

        public SqlConnection baglantiKapat()
        { 
            con.Close();
            return con;
        }
    }
}
