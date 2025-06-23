using Microsoft.AspNetCore.Mvc;
using Microsoft.ILP.UserBusiness.Interfaces;
using Microsoft.ILP.UserRepository.Models;

namespace Microsoft.ILP.UserService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            var users = _service.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            var user = _service.GetUserById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            _service.CreateUser(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] User user)
        {
            var existing = _service.GetUserById(id);
            if (existing == null) return NotFound();
            user.Id = id;
            _service.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _service.GetUserById(id);
            if (existing == null) return NotFound();
            _service.DeleteUser(id);
            return NoContent();
        }
    }
}
