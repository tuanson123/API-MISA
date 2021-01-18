using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Infarstructure.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MISACukCuk.AplicationCore.Entities;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MISA.Infarstructure
{
    public class CustomerRepository : ICustomerRespository
    {
        #region Declare
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        IDbConnection _dbConnection = null;
        #endregion

        public CustomerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("MISACukCukConnectionString");
            _dbConnection = new MySqlConnection(_connectionString);
        }    
        #region method
        public int AddCustomer(Customer customer)
        {
            //Khởi tạo kết nối với database
            var parameters = MappingDbType(customer);

            //Thực hiện câu lệnh truy vấn thêm mới vào database
            var res = _dbConnection.Execute("Proc_InsertCustomer", parameters, commandType: CommandType.StoredProcedure);
            //Trả dữ liệu cho client

            return res;
        }

        

        public int DeleteCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerByCode(string customerCode)
        {
           
            
            var res = _dbConnection.Query<Customer>("Proc_GetCustomerByCode", new { CustomerCode = customerCode }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return res;
        }

        public Customer GetCustomerById(Guid customerId)
        {
          
            
            
            //Lấy dữ liệu data base
            var customers = _dbConnection.Query<Customer>("Proc_GetCustomerById",new { CustomerId= customerId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            //Trả về dữ liệu
            return customers;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            //Kết nối tới CSDL

            var connectionString = _configuration.GetConnectionString("MISACukCukConnectionString");
           
            //Lấy dữ liệu data base
            var customers = _dbConnection.Query<Customer>("Proc_GetCustomers", commandType: CommandType.StoredProcedure);
            //Trả về dữ liệu
            return customers;
        }

        public int UpdateCustomer(Customer customer)
        {   //Khởi tạo kết nối với database
            var parameters=MappingDbType(customer);
             //Thực hiện câu lệnh truy vấn thêm mới vào database
            var res = _dbConnection.Execute("Proc_UpdateCustomer",parameters ,commandType: CommandType.StoredProcedure);
            //Trả dữ liệu cho client

            return res;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        private DynamicParameters MappingDbType<TEntity>(TEntity entity)
        {
            var properties = entity.GetType().GetProperties();
            var parameters = new DynamicParameters();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                if (property.PropertyType == typeof(Guid) || property.PropertyType == typeof(Guid?))
                {
                    propertyValue = property.GetValue(entity, null).ToString();
                }
                parameters.Add($"@{propertyName}", propertyValue);
            }
            return parameters;

        }

        #endregion
    }
}
