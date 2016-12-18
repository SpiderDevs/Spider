using Spider.Helpers;
using Spider.Interfaces;
using Spider.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.App.Engine
{
    /// <summary>
    /// Register of services names. Going by name. 
    /// </summary>
    public enum ServiceEnum
    {
        Test,
        Authorisation,
    }

    public static class ServicesFactory
    {
        //TODO: Get for channel
        public static IService Get(string name)
        {
            ServiceEnum serviceEnum = EnumHelper.GetEnum<ServiceEnum>(name);
            switch (serviceEnum)
            {
                case ServiceEnum.Test:
                    {
                        return new TestService();
                    }
                case ServiceEnum.Authorisation:
                    {
                        return new AuthorisationService();
                    }
                default:
                    throw new NotImplementedException("Not found service by name");
            }
        }

    }
}
