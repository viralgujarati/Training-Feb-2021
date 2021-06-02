using ProjectHotstar.Models;
using ProjectHotstar.Repository.IGenericRepository;
using ProjectHotstar.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHotstar.Repository.GenericRepository
{
    public class UserAccountRepo : GenericRepository<IUserAccount>, IUserAccount
    {
        public UserAccountRepo(HotstarContext context) : base(context)
        {

        }
    }
}

