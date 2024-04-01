using BackendAPI.Controllers.Common;
using BackendAPI.Models.ModelsForApiCalls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace TemalabBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseEntityController
    {
        private readonly SignInManager<User> signInManager;

        public UserController(DatabaseContext dbContext, UserManager<User> userManager, SignInManager<User> signInManager) : base(dbContext, userManager) 
        {
            this.signInManager = signInManager;
        }

        #region UniqueOperations
        //Regisztrációs api hívás. Az identity biztosít egy alapot, de ott nem lehet 
        //Felülírni a mezőket.
        [HttpPost("register/")]
        public async Task<ActionResult<User>> Register(RegisterModel registerModel) 
        {
            //Console.WriteLine("REGUSTRÁÁCIÓÓÓÓ");
            User newUser = new User()
            {
                UserName = registerModel.UserName,
                Email = registerModel.Email,
                PhoneNumber = registerModel.PhoneNumber,
                UserRole = registerModel.UserRole
            };

            if(registerModel.Password.Equals(registerModel.PasswordAgain)) 
            {
                await this.userManager.CreateAsync(newUser, registerModel.Password);
                return Ok(newUser);
            }
            return BadRequest("Something went wrong");
        }

        //Ugyanúgy custom login api hívás, mint a regisztráció.
        [HttpPost("login/")]
        public async Task<ActionResult<LoginModel>> Login(LoginModel loginModel)
        {
            if (loginModel.UserName != null && loginModel.Password != null)
            {
                var logInResult = await signInManager.PasswordSignInAsync(
                    userName: loginModel.UserName,
                    password: loginModel.Password,
                    isPersistent: false,
                    lockoutOnFailure: false
                );
                if (logInResult.Succeeded)
                {
                    return Ok(loginModel);
                }
                return Unauthorized("Login failed");
            }
            return BadRequest("Fill in the fields!");
        }

        //A bejelentkezett user user page-nek megfelelő adataival tér vissza egy UserDataModelként
        [HttpGet("getLoggedInUserData/"),Authorize]
        public async Task<ActionResult<UserDataModel>> GetUserByName()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user =  await this.userManager.FindByIdAsync(userId);
            if (user != null)
            {
                UserDataModel dataModel = new UserDataModel()
                {
                    Name = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Password = "ValamiValami21"
                };
                return Ok(dataModel);
            }
            return NotFound("User not found!");
        }

        //A paraméterként kapott UserDataModel alapján megváltoztatja a user bizonyos adatait.
        //Validáció nincs, úgyhogy az még kell. Will Farell azt mondta, hogy a dbcontext-ben elvileg
        //Van olyan update metódus, amivel ezt meg lehet egyszerűen csinálni.
        [HttpPut("editUserDate/{name}"), Authorize]
        public async Task<ActionResult> EditUserDataByName(UserDataModel newDataModel) 
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await this.userManager.FindByIdAsync(userId);
            if(user != null) 
            {
                user.UserName = newDataModel.Name;
                user.Email = newDataModel.Email;
                user.PhoneNumber = newDataModel.PhoneNumber;
                await this.userManager.UpdateAsync(user);
                return Ok("User data updated");
            }
            return BadRequest("Unsuccesfulupdate");
        }
        #endregion
    }
}
