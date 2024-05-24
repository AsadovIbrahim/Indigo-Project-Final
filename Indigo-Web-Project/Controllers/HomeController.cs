using DataBase.Repositories.Abstracts;
using Indigo_Web_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Indigo_Web_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostRepository _postRepository;
        public HomeController(ILogger<HomeController> logger,IPostRepository postRepository)
        {
            _logger = logger;
            _postRepository = postRepository;
        }

        public async Task<IActionResult> Index()
        {
            var data=await _postRepository.GetAllAsync();
            return View(data);
        }

       
    }
}
