using FinalProjectSeddik.Data;
using FinalProjectSeddik.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace FinalProjectSeddik.Controllers
{
    public class JudgeController : Controller
    {
        private AppDbContext db;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        public JudgeController(AppDbContext context, UserManager<ApplicationUser> applicationUser, SignInManager<ApplicationUser> signInManager)
        {
            db = context;
            _userManager = applicationUser;
            _signInManager = signInManager;
        }

        // صفحه البروفايل بتاع الجادج
        public async Task<IActionResult> ProfileUg()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(user);
        }


        // صفحه مراجعة المشروع بتاع الجادج
        public IActionResult JudgeDeg()
        {
            var user = db.UploadProject.ToList();
            return View(user);
        }
    }
}
