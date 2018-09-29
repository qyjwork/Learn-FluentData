using System.Collections.Generic;
using Learn_FluentData.DTO;
using Learn_FluentData.Model;

namespace Learn_FluentData.Service
{
    public class UserService
    {
        private Learn_FluentData.DataAccess.DataAccess dataAccess;

        public UserService()
        {
            this.dataAccess = new Learn_FluentData.DataAccess.DataAccess();
        }

        /// <summary>
        /// 查询某一个用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserDTO GetUserInfoById(int id)
        {
            User user = this.dataAccess.GetUserById(id);

            return AutoMapper.Mapper.Map<UserDTO>(user);
        }

        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        public List<UserDTO> GetAllUser()
        {
            var users = this.dataAccess.GetAllUser();

            return AutoMapper.Mapper.Map<List<UserDTO>>(users);
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public bool AddUser(UserDTO userDto)
        {
            var user = AutoMapper.Mapper.Map<User>(userDto);

            return this.dataAccess.InsertUser(user);
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public bool UpdateUser(UserDTO userDto)
        {
            var user = AutoMapper.Mapper.Map<User>(userDto);

            return this.dataAccess.UpdateUser(user);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteUserInfoById(int id)
        {
            return this.dataAccess.DeleteByUserId(id);
        }
    }
}
