using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Server.Repositories;
using StoreApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Server.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [Route("api/SaveProduct")]
        [HttpPost]
        public async Task<ActionResult<Product>> SaveProduct(Product product)
        {
            Product p;
            try
            {
                if (product == null)
                {
                    return BadRequest();
                }
                p = await productRepository.Save(product);
            }
            catch (Exception e)
            {
                throw new Exception($"Se produjo un error al guardar el producto: {e.Message}");
            }
            return p;
        }
    }
}
