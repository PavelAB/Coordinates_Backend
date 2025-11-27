using Coordiantes_Tools.Results;
using Coordinates_API.Dtos.Result;
using Coordinates_API.Dtos.Spot;
using Coordinates_API.Mappers;
using Coordinates_CQS_Domain.Entities.Spot;
using Coordinates_CQS_Domain.Queries.Spot;
using Coordinates_CQS_Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Coordinates_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpotController : Controller
    {
        private readonly ISpotRepository _spotRepository;

        public SpotController(ISpotRepository spotRepository)
        {
            this._spotRepository = spotRepository;
        }

        [HttpPost("GetByCoordinates")]
        public async Task<IActionResult> GetSpotById(SpotGet searchedSpot)
        {
            try
            {
                GetSpotQuery getSpotQueryStart = new(longitude: searchedSpot.Longitude, latitude: searchedSpot.Latitude);

                ICqsResult<List<Spot_Get>> spots = await _spotRepository.ExecuteAsync(getSpotQueryStart);

                IApiResult<List<Spot_Get>> result = spots.ToIApiResult();

                if (result.IsFailure)
                    BadRequest(result);

                return Ok(result);
                
            }
            catch (Exception e)
            {
                return StatusCode(500, IApiResult.Failure(e.Message));
            }
            
        }

        [HttpGet("GetSpots")]
        public async Task<IActionResult> GetSpots(
            [FromQuery] Guid? idSpot,
            [FromQuery] decimal? latitude,
            [FromQuery] decimal? longitude,
            [FromQuery] string? name,
            [FromQuery] Guid? createdBy,
            [FromQuery] bool? isPrivate )
        {
            try
            {
                GetSpotQuery getSpots = new(idSpot, longitude, latitude, name, createdBy, isPrivate);

                ICqsResult<List<Spot_Get>> spots = await _spotRepository.ExecuteAsync(getSpots);
                IApiResult<List<Spot_Get>> result = spots.ToIApiResult();

                if (result.IsFailure)
                    return BadRequest(result);


                return Ok(result);
            }
            catch (Exception e )
            {
                return StatusCode(500, IApiResult.Failure(e.Message));
            }
        }
    }
}
