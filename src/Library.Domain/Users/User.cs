using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Users
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }   
    }
}
