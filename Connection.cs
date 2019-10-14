using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace AracGaleri
{
    public class Connection
    {
        
        private static Connection c = null;
        public static NpgsqlConnection con;

        private Connection () { }
        public static Connection GetInstance()
        {
            if (c == null)
            {
                c = new Connection();
                return c;
            }
            else
            {
                return c;
            }
        }

        private static NpgsqlConnection connect()
        {
            if (con == null)
            {
                con  = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=1234;Database=AracGaleri;");
            }
            return con;
        }

        public static NpgsqlConnection Connect()
        {
            return connect();
        }

        public static void open()
        {
            con.Open();
        }
        public static void close()
        {
            con.Close();
        }

        

    }
}
