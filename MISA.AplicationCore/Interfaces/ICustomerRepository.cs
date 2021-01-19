
using MISACukCuk.AplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infarstructure.Interfaces
{
    /// <summary>
    /// Interface danh mục khách hàng
    /// </summary>
    /// CreateBy:DTSON(1/18/2021)
    public interface ICustomerRepository
    {/// <summary>
     /// Lấy danh sách khách hàng
     /// </summary>
     /// <returns>Danh sách khách hàng</returns>
     /// CreateBy:DTSON(1/18/2021)
        IEnumerable<Customer> GetCustomers();
        /// <summary>
        /// Lấy danh sách khách hàng theo ID
        /// </summary>
        /// <returns> khách hàng</returns>
        /// CreateBy:DTSON(1/18/2021)
        Customer GetCustomerById(Guid customerId);
        
        /// <summary>
        /// Thêm khách hàng
        /// </summary>
        /// <returns> số bản ghi thêm thành công</returns>
        /// CreateBy:DTSON(1/18/2021)
        int AddCustomer(Customer customer);
       
        /// <summary>
        /// Cập nhật khách hàng
        /// </summary>
        /// <returns> Số bản ghi cập nhật thành công</returns>
        /// CreateBy:DTSON(1/18/2021)
        int UpdateCustomer(Customer customer);
        
        /// <summary>
        /// Xóa khách hàng theo ID
        /// </summary>
        /// <returns> Số bản ghi xóa thành công</returns>
        /// CreateBy:DTSON(1/18/2021)
        int DeleteCustomer(Guid customerId);
        
        /// <summary>
        /// Lấy danh sách khách hàng theo ID
        /// </summary>
        /// <returns> khách hàng</returns>
        /// CreateBy:DTSON(1/18/2021)
        Customer GetCustomerByCode(string customerCode);
    }
}
