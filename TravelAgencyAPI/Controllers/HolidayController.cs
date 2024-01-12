using Microsoft.AspNetCore.Mvc;
using Microsoft.OData.Edm;
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
            [FromQuery] CreateLocationDTO? location = null,
            [FromQuery] DateTime? startDate= null,
            [FromQuery] int? duration = null)
        {
            try
            {
                IEnumerable<Holiday> holidays;
                if(duration != null)
                {
                    return Ok(startDate.ToString);
                    // holidays = await this.holidayRepository.GetItems(duration,null);
                }
                if(startDate != null)
                {
                    holidays = await this.holidayRepository.GetItems(null, startDate.Value.ToShortDateString());
                }
                else
                {
                     holidays = await this.holidayRepository.GetItems(null,null);
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
