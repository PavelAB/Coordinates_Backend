using Coordiantes_Tools.Results;
using Coordinates_API.Dtos;
using Coordinates_API.Dtos.Result;
using Coordinates_API.Mappers;
using Coordinates_CQS_Domain.Entities.User;
using Coordinates_CQS_Domain.Queries.User;
using Coordinates_CQS_Domain.Repositories;
using DotNetEnv;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coordinates_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthRepository _authRepository;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(IAuthRepository authRepository, ITokenRepository tokenRepository)
        {
            _authRepository = authRepository;
            _tokenRepository = tokenRepository;
        }
        [HttpPost]
        public IActionResult Login(LoginDto value)
        {

            try
            {
                if (value.Login is null || value.Password is null)
                    return BadRequest(ICqsResult.Failure("Invalid input"));

                IApiResult<User> authUser = _authRepository.Execute(new CheckPasswordQuery(value.Login, value.Password)).ToIApiResult();



                if (authUser.IsFailure)
                    return BadRequest(authUser);

                if(authUser.IsSuccess)
                    authUser.Content.Token = _tokenRepository.GenerateToken(authUser.Content);

                return Ok(authUser);
            }
            catch (Exception e)
            {
                return StatusCode(500, ICqsResult.Failure(e.Message));
            }
            
        }

        [HttpGet("GetConnectedUser")]
        [Authorize]
        public IActionResult GetConnectedUser()
        {           

            try
            {
                Guid searchId = _tokenRepository.ReadFromToken(HttpContext.Request);

                GetUserByIdQuery getUserById = new(searchId: searchId);

                ICqsResult<User> authUser = _authRepository.Execute(getUserById);

                if (authUser.IsFailure)
                    return BadRequest(authUser);

                if (authUser.IsSuccess)
                    authUser.Content.Token = _tokenRepository.GenerateToken(authUser.Content);

                return Ok(authUser);

            }
            catch (Exception e)
            {
                return StatusCode(500, ICqsResult.Failure(e.Message));
            }
        }
    
    }



}
