using Microsoft.AspNetCore.Mvc;
using Microsoft.ILP.ProductBusiness.Interfaces;
using Microsoft.ILP.ProductRepository.Models;

namespace Microsoft.ILP.ProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return Ok(_service.GetAllProducts());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _service.GetProductById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            _service.CreateProduct(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Product product)
        {
            var existing = _service.GetProductById(id);
            if (existing == null) return NotFound();
            product.Id = id;
            _service.UpdateProduct(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _service.GetProductById(id);
            if (existing == null) return NotFound();
            _service.DeleteProduct(id);
            return NoContent();
        }
    }
}
