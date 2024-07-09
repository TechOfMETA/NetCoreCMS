/*************************************************************
 *          Project: NetCoreCMS                              *
 *              Web: http://dotnetcorecms.org                *
 *           Author: OnnoRokom Software Ltd.                 *
 *          Website: www.onnorokomsoftware.com               *
 *            Email: info@onnorokomsoftware.com              *
 *        Copyright: OnnoRokom Software Ltd.                 *
 *          License: BSD-3-Clause                            *
 *************************************************************/

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NetCoreCMS.Framework.Core.Data;
using NetCoreCMS.Framework.Core.Models;
using System.Security.Claims;

namespace NetCoreCMS.Framework.Core.Auth
{

    public class NccUserStore : UserStore<NccUser, NccRole, NccDbContext, long, NccUserClaim, NccUserRole, NccUserLogin, NccUserToken, NccRoleClaim>
    {
        public NccUserStore(NccDbContext context) : base(context)
        {
        }

        protected override NccUserRole CreateUserRole(NccUser user, NccRole role)
        {
            return new NccUserRole()
            {
                UserId = user.Id,
                RoleId = role.Id
            };
        } 

        protected override NccUserClaim CreateUserClaim(NccUser user, Claim claim)
        {
            var userClaim = new NccUserClaim { UserId = user.Id };
            userClaim.InitializeFromClaim(claim);
            return userClaim;
        }

        protected override NccUserLogin CreateUserLogin(NccUser user, UserLoginInfo login)
        {
            return new NccUserLogin
            {
                UserId = user.Id,
                ProviderKey = login.ProviderKey,
                LoginProvider = login.LoginProvider,
                ProviderDisplayName = login.ProviderDisplayName
            };
        }

        protected override NccUserToken CreateUserToken(NccUser user, string loginProvider, string name, string value)
        {
            return new NccUserToken
            {
                UserId = user.Id,
                LoginProvider = loginProvider,
                Name = name,
                Value = value
            };
        }
    }
}
