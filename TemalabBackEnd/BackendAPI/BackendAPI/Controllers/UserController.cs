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

        [HttpGet("getAllRows/")]
        public override async Task<ActionResult<List<IEntityModelBase>>> GetAllRows() 
        {
            List<User> users = await this._dbContext.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("searchByID/{id}")]
        public override async Task<ActionResult<IEntityModelBase>> GetRowById(int id) 
        {
            User? user = await this._dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("User not found!");
            }
            return Ok(user);
        }

        [HttpDelete("deleteByID/{id}")]
        public override async Task<ActionResult<IEntityModelBase>> DeleteUserById(int id) 
        {
            User? user = await this._dbContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound("User not fount, you cant delete it");
            }
            this._dbContext.Users.Remove(user);
            this._dbContext.SaveChanges();
            return Ok(user);
        }

        [HttpPost("insertNewRow/{newEntity}")]
        public override async Task<ActionResult> InsertNewRow(User entity)
        {
            try
            {
                this._dbContext.Users.Add(entity);
                this._dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(entity);
        }

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
