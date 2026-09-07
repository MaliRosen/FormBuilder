using Microsoft.AspNetCore.Mvc;
using ServerApp.DTOs;
using ServerApp.Entities;
using ServerApp.Services;

namespace ServerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormsController : ControllerBase
    {
        private readonly IFormService _formService;

        public FormsController(IFormService formService)
        {
            _formService = formService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormTemplate>>> GetForms()
        {
            var forms = await _formService.GetAllAsync();

            return Ok(forms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FormTemplate>> GetForm(int id)
        {
            var form = await _formService.GetByIdAsync(id);

            if (form == null)
            {
                return NotFound();
            }

            return Ok(form);
        }

        [HttpPost]
        public async Task<ActionResult<FormTemplate>> CreateForm(
            [FromBody] CreateFormDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var form = await _formService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetForm),
                new { id = form.Id },
                form);
        }
    }
}