using Hotstar_API.Models;
using Hotstar_API.Repository.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotstar_API.Repository.GenericRepository
{
    public class ContentRepo : GenericRepository<Content>, IContent
    {
        public ContentRepo(HOTSTARDATAContext context) : base(context)
        {

        }
    }
}
