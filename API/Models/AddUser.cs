using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    
    public class AddUserResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
