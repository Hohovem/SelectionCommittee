using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SelectionCommittee.BLL.DTO;
using SelectionCommittee.BLL.Infrastructure;
using SelectionCommittee.BLL.Interfaces;
using SelectionCommittee.Web.Models;

namespace SelectionCommittee.Web.Controllers
{
    public class AccountController : Controller
    {
        private IUserService UserService => HttpContext.GetOwinContext().GetUserManager<IUserService>();
        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel viewModel)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO { Email = viewModel.Email, Password = viewModel.Password };
                ClaimsIdentity claim = await UserService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(viewModel);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel viewModel)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = viewModel.Email,
                    Password = viewModel.Password,
                    Role = "user"
                };
                OperationDetails operationDetails = await UserService.Create(userDto);
                if (operationDetails.Succedeed)
                    //TODO разобратся с этим
                    return View("SuccessRegister");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(viewModel);
        }
        private async Task SetInitialDataAsync()
        {
            await UserService.SetInitialData(new UserDTO
            {
                //TODO переписать
                Email = "somemail@mail.ru",
                UserName = "somemail@mail.ru",
                Password = "ad46D_ewr3",
                Name = "Семен Семенович Горбунков",
                Address = "ул. Спортивная, д.30, кв.75",
                Role = "admin",
            }, new List<string> { "user", "admin" });
        }
    }
}