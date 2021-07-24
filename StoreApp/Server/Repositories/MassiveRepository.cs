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
        private string StringConnection;

        public MassiveRepository(DataAccess stringConnection)
        {
            this.StringConnection = stringConnection.ConnectionStringSQL;
        }

        private SqlConnection Connection()
        {
            return new SqlConnection(this.StringConnection);
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
                    product.Id = Convert.ToInt32(sqlDataReader["id"]);
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
    }
}
