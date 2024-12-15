using API.Models;
using MongoDB.Driver;

namespace API.DataAccessLayer
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly MongoClient _mongoClient;
        private readonly IMongoCollection<AppUser> _mongoCollection;
        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _mongoClient = new MongoClient(_configuration["DatabaseSettings:ConnectionString"]);
            var _MongoDatabase = _mongoClient.GetDatabase(_configuration["DatabaseSettings:DatabaseName"]);
            _mongoCollection = _MongoDatabase.GetCollection<AppUser>("Users");
        }
        public async Task<AddUserResponse> AddUser(AppUser request)

        {
            AddUserResponse response = new AddUserResponse();
            response.IsSuccess = true;
            response.Message = "Succesfull";
            try
            {
                await _mongoCollection.InsertOneAsync(request);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occur " + ex.Message;
            }
            return response;
        }
    }
}
