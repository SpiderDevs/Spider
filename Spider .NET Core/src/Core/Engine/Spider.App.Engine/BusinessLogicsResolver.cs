using Spider.BusinessLogic;
using Spider.Interfaces;
using Spider.Interfaces.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.App.Engine
{
    public class BusinessLogicsResolver : IBusinessLogic
    {
        private IUserAuthenticationBusinessLogic _userAuthenticationBusinessLogic;
        private IUserBusinessLogic _userBusinessLogic;
        
        public IUserAuthenticationBusinessLogic UserAuthenticationBusinessLogic
        {
            get
            {
                return _userAuthenticationBusinessLogic ?? ResolveUserAuthenticationBussinesLogic();
            }
        }

        private IUserAuthenticationBusinessLogic ResolveUserAuthenticationBussinesLogic()
        {
            _userAuthenticationBusinessLogic = new UserAuthenticationBusinessLogic();
            return _userAuthenticationBusinessLogic;
        }

        public IUserBusinessLogic UserBusinessLogic
        {
            get
            {
                return _userBusinessLogic ?? ResolveUserBussinesLogic();
            }
        }

        private IUserBusinessLogic ResolveUserBussinesLogic()
        {
            _userBusinessLogic = new UserBusinessLogic();
            return _userBusinessLogic;
        }
    }
}
