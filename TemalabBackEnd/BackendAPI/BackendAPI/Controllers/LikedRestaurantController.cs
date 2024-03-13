using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    public class LikedRestaurantController : BaseEntityController<LikedRestaurant>
    {
        public LikedRestaurantController(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public override Task<ActionResult<IEntityModelBase>> UpdateUserPropertiesByID(int id, LikedRestaurant updatedEntity)
        {
            throw new NotImplementedException();
        }
    }
}
