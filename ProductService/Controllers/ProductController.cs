using Microsoft.AspNetCore.Mvc;
using ProductService.Models;

namespace ProductService.Controllers;


[ApiController]
[Route("api/product")]
public class ProductController : Controller
{
    [HttpGet("getall")]
    public ActionResult<IEnumerable<ProductDTO>> GetProducts()
    {
        return Ok(new ProductDTO(){Name = "Dell XPS", Price = 2500.78F, ProductTag = "P001"});
    }

    [HttpGet("{ProductId}")]
    public ActionResult<ProductDTO> GetOneProduct()
    {
        return Ok(new ProductDTO() { Name = "Dell XPS", Price = 2500.78F, ProductTag = "P001" });
    }

}

