using MISA.AplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISACukCuk.Entities.Models
{
    /// <summary>
    /// Nhóm khách hàng
    /// CreateBy:DTSON(01/14/2021)
    /// </summary>
    public class CustomerGroup: BaseEntity
    {
        #region declare

        #endregion

        #region constructor

        #endregion

        #region Method

        #endregion

        #region Property
        /// <summary>
        /// Nhóm khách hàng
        /// </summary>
        public Guid CustomerGroupId { get; set; }
        /// <summary>
        /// Tên nhóm khách hàng
        /// </summary>
        public string CustomerGroupName { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        public string Desciption { get; set; }
        #endregion

    }
}
