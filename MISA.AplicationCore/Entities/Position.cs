using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AplicationCore.Entities
{
    public class Position:BaseEntity
    {
        /// <summary>
        /// Thông tin vị trí
        /// CreateBy:DTSON(19/01/2021)
        /// </summary>
        #region property
        /// <summary>
        /// ID của vị trí làm việc
        /// </summary>
        public Guid PositionId { get; set; }
        /// <summary>
        /// Tên vị trí
        /// </summary>
        public string PositionName { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }
        #endregion
    }
}
