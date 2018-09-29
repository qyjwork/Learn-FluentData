using Learn_FluentData.Common;
using Learn_FluentData.DTO;
using Learn_FluentData.Service;
using System;

namespace Learn_FluentData
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoMapperRegister.Register();

            UserService userService = new UserService();

            Console.WriteLine("======GetUserInfoById======");
            var userInfo = userService.GetUserInfoById(1);

            Console.WriteLine(userInfo.ToString());

            Console.WriteLine("======GetAllUser======");
            var userInfos = userService.GetAllUser();

            userInfos.ForEach(userinfo =>
            {
                Console.WriteLine(userinfo.ToString());
            });


            UserDTO userDto = new UserDTO
            {
                Name = "new add",
                Age = 89
            };


            bool insertResult = userService.AddUser(userDto);
            if (!insertResult)
            {
                Console.WriteLine("Insert Failed !!!");
            }
            else
            {
                Console.WriteLine("======afterAdduserInfos======");
                var afterAdduserInfos = userService.GetAllUser();

                afterAdduserInfos.ForEach(userinfo =>
                {
                    Console.WriteLine(userinfo.ToString());
                });

            }


            userDto.Id = 7;
            userDto.Name = "update";

            bool updateResult = userService.UpdateUser(userDto);
            if (!updateResult)
            {
                Console.WriteLine("Update Failed !!!");
            }
            else
            {
                Console.WriteLine("======afterUpdateuserInfos======");
                var afterUpdateuserInfos = userService.GetAllUser();

                afterUpdateuserInfos.ForEach(userinfo =>
                {
                    Console.WriteLine(userinfo.ToString());
                });
            }

            bool deleteResult = userService.DeleteUserInfoById(4);
            if (!updateResult)
            {
                Console.WriteLine("Delete Failed !!!");
            }
            else
            {
                Console.WriteLine("======afterDeleteuserInfos======");
                var afterDeleteuserInfos = userService.GetAllUser();

                afterDeleteuserInfos.ForEach(userinfo =>
                {
                    Console.WriteLine(userinfo.ToString());
                });
            }


            Console.ReadKey();
        }
    }
}
