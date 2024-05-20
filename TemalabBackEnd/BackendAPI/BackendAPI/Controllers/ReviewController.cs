using BackendAPI.Controllers.Common;
using BackendAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        public ReviewController([FromServices] DatabaseContext dbContext, [FromServices] UserManager<User> userManager) : base(dbContext, userManager)
        {
        }

        //[Authorize(Roles = "Customer")]
        [HttpGet("getAvargeRatingByRestaurantId/")]
        [Authorize(Roles = "Owner, Customer")]
        public async Task<ActionResult<double>> GetAvargeRatingByRestaurantId(string restaurantId)
        {
            List<Review> reviews = await this.crudOperator.GetMultipleRowsByForeignId<Review>(restaurantId, "RestaurantId");
            if(reviews.Any()) 
            {
                double avarge = reviews.Average(r => r.Rating);
                return Ok(avarge);
            }
            return BadRequest("There are no reviews for the restaurant");
        }

        [HttpGet("getReviewsForRestaurantById/")]
        [Authorize(Roles = "Owner, Customer")]
        public async Task<ActionResult<ReviewDto>> GetReviewsForRestaurantById(string restaurantId) 
        {
            try 
            {
                List<Review> reviews = await this.crudOperator.GetAllRows<Review>();
                List<Review> reviewsByRestaurantID = reviews.Where(r => r.RestaurantId == restaurantId).ToList();
                List<ReviewDto> reviewDtos = new List<ReviewDto>();
                reviewsByRestaurantID.ForEach(r => reviewDtos.Add(new ReviewDto(r.Id, r.UserName, r.Rating, r.Description)));
                return Ok(reviewDtos);
            } catch (Exception ex) 
            {
                return BadRequest(ex.Message);   
            }
        }

        [HttpPost("createNewReviewForRestaurant/")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult<Review>> CreateNewReviewForRestaurant(string restaurantId, CreateReviewDto reviewDto) 
        {
            try 
            {
                string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                User? user = await this.userManager.FindByIdAsync(userId!);
                Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(restaurantId);
                if(user != null && restaurant != null) 
                {
                    Review review = new Review(user, restaurant, reviewDto.Rating, reviewDto.Description, user.UserName!);
                    await this.crudOperator.InsertNewRow<Review>(review);
                    return Ok(review);
                }
                return NotFound("User or restaurant not found!");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deleteReviewById/")]
        [Authorize(Roles = "Owner, Customer")]
        public async Task<ActionResult> DeleteReviewById(string reviewId) 
        {
            try 
            {
                await this.crudOperator.DeleteRowById<Review>(reviewId);
                return Ok("Review deleted succesfully!");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
