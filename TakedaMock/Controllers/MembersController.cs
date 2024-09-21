using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TakedaMockModels;
using TakedaServices.Contracts;

namespace TakedaMock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController: ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MembersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/members/GetAll
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            var members = await _unitOfWork.MemberRepository.GetAll();
            return Ok(members);
        }

        // GET: api/members/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(int id)
        {
            var member = await _unitOfWork.MemberRepository.Get(u=> u.Id == id);
            return Ok(member);
        }

        // POST: api/members
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task PostMember(Member createMember)
        {
            await _unitOfWork.MemberRepository.Add(createMember);
            await _unitOfWork.Save();
        }

        // PUT: api/members/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(int id, Member member)
        {
            
            Member DbMember=await _unitOfWork.MemberRepository.Get(u=> u.Id == id);
            if(DbMember == null)
            {
                return NotFound();
            }
            DbMember.Name= member.Name;
            _unitOfWork.MemberRepository.Update(DbMember);
            await _unitOfWork.Save();

            return NoContent();
        }

        // DELETE: api/members/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var member=await _unitOfWork.MemberRepository.Get(u=> u.Id == id);
            _unitOfWork.MemberRepository.Remove(member);
            await _unitOfWork.Save();
            return NoContent();
        }

    }
}
