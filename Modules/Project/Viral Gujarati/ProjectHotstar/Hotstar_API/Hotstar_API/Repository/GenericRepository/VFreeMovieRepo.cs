using Hotstar_API.Models;
using Hotstar_API.Repository.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotstar_API.Repository.GenericRepository
{
    public class VFreeMovieRepo : GenericRepository<VFreeMovie>, IVFreeMovie
    {
        public VFreeMovieRepo(HOTSTARDATAContext context) : base(context)
        {

        }
    }
}

