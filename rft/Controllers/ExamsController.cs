using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rft.Data;
using rft.Models;
using rft.Repositories.ExamRepository;

namespace rft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamRepository examRepository;

        public ExamsController(IExamRepository examRepository)
        {
            this.examRepository= examRepository;
        }

        // GET: api/Exams
        [HttpGet]
        public async Task<ActionResult> GetExams()
        {
            try
            {
                var result = examRepository.Get();
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/Exams/5
        [HttpGet("{examId}")]
        public async Task<ActionResult<Exam>> GetExam(int examId)
        {
            /*
            if (_context.Exams == null)
            {
                return NotFound();
            }
            var exam = await _context.Exams.FindAsync(examId);

            if (exam == null)
            {
                return NotFound();
            }

            return exam;
            */

            return NotFound();
        }

        // PUT: api/Exams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{userId}")]
        public async Task<IActionResult> PutExam(int userId, Exam exam)
        {
            /*
            if (id != exam.Id)
            {
                return BadRequest();
            }

            _context.Entry(exam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            */

            return NoContent();
        }

        // POST: api/Exams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{userId}")]
        public async Task<ActionResult<Exam>> PostExam(Exam exam, int userId)
        {
            //
            /*
             if (_context.Exams == null)
             {
                 return Problem("Entity set 'DataContext.Exams'  is null.");
             }
             _context.Exams.Add(exam);
             await _context.SaveChangesAsync();

             return CreatedAtAction("GetExam", new { id = exam.Id }, exam);
            */
            return NotFound();
        }

        // DELETE: api/Exams/5
        [HttpDelete("{examId}/{userId}")]
        public async Task<IActionResult> DeleteExam(int examId, int userId)
        {
            /*
            if (_context.Exams == null)
            {
                return NotFound();
            }
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }

            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();
            */
            return NoContent();
        }

        private bool ExamExists(int id)
        {
            return true;// (_context.Exams?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
