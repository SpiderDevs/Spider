using Spider.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Services
{
    public class RequirePermissionAttribute : Attribute
    {
        private PermissionEnum[] _RequiredPermissions;

        public RequirePermissionAttribute(params PermissionEnum[] RequiredPermission)
        : base()
        {
            _RequiredPermissions = RequiredPermission;
        }

        public bool UserHasPermision()
        {
            return false;
        }
    }
}
