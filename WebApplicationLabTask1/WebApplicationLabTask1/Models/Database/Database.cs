using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebApplicationLabTask1.Models.Database
{
    public class Database
    {
        public Logins Logins { get; set; }
        public Departments Departments { get; set; }
        public Students Students { get; set; }

        public Database()
        {
            string connString = @"Data Source=DESKTOP-CLHA1Q5\SQLEXPRESS;Initial Catalog=student;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);

            Logins = new Logins(conn);
            Departments = new Departments(conn);
            Students = new Students(conn);

        }
    }
    
}