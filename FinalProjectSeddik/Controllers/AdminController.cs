using FinalProjectSeddik.Data;
using FinalProjectSeddik.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectSeddik.Controllers
{
    public class AdminController : Controller
    {
        private AppDbContext _App;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;
        public AdminController(AppDbContext App, UserManager<ApplicationUser> applicationUser, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _App = App;
            _userManager = applicationUser;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        
        public IActionResult Index(string id)
        {
            var contacts = _App.ContactUs.ToList();
            int Comps = 0;
            int Judges = 0;
            foreach (var item in _roleManager.Roles)
            {
                if (item.Name == "Comp")
                {
                    Comps++;
                }
                if (item.Name == "Judge")
                {
                    Judges++;
                }
            }
            ViewBag.CompsCount = Comps;
            ViewBag.JudgesCount = Judges;
            ViewBag.compReg = _App.ComptitveRegistration.Where(b=>b.IsAccepted==false).ToList();
            ViewBag.contact = _App.ContactUs.Where(r => r.Id == id).FirstOrDefault();
            ViewBag.requests = _App.ContactUs.Where(r => r.Id == id).FirstOrDefault();
            return View(contacts);
        }
        //public IActionResult Index()

        public IActionResult CompRequest(int id)
        {
            var RequestComp = _App.ComptitveRegistration.Where(d => d.Id == id).FirstOrDefault();
            return View(RequestComp);
        }
        [HttpPost]
        public async Task<IActionResult> CompRequest(int id,string fake)
        {
            var requests = _App.ComptitveRegistration.Where(r => r.Id == id).FirstOrDefault();
            var user = _userManager.Users.Where(u => u.Email == requests.Email).FirstOrDefault();
            requests.IsAccepted = true;
            await _userManager.AddToRoleAsync(user, "Comp");
            _App.SaveChanges();
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index","Admin");
        }

        public IActionResult Contact(string id)
        {
            var contact = _App.ContactUs.Where(d => d.Id == id).FirstOrDefault();
           
            return View(contact);
        }
        public IActionResult Result()
        {
            var result = _App.ComptitveRegistration.ToList();
            return View(result);
        }
        public async Task<IActionResult> UserMangment()
        {
            var user = await _userManager.Users.Select(user => new UserVm
            {
                Id = user.Id,
                Name = user.Name,
                Specialization = user.Specialization,
                Email = user.Email,
                Roles = _userManager.GetRolesAsync(user).Result
            }).ToListAsync();
            return View(user);
        }


        public IActionResult JopSelction(string id)
        {

            var JopSelction = _userManager.Users.Where(x => x.Id == id).FirstOrDefault();

            return View(JopSelction);
        }
        [HttpPost]
        public async Task<IActionResult> JopSelction(string id, ApplicationUser _user)
        {
            var user = _userManager.Users.Where(x => x.Id == id).FirstOrDefault();

            user.Specialization = _user.Specialization;
            if (_user.Role == "متحكم")
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            else if (_user.Role == "مستخدم")
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
            else if (_user.Role == "مصحح")
            {
                await _userManager.AddToRoleAsync(user, "Judge");
            }

            await _userManager.UpdateAsync(user);
            return RedirectToAction("UserMangment");
        }
    }
}
