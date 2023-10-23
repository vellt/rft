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
        private readonly IExamRepository examRepo;

        public ExamsController(IExamRepository examRepository)
        {
            this.examRepo= examRepository;
        }

        // GET: api/Exams
        [HttpGet]
        public async Task<ActionResult> GetExams()
        {
            try
            {
                var result = examRepo.Get();
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Exams/5
        [HttpGet("{examId}")]
        public async Task<ActionResult<Exam>> GetExam(int examId)
        {
            try
            {
                var result = examRepo.Get(examId);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Exams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{userId}")]
        public async Task<IActionResult> PutExam(Exam exam, int userId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = examRepo.Put(exam, userId);
                    return StatusCode(200, result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Exams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{userId}")]
        public async Task<ActionResult<Exam>> PostExam(Exam exam, int userId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = examRepo.Post(exam, userId);
                    return StatusCode(200, result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Exams/5
        [HttpDelete("{examId}/{userId}")]
        public async Task<IActionResult> DeleteExam(int examId, int userId)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    examRepo.Delete(examId, userId);
                    return StatusCode(200, "deleted");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
