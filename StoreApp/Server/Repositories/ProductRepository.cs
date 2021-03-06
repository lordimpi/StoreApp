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
    public class ProductRepository : IProductRepository
    {
        private readonly string stringConnection;

        public ProductRepository(DataAccess dataAccess)
        {
            this.stringConnection = dataAccess.ConnectionStringSQL;
        }

        public Task<bool> Delet(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Product> Find(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<Product> Save(Product product)
        {
            SqlConnection sqlConnection = Connection();
            SqlCommand sqlCommand = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                sqlConnection.Open();
                sqlCommand = sqlConnection.CreateCommand();
                sqlTransaction = sqlConnection.BeginTransaction();
                sqlCommand.CommandText = "dbo.GuardarProducto";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Transaction = sqlTransaction;

                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.Add("Gnombre", SqlDbType.VarChar, 100).Value = product.Nombre;
                sqlCommand.Parameters.Add("Gdescripcion", SqlDbType.VarChar, 1000).Value = product.Descripcion;
                sqlCommand.Parameters.Add("GrutaImagen", SqlDbType.VarChar, 500).Value = product.RutaImagen;
                sqlCommand.Parameters.Add("GfechaAlta", SqlDbType.DateTime).Value = product.FechaAlta;
                sqlCommand.Parameters.Add("GfechaBaja", SqlDbType.DateTime).Value = product.FechaBaja;
                sqlCommand.Parameters.Add("GprecioVenta", SqlDbType.Float).Value = product.Precio.PrecioVenta;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                if (sqlTransaction != null)
                {
                    sqlTransaction.Rollback();
                }
                throw new Exception($"Se produjo un error al guardas los productos: {ex.Message}");
            }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return product;
        }
        public Task<Product> Update(Product product)
        {
            throw new NotImplementedException();
        }
        private SqlConnection Connection()
        {
            return new SqlConnection(stringConnection);
        }

    }
}
