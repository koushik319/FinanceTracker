using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinanceTracker.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace FinanceTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ExpensesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ExpensesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Expenses
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Expense>>> GetExpenses()
        //{
        //    if (_context.Expenses == null)
        //    {
        //        return NotFound();
        //    }
        //    return await _context.Expenses.ToListAsync();
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expense>>> GetExpenses([FromQuery] string? date, [FromQuery] int? categoryId, [FromQuery] int? userId)
        {
            if (_context.Expenses == null)
            {
                return NotFound();
            }

            var expensesQuery = _context.Expenses.AsQueryable();

            if (userId.HasValue)
            {
                expensesQuery = expensesQuery.Where(e => e.UserId == userId);
            }

            if (categoryId.HasValue)
            {
                expensesQuery = expensesQuery.Where(e => e.CategoryId == categoryId);
            }

            if (!string.IsNullOrEmpty(date))
            {
                DateTime selectedDate;
                if (DateTime.TryParse(date, out selectedDate))
                {
                    expensesQuery = expensesQuery.Where(e => e.Date.Date == selectedDate.Date);
                }
            }

            return await expensesQuery.ToListAsync();
        }


        // GET: api/Expenses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Expense>> GetExpense(int id)
        {
            if (_context.Expenses == null)
            {
                return NotFound();
            }
            var expense = await _context.Expenses.FindAsync(id);

            if (expense == null)
            {
                return NotFound();
            }

            return expense;
        }

        [HttpGet("GetSkillByUserId/{id}")]
        public async Task<IActionResult> GetSkillByUserId(int id)
        {
            if (_context == null || _context.Expenses == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Database context is unavailable." });
            }

            var exp = await _context.Expenses
                .Where(e => e.UserId == id)
                .Include(s => s.Category)
                .Select(s => new
                {
                    SkillId = s.ExpenseId,
                    Description = s.Description,
                    //ITRoleName = s.ITRole != null ? s.ITRole.RoleName : null,
                    //ExperienceYears = s.ExperienceYears
                })
                .ToListAsync();

            if (!exp.Any())
            {
                return NotFound(new { message = "No expenses found for the given User ID." });
            }

            //return Ok(new { success = true, data = expenses });
            return Ok(exp);
        }


        // PUT: api/Expenses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpense(int id, Expense expense)
        {
            if (id != expense.ExpenseId)
            {
                return BadRequest();
            }

            _context.Entry(expense).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseExists(id))
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

        // POST: api/Expenses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]

        public async Task<ActionResult<Expense>> PostExpense(Expense expense)
        {
            if (_context.Expenses == null)
            {
                return Problem("Entity set 'AppDBContext.Expense'  is null.");
            }
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpense", new { id = expense.ExpenseId }, expense);
        }

        // DELETE: api/Expenses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            if (_context.Expenses == null)
            {
                return NotFound();
            }
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExpenseExists(int id)
        {
            return (_context.Expenses?.Any(e => e.ExpenseId == id)).GetValueOrDefault();
        }
    }
}
