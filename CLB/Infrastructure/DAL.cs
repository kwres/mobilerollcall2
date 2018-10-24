using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLB.Infrastructure
{
    public class DAL
    {
        public static MySqlConnection getCn()
        {
            var cn = new MySqlConnection();
            cn.ConnectionString = "Server=94.101.95.50;Database=db028312_82;uid=user028312_82;pwd=123456qQ!;SslMode=None";
            return cn;
        }
    }
}
