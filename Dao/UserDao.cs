using AracGaleri.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace AracGaleri
{
    class UserDao
    {
        private User user;
        private List<User> userList;

        public User userCheck(String ad,String soyad,String user_adi,String sifre,String email)
        {
            
            NpgsqlCommand komut = new NpgsqlCommand();
            komut.Connection = Connection.Connect();
            komut.CommandText = "select * from public.user where  user_adi='" + user_adi + "' and sifre='" + sifre + "' and email='" + email + "' ";
            //komut.CommandText = "select * from public.user where ad='"+ad+"' and soyad='"+soyad+ "' and user_adi='"+user_adi+"' and sifre='" + sifre+ "' and email='"+email+"' ";
            Connection.open();
            NpgsqlDataReader dr = komut.ExecuteReader();

            if (dr.HasRows)
            {
                this.user = new User();
                dr.Read();
                this.user.User_adi= dr["user_adi"].ToString();
                this.user.Email = dr["email"].ToString();
                this.user.Sifre = dr["sifre"].ToString();
                Connection.close();
                return this.user;
            }
            else
            {
                Connection.close();
                return null;
            }
            
        }




        internal User User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
            }
        }

        internal List<User> UserList
        {
            get
            {
                return userList;
            }

            set
            {
                userList = value;
            }
        }
    }
}
