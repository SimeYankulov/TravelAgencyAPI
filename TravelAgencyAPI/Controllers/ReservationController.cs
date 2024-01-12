using Microsoft.AspNetCore.Mvc;
using TravelAgencyAPI.Extensions;
using TravelAgencyAPI.Repositories.Contracts;
using TravelAgencyModels.DTOs;

namespace TravelAgencyAPI.Controllers
{
    [ApiController]
    [Route("reservations")]
    public class ReservationController : Controller
    {
        private readonly IReservationRepository reservationRepository;

        public ReservationController(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseReservationDTO>>> GetItems()
        {
            try
            {
                var reservations = await this.reservationRepository.GetItems();

                if (reservations == null)
                {
                    return BadRequest();
                }
                else
                {
                    var reservationDtos = reservations.ConvertToDto();
                    return Ok(reservationDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                                    "Error retriving data from the database");
            }
        }

        [HttpGet("{reservationId}")]
        public async Task<ActionResult<ResponseReservationDTO>> GetItem(long reservationId)
        {
            try
            {
                var reservation = await this.reservationRepository.GetItem(reservationId);
                
                if(reservation == null)
                {
                    return BadRequest();
                }
                else
                {
                    var reservationDto = reservation.ConvertToDto();

                    return Ok(reservationDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                                   "Error retriving data from the database");
            }
        }

        [HttpDelete("{reservationId}")]
        public async Task<ActionResult<bool>> DeleteItem(long reservationId)
        {
            try
            {
                var reservation = await this.reservationRepository.DeleteItem(reservationId);

                if(reservation != null)
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
        public async Task<ActionResult<ResponseReservationDTO>> PostItem([FromBody] CreateReservationDTO reservationDTO)
        {
            try
            {
                var newReservation = await this.reservationRepository.AddItem(reservationDTO);

                if (newReservation == null)
                {
                    return BadRequest();
                }

                var reservation = await this.reservationRepository.GetItem(newReservation.Id);

                if (reservation == null)
                {
                    return BadRequest();
                }

                var newReservationDTO = newReservation.ConvertToDto();

                return CreatedAtAction(nameof(GetItem), new { newReservationDTO.id }, newReservationDTO);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                             "Error writing data in the database");
            }

        }

        [HttpPut]
        public async Task<ActionResult<ResponseReservationDTO>> PutItem([FromBody] UpdateReservationDTO reservationDTO)
        {
            try
            {
                var reservation = await this.reservationRepository.PutItem(reservationDTO);

                if(reservation != null)
                {
                    return Ok(reservation.ConvertToDto());
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
