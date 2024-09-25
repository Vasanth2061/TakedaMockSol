using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TeamMembersController(IWebHostEnvironment webHostEnvironment, IUnitOfWork unitOfWork)
        {
            _webHostEnvironment = webHostEnvironment;
            _unitOfWork = unitOfWork;

        }

        // GET: api/TeamMembers/GetAll
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Colleague>>> GetAllTeamMembers()
        {
            IEnumerable<Colleague> result = await _unitOfWork.ColleagueRepository.GetAll();
            IEnumerable<Colleague> members = result.Where(u => u.IsTeamMember == true);
            return Ok(members);
        }

        // GET: api/TeamMembers/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Colleague>> GetTeamMember(int id)
        {
            var colleague = await _unitOfWork.ColleagueRepository.Get(u => u.Id == id);
            return Ok(colleague);
        }

        // POST: api/TeamMembers
        
        [HttpPost]
        public async Task PostTeamMember([FromForm] Colleague colleague, [FromForm] IFormFile? file)
        {
            if (file != null && file.Length > 0)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(wwwRootPath, "images", "colleagues", fileName);

                colleague.ImageURL = filePath;

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }                
            }
            await _unitOfWork.ColleagueRepository.Add(colleague);
            await _unitOfWork.Save();
        }

        // PUT: api/TeamMembers/5
       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamMember(int id, Colleague colleagueMet, [FromForm] IFormFile? file)
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

                colleagueMet.ImageURL = @"\images\colleagues\" + fileName;
            }

            DbColleague.ColleagueName = colleagueMet.ColleagueName;
            _unitOfWork.ColleagueRepository.Update(DbColleague);
            await _unitOfWork.Save();

            return NoContent();
        }

        // DELETE: api/TeamMembers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamMember(int id)
        {
            var colleague = await _unitOfWork.ColleagueRepository.Get(u => u.Id == id);
            _unitOfWork.ColleagueRepository.Remove(colleague);
            await _unitOfWork.Save();
            return NoContent();
        }

        //[HttpPost("upload-image")]
        //public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
        //{
        //    if (file != null && file.Length > 0)
        //    {
        //        string wwwRootPath = _webHostEnvironment.WebRootPath;
        //        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        //        string filePath = Path.Combine(wwwRootPath, "images", "product", fileName);

        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await file.CopyToAsync(fileStream);
        //        }

        //        // Return the image URL or file name to the client
        //        return Ok(new { imageUrl = "/images/product/" + fileName });
        //    }
        //    else
        //    {
        //        return BadRequest("No file uploaded");
        //    }
        //}
    }
}
