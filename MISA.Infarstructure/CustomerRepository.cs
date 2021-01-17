﻿using Dapper;
using MISA.Infarstructure.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infarstructure
{
    public class CustomerRepository : ICustomerRespository
    {
        public int AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public int DeleteCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            //Kết nối tới CSDL

            var connectionString = "User Id=nvmanh;" +
               "Host=103.124.92.43;" +
               "Port=3306;" +
               "Database=MISACukCuk_MF650_DTSON;" +
               "Password=12345678;" +
               "Character Set=utf8";
            //Khởi tạo đối tượng kết nối
            var dbConnection = new MySqlConnection(connectionString);
            //Lấy dữ liệu data base
            var customers = dbConnection.Query<Customer>("Proc_GetCustomers", commandType: CommandType.StoredProcedure);
            //Trả về dữ liệu
            return customers;
        }

        public int UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
