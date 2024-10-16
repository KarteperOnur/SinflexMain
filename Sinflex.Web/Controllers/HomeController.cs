using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sinflex.BLL.Repositories.Abstracts;
using Sinflex.BLL.Repositories.ViewModels.AppUserViewModels;
using Sinflex.BLL.Repositories.ViewModels.MovieViewModels;
using Sinflex.Model.Entities;
using Sinflex.Web.Models;
using System.Diagnostics;


namespace Sinflex.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;


        public HomeController(ILogger<HomeController> logger, IMovieService movieService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _movieService = movieService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index(DateTime? searchDate, string searchFilter, bool isSecondClick)
        {
            IEnumerable<MovieListModel> movies;

            if (searchDate.HasValue)
            {
                movies = _movieService.GetByDate(searchDate.Value);
            }
            else
            {
                movies = _movieService.GetAllMovies(searchFilter, isSecondClick);
            }

            ViewBag.ClickValue = isSecondClick ? "false" : "true";
            return View(movies);
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {

                AppUser user = new AppUser
                {
                    Email = registerViewModel.Email,
                    UserName = registerViewModel.Username,
                    Address = registerViewModel.Address,
                    EconomicalStatus = registerViewModel.EconomicalStatus,
                    BirthDate = registerViewModel.BirthDate,
                    UserType = Core.Enums.UserType.Regular,
                    Profession = registerViewModel.Profession,
                    PhoneNumber = registerViewModel.PhoneNumber,
                    Gender = registerViewModel.Gender,
                    EmailConfirmed = registerViewModel.Email == registerViewModel.ConfirmEmail ? true : false,

                };

                var result = await _userManager.CreateAsync(user, registerViewModel.ConfirmPassword);

                if (result.Succeeded)
                {
                    //var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    //var encodeToken = HttpUtility.UrlEncode(emailToken);


                    //string confirmationLink = Url.Action("Activation", "Home", new { id = user.Id, token = encodeToken }, Request.Scheme);

                    //string body = $"Merhaba {registerViewModel.Username} kayýt olduðunuz için teþekkürler. Hesabýný aktif hale getirebilmek için ilgili linki týklayýn. {confirmationLink}";

                    ////todo: Konfirmasyon maili gönderilecek.
                    //EmailSender.SendEmail(registerViewModel.Email, "Aktivasyon Maili", body);

                    //TempData["Success"] = $"belirlemiþ olduðunuz {registerViewModel.Email} adresine aktivasyon maili gönderildi. Lütfen ilgili linki týklayarak üyeliðinizi aktif hale getirin.";
                }
                else
                {
                    TempData["Error"] = $"Bir hata meydana geldi";
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(registerViewModel);
            }
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {



                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.Remember, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }

                }

                return View();

            }
            else
            {
                return View(loginViewModel);
            }

        }

        public async Task<IActionResult> Signout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();

            }


            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
