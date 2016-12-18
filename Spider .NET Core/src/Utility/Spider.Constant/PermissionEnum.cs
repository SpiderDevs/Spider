using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Constant
{
    public enum PermissionEnum
    {
        /// <summary>
        /// Any group split by 1000.  We should split this by modules
        /// Like Read users=1001, edit users= 1002   /  CreateInvoices = 2001, EditInvoices2002, 
        /// Target of this project is business applications so the permisssions is manadtory to correct working. Public enum seams to be a god idea
        /// I think about  idea for 0  like: 1000, 2000, 3000, - meaybe read? or .... access for view - separated permission for acces to module. Any begin of range is access to module. Based on this enums we can hide thiongs on UI
        /// </summary>
        Unknown = 0,
        Public = 1,


        //Demonstration - should be removed/changed
        #region Users
        UsersAccess = 1000,
        #endregion


        //Demonstration - should be removed/changed
        #region Invoices 
        InvoicessAccess = 2000,
        #endregion


        #region Administration
        AdministrationAccess = 2000000000, 
        #endregion

        #region Specialservices 
        SpecialServicessAccess = 2100000000,
        #endregion


        //This is the max of integer
        // 2147483647,
    }
}
