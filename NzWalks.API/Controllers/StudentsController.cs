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
    }
}

