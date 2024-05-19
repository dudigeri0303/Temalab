using BackendAPI.Controllers.Common;
using BackendAPI.Models.DTOs;
using BackendAPI.Models.EntityFrameworkModel.EntityModels;
using BackendAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Services.Implementations
{
    public class OwnerService : IOwnerService
    {
        public async Task<ActionResult<List<RestaurantDataDto>>> ListRestaurantsByOwner(string userId, GenericCrudOperator crudOperator)
        {
            List<Owner> ownerConnections = await crudOperator.GetMultipleRowsByForeignId<Owner>(userId, "UserId");
            List<RestaurantDataDto> restaurantModels = new List<RestaurantDataDto>();
            foreach (Owner owner in ownerConnections)
            {
                Restaurant? restaurant = await crudOperator.GetRowById<Restaurant>(owner.RestaurantId);
                List<RestaurantOpeningHours> openingHours = await crudOperator.GetMultipleRowsByForeignId<RestaurantOpeningHours>(restaurant.Id, "RestaurantId");
                List<OpeningHourDto> openingHourDtos = new List<OpeningHourDto>();
                openingHours.ForEach(openingHour => openingHourDtos.Add(new OpeningHourDto(openingHour.DayName, openingHour.OpeningHour)));
                restaurantModels.Add(new RestaurantDataDto(restaurant.Id, restaurant.Name, restaurant.Label, restaurant.Description, $"{restaurant.City} {restaurant.Street} {restaurant.HouseNumber}", openingHourDtos));
            }
            return new OkObjectResult(restaurantModels);
        }
    }
}
