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
{/// <summary>
 /// nghiệp vụ của khách hàng
 /// CreateBy:DTSON(19/01/2021)
 /// </summary>
    public class CustomerService : BaseService<Customer>, ICustomerService
    {

        ICustomerRepository _customerRepository;
        #region Constructor
        //Khởi tạo
        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {

            _customerRepository = customerRepository;
        }

        #endregion
        #region Method
        //Ghi lại phương thức validate
        protected override bool ValidateCustom(Customer entity)
        {

            return true;
        }
        //Phân trang
        public IEnumerable<Customer> GetCustomerPaging(int limit, int offset)
        {
            throw new NotImplementedException();
        }
        //Lấy phòng ban theo id phòng ban
        public IEnumerable<Customer> GetCustomersByGroup(Guid departmentId)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
