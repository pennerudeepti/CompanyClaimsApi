using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompanyClaimApi.Data;
using CompanyClaimApi.Models;

namespace CompanyClaimApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private readonly CompanyClaimContext _context;
       
        public ClaimController(CompanyClaimContext context)
        {
            _context = context;
        }

        //In memory Database Get method to get claim by id. Use this in memory db method after creating claim using post method
        // GET: api/Claims/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Claim>> GetClaim(int id)
        {
            if (_context.Claim == null)
            {
                return NotFound();
            }
            var claim = await _context.Claim.FindAsync(id);

            if (claim == null)
            {
                return NotFound();
            }

            return claim;
        }

        //In memory Database post api method (To create new claim) Create claim using this method. We can use swagger to create claim.
        // POST: api/Claims
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Claim>> PostClaim(Claim claim)
        {
            if (_context.Claim == null)
            {
                return Problem("Entity set 'CompanyClaimContext.Claims' is null.");
            }

            _context.Claim.Add(claim);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClaim), new { id = claim.ClaimId }, claim);
        }

        //In memory Database put api method (To update claim data)
        // PUT: api/Claims/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClaim(int id, Claim claim)
        {
            if (id != claim.ClaimId)
            {
                return BadRequest();
            }

            _context.Entry(claim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClaimExists(id))
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

        private bool ClaimExists(int id)
        {
            return (_context.Claim?.Any(e => e.ClaimId == id)).GetValueOrDefault();
        }
    }
}

