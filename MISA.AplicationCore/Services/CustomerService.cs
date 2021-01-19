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
using MISA.AplicationCore.Enums;

namespace MISA.AplicationCore
{
    public class CustomerService: ICustomerService
    {
        ICustomerRepository _customerRepository;
        #region Constructor
        //Khởi tạo
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            
        }

        #endregion
        #region Method
        //Lấy danh sách khách hàng
        public IEnumerable<Customer> GetCustomers()
        {
            
            
            var customers = _customerRepository.GetCustomers();

            return (IEnumerable<Customer>)customers;

        }
        //Lấy danh sách khách hàng theo ID
        public Customer GetCustomerById(Guid customerId)
        {
            throw new NotImplementedException();
        }
        //Cập nhật khách hàng
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
                serviceResult.MISACode = MISACode.NotValid;
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
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = "Mã khách hàng không được phép để trống";
                serviceResult.Data = msg;
                return serviceResult;
            }

            //Thêm mới khi dữ liệu đã hợp lệ:
            var rowAffects = _customerRepository.AddCustomer(customer);
            serviceResult.MISACode = MISACode.NotValid;
            serviceResult.Messenger = "Thêm Thành Công";
            serviceResult.Data = rowAffects;

            return serviceResult;
        }
        //Xóa khách hàng
        public ServiceResult DeleteCustomer(Guid customerId)
        {
           var serviceResult=new ServiceResult();
            serviceResult.Data = _customerRepository.DeleteCustomer(customerId);
            return serviceResult;
        }

        //Sửa khách hàng
        #endregion
    }
}
