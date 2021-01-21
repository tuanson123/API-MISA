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
        
        ICustomerRepository _customerRepository;
        #region Constructor
        //Khởi tạo
        public CustomerService(ICustomerRepository customerRepository) :base(customerRepository)
        {
            
            _customerRepository = customerRepository;
        }

        #endregion
        #region Method

        //public override int Add(Customer entity)
        // {
        //    //validate thoong tin:
        //    var isValid = true;
        //    //1. check trùng mã khách hàng:
        //    var customerDuplicate = _customerRepository.GetCustomerByCode(entity.CustomerCode);
        //    if(customerDuplicate!=null)
        //    {
        //        isValid = false;
        //    }    
        //    //Logic validate:
        //    if(isValid==true)
        //    {
        //        var res = base.Add(entity);
        //        return res;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
            
        //}
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
