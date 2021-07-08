using System;
using System.Collections.Generic;

#nullable disable

namespace Hotstar_API.Models
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            Contents = new HashSet<Content>();
        }

        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int? ParentCategoryId { get; set; }

        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Content> Contents { get; set; }
    }
}
