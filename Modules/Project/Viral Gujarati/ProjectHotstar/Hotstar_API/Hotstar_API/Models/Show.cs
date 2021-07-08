using System;
using System.Collections.Generic;

#nullable disable

namespace Hotstar_API.Models
{
    public partial class Show
    {
        public int ShowId { get; set; }
        public string ShowName { get; set; }
        public int? Episode { get; set; }
        public int? Season { get; set; }
        public int? ContentId { get; set; }

        public virtual Content Content { get; set; }
    }
}
