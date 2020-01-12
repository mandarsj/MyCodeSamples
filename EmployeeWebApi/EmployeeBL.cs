using EmployeeWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace EmployeeWebApi
{
    public class EmployeeBL
    {
        private  readonly SqlConnection _sqlConnection;
        public EmployeeBL(SqlConnection connection)
        {
            _sqlConnection = connection;
        }

        public  List<Employee> GetEmployees()
        {
            try
            {
                /* Dapper Implementation
                var employees = await _sqlConnection.QueryAsync<Employee>("select ID,FirstName,LastName from Employee");
                return employees.ToList();

                */

                var listEmployees = new List<Employee>();
                listEmployees.Add(new Employee() { ID = 1, FirstName = "Test", LastName = "TestLast" });

                return listEmployees;
            }
            catch
            {
                throw;
            }
        }

        public void PostEmployee(Employee employee)
        {
            try
            {
                /* Dapper Post" with the correct SQL Connection in place , this query will run and exit the method.
                string query = $"Insert into Employee(FirstName,LastName)values('{employee.FirstName}','{employee.LastName}')";
                _sqlConnection.Execute(query);

                */

            }
            catch
            {
                throw;
            }
        }
    }
}
