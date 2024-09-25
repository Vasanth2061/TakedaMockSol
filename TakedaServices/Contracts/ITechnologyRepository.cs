using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakedaMockModels;

namespace TakedaServices.Contracts
{
    public interface ITechnologyRepository : IRepository<Technology>
    {
        Task Update(int id,Technology obj);
    }
}
