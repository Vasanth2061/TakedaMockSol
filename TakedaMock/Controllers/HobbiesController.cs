using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakedaMockModels;
using TakedaServices.Contracts;

namespace TakedaMock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbiesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public HobbiesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/TrainingActivities/GetAll
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Hobby>>> GetHobbies()
        {
            var members = await _unitOfWork.HobbyRepository.GetAll();
            return Ok(members);
        }

        // GET: api/TrainingActivities/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Hobby>> GetHobby(int id)
        {
            var hobby = await _unitOfWork.HobbyRepository.Get(u => u.Id == id);
            return Ok(hobby);
        }

        // POST: api/TrainingActivities
        [HttpPost]
        public async Task PostHobby(Hobby hobby)
        {
            await _unitOfWork.HobbyRepository.Add(hobby);
            await _unitOfWork.Save();
        }

        // PUT: api/TrainingActivities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHobby(int id, Hobby hobby)
        {

            Hobby DbHobby = await _unitOfWork.HobbyRepository.Get(u => u.Id == id);
            if (DbHobby == null)
            {
                return NotFound();
            }
            DbHobby.Name = hobby.Name;
            _unitOfWork.HobbyRepository.Update(DbHobby);
            await _unitOfWork.Save();

            return NoContent();
        }

        // DELETE: api/TrainingActivities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> HobbyTechnology(int id)
        {
            var hobby = await _unitOfWork.HobbyRepository.Get(u => u.Id == id);
            _unitOfWork.HobbyRepository.Remove(hobby);
            await _unitOfWork.Save();
            return NoContent();
        }
    }
}
