using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TakedaMockModels;
using TakedaServices.Contracts;

namespace TakedaMock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllOrigins")]
    public class MembersController: ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public MembersController(IWebHostEnvironment webHostEnvironment,IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/Members/GetAll
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            var members = await _unitOfWork.MemberRepository.GetAll();
            return Ok(members);
        }

        // GET: api/Members/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(int id)
        {
            var member = await _unitOfWork.MemberRepository.Get(u=> u.Id == id);
            return Ok(member);
        }

        // POST: api/Members

        [HttpPost]
        public async Task<IActionResult> PostMember([FromForm] Member createMember)
        {
            if (createMember == null)
            {
                return BadRequest("Member data is required.");
            }

            return Ok(createMember);
        }

        // PUT: api/Members/5

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

        // DELETE: api/Members/5
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
