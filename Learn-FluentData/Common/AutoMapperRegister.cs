using AutoMapper;
using Learn_FluentData.DTO;
using Learn_FluentData.Model;

namespace Learn_FluentData.Common
{
    public class AutoMapperRegister
    {
        public static void Register()
        {
            AutoMapper.Mapper.Initialize(it =>
            {
                it.AddProfile<MapperProfile>();
            });
        }
    }

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            this.CreateMap<User, UserDTO>();
            this.CreateMap<UserDTO, User>();
        }
    }
}
