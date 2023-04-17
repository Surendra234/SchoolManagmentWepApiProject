using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystem.Data;
using SchoolManagmentSystem.Models;

namespace SchoolManagmentSystem.Controllers;

[Route(template: "api/")]
public class HomeController : Controller
{
    // Connection String
    MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(connectionString: "Server=localhost;port=3306;Database=SchoolManagmentSystem;user=root;password=root@1234;Persist security Info=true");

    private readonly SchoolManagmentDbContext _dbContext;

    public HomeController(SchoolManagmentDbContext dbContext)
    {
        _dbContext = dbContext;
    }

  
    // Add Student
    [HttpPost("add_student")]
    public IActionResult AddStudent([FromBody] Students student)
    {
        var responce = new ResponseModel<Students>();
        connection.Open();

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

            var result = command.ExecuteNonQuery();

            if (result>0)
            {
                responce.success = true;
                responce.message = "student added successfully";
            }
            else
            { 
                responce.success = false;
                responce.message = "Failed to add student";
                  
            }
            connection.Close();
        }
        catch (Exception ex)
        {
            responce.success = true;
            responce.message = ex.Message;
        }
        return Ok(responce);
    }

    // Get Student By Id
    [HttpGet("get_student_by_studID")]
    public IActionResult GetStudentById(int id)
    {
        ResponseModel<Students> responce = new ResponseModel<Students>();
        connection.Open();

        MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("sp_get_student_by_studID", connection);
        try
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@_stud_ID", id);

            MySqlConnector.MySqlDataReader read = command.ExecuteReader();
            read.Read();
            Students students = new Students();
            List<Students> studentsList = new List<Students>();

            students.stud_ID = Convert.ToInt32(read["stud_ID"]);
            students.fname = Convert.ToString(read["fname"]);
            students.lname = Convert.ToString(read["lname"]);
            students.gender = Convert.ToString(read["gender"]);
            students.age = Convert.ToInt32(read["age"]);
            students.contact_no = Convert.ToInt32(read["contact_no"]);
            students.stud_email = Convert.ToString(read["stud_email"]);
            students.stud_pass = Convert.ToString(read["stud_pass"]);

            studentsList.Add(students);
            if (students.stud_ID == id)
            {
                responce.success = true;
                responce.message = "student find success fully";
                responce.data = studentsList;
                return Ok(responce);
            }
        }
        catch (Exception ex)
        {
            responce.success = false;
            responce.message = ex.Message;
        }

        return Ok(responce);
    }

    // Delete Student

    [HttpDelete("delete_student")]
    public IActionResult DeleteStudent(int id)
    {
        var response = new ResponseModel<Students>();

        connection.Open();
        MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("sp_delete_student", connection);

        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@_stud_ID", id);

        var result = command.ExecuteNonQuery();
        if (result > 0)
        {
            response.success = true;
            response.message = "Student details deleted success fully";
        }
        else
        {
            response.success = false;
            response.message = "faild to delete student details";
        }
        connection.Close();
        return Ok(response);
    }

    [HttpPost("update_student")]
    public IActionResult UpdateStudent(int id, string name, [FromBody] Students students)
    {
        var response = new ResponseModel<Students>();

        connection.Open();
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

            var result = command.ExecuteNonQuery();

            if (result > 0)
            {
                response.success = true;
                response.message = "Student details updated success fully";
            }
            else
            {
                response.success = false;
                response.message = "failed to update student details";
            }
        }
        catch (Exception ex)
        {
            response.success = false;
            response.message = ex.Message;
        }
        connection.Close();
        return Ok(response);
    }
}

