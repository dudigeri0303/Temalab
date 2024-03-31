using BackendAPI.Controllers.Common;
using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : BaseEntityController
    {
        public ReviewController(DatabaseContext dbContext) : base(dbContext)
        {
        }

        /*[HttpPost("createReview/")]
        public async Task<ActionResult<Review>> CreateReview(Review review, Restaurant restaurant) 
        {


        }*/
    }
}
