using Hotstar_API.Models;
using Hotstar_API.Repository.IGenericRepository;
using Hotstar_API.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Hotstar_API.Repository.GenericRepository
{
    public class UserAccountRepo : GenericRepository<UserAccount>, IUserAccount
    {
        private readonly HOTSTARDATAContext _context;
        public UserAccountRepo(HOTSTARDATAContext context) : base(context)
        {
            this._context = context;
        }

        public bool ValidateUser(string cred, int id)
        {
            var user = this._context.UserAccounts.AsNoTracking().SingleOrDefault(x => x.CustomerId == id);
            if (user == null || user.ApplicationUserId != cred)
            {
                return false;
            }
            return true;
        }
    }
}

