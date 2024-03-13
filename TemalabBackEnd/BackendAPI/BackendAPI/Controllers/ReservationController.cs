using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    public class ReservationController : BaseEntityController<Reservation>
    {
        public ReservationController(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public override Task<ActionResult<IEntityModelBase>> UpdateUserPropertiesByID(int id, Reservation updatedEntity)
        {
            throw new NotImplementedException();
        }
    }
}
