
using MISA.AplicationCore.Interfaces;
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
    public interface ICustomerRepository:IBaseRepository<Customer>
    {
        
        /// <summary>
        /// Lấy thông tin khách hàng theo ID
        /// </summary>
        /// <returns> khách hàng</returns>
        /// CreateBy:DTSON(1/18/2021)
        Customer GetCustomerByCode(string customerCode);
    }
}
