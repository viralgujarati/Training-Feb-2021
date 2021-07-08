using System;
using System.Collections.Generic;

#nullable disable

namespace Hotstar_API.Models
{
    public partial class VFreeMovie
    {
        public int ContentId { get; set; }
        public string ContentLink { get; set; }
        public string ContentPosterLink { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? SuitableAge { get; set; }
        public int? SubCategoryId { get; set; }
        public int CategoryId { get; set; }
        public int? PlanId { get; set; }
        public string ContentLanguage { get; set; }
    }
}
