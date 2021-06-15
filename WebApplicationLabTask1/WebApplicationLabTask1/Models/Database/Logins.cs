using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebApplicationLabTask1.Models.Database
{
    public class Logins
    {
        SqlConnection conn;

        public Logins(SqlConnection conn)
        {
            this.conn = conn;
        }

        public Login ValidateLogin(Login l)
        {
            Login login = null;
            string query = "select * from Admin Where UserName = @UserName and Password = @Password";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@UserName", l.UserName);
            cmd.Parameters.AddWithValue("@Password", l.Password);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                login = new Login()
                {
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                    Password = reader.GetString(reader.GetOrdinal("Password"))
                };
            }
            conn.Close();
            return login;
        }
    }
}