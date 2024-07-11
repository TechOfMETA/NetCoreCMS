using System.Collections.Generic;
using NetCoreCMS.Framework.Core.Models;

namespace Core.Blog.Models
{
    public class RecentPostViewModel
    {
        public bool IsDateShow { get; set; }
        public List<NccPost> PostList { get; set; }
    }
}
