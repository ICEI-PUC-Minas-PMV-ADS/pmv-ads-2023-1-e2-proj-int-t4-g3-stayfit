using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StayFit.Context;
using StayFit.Models;
using StayFit.ViewModels;
using System.Security.Claims;

namespace StayFit.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;
        private readonly helpers.Interfaces.ISession _session;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private int salt = 15935;
        /*
		   public LoginController(AppDbContext context, helpers.Interfaces.ISession session)
        {
            _context = context;
            _session = session;
        }
        */
        public LoginController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }




        public IActionResult Index()
        {
            return View();
        }

        /*[HttpPost]
        public async Task<IActionResult> Login([Bind("Email,Senha")] Usuario usuario)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.Email == usuario.Email);
            ViewBag.msg = "";

            if (user == null)
            {   
                ViewBag.msg = "Email e/ou senha invalida(s)";
                return View("Index");
            }

			//System.Diagnostics.Debug.WriteLine("=====================");
			
			bool isPassValid = BCrypt.Net.BCrypt.Verify(usuario.Senha, user.Senha);


            if(!isPassValid)
            {
				ViewBag.msg = "Email e/ou senha invalida(s)";
				return View("Index");
            }

            //var claims = new List<Claim>
            //{
            //    new Claim(ClaimTypes.Name, user.Nome),
            //    new Claim(ClaimTypes.NameIdentifier, user.UsuarioId.ToString()),
            //    new Claim(ClaimTypes.Role, user.UsuarioId.ToString())
              
            //};

            //var userIdentity = new ClaimsIdentity(claims, "login");
            //ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

            //var props = new AuthenticationProperties
            //{
            //    AllowRefresh = true,
            //    ExpiresUtc = DateTime.Now.ToLocalTime().AddDays(1),
            //    IsPersistent = true,
            //};



            //await HttpContext.SignInAsync(principal, props);

            return View("~/Views/Home/Index.cshtml", user);
        }

        */

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Email,Senha")] Usuario usuario)
        {
            ViewBag.msg = "";
    //        if (!ModelState.IsValid)
    //        {
				//ViewBag.msg = "Erro no formulario";
				//return View("Index", usuario);
    //        }

            var user = await _userManager.FindByNameAsync(usuario.Email);

            System.Diagnostics.Debug.WriteLine("======" + usuario.Email);
            if (user != null)
            {               
				var result = await _signInManager.PasswordSignInAsync(user, usuario.Senha, false, false);
                if (result.Succeeded)
                {
                    usuario.Nome = user.UserName;
                    usuario.Foto = user.Foto;

                    /*   if (string.IsNullOrEmpty(loginVM.ReturnUrl))
                       {
                           return RedirectToAction("Index", "Home");
                       }
                    */
                    return RedirectToAction("Index", "Home");
                }
                else
                {
					ModelState.AddModelError("", "Falha não encontrado!!");
				}
            }
  

            ModelState.AddModelError("", "Falha ao realizar login!!");
            return View("Index", usuario);
        }



        
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.User = null;
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
