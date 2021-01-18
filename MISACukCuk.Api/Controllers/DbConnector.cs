using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISACukCuk.Api.Controllers
{
    public class DbConnector
    {
        #region declare
        //Kết nối tới database
        string _connectionString = "User Id=nvmanh;" +
            "Host=103.124.92.43;" +
            "Port=3306;" +
            "Database=MISACukCuk_MF650_DTSON;" +
            "Password=12345678;" +
            "Character Set=utf8";
        //Khởi tạo đối tượng kết nối tới database
        IDbConnection _dbConnection;
        #endregion
        #region constructor
        public DbConnector()
        {
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MISATEntity> Get<MISATEntity>()
        {   //Biến lấy tên vế sau
            string tableName = typeof(MISATEntity).Name;
            //lấy dữ liệu từ database
            var entities = _dbConnection.Query<MISATEntity>($"Proc_Get{tableName}s", commandType: CommandType.StoredProcedure);
            //trả dữ liệu cho client
            return entities;
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy dữ liệu theo id
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MISATEntity> GetById<MISATEntity>(Guid entityId)
        {   
            //Biến lấy tên vế sau
            string tableName = typeof(MISATEntity).Name;
            //lấy dữ liệu từ database
            var entity = _dbConnection.Query<MISATEntity>($"SELECT *from {tableName} where {tableName}Id='{entityId.ToString()}'").FirstOrDefault();
            //trả dữ liệu cho client
            return (IEnumerable<MISATEntity>)entity;

        }
        #endregion
    }
}
