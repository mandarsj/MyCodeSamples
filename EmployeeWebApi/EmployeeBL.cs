using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebApi
{
    public class EmployeeBL
    {
        private  readonly SqlConnection _sqlConnection;
        public EmployeeBL(SqlConnection connection)
        {
            _sqlConnection = connection;
        }
    }
}
