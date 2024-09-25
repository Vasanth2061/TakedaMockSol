using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakedaMockModels;
using TakedaServices.Contracts;
using TakedaServices.Repositories;

namespace TakedaMock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingActivitiesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainingActivitiesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/TrainingActivities/GetAll
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<TrainingActivity>>> GetTrainingActivities()
        {
            var members = await _unitOfWork.TrainingActivityRepository.GetAll();
            return Ok(members);
        }

        // GET: api/TrainingActivities/1
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingActivity>> GetTrainingActivity(int id)
        {
            var member = await _unitOfWork.TrainingActivityRepository.Get(u => u.Id == id);
            return Ok(member);
        }

        // POST: api/TrainingActivities
        [HttpPost]
        public async Task PostTraingingActivity(TrainingActivity trainingActivity)
        {
            await _unitOfWork.TrainingActivityRepository.Add(trainingActivity);
            await _unitOfWork.Save();
        }

        // PUT: api/TrainingActivities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainingActivity(int id, TrainingActivity trainingActivity)
        {

            TrainingActivity DbTrainingActivity = await _unitOfWork.TrainingActivityRepository.Get(u => u.Id == id);
            if (DbTrainingActivity == null)
            {
                return NotFound();
            }
            await _unitOfWork.TrainingActivityRepository.Update(id,trainingActivity);
            await _unitOfWork.Save();

            return NoContent();
        }

        // DELETE: api/TrainingActivities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingActivity(int id)
        {
            var trainingActivity = await _unitOfWork.TrainingActivityRepository.Get(u => u.Id == id);
            _unitOfWork.TrainingActivityRepository.Remove(trainingActivity);
            await _unitOfWork.Save();
            return NoContent();
        }
    }
}
