using System;

namespace CKEditor_ASP.NETCore.Models
{
    public class UserArticle
    {
        public int ArticleId { get; set; }
        public string UserId { get; set; }
        public string ArticleTitle { get; set; }
        public string Description { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
