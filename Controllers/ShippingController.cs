using Microsoft.AspNetCore.Mvc;
using PaymentShippingAPI.Model;
using PaymentShippingAPI.Service;
using PaymentShippingAPI.Data;

namespace PaymentShippingAPI.Controllers
{
    [ApiController]
    [Route("api/shipping")]
    public class ShippingController : ControllerBase
    {
        private readonly Shipservice shipservice = new Shipservice();
        private readonly shippingpath shiprepo = new shippingpath();

        [HttpPost]
        public IActionResult AddShipping([FromBody] shipinfo shipping)
        {
            string result = shipservice.Processship(shipping);

            if (result.Contains("saved"))
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public ActionResult GetShippingById(int id)
        {
            var shipping = shiprepo.shippingById(id);

            if (shipping == null)
                return NotFound();

            return Ok(shipping);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateShipping(int id, [FromBody] shipinfo shipping)
        {
            shiprepo.updateShipping(id, shipping);
            return Ok("Shipping updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShipping(int id)
        {
            shiprepo.deleteShipping(id);
            return Ok("Shipping deleted successfully.");
        }
    }
}