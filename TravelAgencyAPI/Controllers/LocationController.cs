using Microsoft.AspNetCore.Mvc;
using TravelAgencyAPI.Extensions;
using TravelAgencyAPI.Repositories.Contracts;
using TravelAgencyModels.DTOs;

namespace TravelAgencyAPI.Controllers
{
    [ApiController]
    [Route("locations")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository locationRepository;
        public LocationController(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseLocationDTO>>> GetItems()
        {
            try
            {
                var locations = await this.locationRepository.GetItems();

                if (locations == null)
                {
                    return BadRequest();
                }
                else
                {
                    var locationDtos = locations.ConvertToDto();

                    return Ok(locationDtos);

                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    "Error retriving data from the database");
            }
        }
        [HttpGet("{locationId}")]
        public async Task<ActionResult<ResponseLocationDTO>> GetItem(long locationId)
        {
            try
            {
                var location = await this.locationRepository.GetItem(locationId);

                if (location == null)
                {
                    return BadRequest();
                }
                else
                {
                    var locationDto = location.ConvertToDto();

                    return Ok(locationDto);

                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    "Error retriving data from the database");
            }
        }
        [HttpPost]
        public async Task<ActionResult<ResponseLocationDTO>> PostItem([FromBody] CreateLocationDTO locationDto)
        {
            try
            {
                //Validations 
                //..

                var newLocation = await this.locationRepository.AddItem(locationDto);

                if (newLocation == null)
                {
                    return BadRequest();
                }

                var location = await this.locationRepository.GetItem(newLocation.Id);

                if (location == null)
                {
                    return BadRequest();
                }

                var newLocationDTO = newLocation.ConvertToDto();

                return CreatedAtAction(nameof(GetItem), new { newLocationDTO.id }, newLocationDTO);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                   "Error writing data in the database");
            }
        }
        [HttpDelete("{locationId}")]
        public async Task<ActionResult<bool>> DeleteItem(long locationId)
        {
            try
            {
                var location = await this.locationRepository.DeleteItem(locationId);

                if(location != null)
                {
                    return Ok(true);

                }else
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
        [HttpPut]
        public async Task<ActionResult<ResponseLocationDTO>> PutItem([FromBody] UpdateLocationDTO locationDTO)
        {
            try
            {
                var location = await this.locationRepository.PutItem(locationDTO);

                if(location != null)
                {
                    return Ok(location.ConvertToDto());
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
