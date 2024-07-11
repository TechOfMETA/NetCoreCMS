using Microsoft.AspNetCore.Mvc;
using NetCoreCMS.Framework.Core.Models;

namespace Core.Blog
{
    public static class ModuleExtensions
    {
        public static string PostUrl(this IUrlHelper urlHelper, NccPostDetails postDetails)
        {
            return urlHelper.Action("Index", "Post", new { slug = postDetails.Slug });
        }
    }
}
