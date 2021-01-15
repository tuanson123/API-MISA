using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Infarstructure.Models
{/// <summary>
/// Khách hàng
/// CreatedBy:DOTUANSON(2021/08/01)
/// </summary>
    public class Customer
    {
        #region Declare
        #endregion

        #region Contructor
        public Customer() { }
        #endregion

        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string CustomerCode { get; set; }
       
        /// <summary>
        /// Họ và tên
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Gioi tính 0-nữ 1-nam 2-khác
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Ngày tháng năm sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Địa chỉ email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Mã nhóm khách hàng
        /// </summary>
        public Guid? CustomeGroupId { get; set; }
       
        /// <summary>
        /// Số thẻ thành viên
        /// </summary>
        public string MemberCardCode { get; set; }
        /// <summary>
        /// Tên công ty làm việc
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Mã số thuế cong ty
        /// </summary>
        public string CompanyTaxCode { get; set; }
        /// <summary>
        /// Ngừng theo dõi(true ngừng theo dõi, false-ngược lại)
        /// </summary>
        

        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        #endregion

        #region Method
        #endregion

    }
}
