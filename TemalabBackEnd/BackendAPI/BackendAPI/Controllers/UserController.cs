using BackendAPI.Controllers.Common;
using BackendAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult<User>> Register(UserRegisterDto registerDto) 
        {
            User newUser = new User()
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
            };
            if(registerDto.Password.Equals(registerDto.PasswordAgain)) 
            {
                await this.userManager.CreateAsync(newUser, registerDto.Password);
                if (registerDto.UserRole == "customer") { await this.userManager.AddToRoleAsync(newUser, "Customer"); }
                else if (registerDto.UserRole == "owner") { await this.userManager.AddToRoleAsync(newUser, "Owner"); }  
                return Ok(newUser);
            }
            return BadRequest("Something went wrong");
        }

        //Ugyanúgy custom login api hívás, mint a regisztráció.
        [HttpPost("login/")]
        public async Task<ActionResult<UserLoginDto>> Login(UserLoginDto loginDto)
        {
            if (loginDto.UserName != null && loginDto.Password != null)
            {
                var logInResult = await signInManager.PasswordSignInAsync(
                    userName: loginDto.UserName,
                    password: loginDto.Password,
                    isPersistent: false,
                    lockoutOnFailure: false
                );
                if (logInResult.Succeeded)
                {
                    //A kapott információk alapján beállít egy user role-t.
                    //A loginModel-t visszaküldi, és ez alapján navigál a kliens
                    //Lehet hogy szar megoldás, és ki kéne találni valami jobbat
                    User? user = await this.userManager.FindByNameAsync(loginDto.UserName);
                    var userRoles = await this.userManager.GetRolesAsync(user);
                    if (userRoles.Contains("Owner"))
                    {
                        loginDto.UserRole = "owner";
                    }
                    else { loginDto.UserRole = "customer"; }

                    //loginmodel paswordjének átírása üres stringre. Igy legalább nem küldi vissza a frontendre, bár elég gagyi megoldás
                    loginDto.Password = "";
                    return Ok(loginDto);
                }
                return Unauthorized("Login failed");
            }
            return BadRequest("Fill in the fields!");
        }

        [Authorize]
        [HttpPost("logOut/")]
        public async Task<ActionResult> LogOut() 
        {
            await this.signInManager.SignOutAsync();
            return Ok("LoggedOut");
        }

        //A bejelentkezett user user page-nek megfelelő adataival tér vissza egy UserDataModelként
        [HttpGet("getLoggedInUserData/"), Authorize]
        public async Task<ActionResult<UserDatasDto>> GetLoggedInUsersData()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user =  await this.userManager.FindByIdAsync(userId);
            if (user != null)
            {
                UserDatasDto dataModel = new UserDatasDto(user.UserName, user.PhoneNumber, user.Email);
                return Ok(dataModel);
            }
            return NotFound("User not found!");
        }

        //A paraméterként kapott UserDataModel alapján megváltoztatja a user bizonyos adatait.
        //Validáció nincs, úgyhogy az még kell. Will Farell azt mondta, hogy a dbcontext-ben elvileg
        //Van olyan update metódus, amivel ezt meg lehet egyszerűen csinálni.
        [HttpPut("editUserDate/{name}"), Authorize]
        public async Task<ActionResult> EditUserDataByName(UserDatasDto newDataModel) 
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

        //Osszes user lekerdezese
        [HttpGet("getAllUsers/")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await userManager.Users.ToListAsync();

            if (users != null && users.Any())
            {
                return Ok(users);
            }
            return NotFound("No users found");
        }


        //Szerintem a user role-ok közül is törölni kell a user role-jait
        //Ahogy nézem törli a user rolet is, need double check
        [HttpDelete("deleteUserById/")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteUserById(string userId) 
        {
            try 
            {
                User? user = await this.userManager.FindByIdAsync(userId);
                await this.userManager.DeleteAsync(user);
                return Ok("User deleted succesfully");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }
        #endregion
    }
}
