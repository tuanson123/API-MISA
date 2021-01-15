using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Infarstructure.Models;
using MISA.Infarstructure;
using MISA.AplicationCore.Entities;

namespace MISA.AplicationCore
{
    public class CustomerService 
    {  
        #region Method
        //Lấy danh sách khách hàng
        public IEnumerable<Customer> GetCustomers()
        {
            
            var customerContext = new CustomerContext();
            var customers = customerContext.GetCustomers();
            return (IEnumerable<Customer>)customers;

        }
        //Thêm mới khách hàng
        /*public ServiceResult InsertCustomer(Customer customer)
        {   
            var serviceResult = new ServiceResult();
            var customerContext = new CustomerContext();
            //Validate dữ liệu:
            //Check trường bắt buộc nhập
            var customerCode = customer.CustomerCode;
            if(string.IsNullOrEmpty(customerCode))
            {
                var msg = new {
                    devMsg = new {fieldName="CustomerCode",msg="Mã khách hàng không được để trống"},
                    userMsg="Mã khách hàng không được để trống",
                    Code=900,
                };
                serviceResult.MISACode = 900;
                serviceResult.Messenger = "Mã khách hàng không được phép để trống";
                serviceResult.Data = msg;
                return serviceResult;   
            }
            //Check trùng mã
            var res = customerContext.GetCustomerByCode(customerCode);
            if (res!=null){
                var msg = new
                {
                    devMsg = new { fieldName = "CustomerCode", msg = "Mã khách hàng đã tồn tại" },
                    userMsg = "Mã khách hàng không được để trống",
                    Code = 900,
                };
                serviceResult.MISACode = 900;
                serviceResult.Messenger = "Mã khách hàng không được phép để trống";
                serviceResult.Data = msg;
                return serviceResult;
            }
                
            //Thêm mới khi dữ liệu đã hợp lệ:
            var rowAffects = customerContext.InsertCustomer(customer);
            serviceResult.MISACode = 100;
            serviceResult.Messenger = "Thêm Thành Công";
            serviceResult.Data = rowAffects;

            return serviceResult;
        } */   
        //Xóa khách hàng

        //Sửa khách hàng
        #endregion
    }
}
