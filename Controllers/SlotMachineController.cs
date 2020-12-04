using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Slot.Data;
using Slot.Models;
using Slot.Services;

namespace Slot.Controllers
{
    [ApiController]
    [Route("slotmachine")]
    public class SlotMachineController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public SlotMachineController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("firstdraw")]
        public ContentResult GetFirstDraw()
        {
            return Content(SlotMachineService.FirstDraw());
        }
        
        [HttpGet("seconddraw")]
        public ContentResult GetSecondDraw()
        {
            return Content(SlotMachineService.SecondDraw());
        }
        
        [HttpGet("thirddraw")]
        public ContentResult GetThirdDraw()
        {
            return Content(SlotMachineService.ThirdDraw());
        }

        [HttpPost("saveresult")]
        public ActionResult SaveResult([FromBody] Result result)
        {
            if (SlotMachineService.ValidateResult(result))
            {
                _context.Results.Add(result);
                return _context.SaveChanges() > 0 ? StatusCode(201) : BadRequest();
            }

            return BadRequest("Please, provide winning result.");
        }

        [HttpGet("results")]
        public IEnumerable<Result> GetAllResults()
        {
            return _context.Results.ToList();
        }
        
    }
}