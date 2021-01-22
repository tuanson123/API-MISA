﻿using MISA.AplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISACukCuk.AplicationCore.Entities
{
    public class Customer:BaseEntity
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
        [PrimaryKey]
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Mã khách hàng
        /// </summary>
       
        [Requied]
        [DisplayName("Mã khách hàng")]
        [MaxLengh(20,"Mã khách hàng không vượt quá 20 kí tự")]
        public string CustomerCode { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        [DisplayName("Họ và tên khách hàng")]
        public string FullName { get; set; }
        /// <summary>
        /// Gioi tính 0-nữ 1-nam 2-khác
        /// </summary>
        [DisplayName("Gioi tính khách hàng")]
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
        [CheckDuplicate]
        [DisplayName("Số điện thoại")]
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
        /// Tiền lương
        /// </summary>
        public double Salary { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        #endregion

        #region Method
        #endregion
    }
}
