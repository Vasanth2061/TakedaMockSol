using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakedaMockModels;
using TakedaServices.Contracts;

namespace TakedaMock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMembersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamMembersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/MembersMet/GetAll
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Colleague>>> GetAllTeamMembers()
        {
            IEnumerable<Colleague> result = await _unitOfWork.ColleagueRepository.GetAll();
            IEnumerable<Colleague> members = result.Where(u => u.IsTeamMemeber == true);
            return Ok(members);
        }

        // GET: api/MembersMet/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Colleague>> GetTeamMember(int id)
        {
            var colleague = await _unitOfWork.ColleagueRepository.Get(u => u.Id == id);
            return Ok(colleague);
        }

        // POST: api/MembersMet
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task PostTeamMember(Colleague colleague)
        {
            await _unitOfWork.ColleagueRepository.Add(colleague);
            await _unitOfWork.Save();
        }

        // PUT: api/MembersMet/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamMember(int id, Colleague colleagueMet)
        {

            Colleague DbColleague = await _unitOfWork.ColleagueRepository.Get(u => u.Id == id);
            if (DbColleague == null)
            {
                return NotFound();
            }
            DbColleague.Name = colleagueMet.Name;
            _unitOfWork.ColleagueRepository.Update(DbColleague);
            await _unitOfWork.Save();

            return NoContent();
        }

        // DELETE: api/MembersMet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamMember(int id)
        {
            var colleague = await _unitOfWork.ColleagueRepository.Get(u => u.Id == id);
            _unitOfWork.ColleagueRepository.Remove(colleague);
            await _unitOfWork.Save();
            return NoContent();
        }
    }
}
