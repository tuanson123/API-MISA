using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AplicationCore.Interfaces
{/// <summary>
 /// Khuôn mẫu Interface theo tác với CSDL
 /// CreateBy:DTSON(19/01/2021)
 /// </summary>
    public interface IBaseRepository<TEntity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetEntities();
        IEnumerable<TEntity> GetEntities(string storeName);
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

        int Add(TEntity entity);

        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Update(TEntity entity);
        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>

        int Delete(Guid entityId);
        TEntity GetEntityByProperty(TEntity entity,PropertyInfo property);
    }
}
