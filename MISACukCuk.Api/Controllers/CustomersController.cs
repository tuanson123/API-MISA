﻿using Microsoft.AspNetCore.Mvc;
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
using MISA.AplicationCore.Enums;

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
            _dbConnection = new MySqlConnection(_connectionString);
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
            if (serviceResult.MISACode == MISACode.IsValid && (int)serviceResult.Data > 0)
                return Created("ssdsad", serviceResult);
            else
                return NoContent();

        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Customer customer)
        {
            
            
            return Ok(1);
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]    
        public IActionResult Delete(Guid id)
        {
            var res=_customerService.DeleteCustomer(id);
            return Ok(res);
        }
        #endregion
    }
}
