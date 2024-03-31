using BackendAPI.Controllers.Common;
using BackendAPI.Models.EntityFrameworkModel.Common;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : BaseEntityController
    {
        public TableController(DatabaseContext dbContext) : base(dbContext)
        {
        }

        [HttpPut("reserveTable/")]
        public async Task<ActionResult> ReserveTable(string id) 
        {
            Table? table = await this.crudOperator.GetRowById<Table>(id);
            if(table != null)
            {
                table.IsReserved = true;
                return Ok(table);
            }
            return NotFound("Table not found");
        }

        [HttpPut("despairReservation/")]
        public async Task<ActionResult> DespairTableReservation(string id) 
        {
            Table? table = await this.crudOperator.GetRowById<Table>(id);
            if (table != null)
            {
                table.IsReserved = false;
                return Ok(table);
            }
            return NotFound("Table not found");
        }
    }
}
