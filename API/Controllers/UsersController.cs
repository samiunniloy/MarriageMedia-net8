using API.DataAccessLayer;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository UserRepository;
        public UsersController(IUserRepository _userRepository)
        {
            UserRepository = _userRepository;
        }
        [HttpPost]
        public async Task<IActionResult> InsertRecord(AppUser request)
        {
           AddUserResponse response = new AddUserResponse();
            try
            {
                response = await UserRepository.AddUser(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occur " + ex.Message;
            }
            return Ok(response);

        }
    }
}
