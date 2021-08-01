using StoreApp.Server.Data;
using StoreApp.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Server.Repositories
{
    public class MassiveRepository : IMassiveRepository
    {
        private readonly string StringConnection;

        public MassiveRepository(DataAccess stringConnection)
        {
            StringConnection = stringConnection.ConnectionStringSQL;
        }

        private SqlConnection Connection()
        {
            return new SqlConnection(StringConnection);
        }
        public async Task<IEnumerable<Product>> SeedDatas()
        {
            List<Product> Products = new List<Product>();
            Product product = null;
            SqlConnection sqlConnection = Connection();
            SqlCommand sqlCommand = null;
            SqlDataReader sqlDataReader = null;

            try
            {
                sqlConnection.Open();
                sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "dbo.CargaInicialDatos";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                while (sqlDataReader.Read())
                {
                    product = new Product();
                    product.Id = Convert.ToInt32(sqlDataReader["id_Product"]);
                    product.Nombre = sqlDataReader["nombre"].ToString();
                    Products.Add(product);
                }
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return Products;
        }
        public async Task<IEnumerable<Product>> ListProducts()
        {
            List<Product> products = new List<Product>();
            Product product = null;
            SqlConnection sqlConnection = Connection();
            SqlCommand sqlCommand = null;
            SqlDataReader sqlDataReader = null;

            try
            {
                sqlConnection.Open();
                sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "dbo.ListarProductos";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                while (sqlDataReader.Read())
                {
                    product = new Product();
                    product.Id = Convert.ToInt32(sqlDataReader["id_Product"]);
                    product.Nombre = sqlDataReader["nombre"].ToString();
                    product.Descripcion = sqlDataReader["descripcion"].ToString();
                    product.RutaImagen = sqlDataReader["rutaImagen"].ToString();
                    product.FechaAlta = Convert.ToDateTime(sqlDataReader["fechaAlta"]);

                    if (sqlDataReader["precioVenta"] != null && Convert.ToDouble(sqlDataReader["precioVenta"]) > 0)
                    {
                        product.Precio = new Price();
                        product.Precio.PrecioVenta = Convert.ToDouble(sqlDataReader["precioVenta"]);
                        product.Precio.Id = Convert.ToInt32(sqlDataReader["id_Price"]);
                    }
                    products.Add(product);
                }
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return products;
        }
    }
}
