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
    public class ColleagueRepository : Repository<Colleague>, IColleagueRepository
    {
        private ApplicationDbContext _db;
        public ColleagueRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        
        public void Update(Colleague obj)
        {
            _db.Colleagues.Update(obj);
        }
    }
}
