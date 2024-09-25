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
    public class TechnologyRepository : Repository<Technology>, ITechnologyRepository
    {
        private ApplicationDbContext _db;
        public TechnologyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task Update(int id,Technology obj)
        {
            Technology DbTechnology = await Get(u => u.Id == id);
            DbTechnology.Name = obj.Name;
            DbTechnology.Proficiency = obj.Proficiency;
            _db.Technologies.Update(DbTechnology);
        }
    }
}
