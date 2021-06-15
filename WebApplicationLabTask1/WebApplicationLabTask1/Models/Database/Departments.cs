using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationLabTask1.Models.Database
{
    public class Departments
    {
        SqlConnection conn;

        public Departments(SqlConnection conn)
        {
            this.conn = conn;
        }
        public List<Department> GetAll()
        {
            List<Department> departments = new List<Department>();
            string query = "SELECT * FROM Department";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Department department = new Department()
                {
                    DeptId = reader.GetString(reader.GetOrdinal("DeptId")),
                    DeptName = reader.GetString(reader.GetOrdinal("DeptName")),
                };
                departments.Add(department);
            }
            conn.Close();
            return departments;
        }
    }
}