using Microsoft.AspNetCore.Mvc;
using PaymentShippingAPI.Model;
using PaymentShippingAPI.Service;
using PaymentShippingAPI.Data;

namespace PaymentShippingAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly ServiceB userservice = new ServiceB();
        private readonly RepData userrepo = new RepData();

        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] InfoM user)
        {
            string result = userservice.Reguser(user);

            if (result.StartsWith("Welcome"))
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public ActionResult GetUserById(int id)
        {
            var user = userrepo.getUserById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] InfoM user)
        {
            userrepo.updateUser(id, user);
            return Ok("User updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            userrepo.deleteUser(id);
            return Ok("User deleted successfully.");
        }
    }
}