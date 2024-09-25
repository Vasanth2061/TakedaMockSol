using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakedaMockModels;

namespace TakedaServices.Contracts
{
    public interface IPersonalImageRepository : IRepository<PersonalImage>
    {
        void Update(PersonalImage obj);
    }
}
