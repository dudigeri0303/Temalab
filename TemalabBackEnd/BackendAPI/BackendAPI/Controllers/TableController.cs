﻿using BackendAPI.Controllers.Common;
using BackendAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
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
        public TableController([FromServices] DatabaseContext dbContext, [FromServices] UserManager<User> userManager) : base(dbContext, userManager)
        {
        }

        [HttpGet("listTablesByRestaurantId/")]
        [Authorize(Roles = "Owner, Customer")]
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
        [Authorize(Roles = "Owner")]
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
        [Authorize(Roles = "Owner")]
        public async Task<ActionResult<Table>> AddTableToRestaurant(string restaurantId, CreateTableDto tableDto) 
        {
            try 
            {

                Restaurant? restaurant = await this.crudOperator.GetRowById<Restaurant>(restaurantId);
                if (restaurant != null)
                {
                    Table table = new Table(restaurant, tableDto.NumOfSeats);
                    //Nagyon gagyi de itt kell hozzáadni a férőhelyek számét a foglalásban
                    //létrejött változatások miatt
                    restaurant.NumOfFreeSeats += table.NumOfSeats;
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
