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

        
        public async Task Update(int id,Colleague obj)
        {
            Colleague DbColleague = await Get(u => u.Id == id);
            DbColleague.ColleagueName = obj.ColleagueName;
            DbColleague.IsTeamMember = obj.IsTeamMember;
            DbColleague.ImageURL = obj.ImageURL;
            DbColleague.Description = obj.Description;
            _db.Colleagues.Update(DbColleague);
        }
    }
}
