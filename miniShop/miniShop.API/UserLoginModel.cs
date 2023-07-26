using System.ComponentModel.DataAnnotations;

namespace miniShop.API
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Kullanıcı adı eksik :(")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifreniz de lazım")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
