using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Server.Repositories;
using StoreApp.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        [Route("api/GetLastProduct")]
        [HttpGet]
        public async Task<ActionResult<int>> GetLastProduct()
        {
            int Id;
            try
            {
                Product p = await productRepository.GetLastProduct();
                Id = p.Id;
            }
            catch (SqlException exc)
            {
                throw new Exception("Se ha producido un error al obtener el ultimo producto: " + exc.Message.ToString());
            }
            return Id;
        }

        [Route("api/EditProduct")]
        [HttpPut]
        public async Task<ActionResult<Product>> EditProduct(Product product)
        {
            Product p;
            try
            {
                p = await productRepository.Update(product);
            }
            catch (SqlException exc)
            {
                throw new Exception("No se pudo actualizar el producto: " + exc.Message.ToString());
            }
            return p;
        }

        [Route("api/DeletProduct/{id:int}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeletProduct(int id)
        {
            bool result = false;
            try
            {
                result = await productRepository.Delet(id);
            }
            catch (SqlException exc)
            {
                throw new Exception("No se pudo eliminar el producto: " + exc.Message.ToString());
            }
            return result;
        }
    }
}
