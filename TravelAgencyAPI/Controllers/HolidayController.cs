using Microsoft.AspNetCore.Mvc;
using TravelAgencyAPI.Extensions;
using TravelAgencyAPI.Repositories.Contracts;
using TravelAgencyModels.DTOs;

namespace TravelAgencyAPI.Controllers
{
    [ApiController]
    [Route("holidays")]
    public class HolidayController : ControllerBase
    {
        private readonly IHolidayRepository holidayRepository;

        public HolidayController(IHolidayRepository holidayRepository)
        {
            this.holidayRepository = holidayRepository;
        }

        [HttpGet("example")]
        public IActionResult MyEndpoint(
            [FromQuery] string param1 = " ",
            //[FromQuery] DateOnly param2,
            [FromQuery] int param3 = 0)
        {
            // Your logic here using param1, param2, and param3
            if (param1 != null) { return Ok(new { Param1 = param1 }); }
            else if (param3 != 0) { return Ok(new { Param3 = param3 }); }
            else
                // For example, return a JSON response
                return Ok(new { Param1 = param1, Param3 = param3 });
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseHolidayDTO>>> GetItems()
        {
            try
            {
                var holidays = await this.holidayRepository.GetItems();

                if (holidays == null)
                {
                    return BadRequest();
                }
                else
                {
                    var holidayDtos = holidays.ConvertToDto();
                    return Ok(holidayDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                                    "Error retriving data from the database");
            }
        }
        [HttpGet("{holidayId}")]
        public async Task<ActionResult<ResponseHolidayDTO>> GetItem(long holidayId)
        {
            try
            {
                var holiday = await this.holidayRepository.GetItem(holidayId);

                if (holiday == null)
                {
                    return BadRequest();
                }
                else
                {
                    var holidayDto = holiday.ConvertToDto();

                    return Ok(holidayDto);

                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    "Error retriving data from the database");
            }
        }
        [HttpDelete("{holidayId}")]
        public async Task<ActionResult<bool>> DeleteItem(long holidayId)
        {
            try
            {
                var holiday = await this.holidayRepository.DeleteItem(holidayId);

                if (holiday != null)
                {
                    return Ok(true);

                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                   "Error writing data in the database");
            }
        }
        [HttpPost]
        public async Task<ActionResult<ResponseHolidayDTO>> PostItem([FromBody] CreateHolidayDTO holidayDto)
        {
            try
            {
                //Validations 
                //..

                var newHoliday = await this.holidayRepository.AddItem(holidayDto);

                if (newHoliday == null)
                {
                    return BadRequest();
                }

                var holiday = await this.holidayRepository.GetItem(newHoliday.Id);

                if (holiday == null)
                {
                    return BadRequest();
                }

                var newHolidayDTO = newHoliday.ConvertToDto();

                return CreatedAtAction(nameof(GetItem), new { newHolidayDTO.id }, newHolidayDTO);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                   "Error writing data in the database");
            }
        }
        [HttpPut]
        public async Task<ActionResult<ResponseHolidayDTO>> PutItem([FromBody] UpdateHolidayDTO holidayDTO)
        {
            try
            {
                var holiday = await this.holidayRepository.PutItem(holidayDTO);

                if (holiday != null)
                {
                    return Ok(holiday.ConvertToDto());
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                   "Error writing data in the database");
            }
        }
    }
}
