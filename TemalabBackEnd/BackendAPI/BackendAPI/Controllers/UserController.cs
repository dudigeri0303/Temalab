using BackendAPI.Controllers;
using BackendAPI.Controllers.Common;
using BackendAPI.Models.DTOs;
using BackendAPI.Services.Implementations;
using BackendAPI.Services.Interfaces;
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
        private IRestaurantService restaurantService;
        private IOwnerService ownerService;
        private IReservationService reservationService;
        private ILikedRestaurantService likedRestaurantService;

        public UserController([FromServices] DatabaseContext dbContext, 
            [FromServices] UserManager<User> userManager, 
            [FromServices] SignInManager<User> signInManager,
            [FromServices] IRestaurantService restaurantService, 
            [FromServices] IOwnerService ownerService,
            [FromServices] IReservationService reservationService,
            [FromServices] ILikedRestaurantService likedRestaurantService) : base(dbContext, userManager) 
        {
            this.signInManager = signInManager;
            this.restaurantService = restaurantService;
            this.ownerService = ownerService;
            this.reservationService = reservationService;
            this.likedRestaurantService = likedRestaurantService;
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
            if(registerDto.Password!.Equals(registerDto.PasswordAgain)) 
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
                    var userRoles = await this.userManager.GetRolesAsync(user!);
                    if (userRoles.Contains("Admin"))
                    {
                        loginDto.UserRole = "admin";
                    }
                    else if (userRoles.Contains("Owner"))
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

        [HttpPost("logOut/")]
        [Authorize(Roles = "Owner, Customer, Admin")]
        public async Task<ActionResult> LogOut() 
        {
            await this.signInManager.SignOutAsync();
            return Ok("LoggedOut");
        }

        //A bejelentkezett user user page-nek megfelelő adataival tér vissza egy UserDataModelként
        [HttpGet("getLoggedInUserData/")]
        [Authorize(Roles = "Owner, Customer, Admin")]
        public async Task<ActionResult<UserDatasDto>> GetLoggedInUsersData()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user =  await this.userManager.FindByIdAsync(userId!);
            if (user != null)
            {
                UserDatasDto dataModel = new UserDatasDto(user.UserName, user.PhoneNumber, user.Email);
                return Ok(dataModel);
            }
            return NotFound("User not found!");
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
        [HttpDelete("deleteUserByIdWithAdmin/")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteUserByIdWithAdmin(string userId) 
        {
            try 
            {
                User? user = await this.userManager.FindByIdAsync(userId);
                await this.DeleteUserDependencies(user!);
                await this.userManager.DeleteAsync(user!);
                return Ok("User deleted succesfully");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpDelete("deleteUserById/")]
        [Authorize(Roles = "Owner, Customer, Admin")]
        public async Task<ActionResult> DeleteUserById()
        {
            try
            {
                string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                User? user = await this.userManager.FindByIdAsync(userId!);
                await this.DeleteUserDependencies(user!);
                await this.userManager.DeleteAsync(user!);
                return Ok("User deleted succesfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //A paraméterként kapott UserDataModel alapján megváltoztatja a user bizonyos adatait.
        //Validáció nincs, úgyhogy az még kell. Will Farell azt mondta, hogy a dbcontext-ben elvileg
        //Van olyan update metódus, amivel ezt meg lehet egyszerűen csinálni.
        [HttpPut("updateUserForLoggedInUser/")]
        [Authorize(Roles = "Owner, Customer, Admin")]
        public async Task<ActionResult> UpdateUserForLoggedInUser(UpdateUserDto userDto)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await this.userManager.FindByIdAsync(userId!);
            if (user != null)
            {
                user.UserName = userDto.UserName;
                user.Email = userDto.Email;
                user.PhoneNumber = userDto.PhoneNumber;
                await this.userManager.UpdateAsync(user);
                this.crudOperator.SaveDatabaseChanges();
                return Ok("User data updated succesfully!");
            }
            return NotFound("User not found:(");
        }
        #endregion

        #region HelperMethods

        private async Task DeleteUserDependencies(User user) 
        {
            var userRoles = await this.userManager.GetRolesAsync(user);
            //Ha owner volt a user
            if (userRoles.Contains("Owner"))
            {
                var actionResult = await this.ownerService.ListRestaurantsByOwner(user.Id, this.crudOperator);
                if (actionResult.Result is OkObjectResult okResult && okResult.Value is List<RestaurantDataDto> restaurants)
                {
                    foreach (var restaurant in restaurants)
                    {
                        await this.restaurantService.DeleteRestaurantById(restaurant.Id!, this.crudOperator);
                    }
                }
            }
            //Ha customer volt a user
            else if(userRoles.Contains("Customer"))
            {
                var reservationActionResult = await this.reservationService.GetReservationsByLoggedInUser(user, this.crudOperator);
                if (reservationActionResult.Result is OkObjectResult okRestult && okRestult.Value is List<ReservationDto> reservations) 
                {
                    foreach (var reservation in reservations) 
                    {
                        await this.reservationService.DeleteReservationByIdForLoggedUser(reservation.Id!, this.crudOperator);
                    }
                }
                var likedeRestaurantActionResult = await this.likedRestaurantService.GetLikedRestaurantByLoggedInUser(user.Id!, this.crudOperator);
                if (likedeRestaurantActionResult.Result is OkObjectResult okResult && okResult.Value is List<LikedRestaurantDto> likedRestaurants) 
                {
                    foreach(var lr in likedRestaurants) 
                    {
                        await this.likedRestaurantService.DeleteLikedRestaurantByIdForLoggedUser(lr.Id!, this.crudOperator);
                    }
                } 
            }
        }
        #endregion
    }
}
