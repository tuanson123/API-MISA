using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Enums;
using MISA.AplicationCore.Interfaces;
using MISACukCuk.AplicationCore.Entities;
using MISACukCuk.Entities.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infarstructure
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>,IDisposable where TEntity:BaseEntity
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
            var rowAffects = 0;
            _dbConnection.Open();
            using (var transaction = _dbConnection.BeginTransaction())
            {
                try
                {
                    var parameters = MappingDbType(entity);
                    // Thực hiện thêm khách hàng:
                    rowAffects = _dbConnection.Execute($"Proc_Insert{_tableName}", parameters, commandType: CommandType.StoredProcedure);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
            // Trả về kết quả (số bản ghi thêm mới được)
            return rowAffects;
        }

        public int Delete(Guid customerId)
        {


            var res = 0;
            _dbConnection.Open();
            using (var transaction = _dbConnection.BeginTransaction())
            {
                res = _dbConnection.Execute($"DELETE FROM {_tableName} WHERE {_tableName}Id = '{customerId.ToString()}'", commandType: CommandType.Text);
                transaction.Commit();
            }
            return res;
        }

        public virtual IEnumerable<TEntity> GetEntities()
        {
            //Lấy dữ liệu data base
            var entities = _dbConnection.Query<TEntity>($"Proc_Get{_tableName}s", commandType: CommandType.StoredProcedure);
            //Trả về dữ liệu
            return entities;
        }

        public virtual IEnumerable<TEntity> GetEntities(string storeName)
        {
            //Lấy dữ liệu data base
            var entities = _dbConnection.Query<TEntity>($"storeName", commandType: CommandType.StoredProcedure);
            //Trả về dữ liệu
            return entities;
        }
        public TEntity GetEntityId(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public int Update(TEntity entity)
        {
            //Khởi tạo kết nối với database
            var parameters = MappingDbType(entity);

            //Thực hiện câu lệnh truy vấn thêm mới vào database
            var res = _dbConnection.Execute($"Proc_Update{_tableName}", parameters, commandType: CommandType.StoredProcedure);
            //Trả dữ liệu cho client

            return res;
        }
        private DynamicParameters MappingDbType(TEntity entity)
        {
            var properties = entity.GetType().GetProperties();
            var parameters = new DynamicParameters();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    parameters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else if (propertyType == typeof(bool) || propertyType == typeof(bool?))
                {
                    var dbValue = ((bool)propertyValue == true ? 1 : 0);
                    parameters.Add($"@{propertyName}", dbValue, DbType.Int32);
                }
                else
                {
                    parameters.Add($"@{propertyName}", propertyValue);
                }

            }
            return parameters;

        }

        public TEntity GetEntityByProperty(TEntity entity, PropertyInfo property)
        {
            var propertyName = property.Name;
            var propertyValue =property.GetValue(entity);
            var keyValue = entity.GetType().GetProperty($"{_tableName}Id").GetValue(entity);
            var query = string.Empty;
            if(entity.EntityState==EntityState.AddNew)
            {
                query = $"SELECT *FROM {_tableName} WHERE {propertyName}='{propertyValue}'";
            }    
            else if(entity.EntityState == EntityState.Update)
            {
                query = $"SELECT *FROM {_tableName} WHERE {propertyName}='{propertyValue}' AND {_tableName}Id <> '{keyValue}'";
            }
            else
            {
                return null;
            }
            var entityReturn = _dbConnection.Query<TEntity>(query, commandType: CommandType.Text).FirstOrDefault();
            return entityReturn;
        }

        public void Dispose()
        {
            if (_dbConnection.State == ConnectionState.Open)
                _dbConnection.Close();
        }
    }
}
