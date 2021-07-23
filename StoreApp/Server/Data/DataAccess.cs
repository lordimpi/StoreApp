using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Server.Data
{
    public class DataAccess
    {
        private string connectionStringSQL;

        public string ConnectionStringSQL { get => connectionStringSQL; }

        public DataAccess(string ConnectionSQL)
        {
            this.connectionStringSQL = ConnectionSQL;
        }
    }
}
