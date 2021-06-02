using Project_Hotstar.Models.Authentication;
using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectHotstar.Models
{
    public partial class UserAccount
    {
        public UserAccount()
        {
            Subscriptions = new HashSet<Subscription>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime? Dob { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser applicationUser { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
