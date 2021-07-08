using System;
using System.Collections.Generic;

#nullable disable

namespace Hotstar_API.Models
{
    //spelling mistake in subscription modal name 

    public partial class SubcriptionPriceList
    {
        public SubcriptionPriceList()
        {
            SubscriptionDetails = new HashSet<SubscriptionDetail>();
        }

        public int Id { get; set; }
        public int? PlanId { get; set; }
        public string Validity { get; set; }
        public decimal Price { get; set; }

        public virtual Plan Plan { get; set; }
        public virtual ICollection<SubscriptionDetail> SubscriptionDetails { get; set; }
    }
}
