using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectHotstar.Models
{
    public partial class Movie
    {
        public int MovieId { get; set; }
        public int? ContentId { get; set; }
        public string MovieTitle { get; set; }
        public string MovieLanguage { get; set; }

        public virtual Content Content { get; set; }
    }
}
