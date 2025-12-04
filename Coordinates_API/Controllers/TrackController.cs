using Coordiantes_Tools.Results;
using Coordinates_API.Dtos.Result;
using T = Coordinates_API.Dtos.Track;
using Coordinates_API.Mappers;
using Coordinates_CQS_Domain.Commands.Track;
using Coordinates_CQS_Domain.Entities.Track;
using Coordinates_CQS_Domain.Queries.Track;
using Coordinates_CQS_Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coordinates_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : Controller
    {
        private readonly ITrackRepository _trackRepository;
        public TrackController(ITrackRepository trackRepository)
        {
            _trackRepository = trackRepository;
        }

        [HttpPost("CreateTrack")]
        [Authorize]
        public async Task<IActionResult> CreateTrack(T.TrackCreate value)
        {
            try
            {
                CreateTrackCommand newTrack = new(
                    value.Distance,
                    value.Ascent,
                    value.Descent,
                    value.PolyLine,
                    value.CreatedBy,
                    value.IsPrivate,
                    value.EntityType,
                    value.Surface,
                    value.Name);

                ICqsResult cqsResult = _trackRepository.Execute(newTrack);
                IApiResult result = cqsResult.ToIApiResult();

                if (result.IsFailure)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, IApiResult.Failure(e.Message));
            }
        }

        [HttpGet("GetTracks")]
        //[Authorize]
        public async Task<IActionResult> GetTracks(
            [FromQuery] Guid? idTrack,
            [FromQuery] decimal? distance,
            [FromQuery] decimal? ascent,
            [FromQuery] decimal? descent,
            [FromQuery] string? name,
            [FromQuery] Guid? createdBy            
            )
        {
            try
            {
                string[] allowedKeys = new[]
                    {
                        "idTrack",
                        "distance",
                        "ascent",
                        "descent",
                        "createdBy",
                        "name"
                    };

                IEnumerable<string> queryKeys = HttpContext.Request.Query.Keys;

                List<string> invalidParams = queryKeys
                    .Except(allowedKeys, StringComparer.OrdinalIgnoreCase)
                    .ToList();

                if (invalidParams.Any())
                    return BadRequest(invalidParams);

                GetTrackQuery query = new(idTrack, distance, ascent, descent, name, createdBy );

                ICqsResult<List<Track_Get>> tracks = await _trackRepository.ExecuteAsync(query);
                IApiResult<List<Track_Get>> result = tracks.ToIApiResult();

                if(result.IsFailure)
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
