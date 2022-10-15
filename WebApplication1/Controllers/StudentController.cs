using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApplication1.DB;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Student>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult GetAllStudents()
        {
            List<Student> students = DataAcessLayer.Instance.GetStudents();

            if (students.Count <= 0)
            {
                return NotFound("No students found");
            } else
            {
                return Ok(DataAcessLayer.Instance.GetStudents());
            }
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Student))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult GetStudentById([FromQuery][Required] int studentId)
        {
            Student student = DataAcessLayer.Instance.GetStudentById(studentId);

            if (student == null)
            {
                return NotFound("Student not found");
            }
            else
            {
                return Ok(DataAcessLayer.Instance.GetStudentById(studentId));
            }
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult CreateStudent([FromBody][Required] Student stud)
        {
            var res = DataAcessLayer.Instance.CreateStudent(stud);

            if (res == "")
            {
                return Ok("Student Created successfully");
            }
            else
            {
                return BadRequest(res);
            }
        }

        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult DeleteStudent([FromQuery][Required] int studentId)
        {
            string res = DataAcessLayer.Instance.DeleteStudent(studentId);
            if (res == "")
            {
                return Ok("Student Deleted successfully");
            }
            else
            {
                return BadRequest(res);
            }
        }

        [HttpPut("changeStudent")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult ChangeStudent([FromBody][Required] Student stud)
        {
        string res = DataAcessLayer.Instance.ChangeStudent(stud);
        if (res == "")
            {
                return Ok("Student changed sccesfully");
            }
        else
            {
                return BadRequest(res);
            }
        
        
        }
        
        [HttpPut("changeStudentAddress")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult ChangeStudentAddress([FromQuery][Required] int studentId, [FromBody][Required] Adresa adresa)
        {
           var res = DataAcessLayer.Instance.ChangeStudentAddress(studentId, adresa);
            if (res == 1)
            {
                return Ok("Student Adress changed sccesfully");
                
            }
            else if (res == 2)
            {
                return Ok("Student Adress created succesfully");
            }
            else
            {
                return BadRequest("Baj van more");
            }
        }

        [HttpDelete("deleteStudentPlus")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult DeleteStudentPlus([FromQuery][Required] int studentId)
        {
            var res = DataAcessLayer.Instance.DeleteStudentPlus(studentId);
            if (res == 1)
            {
                return BadRequest("Error deleting student");
            }
            else
            {
                return Ok("Student deleted");
            }
        }

        [HttpPost("createSubject")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult CreateSubject([FromBody][Required] Subject subject)
        {
            var res = DataAcessLayer.Instance.CreateSubject(subject);

            if(res == "")
            {
                return Ok("Subject succesfully created");
            }
            else
            {
                return BadRequest(res);
            }
        }

        [HttpPatch("addMark")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult AddMark([Required] int studentId, [FromBody][Required] Mark mark)
        {
            var res = DataAcessLayer.Instance.AddMark(studentId, mark);

            if (res == "")
            {
                return Ok("Mark succesfully added");
            }
            else
            {
                return BadRequest(res);
            }
        }
    }
}
