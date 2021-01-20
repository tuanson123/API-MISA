using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.AplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infarstructure
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {
        #region Declare
        //Khai báo biến
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        protected IDbConnection _dbConnection = null;
        protected string _tableName;
        #endregion
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("MISACukCukConnectionString");
            _dbConnection = new MySqlConnection(_connectionString);
            _tableName = typeof(TEntity).Name;
        }
        public int Add(TEntity entity)
        {
            //Khởi tạo kết nối với database
            var parameters = MappingDbType(entity);

            //Thực hiện câu lệnh truy vấn thêm mới vào database
            var res = _dbConnection.Execute($"Proc_Insert{_tableName}", parameters, commandType: CommandType.StoredProcedure);
            //Trả dữ liệu cho client

            return res;
        }

        public int Delete(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TEntity> GetEntities()
        {
            //Lấy dữ liệu data base
            var entities = _dbConnection.Query<TEntity>($"Proc_Get{_tableName}s", commandType: CommandType.StoredProcedure);
            //Trả về dữ liệu
            return entities;
        }

        public TEntity GetEntityId(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public int Update(TEntity customer)
        {
            throw new NotImplementedException();
        }
        private DynamicParameters MappingDbType(TEntity entity)
        {
            var properties = entity.GetType().GetProperties();
            DynamicParameters dynamicParameters = new DynamicParameters();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                if (property.PropertyType == typeof(Guid) || property.PropertyType == typeof(Guid?))
                {
                    propertyValue = property.GetValue(entity, null).ToString();
                }
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            return dynamicParameters;

        }
    }
}
