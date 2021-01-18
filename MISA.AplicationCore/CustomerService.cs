using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MISA.Infarstructure;
using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Interfaces;
using MISACukCuk.AplicationCore.Entities;
using MISA.Infarstructure.Interfaces;

namespace MISA.AplicationCore
{
    public class CustomerService: ICustomerService
    {
        ICustomerRespository _customerRepository;
        #region Constructor
        public CustomerService(ICustomerRespository customerRepository)
        {
            _customerRepository = customerRepository;
        }

      

        public ServiceResult DeleteCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(Guid customerId)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Method
        //Lấy danh sách khách hàng
        public IEnumerable<Customer> GetCustomers()
        {
            
            
            var customers = _customerRepository.GetCustomers();

            return (IEnumerable<Customer>)customers;

        }

        public ServiceResult UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
        //Thêm mới khách hàng
        public ServiceResult AddCustomer(Customer customer)
        {
            var serviceResult = new ServiceResult();
           
            //Validate dữ liệu:
            //Check trường bắt buộc nhập
            var customerCode = customer.CustomerCode;
            if (string.IsNullOrEmpty(customerCode))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "CustomerCode", msg = "Mã khách hàng không được để trống" },
                    userMsg = "Mã khách hàng không được để trống",
                    Code = 900,
                };
                serviceResult.MISACode = 900;
                serviceResult.Messenger = "Mã khách hàng không được phép để trống";
                serviceResult.Data = msg;
                return serviceResult;
            }
            //Check trùng mã
            var res = _customerRepository.GetCustomerByCode(customerCode);
            if (res != null)
            {
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
            var rowAffects = _customerRepository.AddCustomer(customer);
            serviceResult.MISACode = 100;
            serviceResult.Messenger = "Thêm Thành Công";
            serviceResult.Data = rowAffects;

            return serviceResult;
        }
        //Xóa khách hàng

        //Sửa khách hàng
        #endregion
    }
}
