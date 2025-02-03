using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Common.DTOs
{
    public class LoginGoogleDTO
    {
        [EmailAddress]
        public required string Email { get; set; }
        public required string Sub { get; set; }
        public required string Jti { get; set; }
    }
}
