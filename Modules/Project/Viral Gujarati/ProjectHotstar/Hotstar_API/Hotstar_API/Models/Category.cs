using System;
using System.Collections.Generic;

#nullable disable

namespace Hotstar_API.Models
{
    public partial class Category
    {
        public Category()
        {
            Contents = new HashSet<Content>();
            SubCategories = new HashSet<SubCategory>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Content> Contents { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
