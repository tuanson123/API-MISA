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
        /// <summary>
        /// Theo tác dữ liệu với nhân viên
        /// CreateBy:DTSON(19/01/2021)
        /// </summary>
        #region Declare
        //Khai báo biến
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        IDbConnection _dbConnection = null;
        #endregion

        #region Contructor
        //Hàm khởi tạo
        public EmployeeRepository(IConfiguration configuration) : base (configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("MISACukCukConnectionString");
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion
        #region method
        //Lấy ra nhân viên theo mã
        public Employee GetEmployeeByCode(string employeeCode)
        {
            var employeeDulicate = _dbConnection.Query<Employee>($"select *from Employee where employeeCode='{employeeCode}'", commandType: CommandType.Text).FirstOrDefault();
            return employeeDulicate;
        }
        #endregion

    }
}
