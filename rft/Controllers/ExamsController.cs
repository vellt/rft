﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rft.Data;
using rft.Models;

namespace rft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly DataContext _context;

        public ExamsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Exams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exam>>> GetExams()
        {
          if (_context.Exams == null)
          {
              return NotFound();
          }
            return await _context.Exams.ToListAsync();
        }

        // GET: api/Exams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exam>> GetExam(int id)
        {
          if (_context.Exams == null)
          {
              return NotFound();
          }
            var exam = await _context.Exams.FindAsync(id);

            if (exam == null)
            {
                return NotFound();
            }

            return exam;
        }

        // PUT: api/Exams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExam(int id, Exam exam)
        {
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

            return NoContent();
        }

        // POST: api/Exams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Exam>> PostExam(Exam exam)
        {
          if (_context.Exams == null)
          {
              return Problem("Entity set 'DataContext.Exams'  is null.");
          }
            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExam", new { id = exam.Id }, exam);
        }

        // DELETE: api/Exams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam(int id)
        {
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

            return NoContent();
        }

        private bool ExamExists(int id)
        {
            return (_context.Exams?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
