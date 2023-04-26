using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystem.Data;

namespace SchoolManagmentSystem.Controllers;

[Route(template: "api/")]
public class HomeController : Controller
{
   
    MyMethod method = new MyMethod();

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
        var output = new ResponseModel<Students>();

        try
        {
            var result = method.AddStudent(student, connection);
            if (result > 0)
            {
                output.message = "Student Added successfully";
                output.success = true;
            }
            else
            {
                output.message = "Failed To Added Student details";
                output.success = false;
            }
            return Ok(output);
        }
        catch(Exception ex)
        {
            output.message = ex.Message;
            output.success = false;
            return Ok(output);
        }
    }

    [HttpGet("get_all_students")]
    public IActionResult GetAllStudents([FromHeader] string email, [FromHeader] string password)
    {
        var output = new ResponseModel<Students>();
        try
        {
            var result = method.GetAllStudents(email, password, connection);
            output.message = "Students list find successfully";
            output.success = true;
            output.data = result;
            return Ok(output);
        }
        catch(Exception ex)
        {
            output.message = ex.Message;
            output.success = false;
            return Ok(output);
        }
    }

    // Get Student By Id
    [HttpGet("get_student_by_studID")]
    public IActionResult GetStudentById(int id)
    {
        var output = new ResponseModel<Students>();

        try
        {
            var result = method.GetStudent(id, connection);
            output.message = "Student details find successfully";
            output.success = true;
            output.data = result;
            return Ok(output);
        }
        catch(Exception ex)
        {
            output.message = ex.Message;
            output.success = false;
            return Ok(output);
        }
    }

    // Delete Student
    [HttpPost("delete_student")]
    public IActionResult DeleteStudent(int id)
    {
        var output = new ResponseModel<Students>();
        try
        {
            var result = method.DeleteStudent(id, connection);
            if (result > 0)
            {
                output.message = "Student Details deleted successfully";
                output.success = true;
            }
            else
            {
                output.message = "Failed to delete student";
                output.success = false;
            }
            return Ok(output);
        }
        catch(Exception ex)
        {
            output.message = ex.Message;
            output.success = false;
            return Ok(output);
        }
    }

    [HttpPost("update_student")]
    public IActionResult UpdateStudent(int id, string name, [FromBody] Students students)
    {
        var output = new ResponseModel<Students>();
        try
        {
            var result = method.UpdateStudent(id, name, students, connection);
            if (result > 0)
            {
                output.message = "Student Details update successfully";
                output.success = true;
            }
            else
            {
                output.message = "Failed to update student";
                output.success = true;
            }
            return Ok(result);
        }
        catch(Exception ex)
        {
            output.message = ex.Message;
            output.success = false;
            return Ok(output);
        }
    }
}

