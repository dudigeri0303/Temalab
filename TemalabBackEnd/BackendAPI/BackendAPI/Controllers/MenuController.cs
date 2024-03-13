using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : BaseEntityController<Menu>
    {
        public MenuController(DatabaseContext dbContext) : base(dbContext)
        {
        }

        [HttpPut("updateEntityPropertiesByID/{id, updatedEntity}")]
        public override async Task<ActionResult<Menu>> UpdateUserPropertiesByID(int id, Menu updatedEntity)
        {
            return NotFound("Not yet implemented!");
        }
    }
}
