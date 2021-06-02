using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_Hotstar.Repo.IRepository;
using Project_Hotstar.Repo.Repository;
using Project_Hotstar.Models;
using Project_Hotstar.Repo.Interface;

namespace Project_Hotstar.Repo.Repository
{
    public class SubscriptionRepo : GenericRepository<Subscription>, ISubscriptionRepo
    {
        public SubscriptionRepo(HotstarDBContext context) : base(context)
        {

        }
    }
}
