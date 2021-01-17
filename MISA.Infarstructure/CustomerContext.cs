using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Infarstructure.Models;
using MySql.Data.MySqlClient;
using Dapper;

namespace MISA.Infarstructure
{
    public class CustomerContext
    {
        #region method

        /// <summary>
        /// Lấy toàn bộ danh sách khách hàng
        /// </summary>
        /// <returns>DANH SÁCH KHÁCH HÀNG</returns>
        /// CreatedBy:NVMANH(24/11/2020)
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
        //Láy thông tin khách hàng theo mã khách hàng
        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">object khách hàng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy:DTSON(1/13/2021)
        public int InsertCustomer(Customer customer){
            //Khai báo thông tin kết nối database
            var connectionString = "User Id=nvmanh;" +
               "Host=103.124.92.43;" +
               "Port=3306;" +
               "Database=MISACukCuk_MF650_DTSON;" +
               "Password=12345678;" +
               "Character Set=utf8";
            //Khởi tạo đối tượng kết nối
            var dbConnection = new MySqlConnection(connectionString);
            var storeParamObject = new
            {
                CustomerId = customer.CustomerId.ToString(),
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


            //Thực hiện câu lệnh truy vấn thêm mới vào database
            var res = dbConnection.Execute("Proc_InsertCustomer", commandType: CommandType.StoredProcedure, param: storeParamObject);
            //Trả dữ liệu cho client

            return res;
        }
        /// <summary>
        /// Lấy khách hàng theo mã khách hàng
        /// </summary>
        /// <param name="customerCode">Mã khách hàng</param>
        /// <returns>object khách hàng đầu tiên lấy được</returns>
        /// CreatedBy:DTSON(1/14/2021)
        public Customer GetCustomerByCode(string customerCode)
        {
            var connectionString = "User Id=nvmanh;" +
               "Host=103.124.92.43;" +
               "Port=3306;" +
               "Database=MISACukCuk_MF650_DTSON;" +
               "Password=12345678;" +
               "Character Set=utf8";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            var res = dbConnection.Query<Customer>("Proc_GetCustomerByCode", new { CustomerCode = customerCode }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return res;
        }

        
        //Thêm mới khách hàng

        //Sửa thông tin khách hàng

        //Xóa khách hàng theo khóa chính

        #endregion
    }
}
