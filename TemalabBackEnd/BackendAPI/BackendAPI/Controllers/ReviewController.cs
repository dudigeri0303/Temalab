using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    public class ReviewController : BaseEntityController<Review>
    {
        public ReviewController(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public override Task<ActionResult<IEntityModelBase>> UpdateUserPropertiesByID(int id, Review updatedEntity)
        {
            throw new NotImplementedException();
        }
    }
}
