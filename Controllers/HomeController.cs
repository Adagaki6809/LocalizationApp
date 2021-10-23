using System;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Microsoft.Extensions.Localization;
using LocalizationApp.ViewModels;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace LocalizationApp.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IStringLocalizer<HomeController> _localizer;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;
        private readonly IStringLocalizer _localizer;
        public HomeController(IStringLocalizer localizer,
                   IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _localizer = localizer;
            _sharedLocalizer = sharedLocalizer;
        }

        public string Test()
        {
            // получаем ресурс Message
            string message = _localizer["Message"];
            return message;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = _localizer["Header"];
            ViewData["Message"] = _localizer["Message"];
            return View();
        }

        public string GetCulture(string code = "")
        {
            if (!String.IsNullOrEmpty(code))
            {
                CultureInfo.CurrentCulture = new CultureInfo(code);
                CultureInfo.CurrentUICulture = new CultureInfo(code);
            }
            return $"CurrentCulture:{CultureInfo.CurrentCulture.Name}, CurrentUICulture:{CultureInfo.CurrentUICulture.Name}";
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                return Content("модель добавлена");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}