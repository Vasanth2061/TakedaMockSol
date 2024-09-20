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
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        private ApplicationDbContext _db;
        public MemberRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Member obj)
        {
            _db.Members.Update(obj);
        }
    }
}
