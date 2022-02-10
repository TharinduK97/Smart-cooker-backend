using Microsoft.AspNetCore.Mvc;
using Smart_Cookers.Dtos.OutletDtos;
using Smart_Cookers.Models;
using Smart_Cookers.Services.OutletService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smart_Cookers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OutletController : ControllerBase
    {

        private readonly IOutletService _outletService;

        public OutletController(IOutletService outletService)
        {
            _outletService = outletService;

        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetOutletDto>>>> Get()
        {
            return Ok(await _outletService.GetAllOutles());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetOutletDto>>>> AddOutlet(AddOutletDto newOutlet)
        {
            return Ok(await _outletService.AddOutlet(newOutlet));
        }
    }
}
