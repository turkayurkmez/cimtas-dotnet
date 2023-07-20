using System.ComponentModel.DataAnnotations;

namespace introduceDotnetCore.Models
{
    public class UserResponse
    {
        [Required(ErrorMessage = "Lütfen adınızı belirtin")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Eposta adresiniz lazım :)")]
        [EmailAddress(ErrorMessage = "Böyle e-posta adresi mi olur!")]
        public string Email { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
