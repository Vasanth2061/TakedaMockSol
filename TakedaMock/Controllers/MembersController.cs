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

        private readonly IWebHostEnvironment _webHostEnvironment;

        public MembersController(IWebHostEnvironment webHostEnvironment,IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
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
       
        [HttpPost]
        public async Task PostMember(Member createMember, [FromForm] IEnumerable<IFormFile?> files)
        {
            int i = 0;
            foreach (var file in files)
            {
                if (file != null && file.Length > 0)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string filePath = Path.Combine(wwwRootPath, "images", "members", fileName);

                    createMember.Images[i] = filePath;

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                }
                i++;
            }
            await _unitOfWork.MemberRepository.Add(createMember);
            await _unitOfWork.Save();
        }

        // PUT: api/members/5
       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(int id, Member member, [FromForm] IEnumerable<IFormFile?> files)
        {
            
            Member DbMember=await _unitOfWork.MemberRepository.Get(u=> u.Id == id);
            if(DbMember == null)
            {
                return NotFound();
            }

            string wwwRootPath = _webHostEnvironment.WebRootPath;
            int i = 0;
            foreach (var file in files)
            {
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string filePath = Path.Combine(wwwRootPath, @"images\members");

                    if (!string.IsNullOrEmpty(member.Images[i]))
                    {
                        //delete the old image
                        var oldImagePath =
                            Path.Combine(wwwRootPath, member.Images[i].TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    member.Images[i] = @"\images\members\" + fileName;
                }
                i++;
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
