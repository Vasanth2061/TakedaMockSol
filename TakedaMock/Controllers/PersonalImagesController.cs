using Microsoft.AspNetCore.Hosting;
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

        private readonly IWebHostEnvironment _webHostEnvironment;

        public PersonalImagesController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/PersonalImages/GetAll
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<PersonalImage>>> GetPersonalImages()
        {
            var members = await _unitOfWork.PersonalImageRepository.GetAll(); 
            return Ok(members);
        }

        // GET: api/PersonalImages/1
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalImage>> GetPersonalImage(int id)
        {
            var member = await _unitOfWork.PersonalImageRepository.Get(u => u.Id == id);
            return Ok(member);
        }

        // POST: api/PersonalImages
        [HttpPost]
        public async Task PostPersonalImage([FromForm] IFormFile? file)
        {
            PersonalImage personalImage = new PersonalImage();

            if (file != null && file.Length > 0)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(wwwRootPath, "images", "personalImages", fileName);

                personalImage.ImageURL = $"images/personalImages/{fileName}";

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
            await _unitOfWork.PersonalImageRepository.Add(personalImage);
            await _unitOfWork.Save();
        }

        // PUT: api/PersonalImages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalImage(int id, [FromForm] IFormFile? file)
        {

            PersonalImage DbPersonalImage = await _unitOfWork.PersonalImageRepository.Get(u => u.Id == id);
            if (DbPersonalImage == null)
            {
                return NotFound();
            }

            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(wwwRootPath, @"images\colleagues");

                if (!string.IsNullOrEmpty(DbPersonalImage.ImageURL))
                {
                    //delete the old image
                    var oldImagePath =
                        Path.Combine(wwwRootPath, DbPersonalImage.ImageURL.TrimStart('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                using (var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                DbPersonalImage.ImageURL = @"images\colleagues\" + fileName;
            }
            _unitOfWork.PersonalImageRepository.Update(DbPersonalImage);
            await _unitOfWork.Save();

            return NoContent();
        }

        // DELETE: api/PersonalImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalImage(int id)
        {
            var personalImage = await _unitOfWork.PersonalImageRepository.Get(u => u.Id == id);

            _unitOfWork.PersonalImageRepository.Remove(personalImage);
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (!string.IsNullOrEmpty(personalImage.ImageURL))
             {
                    //delete the old image
                    var oldImagePath =
                        Path.Combine(wwwRootPath, personalImage.ImageURL.TrimStart('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
            await _unitOfWork.Save();
            return NoContent();
        }
    }
}
