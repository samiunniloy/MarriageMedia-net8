namespace API.Models
{
    public class GatAllUserResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<AppUser> data { get; set; }
    }
}
