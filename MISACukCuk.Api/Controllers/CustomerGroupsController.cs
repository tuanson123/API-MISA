using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MISACukCuk.Entities.Models;

namespace MISACukCuk.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerGroupsController : ControllerBase
    {
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
        public CustomerGroupsController()
        {
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion
        [HttpGet]
        public IActionResult Get()
        {
            DbConnector dbConnector = new DbConnector();

            //lấy dữ liệu từ database
            var customerGroups = dbConnector.Get<CustomerGroup>();
            //trả dữ liệu cho client
            return Ok(customerGroups);
        }
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {   
            var dynamicParametes = new DynamicParameters();
            dynamicParametes.Add("@CustomerGroupId", id);
            //lấy dữ liệu từ database
            var customerGroup = _dbConnection.Query<CustomerGroup>("Proc_GetCustomerGroupById", commandType: CommandType.StoredProcedure).FirstOrDefault();
            //trả dữ liệu cho client
            return Ok(customerGroup);
        }
        [HttpPost]
        public IActionResult Post()
        {
            return Ok(1);
        }
        [HttpPut]
        public IActionResult Put()
        {
            return Ok(1);
        }
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok(1);
        }


    }
}
