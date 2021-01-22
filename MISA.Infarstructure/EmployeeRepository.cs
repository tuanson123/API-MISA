using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infarstructure
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        #region Declare
        //Khai báo biến
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        IDbConnection _dbConnection = null;
        #endregion
        public EmployeeRepository(IConfiguration configuration) : base (configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("MISACukCukConnectionString");
            _dbConnection = new MySqlConnection(_connectionString);
        }    
        public int AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public int DeleteEmployee(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeByCode(string employeeCode)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _dbConnection.Query<Employee>("SELECT *FROM Employee");
        }

        public int UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
