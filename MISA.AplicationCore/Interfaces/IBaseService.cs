using MISA.AplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AplicationCore.Interfaces
{/// <summary>
 /// Khuôn mẫu Interface check nghiệp vụ
 /// CreateBy:DTSON(19/01/2021)
 /// </summary>
    public interface IBaseService<TEntity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetEntities();
        /// <summary>
        /// Lấy dữ liệu theo ID
        /// </summary>
        /// <returns></returns>
        TEntity GetEntityId(Guid entityId);
        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>

        ServiceResult Add(TEntity entity);

        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ServiceResult Update(TEntity entity);
        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>

        ServiceResult Delete(Guid entityId);
    }
}
