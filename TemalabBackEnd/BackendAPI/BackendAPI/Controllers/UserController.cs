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
            User user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("User not found!");
            }
            return Ok(user);
        }

        [HttpGet("serachByName/{name}")]
        public async Task<ActionResult<List<User>>> GetUserByName(string name)
        {
            List<User> users = await _context.Users.Where(u => u.UserName == name).ToListAsync();
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
            User user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound("User not fount, you cant delete it");
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok(user);
        }

        /*
        //KELL??
        [HttpPost("createNewUser/")]
        public User CreateNewUser(string username, string password, string email, string phoneNumber, string userrole) 
        {
            return new User(username, password, email, phoneNumber, userrole);
        }
        //KELL??
        */

        /*
        //Password küldése így????
        [HttpPut("updateUserPropertiesByID/{id}")]
        public async Task<ActionResult<User>> UpdateUserPropertiesByID(int id, User newUser) 
        {
            User user = await _context.Users.FindAsync(id);
        }

        //string username, string password, string email, string phoneNumber, string userrole
        */
    }
}
