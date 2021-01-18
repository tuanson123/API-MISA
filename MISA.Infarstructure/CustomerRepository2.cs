using MISA.Infarstructure.Interfaces;
using MISA.Infarstructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infarstructure
{
    public class CustomerRepository2 : ICustomerRespository
    {
        public int AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public int AddCustomer(MISACukCuk.AplicationCore.Entities.Customer customer)
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
            throw new NotImplementedException();
        }

        public int UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public int UpdateCustomer(MISACukCuk.AplicationCore.Entities.Customer customer)
        {
            throw new NotImplementedException();
        }

        MISACukCuk.AplicationCore.Entities.Customer ICustomerRespository.GetCustomerById(Guid customerId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<MISACukCuk.AplicationCore.Entities.Customer> ICustomerRespository.GetCustomers()
        {
            throw new NotImplementedException();
        }
    }
}
