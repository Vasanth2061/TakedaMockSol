using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakedaMockData;
using TakedaMockModels;
using TakedaServices.Contracts;

namespace TakedaServices.Repositories
{
    public class PersonalImageRepository : Repository<PersonalImage>, IPersonalImageRepository
    {
        private readonly ApplicationDbContext _db;
        public PersonalImageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(PersonalImage obj)
        {
            _db.PersonalImages.Update(obj);
        }
    }
}
