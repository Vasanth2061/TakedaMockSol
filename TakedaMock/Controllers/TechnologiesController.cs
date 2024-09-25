using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakedaMockModels;
using TakedaServices.Contracts;

namespace TakedaMock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TechnologiesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Technologies/GetAll
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Technology>>> GetTechnologies()
        {
            var members = await _unitOfWork.TechnologyRepository.GetAll();
            return Ok(members);
        }

        // GET: api/Technologies/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Technology>> GetTechnology(int id)
        {
            var member = await _unitOfWork.TechnologyRepository.Get(u => u.Id == id);
            return Ok(member);
        }

        // POST: api/Technologies
        [HttpPost]
        public async Task PostTechnology(Technology technology)
        {
            await _unitOfWork.TechnologyRepository.Add(technology);
            await _unitOfWork.Save();
        }

        // PUT: api/Technologies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTechnology(int id, Technology technology)
        {

            Technology DbTechnology = await _unitOfWork.TechnologyRepository.Get(u => u.Id == id);
            if (DbTechnology == null)
            {
                return NotFound();
            }
            await _unitOfWork.TechnologyRepository.Update(id,technology);
            await _unitOfWork.Save();

            return NoContent();
        }

        // DELETE: api/Technologies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechnology(int id)
        {
            var technology = await _unitOfWork.TechnologyRepository.Get(u => u.Id == id);
            _unitOfWork.TechnologyRepository.Remove(technology);
            await _unitOfWork.Save();
            return NoContent();
        }
    }
}
