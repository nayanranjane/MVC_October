using IdentityMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdentityMVC.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {

        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
           
        }

        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }

       public IActionResult Create()
        {
            var role = new IdentityRole();
            return View(role);
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            var isRoleExist = await roleManager.RoleExistsAsync(role.Name);
            if (isRoleExist)
            {
                ViewBag.Message = $"Role {role.Name} is already Exist";
                return View(role);
            }
            // create a new role
            var result = await roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Message = $"Role {role.Name} Creation Failed";
            return View(role);
        }
        [Authorize(Roles ="Admin")]
        public IActionResult AssignRoleToUser()
        {
            // 1. Get All Roles
            var roles = roleManager.Roles;

            List<SelectListItem> roleItems = new List<SelectListItem>();
            foreach (var role in roles)
            {
                roleItems.Add(new SelectListItem(role.Name, role.Id));
            }
            ViewBag.Roles = roleItems;

            // 2. Get All Users
            var users = userManager.Users;
            List<SelectListItem> usersItems = new List<SelectListItem>();
            foreach (var user in users)
            {
                usersItems.Add(new SelectListItem(user.UserName, user.Id));
            }
            ViewBag.Users = usersItems;

            return View(new UserInRole());
        }

        [HttpPost]
        public async Task<IActionResult> AssignRoleToUser(UserInRole userInRole)
        {
            if (userInRole == null || userInRole.UserId == null || userInRole.RoleId == null)
            {
                // 1. Get All Roles
                var roles = roleManager.Roles;

                List<SelectListItem> roleItems = new List<SelectListItem>();
                foreach (var role in roles)
                {
                    roleItems.Add(new SelectListItem(role.Name, role.Id));
                }
                ViewBag.Roles = roleItems;

                // 2. Get All Users
                var users = userManager.Users;
                List<SelectListItem> usersItems = new List<SelectListItem>();
                foreach (var user in users)
                {
                    usersItems.Add(new SelectListItem(user.UserName, user.Id));
                }
                ViewBag.Users = usersItems;

                return View(new UserInRole());
            }

            // 1. Check if USe Exist
            var UserExist = await userManager.FindByIdAsync(userInRole.UserId);
            // 2. Check Role Exists
            var RoleExist = await roleManager.FindByIdAsync(userInRole.RoleId);
            if (UserExist == null || RoleExist == null)
            {
                ViewBag.UserStatus = $"The USer {userInRole.UserId} is not exist";
                ViewBag.RoleStatus = $"The Role {userInRole.RoleId} is not exist";
                // Also Pass ViewBag for USers and Roles 
                return View(new UserInRole());
            }

            //2.B Only one user can have one role
            var userRole = await userManager.GetRolesAsync(UserExist);
            

            // 3. Assign Role To User



            if (result.Succeeded)
                return RedirectToAction("Index");
            return View(new UserInRole());

        }
    }
}
