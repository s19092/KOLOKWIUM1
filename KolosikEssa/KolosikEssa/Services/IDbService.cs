
using KolosikEssa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolosikEssa.Services
{
    public interface IDbService
    {

        public Project GetProject(int id);

        public bool Add(Models.Task taskReq);

    }
}
