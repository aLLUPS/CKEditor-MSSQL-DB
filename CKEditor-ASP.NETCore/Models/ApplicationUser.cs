using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CKEditor_ASP.NETCore.Models
{
    public partial class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            UserArticles = new HashSet<UserArticle>();
        }

        public virtual ICollection<UserArticle> UserArticles { get; set; }
    }
}
