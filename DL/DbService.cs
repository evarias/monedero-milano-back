using System.Data;
using System.Globalization;
using System.Text;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DL
{
    public class DbService : IStoredProcedureService
    {
        private readonly IConfiguration _configuration;

        public DbService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IEnumerable<T> ExecuteStoredProcedure<T>(string connectionStringName, string storedProcedureName, object parameters)
        {
            var connectionString = _configuration.GetConnectionString(connectionStringName);

            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                if (dbConnection == null)
                {
                    throw new ArgumentNullException(nameof(dbConnection));
                }

#if DEBUG
                string spDebug = BuildExec(storedProcedureName, parameters);
#endif

                try
                {
                    var results = dbConnection.Query<T>(
                        storedProcedureName,
                        parameters,
                        commandType: CommandType.StoredProcedure,
                        commandTimeout: 0
                    );

                    return results;
                }
                catch (Exception)
                {
                    return Enumerable.Empty<T>();
                }
            }
        }

        private string BuildExec(string storedProcedureName, object parameters)
        {
            StringBuilder spDebug = new StringBuilder();
            spDebug.Append("EXEC ");
            spDebug.Append(storedProcedureName);
            spDebug.Append(" ");

            if (parameters is Dictionary<string, object> dict)
            {
                spDebug.Append(string.Join(", ", dict.Select(kv =>
                    $"@{kv.Key} = {FormatValue(kv.Value)}")));
            }
            else
            {
                var props = parameters.GetType().GetProperties();
                spDebug.Append(string.Join(", ", props.Select(p =>
                    $"@{p.Name} = {FormatValue(p.GetValue(parameters))}")));
            }

            return spDebug.ToString();
        }

        private string FormatValue(object value)
        {
            if (value == null)
                return "NULL";

            if (value is string || value is char)
                return $"'{value.ToString().Replace("'", "''")}'";

            if (value is DateTime dateTime)
                return $"'{dateTime:yyyy-MM-dd HH:mm:ss}'";

            if (value is bool boolean)
                return boolean ? "1" : "0";

            if (value is decimal || value is double || value is float)
                return Convert.ToString(value, CultureInfo.InvariantCulture);

            return value.ToString();
        }
    }
}
