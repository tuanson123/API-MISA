using MISA.AplicationCore.Entities;
using MISACukCuk.AplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AplicationCore.Interfaces
{/// <summary>
 /// Interface check nghiệp vụ của khách hàng
 /// CreateBy:DTSON(19/01/2021)
 /// </summary>
    public interface ICustomerService : IBaseService<Customer>
    {/// <summary>
     /// Lấy dữ liệu phân trang
     /// </summary>
     /// <param name="limit"></param>
     /// <param name="offset"></param>
     /// <returns></returns>
        IEnumerable<Customer> GetCustomerPaging(int limit, int offset);
        /// <summary>
        /// Lấy danh sách khách hàng theo nhóm khách hàng
        /// </summary>
        /// <param name="groupId">Nhom khách hàng</param>
        /// <returns>List khách hàng</returns>
        /// CreatedBy:DTSON(19/01/2021)
        IEnumerable<Customer> GetCustomersByGroup(Guid groupId);
    }
}
