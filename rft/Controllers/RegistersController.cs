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
using rft.Repositories.RegisterRepository;

namespace rft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly IRegisterRepository registerRepo;

        public RegistersController(IRegisterRepository registerRepo)
        {
            this.registerRepo = registerRepo;
        }


        // POST: api/Registers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Register>> PostRegister(Register register)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = registerRepo.Post(register);
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

        // DELETE: api/Registers/5
        [HttpDelete("{registId}")]
        public async Task<ActionResult> DeleteRegister(int registId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    registerRepo.Delete(registId);
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

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult> GetRegisters()
        {
            try
            {
                var result = registerRepo.Get();
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
