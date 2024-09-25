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
    public class HobbyRepository : Repository<Hobby>, IHobbyRepository
    {
        private readonly ApplicationDbContext _db;
        public HobbyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Hobby obj)
        {
            _db.Hobbies.Update(obj);
        }
    }
}
