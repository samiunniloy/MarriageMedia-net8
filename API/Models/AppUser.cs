using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class AppUser
    {
        public int ID { get; set; } = 0;
        [Required]
        public string UserName { get; set; } = "";
         
    }
        
}
