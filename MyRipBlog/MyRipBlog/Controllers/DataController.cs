using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyRipBlog.Models;

namespace MyRipBlog.Controllers
{
    public class DataController : Controller
    {
        IRepository<User> _dbUser;
        IRepository<Tag> _dbTag;
        public DataController(MyRipBlogContext context)
        {
            _dbUser = new UserRepository(context);
            _dbTag = new TagRepository(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Tags()
        {
            return View(_dbTag.GetAll());
        }

        public async Task<IActionResult> Users()
        {
            return View(_dbUser.GetAll());
        }
    }
}