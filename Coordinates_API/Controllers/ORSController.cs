using Coordiantes_Tools.Results;
using Coordinates_API.Dtos.Result;
using Coordinates_API.Mappers;
using Coordinates_CQS_Domain.Entities.Track;
using Coordinates_CQS_Domain.Queries.ORS;
using Coordinates_CQS_Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coordinates_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ORSController : Controller
    {
        private readonly IORSRepository _orsRepository;
        private readonly string _securityKey;

        public ORSController(IORSRepository orsRepository)
        {
            _orsRepository = orsRepository;
            _securityKey = Environment.GetEnvironmentVariable("SECURITY_ORS_KEY")!;
        }
        [HttpGet("GetORSTrack")]
        [Authorize]
        public async Task<IActionResult> GetORSTrack(
            [FromQuery] decimal LongitudeStart,
            [FromQuery] decimal LatitudeStart,
            [FromQuery] decimal LongitudeEnd,
            [FromQuery] decimal LatitudeEnd
            )
        {
            try
            {
                if (_securityKey is null)
                    throw new ArgumentNullException("ORS security key");

                GetTrackORSQuery newTrack = new(
                    new (decimal Longitude, decimal Latitude)[]
                    {
                        (LongitudeStart, LatitudeStart),
                        (LongitudeEnd, LatitudeEnd)
                    },
                    _securityKey
                );
                ICqsResult<TrackCreate> cqsResult = await _orsRepository.ExecuteAsync(newTrack);
                IApiResult<TrackCreate> result = cqsResult.ToIApiResult();

                if (result.IsFailure)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, IApiResult.Failure(e.Message));
            }
            
        }
    }
}
