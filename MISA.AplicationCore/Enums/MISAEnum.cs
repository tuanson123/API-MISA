using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AplicationCore.Enums
{
    /// <summary>
    /// Trả về các loại lỗi
    /// CreateBy:DTSON(19/01/2021)
    /// </summary>

    public enum MISACode

        {   /// <summary>
            /// Dữ liệu hợp lệ
            /// </summary>
            IsValid = 100,
            /// <summary>
            /// Dữ liệu chưa hợp lệ
            /// </summary>
            NotValid = 900,
            /// <summary>
            /// Thành công
            /// </summary>
            Success = 200,
            Exception=500
        }
    /// <summary>
    /// Xác định trạng thái của object
    /// </summary>
        public enum EntityState
        {
        /// <summary>
        /// Nếu thêm thì là 1
        /// </summary>
            AddNew=1,
        /// <summary>
        /// Nếu sửa thì là 2
        /// </summary>
        Update = 2,
        /// <summary>
        /// Nếu xóa thì là 3
        /// </summary>
        Delete = 3,

        }
    
}
