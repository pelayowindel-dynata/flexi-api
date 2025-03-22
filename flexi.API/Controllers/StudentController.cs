using Microsoft.AspNetCore.Mvc;
using flexi.Entities;
using flexi.Logic;

namespace flexi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentLogic _studentLogic;

    public StudentController(IStudentLogic studentLogic)
    {
        _studentLogic = studentLogic;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        var students = await _studentLogic.GetAllStudents();
        return Ok(students);
    }

    [HttpPost]
    public async Task<IActionResult> AddStudent([FromBody] Student student)
    {
        if (student == null || string.IsNullOrWhiteSpace(student.StudentFirstName) || string.IsNullOrWhiteSpace(student.StudentLastName) || string.IsNullOrWhiteSpace(student.StudentEmail) || string.IsNullOrWhiteSpace(student.StudentPassword))
        {
            return BadRequest("Invalid Student data.");
        }

        await _studentLogic.AddStudent(student);
        return CreatedAtAction(nameof(GetStudents), new { student.StudentFirstName, student.StudentLastName, student.StudentEmail, student.StudentPassword }, student);
    }
}

