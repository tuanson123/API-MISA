using Microsoft.AspNetCore.Mvc;
using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using MISA.AplicationCore;
using MISA.AplicationCore.Interfaces;

using MISACukCuk.AplicationCore.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISACukCuk.Api.Controllers
{
    /// <summary>
    /// Api danh mục kháCH HÀNG
    /// CreatedBy:DTSON(08/01/2021)
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        #region declare
        //Kết nối tới database
        string _connectionString = "User Id=nvmanh;" +
            "Host=103.124.92.43;" +
            "Port=3306;" +
            "Database=MISACukCuk_MF650_DTSON;" +
            "Password=12345678;" +
            "Character Set=utf8";
        //Khởi tạo đối tượng kết nối tới database
        IDbConnection _dbConnection;
        #endregion

        #region constructor
        public CustomersController()
        {
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Method

        
        // GET: api/<CustomersController>
        /// <summary>
        /// Lấy toàn bộ khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy:DTSON(08/01/2020)
        [HttpGet]
        public IActionResult Get()
        {
            

            //lấy dữ liệu từ database
            var customer = _customerService.GetCustomers();
            //trả dữ liệu cho client
            return Ok(customer);
        }

        // GET api/<CustomersController>/5
        /// <summary>
        /// Lấy ds khách hàng theo id và tên
        /// </summary>
        /// <param name="id">id của khách hàng</param>
        /// <param name="name">tên khách hàng</param>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy:DTSON(08/01/2020)
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {   
            
            //Lấy dữ liệu từ database
            var customers = _dbConnection.Query<Customer>($"SELECT *from Customer where CustomerId='{id.ToString()}'").FirstOrDefault();
            //Trả dữ liệu cho client
            return Ok(customers);   
            
        }

        // POST api/<CustomersController>
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            
            var serviceResult = _customerService.AddCustomer(customer);
            if (serviceResult.MISACode == MISACode.NotValid)
                return BadRequest(serviceResult.Data);
            if (serviceResult.MISACode == 100 && (int)serviceResult.Data > 0)
                return Created("ssdsad", customer);
            else
                return NoContent();

        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Customer customer)
        {
            
            string changeId = id.ToString();
            
            var storeParamObject = new
            {
                CustomerId = changeId,
                CustomerCode = customer.CustomerCode,
                FullName = customer.FullName,
                MemberCardCode = customer.MemberCardCode,
                CustomerGroupId = customer.CustomeGroupId.ToString(),
                DateOfBirth = customer.DateOfBirth,
                Gender = customer.Gender,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                CompanyName = customer.CompanyName,
                CompanyTaxCode = customer.CompanyTaxCode,
                Address = customer.Address,
                CreatedDate = customer.CreatedDate,
                CreatedBy = customer.CreatedBy,
                ModifiedDate = customer.ModifiedDate,
                ModifiedBy = customer.ModifiedBy,
            };
            DynamicParameters dynamicParameters = new DynamicParameters();
            var properties = customer.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(customer);
                if (property.PropertyType == typeof(Guid))
                {
                    propertyValue = property.GetValue(customer).ToString();
                }
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            //Thực hiện câu lệnh truy vấn sửa vào database
            var res = _dbConnection.Execute("Proc_UpdateCustomer", commandType: CommandType.StoredProcedure, param: storeParamObject);
            //Trả dữ liệu cho client
            return Ok(res);
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]    
        public IActionResult Delete(Customer customer)
        {
            return Ok(1);
        }
        #endregion
    }
}
