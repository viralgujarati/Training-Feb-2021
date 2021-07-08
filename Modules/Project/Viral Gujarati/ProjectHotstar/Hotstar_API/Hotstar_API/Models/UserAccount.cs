using Hotstar_API.Models.Authentication;
using System;
using System.Collections.Generic;

#nullable disable

namespace Hotstar_API.Models
{
    public partial class UserAccount
    {
        public UserAccount()
        {
            SubscriptionDetails = new HashSet<SubscriptionDetail>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
#nullable enable
        public string Address { get; set; }

        public DateTime? Dob { get; set; }

        //changes
        public string ApplicationUserId { get; set; }

        public ApplicationUser applicationUser { get; set; }

        public virtual ICollection<SubscriptionDetail> SubscriptionDetails { get; set; }
    }
}



