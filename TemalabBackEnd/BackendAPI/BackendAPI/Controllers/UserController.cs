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

        #region CrudOperations


        [HttpPut("updateEntityPropertiesByID/{id, updatedEntity}")]
        public override async Task<ActionResult<IEntityModelBase>> UpdateUserPropertiesByID(int id, User updatedEntity) 
        {
            User newUser = updatedEntity;
            User? user = await this._dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("User not found!");
            }
            if (newUser.UserName != "string" && newUser.UserName.Trim() != "")
            {
                user.UserName = newUser.UserName;
            }
            if (newUser.Password != "string" && newUser.Password.Trim() != "")
            {
                user.UserName = newUser.Password;
            }
            if (newUser.Email != "string" && newUser.Email.Trim() != "")
            {
                user.Email = newUser.Email;
            }
            if (newUser.PhoneNumber != "string" && newUser.PhoneNumber.Trim() != "")
            {
                user.PhoneNumber = newUser.PhoneNumber;
            }
            this._dbContext.SaveChanges();
            return Ok(user);
        }

        #endregion

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

        #endregion
    }
}
