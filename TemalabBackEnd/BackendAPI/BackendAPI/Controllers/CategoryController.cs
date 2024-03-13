using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    public class CategoryController : BaseEntityController<Category>
    {
        public CategoryController(DatabaseContext dbContext) : base(dbContext)
        {
        }

        [HttpPut("updateEntityPropertiesByID/{id, updatedEntity}")]
        public override async Task<ActionResult<Category>> UpdateUserPropertiesByID(int id, Category updatedEntity)
        {
            return NotFound("Method is not implemented yet");
        }
    }
}
