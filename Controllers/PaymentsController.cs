using Microsoft.AspNetCore.Mvc;
using PaymentShippingAPI.Model;
using PaymentShippingAPI.Service;
using PaymentShippingAPI.Data;

namespace PaymentShippingAPI.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly Payservice payservice = new Payservice();
        private readonly Orderrepo payrepo = new Orderrepo();

        [HttpPost]
        public IActionResult AddPayment([FromBody] payinfo payment)
        {
            string result = payservice.Processpay(payment);

            if (result.Contains("Successful"))
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public ActionResult GetPaymentById(int id)
        {
            var payment = payrepo.paymentById(id);

            if (payment == null)
                return NotFound();

            return Ok(payment);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePayment(int id, [FromBody] payinfo payment)
        {
            payrepo.updatePayment(id, payment);
            return Ok("Payment updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePayment(int id)
        {
            payrepo.deletePayment(id);
            return Ok("Payment deleted successfully.");
        }
    }
}