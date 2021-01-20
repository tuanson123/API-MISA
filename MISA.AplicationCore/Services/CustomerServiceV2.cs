using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Interfaces;
using MISACukCuk.AplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AplicationCore
{
    public class CustomerServiceV2 : ICustomerService
    {
        public int Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomerPaging(int limit, int offset)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomersByGroup(Guid groupId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetEntities()
        {
            throw new NotImplementedException();
        }

        public Customer GetEntityId(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public int Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
