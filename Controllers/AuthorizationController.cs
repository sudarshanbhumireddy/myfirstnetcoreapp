using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using myfirstnetcoreapp.Models;
using myfirstnetcoreapp.Views.Home.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfirstnetcoreapp.Controllers
{
    [AllowAnonymous]
    public class AuthorizationController : Controller
    {
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly UserManager<ApplicationUser> _usermanager;

        public AuthorizationController(RoleManager<IdentityRole> role, UserManager<ApplicationUser> userManager)
        {
            _rolemanager = role;
            _usermanager = userManager;
        }
        [HttpGet]
        public IActionResult CreateIdentityRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateIdentityRole(IdentityRoleModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole() { Name = model.RoleName };
                var result = await _rolemanager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("List", "Home");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    
                }
            }
           
            return View(model);
        }

        public ActionResult ListRoles()
        {
          return  View(_rolemanager.Roles);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
          var role= await _rolemanager.FindByIdAsync(id);
            if (role != null)
            {
                EditRoleModel model = new EditRoleModel() { RoleId = id, RoleName = role.Name };
                foreach(var user in _usermanager.Users)
                {
                    if (await _usermanager.IsInRoleAsync(user, role.Name))
                    {
                        model.users.Add(user.UserName);
                    }
                }
                return View(model);  

            }
            else
            {
                ViewBag.ErrorMessage = $"Role with id {id} not found";
                return View("NotFound");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await _rolemanager.FindByIdAsync(model.RoleId);
                if (role != null)
                {

                    role.Name = model.RoleName;
                var result=  await  _rolemanager.UpdateAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("ListRoles");
                    }
                    else
                    {
                        foreach(var error in result.Errors)
                        {
                            ModelState.AddModelError("",error.Description);
                        }
                    }

                }
                else
                {
                    ViewBag.ErrorMessage = $"Role with id {model.RoleId} not found";
                    return View("NotFound");
                }
            } return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddRemoveUsersToRole(string roleId)
        {
            ViewBag.RoleId = roleId;
         var role=   await _rolemanager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with id {roleId} not found";
                return View("NotFound");
            }
            else
            {
                var model = new List<UserRoleViewModel>();
                foreach (var user in _usermanager.Users)
                {
                    UserRoleViewModel userview = new UserRoleViewModel() {UserName=user.UserName,UserId=user.Id};
                    if (await _usermanager.IsInRoleAsync(user, role.Name))
                    {
                        
                        userview.IsSelected = true;
                    }
                    else
                    {
                        userview.IsSelected = false;
                    }
                    model.Add(userview);
                }

                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRemoveUsersToRole(List<UserRoleViewModel> model,string roleId)
        {
         var role=  await _rolemanager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with id {roleId} not found";
                return View("NotFound");
            }
            IdentityResult result = null;
            for (int i = 0; i < model.Count; i++)
            {
                var user = await _usermanager.FindByIdAsync(model[i].UserId);
                if(model[i].IsSelected && !( await _usermanager.IsInRoleAsync(user, role.Name)))
                {
                  result= await _usermanager.AddToRoleAsync(user, role.Name);
                }

               else if (!model[i].IsSelected && await _usermanager.IsInRoleAsync(user, role.Name))
                {
                    result = await _usermanager.RemoveFromRoleAsync(user, role.Name);
                }

                else
                {
                    continue;
                }
                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("EditRole", new { id = roleId });
                    }
                }

            }
            return View();
        }  
           


    }
}
