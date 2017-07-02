using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Command
    {
        Baglan baglan = new Baglan();
        public SqlCommand command(string sqlCumlesi)
        {
            SqlCommand cmd = new SqlCommand(sqlCumlesi, baglan.baglantiAc());
            return cmd;
        }
            
    }
}
