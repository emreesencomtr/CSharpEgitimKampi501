using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi501.ConnectionString
{
    public static class DatabaseConnectionString
    {
        public static void SQLDatabaseConnectionString()

        {
            SqlConnection connection = new SqlConnection("Server=LAPTOP-83L42UFV\\SQLEXPRESS; initial Catalog=EgitimKampi501Db; integrated Security= true");
        } 
    }
}
