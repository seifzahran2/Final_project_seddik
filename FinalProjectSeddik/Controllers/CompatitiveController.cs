using FinalProjectSeddik.Data;
using FinalProjectSeddik.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectSeddik.Controllers
{
    public class CompatitiveController : Controller
    {
        private AppDbContext db;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        public CompatitiveController(AppDbContext context, UserManager<ApplicationUser> applicationUser, SignInManager<ApplicationUser> signInManager)
        {
            db = context;
            _userManager = applicationUser;
            _signInManager = signInManager;
        }

        // صفحه التقديم في المسابقه


        // نهايه صفحه التقديم في المسابقه

        //  صفحه ارسال المشروع

        public async Task<IActionResult> UploadProject()
        {

            ViewBag.user = await _userManager.GetUserAsync(User);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadProject(UploadProject model)
        {

            var user = await _userManager.GetUserAsync(User);
            model.Specialization = user.Specialization;

            db.UploadProject.Add(model);
            db.SaveChanges();
            user.IsProjSent = true;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Home");
        }
        // نهايه صفحه ارسال المشروع

        // بروفايل ال Comptitve
        public IActionResult ComptitveProfile()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = db.ComptitveRegistration.FirstOrDefault();

            return View(user);
        }
    }
}
