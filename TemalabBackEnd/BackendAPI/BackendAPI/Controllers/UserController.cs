using BackendAPI.Controllers;
using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace TemalabBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseEntityController<User>
    {
        public UserController(DatabaseContext context) : base(context) 
        {

        }
        #region UniqueOperations

        [HttpGet("serachByName/{name}")]
        public async Task<ActionResult<List<User>>> GetUserByName(string name)
        {
            List<User> users = await this._dbContext.Users.Where(u => u.UserName == name).ToListAsync();
            if (users == null)
            {
                return NotFound("User not found!");
            }
            return Ok(users);
        }

        [HttpGet("login/")]
        public async Task<ActionResult<List<User>>> UserLogin(string name)
        {
            //Hogyan kene atadni az emailt es a jelszot?
            //jelszo ellenorzese: Argon2.Verify(user.Password, password);
            return BadRequest("Not implemented yet!");
        }

        #endregion
    }
}
