using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AplicationCore.Entities
{/// <summary>
/// Thông tin nhân viên
/// CreateBy:DTSON(19/01/2021)
/// </summary>
    public class Employee:BaseEntity
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Họ tên nhân viên
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Gioi tính
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// Gố CMTCD/Căn cước
        /// </summary>
        public string CitienID { get; set; }
        /// <summary>
        /// Ngày cấp CMTCD/Căn cước
        /// </summary>
        public DateTime? DateOfID { get; set; }
        /// <summary>
        /// Nơi cấp CMTCD/Căn cước
        /// </summary>
        public string PlaceOfID { get; set; }
        /// <summary>
        /// Địa chỉ Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Khóa ngoại với bảng POSITION
        /// </summary>
        public Guid? PositionId { get; set; }
        /// <summary>
        /// Khóa ngoại với bảng Department
        /// </summary>
        public Guid? DepartmentId { get; set; }
        /// <summary>
        /// Mã số thuế cá nhân
        /// </summary>
        public string PersonalTaxCode { get; set; }
        /// <summary>
        /// ngày gia nhập
        /// </summary>
        public DateTime? DateOfJoining { get; set; }
        /// <summary>
        /// Trạng thái công việc(0-Đã nghỉ việc, 1-Đang làm việc)
        /// </summary>
        public int WorkStatus { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
