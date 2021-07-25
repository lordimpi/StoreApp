using StoreApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Server.Repositories
{
    public interface IMassiveRepository
    {
        public Task<IEnumerable<Product>> SeedDatas();
        public Task<IEnumerable<Product>> ListProducts();

    }
}
