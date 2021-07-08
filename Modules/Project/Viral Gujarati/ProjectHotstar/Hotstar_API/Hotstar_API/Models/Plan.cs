using System;
using System.Collections.Generic;

#nullable disable

namespace Hotstar_API.Models
{
    public partial class Plan
    {
        public Plan()
        {
            Contents = new HashSet<Content>();
            SubcriptionPriceLists = new HashSet<SubcriptionPriceList>();
            SubscriptionDetails = new HashSet<SubscriptionDetail>();
        }

        public int PlanId { get; set; }
        public string PlanCategory { get; set; }

        public virtual ICollection<Content> Contents { get; set; }
        public virtual ICollection<SubcriptionPriceList> SubcriptionPriceLists { get; set; }
        public virtual ICollection<SubscriptionDetail> SubscriptionDetails { get; set; }
    }
}
