using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IStoredProcedureService
    {
        IEnumerable<T> ExecuteStoredProcedure<T>(string connectionStringName, string storedProcedureName, object parameters);
    }
}
