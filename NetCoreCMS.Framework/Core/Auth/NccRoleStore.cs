/*************************************************************
 *          Project: NetCoreCMS                              *
 *              Web: http://dotnetcorecms.org                *
 *           Author: OnnoRokom Software Ltd.                 *
 *          Website: www.onnorokomsoftware.com               *
 *            Email: info@onnorokomsoftware.com              *
 *        Copyright: OnnoRokom Software Ltd.                 *
 *          License: BSD-3-Clause                            *
 *************************************************************/

using System;
using System.Security.Claims;
using NetCoreCMS.Framework.Core.Data;
using NetCoreCMS.Framework.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Extensions.Internal;
using System.Linq;

namespace NetCoreCMS.Framework.Core.Auth
{
    public class NccRoleStore : RoleStore<NccRole, NccDbContext, long, NccUserRole, NccRoleClaim>
    {
        public NccRoleStore(NccDbContext context) : base(context)
        {
        }
        protected override NccRoleClaim CreateRoleClaim(NccRole role, Claim claim)
        {
            return new NccRoleClaim { RoleId = role.Id, ClaimType = claim.Type, ClaimValue = claim.Value };
        }
        public override async Task<NccRole> FindByNameAsync(string normalizedName, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            return await Roles.FirstOrDefaultAsync(r => r.NormalizedName == normalizedName, cancellationToken);
        }
        //internal object FindByNameAsync(object reader)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
