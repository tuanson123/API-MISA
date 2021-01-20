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
        public CustomerRepository(IConfiguration configuration):base(configuration)
        {

        }
        public Customer GetCustomerByCode(string customerCode)
        {
            var customerDulicate = _dbConnection.Query<Customer>($"select *from Customer where CustomerCode='{customerCode}'", commandType: CommandType.Text).FirstOrDefault();
            return customerDulicate;
            
        }
    }
}
