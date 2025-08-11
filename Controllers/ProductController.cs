using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ProductService.Entities;
using ProductService.Models;
using ProductService.Services;

namespace ProductService.Controllers;


[ApiController]
[Authorize]
[Route("api/product")]
public class ProductController : ControllerBase
{

    private readonly IProductServiceRepository _productServiceRepository;
    private readonly IMapper _mapper;

    public ProductController(IProductServiceRepository productRepository, IMapper mapper)
    {
        _productServiceRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }




    [HttpGet("getall")]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
    {
        var productEntities = await _productServiceRepository.GetProductsAsync();
        return Ok(_mapper.Map<IEnumerable<ProductwithoutVariantDTO>>(productEntities));
    }




    //In here we return Task<IActionResult> instead of Task<ActionResult<ProductDTO>>
    //beacuse depending on the condition it may return a normal action result or action result with ProductDTO

    [HttpGet("{productId}", Name = "GetProduct")]
    public async Task<IActionResult> GetOneProduct(int productId)
    {

        //following code is only written to test getting data from jwt token claims
        //var userName = User.Claims.FirstOrDefault(c => c.Type == "user_name")?.Value;

        //if(userName != "Povi")
        //{
        //    return Forbid();
        //}


        var productEntity = await _productServiceRepository.GetProductAsync(productId);
        if (productEntity == null )
        {
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<ProductDTO>(productEntity));
        }
    }


    [HttpGet("check/{productId}")]
    public async Task<ActionResult<bool>> CheckIfProductExist(int productId)
    {
        return Ok(await _productServiceRepository.CheckProductExistsAsync(productId));
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(ProductCreateDTO productInfo)
    {
        var ProductToCreate = _mapper.Map<Entities.Product>(productInfo);

         _productServiceRepository.CreateProduct(ProductToCreate);
        await _productServiceRepository.SaveChangesAsync();

        var ProductToOutput = _mapper.Map<ProductDTO>(ProductToCreate);
        return CreatedAtRoute("GetProduct",
            new
            {
                productId = ProductToOutput.Id
            },
            ProductToOutput);
    }


    [HttpPut]
    public async Task<ActionResult<Product>> UpdateProduct(ProductUpdateDTO productInfo)
    {

        if (!await _productServiceRepository.CheckProductExistsAsync(productInfo.Id))
        {
            return NotFound();
        }


        var ProductToUpdate = _mapper.Map<Entities.Product>(productInfo);
        _productServiceRepository.UpdateProduct(ProductToUpdate);
        await _productServiceRepository.SaveChangesAsync();

        var ProductToOutput = _mapper.Map<ProductDTO>(ProductToUpdate);
        return CreatedAtRoute("GetProduct",
            new
            {
                productId = ProductToOutput.Id
            },
            ProductToOutput);
    }

    [HttpDelete("{productId}")]
    public async Task<ActionResult> DeleteProduct(int productId)
    {
        if(!await _productServiceRepository.CheckProductExistsAsync(productId))
        {
            return NotFound();
        }

        var productToDelete = await _productServiceRepository.GetProductAsync(productId);
        if(productToDelete == null)
        {
            return NotFound();
        }

        _productServiceRepository.DeleteProduct(productToDelete);
        await _productServiceRepository.SaveChangesAsync();

        return NoContent();

    }



}

