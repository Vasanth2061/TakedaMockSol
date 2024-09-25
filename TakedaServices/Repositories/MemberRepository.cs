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
        public async Task Update(int id,Member obj)
        {
            Member DbMember = await Get(u => u.Id == id);
            DbMember.Name = obj.Name;
            DbMember.PhoneNumber = obj.PhoneNumber;
            DbMember.StreetAddress = obj.StreetAddress;
            DbMember.City = obj.City;
            DbMember.State = obj.State;
            DbMember.DateOfBirth = obj.DateOfBirth;
            DbMember.BackGround = obj.BackGround;
            DbMember.PinCode = obj.PinCode;
            _db.Members.Update(DbMember);
        }
    }
}
