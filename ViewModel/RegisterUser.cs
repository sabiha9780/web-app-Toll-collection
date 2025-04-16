using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebAppTollCollection.ViewModel
{


    public class RegisterUser
    {
        [Required, StringLength(50, MinimumLength = 3)]
        public string UserName { get; set; }
        
        [Required, EmailAddress, StringLength(50, MinimumLength = 4)]
        public string UserEmail { get; set; }


        [Required, DataType(DataType.Password), StringLength(50, MinimumLength = 4)]
        public string Password { get; set; }


        [Compare("Password"), DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }

    }

    public class LoginUser
    {
        [Required, EmailAddress, StringLength(50, MinimumLength = 4)]
        public string UserEmail { get; set; }


        [Required, DataType(DataType.Password), StringLength(50, MinimumLength = 4)]
        public string Password { get; set; }


        [DisplayName("Remember Me?")]
        public bool RememberMe { get; set; }

    }

}