using Microsoft.AspNetCore.Mvc;

namespace NzWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentsController : Controller
    {
       
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studentsNames = new string[] { "Ali", "Veli", "Nazım","Hikmet" };
            return Ok(studentsNames);
        }
        [HttpGet("{name}")]
        public IActionResult GetStudentByName(string name)
        {
            string[] studentsNames = new string[] { "Ali", "Veli", "Nazım", "Hikmet" };
            var student = studentsNames.FirstOrDefault(s => s.Equals(name, StringComparison.OrdinalIgnoreCase));
            var student2 = studentsNames.FirstOrDefault(s => s.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0);


            if (student != null)
            {
                //return Ok(student);
                return Ok(student2);

            }
            else
            {
                return NotFound("Student not found");
            }
        }

    }
}

