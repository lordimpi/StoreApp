using StoreApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Server.Repositories
{
    public interface IProductRepository 
    {
        public Task<Product> Save(Product product);
        public Task<Product> Update(Product product);
        public Task<Product> Find(int id);
        public Task<Product> GetLastProduct();
        public Task<bool> Delet(int id);

    }
}
