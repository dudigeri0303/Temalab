using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace TemalabBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public UserController(DatabaseContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            List<User> users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("searchByID/{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            User user = await this._context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("User not found!");
            }
            return Ok(user);
        }

        [HttpGet("serachByName/{name}")]
        public async Task<ActionResult<List<User>>> GetUserByName(string name)
        {
            List<User> users = await this._context.Users.Where(u => u.UserName == name).ToListAsync();
            if (users == null)
            {
                return NotFound("User not found!");
            }
            return Ok(users);
        }

        [HttpDelete("deleteByID/{id}")]
        public async Task<ActionResult<User>> DeleteUserById(int id)
        {
            //User userToDelete = this.GetUserById(id).Result;
            User user = await this._context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound("User not fount, you cant delete it");
            }
            this._context.Users.Remove(user);
            this._context.SaveChanges();
            return Ok(user);
        }

        
        //HTTP POST
        [HttpPost("createNewUser/")]
        public async Task<ActionResult> CreateNewUser(User user) 
        {
            try 
            {
                this._context.Users.Add(user);
                this._context.SaveChanges();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
            return Ok(user);
        }

        //TODO password validation
        [HttpPut("updateUserPropertiesByID/{id}")]
        public async Task<ActionResult<User>> UpdateUserPropertiesByID(int id, User newUser) 
        {
            User user = await _context.Users.FindAsync(id);
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
            this._context.SaveChanges();
            return Ok(user);
        }

        //string username, string password, string email, string phoneNumber, string userrole
    
    
        //++++++++++++++++++++++++++++++++++++
        /*private bool IsValidUser(User user) 
        {
            return true;
        }*/
    
    }
}
