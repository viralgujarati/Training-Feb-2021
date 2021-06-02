using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_Hotstar.Repo.IRepository;
using Project_Hotstar.Repo.Repository;
using Project_Hotstar.Models;

namespace Project_Hotstar.Repo.Repository
{
    public class GenreRepo : GenericRepository<UserAccount>, IGenre
    {
        public GenreRepo(HotstarDBContext context) : base(context)
        {

        }
    }
}
