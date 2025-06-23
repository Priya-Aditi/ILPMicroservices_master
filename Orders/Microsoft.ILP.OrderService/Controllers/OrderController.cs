using Microsoft.AspNetCore.Mvc;
using Microsoft.ILP.OrderBusiness.Interfaces;
using Microsoft.ILP.OrderRepository.Models;

namespace Microsoft.ILP.OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetAll()
        {
            return Ok(_service.GetAllOrders());
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetById(int id)
        {
            var order = _service.GetOrderById(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Order order)
        {
            _service.CreateOrder(order);
            return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Order order)
        {
            var existing = _service.GetOrderById(id);
            if (existing == null) return NotFound();
            order.Id = id;
            _service.UpdateOrder(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _service.GetOrderById(id);
            if (existing == null) return NotFound();
            _service.DeleteOrder(id);
            return NoContent();
        }
    }
}
