using System;
using System.Collections.Generic;

#nullable disable

namespace Hotstar_API.Models
{
    public partial class SubscriptionDetail
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int PlanId { get; set; }
        public int? SubcriptionPriceListId { get; set; }
        public DateTime DateOfSubscription { get; set; }
        public DateTime? ValidThrough { get; set; }

        public virtual UserAccount Customer { get; set; }
        public virtual Plan Plan { get; set; }
        public virtual SubcriptionPriceList SubcriptionPriceList { get; set; }
    }
}
