using Dapper;
using Microsoft.Data.SqlClient;

namespace Crud_Dapper.Data
{
    public class ConnectionBase
    {
        const string connectionString = "Data Source =.\\sqlexpress; Initial Catalog = DapperCrud; Integrated Security = True; ;TrustServerCertificate=True";

        public SqlConnection Connection { get; set; }

        public ConnectionBase()
        {
            Connection = new SqlConnection(connectionString);

            DefaultTypeMap.MatchNamesWithUnderscores = true;

            Connection.Open();
        }
    }
}
