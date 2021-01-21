using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AplicationCore.Interfaces
{
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
        TEntity GetEntityId(Guid customerId);
        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>

        int Add(TEntity customer);

        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        int Update(TEntity customer);
        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>

        int Delete(Guid customerId);
        TEntity GetEntityByProperty(TEntity entity,PropertyInfo property);
    }
}
