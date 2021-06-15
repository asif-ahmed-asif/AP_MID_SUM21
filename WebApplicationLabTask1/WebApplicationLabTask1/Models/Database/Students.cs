using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationLabTask1.Models.Database
{
    public class Students
    {
        SqlConnection conn;

        public Students(SqlConnection conn)
        {
            this.conn = conn;
        }

        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            string query = "SELECT Student.*, Department.DeptName FROM Student INNER JOIN Department ON Student.DeptId = Department.DeptId";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Student student = new Student()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    DOB = reader.GetDateTime(reader.GetOrdinal("DOB")),
                    Credit = reader.GetInt32(reader.GetOrdinal("Credit")),
                    CGPA = reader.GetDouble(reader.GetOrdinal("CGPA")),
                    DeptId = reader.GetString(reader.GetOrdinal("DeptId")),
                    DeptName = reader.GetString(reader.GetOrdinal("DeptName")),
                };
                students.Add(student);
            }
            conn.Close();
            return students;
        }

        public void Insert(Student s)
        {
            string query = "Insert into Student values(@Name,@DOB,@Credit,@CGPA,@DeptId)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", s.Name);
            cmd.Parameters.AddWithValue("@DOB", s.DOB);
            cmd.Parameters.AddWithValue("@Credit", s.Credit);
            cmd.Parameters.AddWithValue("@CGPA", s.CGPA);
            cmd.Parameters.AddWithValue("@DeptId", s.DeptId);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public Student Get(int id)
        {
            Student student = null;
            string query = "SELECT Student.*, Department.DeptName FROM Student INNER JOIN Department ON Student.DeptId = Department.DeptId Where Id = @Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                student = new Student()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    DOB = reader.GetDateTime(reader.GetOrdinal("DOB")),
                    Credit = reader.GetInt32(reader.GetOrdinal("Credit")),
                    CGPA = reader.GetDouble(reader.GetOrdinal("CGPA")),
                    DeptId = reader.GetString(reader.GetOrdinal("DeptId")),
                    DeptName = reader.GetString(reader.GetOrdinal("DeptName")),
                };
            }
            conn.Close();
            return student;
        }

        public void Update(Student s)
        {
            string query = "UPDATE Student SET Name = @Name, DOB = @DOB, Credit = @Credit, CGPA = @CGPA, DeptId = @DeptId Where Id = @Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", s.Name);
            cmd.Parameters.AddWithValue("@DOB", s.DOB);
            cmd.Parameters.AddWithValue("@Credit", s.Credit);
            cmd.Parameters.AddWithValue("@CGPA", s.CGPA);
            cmd.Parameters.AddWithValue("@DeptId", s.DeptId);
            cmd.Parameters.AddWithValue("@Id", s.Id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Student Where Id = @Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}