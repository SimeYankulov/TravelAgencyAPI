using Microsoft.AspNetCore.Mvc;
using TravelAgencyAPI.Entities;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseHolidayDTO>>> GetItems(
              [FromQuery] Location? locationObj = null,
             [FromQuery] DateTime? startDate = null,
             [FromQuery] int? duration = null,
             [FromQuery] string? location = null
            )
        {
            try
            {
                IEnumerable<Holiday> holidays;

                if (locationObj.Id != null)
                {
                    holidays = await this.holidayRepository.GetItems(locationObj);
                }
                else if (startDate != null)
                {
                    holidays = await this.holidayRepository.GetItems(startDate);
                }
                else if(duration > 0)
                {
                   holidays = await this.holidayRepository.GetItems(duration);
                }
                else if(location != null)
                {
                    holidays = await this.holidayRepository.GetItems(location);
                }
                else
                {
                   holidays = await this.holidayRepository.GetItems();
                }
               
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
