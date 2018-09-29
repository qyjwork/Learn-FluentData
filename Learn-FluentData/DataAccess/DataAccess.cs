using FluentData;
using Learn_FluentData.Model;
using System.Collections.Generic;

namespace Learn_FluentData.DataAccess
{
    public class DataAccess
    {

        private IDbContext DbContext;

        /// <summary>
        /// 构造函数创建IDbContext对象,所有对数据库的操作都基于该类型
        /// </summary>
        /// <param name="connName"></param>
        public DataAccess(string connName = "demo")
        {
            DbContext = new DbContext().ConnectionStringName(connName, new SqlServerProvider());
        }


        #region 数据库操作

        /// <summary>
        /// 根据用户Id查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUserById(int id)
        {
            string sqlText = "SELECT * FROM USERS WHERE id =@id";

            var user = this.DbContext.Sql(sqlText)
                                     .Parameter("id", id)
                                     .QuerySingle<User>(MapperData);

            return user;
        }

        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUser()
        {
            string sqlText = "SELECT * FROM USERS";

            var users = this.DbContext.Sql(sqlText)
                                     .QueryMany<User>(MapperData);

            return users;
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool InsertUser(User user)
        {
            string sqlText = "INSERT INTO USERS(NAME,AGE) VALUES(@NAME,@AGE)";

            var result = this.DbContext.Sql(sqlText)
                                        .Parameter("NAME", user.Name)
                                        .Parameter("AGE", user.Age)
                                        .Execute();
            return result > 0;
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UpdateUser(User user)
        {
            string sqlText = "UPDATE USERS SET NAME=@name WHERE ID=@id";

            var result = this.DbContext.Sql(sqlText)
                                        .Parameter("name", user.Name)
                                        .Parameter("id", user.Id)
                                        .Execute();
            return result > 0;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteByUserId(int id)
        {
            string sqlText = "DELETE  FROM USERS WHERE ID =@id";

            var result = this.DbContext.Sql(sqlText)
                                       .Parameter("id", id)
                                       .Execute();

            return result > 0;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 映射数据库与实体
        /// </summary>
        /// <param name="user"></param>
        /// <param name="dataReader"></param>
        private void MapperData(User user, IDataReader dataReader)
        {
            user.Id = dataReader.GetInt32("id");
            user.Name = dataReader.GetString("Name");
            user.Age = dataReader.GetInt32("Age");
        }
        #endregion
    }
}
