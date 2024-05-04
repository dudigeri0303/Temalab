using BackendAPI.Controllers.Common;
using BackendAPI.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : BaseEntityController
    {
        public TableController(DatabaseContext dbContext, UserManager<User> userManager) : base(dbContext, userManager)
        {
        }

        [HttpGet("listTablesByRestaurantId/")]
        public async Task<ActionResult<TableDto>> ListTablesByRestaurantId(string restaurantId) 
        {
            try 
            {
                List<Table> tables = await this.crudOperator.GetMultipleRowsByForeignId<Table>(restaurantId, "RestaurantId");
                if (tables.Any())
                {
                    List<TableDto> tableDtos = new List<TableDto>();
                    tables.ForEach(t => tableDtos.Add(new TableDto(t.Id, t.NumOfSeats, t.IsReserved)));
                    return Ok(tableDtos);
                }
                return BadRequest("Resturant does not have any tables regostered");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deleteTableById/")]
        public async Task<ActionResult> DeleteTableById(string tableId) 
        {
            try 
            {
                await this.crudOperator.DeleteRowById<Table>(tableId);
                return Ok("Table delete succesfully");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("addTableToRestaurant")]
        public async Task<ActionResult<Table>> AddTableToRestaurant(string restaurantId, CreateTableDto tableDto) 
        {
            try 
            {

                Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(restaurantId);
                if (restaurant != null)
                {
                    Table table = new Table(restaurant, tableDto.NumOfSeats);
                    await this.crudOperator.InsertNewRow<Table>(table);
                    return Ok(table);
                }
                return NotFound("Restaurant not found!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
