using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FormAPI.Models;
using FormAPI.DTO;

namespace FormAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {
        private readonly FormContext _context;

        public FormsController(FormContext context)
        {
            _context = context;
        }

        // GET: api/Forms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormDTO>>> GetForms()
        {
            return await _context.Forms.Select(x => FormToDTO(x)).ToListAsync();
        }

        // GET: api/Forms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FormDTO>> GetForm(int id)
        {
            var form = await _context.Forms.FindAsync(id);

            if (form == null)
            {
                return NotFound();
            }

            return FormToDTO(form);
        }

        // PUT: api/Forms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutForm(int id, Form form)
        {
            if (id != form.Id)
            {
                return BadRequest();
            }

            _context.Entry(form).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Forms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FormDTO>> PostForm(Form form)
        {
            _context.Forms.Add(form);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetForm), new { id = form.Id }, FormToDTO(form));
        }

        // DELETE: api/Forms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForm(int id)
        {
            var form = await _context.Forms.FindAsync(id);
            if (form == null)
            {
                return NotFound();
            }

            _context.Forms.Remove(form);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormExists(int id)
        {
            return _context.Forms.Any(e => e.Id == id);
        }

        private static FormDTO FormToDTO(Form form) =>
        new FormDTO
        {
            Id = form.Id,
            Name = form.Name,
        };
    }
}
