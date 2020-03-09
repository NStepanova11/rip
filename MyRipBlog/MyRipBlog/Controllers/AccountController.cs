using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MyRipBlog.ViewModels; // пространство имен моделей RegisterModel и LoginModel
using MyRipBlog.Models; // пространство имен UserContext и класса User
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace MyRipBlog.Controllers
{
    public class AccountController : Controller
    {
        IRepository<User> _dbUser;
        public AccountController(MyRipBlogContext context)
        {
            _dbUser = new UserRepository(context);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User userEmail = await _dbUser.GetByEmail(model.Email);
                User userName = await _dbUser.GetByUsername(model.Username);
                if (userEmail == null && userName == null)
                {
                    var user = new User
                    {
                        Email = model.Email,
                        Username = model.Username,
                        Password = model.Password
                    };
                    await _dbUser.Create(user);

                    await Authenticate(model.Email); // аутентификация

                    return RedirectToAction("Profile", "Account");
                }
                else if (userEmail!=null)
                    ModelState.AddModelError("Email", "Пользователь с таким email уже существует");
                else if (userName!=null)
                    ModelState.AddModelError("Username", "Пользователь с таким именем уже существует");


            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User userEmail = await _dbUser.GetByEmail(model.Email);

                if (userEmail != null)
                {
                    if (userEmail.Email == model.Email && userEmail.Password == model.Password)
                    {
                        await Authenticate(model.Email); // аутентификация

                        return RedirectToAction("Profile", "Account");
                    }
                    else
                        ModelState.AddModelError("Email", "Некорректные логин и(или) пароль");

                }

                ModelState.AddModelError("Email", "Некорректные логин и(или) пароль");
            }

            return View(model);
        }

        private async Task Authenticate(string userEmail)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userEmail)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        
        [Authorize]
        public async Task<IActionResult> ProfileAsync()
        {
            string userEmail = User.Identity.Name;
            User user = await _dbUser.GetByEmail(userEmail);

            ViewData["Username"] = user.Username;
            return View();
        }
        
    }
}