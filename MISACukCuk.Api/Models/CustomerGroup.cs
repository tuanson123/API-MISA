using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISACukCuk.Api.Models
{
    /// <summary>
    /// Nhóm khách hàng
    /// CreateBy:DTSON(01/14/2021)
    /// </summary>
    public class CustomerGroup
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
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        #endregion


    }
}
