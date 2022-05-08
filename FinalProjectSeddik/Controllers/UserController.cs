using FinalProjectSeddik.Data;
using FinalProjectSeddik.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectSeddik.Controllers
{
    public class UserController : Controller
    {
        private AppDbContext db;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        public UserController(AppDbContext context, UserManager<ApplicationUser> applicationUser, SignInManager<ApplicationUser> signInManager)
        {
            db = context;
            _userManager = applicationUser;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> ComptitveRegistration()
        {
            ViewBag.user = await _userManager.GetUserAsync(User);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ComptitveRegistration(ComptitveRegistration model)
        {
            db.ComptitveRegistration.Add(model);
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return View("Error");
            user.Specialization = model.Specialization;
            model.Birthday = user.BirthDay;
            model.FullName = user.Name;
            model.Gender = user.gender;
            model.WorkPlace = user.Workplace;
            if (user.Email != model.Email || user.NationalID != model.NationalId)
            {
                TempData["Message"] = "يجب ان يكون الرقم القومي و البريد الالكتروني مطابق لتسجيل الدخول ، راجع صفحتك الشخصية.";
                return RedirectToAction("ComptitveRegistration", "User");
            }
            user.IsRegSent = true;
            await _userManager.UpdateAsync(user);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        // صفحه البروفايل بتاع اليوزر
        public async Task<IActionResult> ProfileUg()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(user);
        }
    }
}

