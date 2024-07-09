using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace NetCoreCMS.Web.Services
{
    public class NothingUserConfirmation<TUser> : IUserConfirmation<TUser> where TUser : class
    {
        public virtual async Task<bool> IsConfirmedAsync(UserManager<TUser> manager, TUser user)
        {
           return await Task.FromResult(true);
        }
    }

}
