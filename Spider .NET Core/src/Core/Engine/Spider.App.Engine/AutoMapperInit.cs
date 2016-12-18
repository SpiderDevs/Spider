using AutoMapper;
using Spider.Core.Models.User;
using Spider.View.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.App.Engine
{
    //TODO: Refactor. Rename, move somevere??????
    public static class AutoMapperInit
    {
        public static void Init()
        {
            //TODO: There is better way to do this?
            //One point for configure them all  ...... :(
            //We should have separated places for do this. 
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<VMUserRegisterRequest, UserRegisterRequest>();
                cfg.CreateMap<VMUserLogInRequest, UserLogInRequest>();
                cfg.CreateMap<VMUser, User>();
                cfg.CreateMap<User, VMUser>();
            });
        }
    }
}
