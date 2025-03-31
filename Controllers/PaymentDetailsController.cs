using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mini_app_pay.Models;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private readonly PaymentDetailContext _context;

        public PaymentDetailController(PaymentDetailContext context)
        {
            _context = context;
        }

        // GET: api/PaymentDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetail>>> GetPaymentDetail()
        {
            if (_context.paymentDetails == null)
            {
                return NotFound();
            }
            return await _context.paymentDetails.ToListAsync();
        }

        // GET: api/PaymentDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetail>> GetPaymentDetail(int id)
        {
            if (_context.paymentDetails == null)
            {
                return NotFound();
            }
            var PaymentDetail = await _context.paymentDetails.FindAsync(id);

            if (PaymentDetail == null)
            {
                return NotFound();
            }

            return PaymentDetail;
        }

        // PUT: api/PaymentDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentDetail(int id, PaymentDetail PaymentDetail)
        {
            if (id != PaymentDetail.PaymentDetailId)
            {
                return BadRequest();
            }

            _context.Entry(PaymentDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentDetailExists(id))
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

        // POST: api/PaymentDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentDetail>> PostPaymentDetail(PaymentDetail PaymentDetail)
        {
            if (_context.paymentDetails == null)
            {
                return Problem("Entity set 'PaymentDetailContext.PaymentDetail'  is null.");
            }
            _context.paymentDetails.Add(PaymentDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentDetail", new { id = PaymentDetail.PaymentDetailId }, PaymentDetail);
        }
            
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentDetail(int id)
        {
            if (_context.paymentDetails == null)
            {
                return NotFound();
            }
            var PaymentDetail = await _context.paymentDetails.FindAsync(id);
            if (PaymentDetail == null)
            {
                return NotFound();
            }

            _context.paymentDetails.Remove(PaymentDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentDetailExists(int id)
        {
            return (_context.paymentDetails?.Any(e => e.PaymentDetailId == id)).GetValueOrDefault();
        }
    }
}
