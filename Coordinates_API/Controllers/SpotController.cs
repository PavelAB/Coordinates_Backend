using Coordiantes_Tools.Results;
using Coordinates_API.Dtos.Result;
using Coordinates_API.Dtos.Spot;
using Coordinates_API.Mappers;
using Coordinates_CQS_Domain.Commands.Spot;
using Coordinates_CQS_Domain.Entities.Spot;
using Coordinates_CQS_Domain.Queries.Spot;
using Coordinates_CQS_Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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
        [Authorize]
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
                string[] allowedKeys = new[]
                    {
                        "idSpot",
                        "latitude",
                        "longitude",
                        "name",
                        "createdBy",
                        "isPrivate"
                    };

                IEnumerable<string> queryKeys = HttpContext.Request.Query.Keys;

                List<string> invalidParams = queryKeys
                    .Except(allowedKeys, StringComparer.OrdinalIgnoreCase)
                    .ToList();

                if (invalidParams.Any())
                    return BadRequest(invalidParams);


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

        [HttpGet("GetSpotsLight")]
        public async Task<IActionResult> GetSpotsLight(
            [FromQuery] Guid? idSpot,
            [FromQuery] decimal? latitude,
            [FromQuery] decimal? longitude,
            [FromQuery] string? name,
            [FromQuery] Guid? createdBy,
            [FromQuery] bool? isPrivate)
        {
            try
            {
                GetSpotLight spotsLight = new(idSpot, longitude, latitude, name, createdBy, isPrivate);

                ICqsResult<List<Spot_Light>> spots = await _spotRepository.ExecuteAsync(spotsLight);
                IApiResult<List<Spot_Light>> result = spots.ToIApiResult();

                if (result.IsFailure)
                    return BadRequest(result);

                return Ok(result);

            }
            catch (Exception e)
            {

                return StatusCode(500, IApiResult.Failure(e.Message));
            }
        }

        [HttpPost("CreateSpot")]
        [Authorize]
        public async Task<IActionResult> CreateSpot(SpotCreate value)
        {
            try
            {
                CreateSpotCommand newSpot = new(value.Latitude, value.Longitude, value.Elevation, value.CreatedBy, value.Name, value.EntityType, value.SurfaceType);

                ICqsResult cqsResult = _spotRepository.Execute(newSpot);

                IApiResult result = cqsResult.ToIApiResult();

                if(result.IsFailure)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, IApiResult.Failure(e.Message));
            }
        }
        [HttpPut("UpdateSpot")]
        [Authorize]
        public async Task<IActionResult> UpdateSpot(SpotUpdate value)
        {
            try
            {
                UpdateSpotCommand newCommand = new(
                    value.IdSpot,
                    value.UpdatedBy,
                    value.Latitude,
                    value.Longitude,
                    value.Elevation,
                    value.IsPrivate,
                    value.Name);
                ICqsResult cqsResult = _spotRepository.Execute(newCommand);
                IApiResult result = cqsResult.ToIApiResult();

                if(result.IsFailure)
                    return BadRequest(result);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, IApiResult.Failure(e.Message));
            }
        }

        [HttpPost("DeleteSpot")]
        [Authorize]
        public async Task<IActionResult> DeleteSpot(SpotDelete value)
        {
            try
            {
                DeleteSpotCommand newCommand = new(
                    value.IdSpot,
                    value.DeletedBy
                    );

                ICqsResult cqsResult = _spotRepository.Execute(newCommand);
                IApiResult result = cqsResult.ToIApiResult();

                if (result.IsFailure) return BadRequest();
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, IApiResult.Failure(e.Message));
            }
        }
        
    }
}
