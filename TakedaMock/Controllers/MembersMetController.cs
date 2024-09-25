using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakedaMockModels;
using TakedaServices.Contracts;

namespace TakedaMock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersMetController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public MembersMetController(IWebHostEnvironment webHostEnvironment,IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/MembersMet/GetAll
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Colleague>>> GetAllMembersMet()
        {
            IEnumerable<Colleague> members = await _unitOfWork.ColleagueRepository.GetAll();//IEnumerable<Colleague> members = result.Where(u => u.IsTeamMemeber == false);
            return Ok(members);
        }

        // GET: api/MembersMet/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Colleague>> GetMemberMet(int id)
        {
            var colleague = await _unitOfWork.ColleagueRepository.Get(u => u.Id == id);
            return Ok(colleague);
        }

        // POST: api/MembersMet

        [HttpPost]
        public async Task<IActionResult> PostMemberMet([FromForm] Colleague colleague, [FromForm] IFormFile? file)
        {
            if (colleague == null)
            {
                return BadRequest("Colleague data is required.");
            }

            colleague.ImageURL = " ";

            if (file != null && file.Length > 0)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(wwwRootPath, "images", "colleagues", fileName);

                colleague.ImageURL = $"images/colleagues/{fileName}";

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }

            await _unitOfWork.ColleagueRepository.Add(colleague);
            await _unitOfWork.Save();

            return Ok(colleague);
        }

        

        // PUT: api/MembersMet/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMemberMet(int id, [FromForm] Colleague colleagueMet, [FromForm] IFormFile? file)
        {

            Colleague DbColleague = await _unitOfWork.ColleagueRepository.Get(u => u.Id == id);
            if (DbColleague == null)
            {
                return NotFound();
            }

            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(wwwRootPath, @"images\colleagues");

                if (!string.IsNullOrEmpty(colleagueMet.ImageURL))
                {
                    //delete the old image
                    var oldImagePath =
                        Path.Combine(wwwRootPath, colleagueMet.ImageURL.TrimStart('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                using (var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                colleagueMet.ImageURL = @"images\colleagues\" + fileName;
            }
            await _unitOfWork.ColleagueRepository.Update(id,colleagueMet);
            await _unitOfWork.Save();

            return NoContent();
        }

        // DELETE: api/MembersMet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMemberMet(int id)
        {
            var colleague = await _unitOfWork.ColleagueRepository.Get(u => u.Id == id);
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            if (!string.IsNullOrEmpty(colleague.ImageURL))
            {
                //delete the old image
                var oldImagePath =
                    Path.Combine(wwwRootPath, colleague.ImageURL.TrimStart('\\'));

                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }
            _unitOfWork.ColleagueRepository.Remove(colleague);
            await _unitOfWork.Save();
            return NoContent();
        }
    }
}
