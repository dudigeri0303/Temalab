using BackendAPI.Controllers.Common;
using BackendAPI.Models.EntityFrameworkModel.EntityModels;
using BackendAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Services.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        public async Task<ActionResult> DeleteRestaurantById(string restaurantId, GenericCrudOperator crudOperator)
        {
            try
            {
                Restaurant? restaurant = await crudOperator.GetRowById<Restaurant>(restaurantId);
                if (restaurant != null)
                {
                    //delete categories and foods
                    List<Category> categories = await crudOperator.GetMultipleRowsByForeignId<Category>(restaurant.MenuId, "MenuId");
                    foreach (Category category in categories)
                    {
                        //delete foods
                        List<Food> foods = await crudOperator.GetMultipleRowsByForeignId<Food>(category.Id, "CategoryId");
                        foreach (Food food in foods)
                        {
                            await crudOperator.DeleteRowById<Food>(food.Id);
                        }
                        await crudOperator.DeleteRowById<Category>(category.Id);
                    }

                    //delete reservations
                    List<Reservation> reservations = await crudOperator.GetMultipleRowsByForeignId<Reservation>(restaurantId, "RestaurantId");
                    foreach (Reservation reservation in reservations)
                    {
                        crudOperator.DbContext.Reservations.Remove(reservation);
                    }

                    //delete opening hours
                    List<RestaurantOpeningHours> openingHours = await crudOperator.GetMultipleRowsByForeignId<RestaurantOpeningHours>(restaurantId, "RestaurantId");
                    foreach (RestaurantOpeningHours openingHour in openingHours)
                    {
                        crudOperator.DbContext.RestaurantOpeningHours.Remove(openingHour);
                    }

                    //delete menu
                    await crudOperator.DeleteRowById<Menu>(restaurant.MenuId);

                    //delete restaurant
                    await crudOperator.DeleteRowById<Restaurant>(restaurantId);

                    crudOperator.SaveDatabaseChanges();
                    return new OkObjectResult("Restaurant deleted");
                }
                return new NotFoundObjectResult("Restaurant not found");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
