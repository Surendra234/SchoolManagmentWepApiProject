using System;
using System.Xml.Linq;
using SchoolManagmentSystem.Controllers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SchoolManagmentSystem
{
	public class MyMethod
	{

        // Method :- Add Student

        public int AddStudent(Students student, MySqlConnector.MySqlConnection connection)
        {
            MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("sp_add_student", connection);
            try
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@fname", student.fname);
                command.Parameters.AddWithValue("@lname", student.lname);
                command.Parameters.AddWithValue("@gender", student.gender);
                command.Parameters.AddWithValue("@age", student.age);
                command.Parameters.AddWithValue("@contact_no", student.contact_no);
                command.Parameters.AddWithValue("@stud_email", student.stud_email);
                command.Parameters.AddWithValue("@stud_pass", student.stud_pass);

                connection.Open();
                var result = command.ExecuteNonQuery();
                connection.Close();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Method :- Get All Students

        public List<Students> GetAllStudents(string email, string password, MySqlConnector.MySqlConnection connection)
        {
            List<Students> studentsList = new List<Students>();

            MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("sp_get_all_students", connection);

            try
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);

                connection.Open();
                MySqlConnector.MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Students students = new Students();

                    students.stud_ID = Convert.ToInt32(reader["stud_ID"]);
                    students.fname = Convert.ToString(reader["fname"]);
                    students.lname = Convert.ToString(reader["lname"]);
                    students.gender = Convert.ToString(reader["gender"]);
                    students.age = Convert.ToInt32(reader["age"]);
                    students.contact_no = Convert.ToInt32(reader["contact_no"]);
                    students.stud_email = Convert.ToString(reader["stud_email"]);
                    students.stud_pass = Convert.ToString(reader["stud_pass"]);

                    studentsList.Add(students);
                }
                connection.Close();
                return studentsList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Method :- GetStudent By Id

		public List<Students> GetStudent(int id, MySqlConnector.MySqlConnection connection)
		{
            Students students = new Students();
            List<Students> studentsList = new List<Students>();

            MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("sp_get_student_by_studID", connection);
            try
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@_stud_ID", id);

                connection.Open();
                MySqlConnector.MySqlDataReader read = command.ExecuteReader();
                
                read.Read();

                students.stud_ID = Convert.ToInt32(read["stud_ID"]);
                students.fname = Convert.ToString(read["fname"]);
                students.lname = Convert.ToString(read["lname"]);
                students.gender = Convert.ToString(read["gender"]);
                students.age = Convert.ToInt32(read["age"]);
                students.contact_no = Convert.ToInt32(read["contact_no"]);
                students.stud_email = Convert.ToString(read["stud_email"]);
                students.stud_pass = Convert.ToString(read["stud_pass"]);

                studentsList.Add(students);
                connection.Close();
                return studentsList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Method :- Delete Student

        public int DeleteStudent(int id, MySqlConnector.MySqlConnection connection) 
        {
            MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("sp_delete_student", connection);
            try
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@_stud_ID", id);

                connection.Open();
                var result = command.ExecuteNonQuery();
                connection.Close();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Method :- Update Student

        public int UpdateStudent(int id, string name, Students students, MySqlConnector.MySqlConnection connection)
        {
            MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("sp_update_student", connection);

            try
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);

                command.Parameters.AddWithValue("@_fname", students.fname);
                command.Parameters.AddWithValue("@_lname", students.lname);
                command.Parameters.AddWithValue("@_gender", students.gender);
                command.Parameters.AddWithValue("@_age", students.age);
                command.Parameters.AddWithValue("@_contact_no", students.contact_no);
                command.Parameters.AddWithValue("@_stud_email", students.stud_email);
                command.Parameters.AddWithValue("@_stud_pass", students.stud_pass);

                connection.Open();
                var result = command.ExecuteNonQuery();
                connection.Close();

                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
	}
}

