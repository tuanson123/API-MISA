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
using MISA.AplicationCore.Services;

namespace MISA.AplicationCore
{
    public class CustomerService: BaseService<Customer>,ICustomerService
    {
        IBaseRepository<Customer> _customerRepository;
        
        #region Constructor
        //Khởi tạo
        public CustomerService(IBaseRepository<Customer> customerRepository):base(customerRepository)
        {
            _customerRepository = customerRepository;
            
        }

        #endregion
        #region Method
        

        public IEnumerable<Customer> GetCustomerPaging(int limit, int offset)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomersByGroup(Guid departmentId)
        {
            throw new NotImplementedException();
        }

        //Sửa khách hàng
        #endregion
    }
}
