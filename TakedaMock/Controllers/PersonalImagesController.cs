using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakedaMockModels;
using TakedaServices.Contracts;

namespace TakedaMock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalImagesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonalImagesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/TrainingActivities/GetAll
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<PersonalImage>>> GetPersonalImages()
        {
            var members = await _unitOfWork.PersonalImageRepository.GetAll(); 
            return Ok(members);
        }

        // GET: api/TrainingActivities/1
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalImage>> GetPersonalImage(int id)
        {
            var member = await _unitOfWork.PersonalImageRepository.Get(u => u.Id == id);
            return Ok(member);
        }

        // POST: api/TrainingActivities
        [HttpPost]
        public async Task PostPersonalImage(PersonalImage personalImage)
        {
            await _unitOfWork.PersonalImageRepository.Add(personalImage);
            await _unitOfWork.Save();
        }

        // PUT: api/TrainingActivities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalImage(int id, PersonalImage personalImage)
        {

            PersonalImage DbPersonalImage = await _unitOfWork.PersonalImageRepository.Get(u => u.Id == id);
            if (DbPersonalImage == null)
            {
                return NotFound();
            }
            DbPersonalImage.ImageURL = personalImage.ImageURL;
            _unitOfWork.PersonalImageRepository.Update(DbPersonalImage);
            await _unitOfWork.Save();

            return NoContent();
        }

        // DELETE: api/TrainingActivities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalImage(int id)
        {
            var personalImage = await _unitOfWork.PersonalImageRepository.Get(u => u.Id == id);
            _unitOfWork.PersonalImageRepository.Remove(personalImage);
            await _unitOfWork.Save();
            return NoContent();
        }
    }
}
