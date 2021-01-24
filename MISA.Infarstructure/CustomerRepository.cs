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
    public class CustomerRepository :BaseRepository<Customer>, ICustomerRepository
    {
        /// <summary>
        /// Thao tác cơ sở dữ liệu với khách hàng
        /// CreateBy:DTSON(19/01/2021)
        /// </summary>
        public CustomerRepository(IConfiguration configuration):base(configuration)
        {

        }
        //Lấy ra dữ liệu theo mã 
        public Customer GetCustomerByCode(string customerCode)
        {
            var customerDulicate = _dbConnection.Query<Customer>($"select *from Customer where CustomerCode='{customerCode}'", commandType: CommandType.Text).FirstOrDefault();
            return customerDulicate;
            
        }
    }
}
