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
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IMassiveRepository massiveRepository;
        public StoreController(IMassiveRepository repository)
        {
            this.massiveRepository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> InitialSeed()
        {
            List<Product> Results = new List<Product>();
            try
            {
                Results = (List<Product>)await massiveRepository.SeedDatas();
            }
            catch (SqlException exc)
            {
                throw new Exception("Se ha producido un error en la carga de datos: " + exc.Message.ToString());
            }
            return Results;
        }
    }
}
