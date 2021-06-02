using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectHotstar.Models
{
    public partial class News
    {
        public int NewsId { get; set; }
        public int? ContentId { get; set; }
        public string NewsTitle { get; set; }
        public string MovieLanguage { get; set; }

        public virtual Content Content { get; set; }
    }
}
