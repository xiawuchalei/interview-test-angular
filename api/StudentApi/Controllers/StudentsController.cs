using StudentApi.Mediatr.Students;
using StudentApi.Models.Students;
using Microsoft.AspNetCore.Cors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    public class StudentsController : ControllerBase
    {
        private IMediator mediator;

        /// <summary>
        /// Gets the Mediator object.
        /// </summary>
        protected IMediator Mediator => mediator ??= (IMediator)HttpContext.RequestServices.GetService(typeof(IMediator))!;

        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets the current students
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Student>> Get()
        {
            var reponse = await Mediator.Send(new GetStudentsRequest());

            return reponse.Students;
        }

        /// <summary>
        /// Adds a new student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }

            var response = await Mediator.Send(new AddStudentRequest { Student = student });
            if (response.Success)
            {
                return CreatedAtAction(nameof(Get), new { email = student.Email }, student);
            }
            return StatusCode(500);
        }

        /// <summary>
        /// Deletes an existing student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }

            var response = await Mediator.Send(new DeleteStudentRequest { Student = student });
            if (response.Success)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
