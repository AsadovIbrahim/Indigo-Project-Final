using DataBase.Entities.Concretes;
using DataBase.Repositories.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Indigo_Web_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles ="Admin")]
    public class MenuController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MenuController(IPostRepository postRepository, IWebHostEnvironment webHostEnvironment)
        {
            _postRepository = postRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _postRepository.GetAllAsync();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }
            string path = _webHostEnvironment.WebRootPath + @"\Upload\manage\";
            string fileName = Guid.NewGuid() + post.ImgFile.FileName;
            string fullPath = Path.Combine(path, fileName);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                post.ImgFile.CopyTo(stream);
            }
            post.ImgUrl = fileName;
            await _postRepository.AddAsync(post);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _postRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]

        public async Task<IActionResult> Update(int id)
        {
            var existingItem = await _postRepository.GetByIdAsync(id);
            return View(existingItem);
        }

        [HttpPost]
        public IActionResult Update(Post post)
        {
            if (!ModelState.IsValid) {
                return View(post);
            }
            if (post.ImgFile != null) {

                string path = _webHostEnvironment.WebRootPath + @"\Upload\manage\";
                string fileName = Guid.NewGuid() + post.ImgFile.FileName;
                string fullPath = Path.Combine(path, fileName);

                using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                {
                    post.ImgFile.CopyTo(stream);
                }
                post.ImgUrl = fileName;
            }
            _postRepository.UpdateAsync(post);
            return RedirectToAction("Index");
        }

    }
}
