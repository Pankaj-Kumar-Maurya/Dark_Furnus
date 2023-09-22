using System.ComponentModel.DataAnnotations;

namespace Dark_Furnus.Models
{
    public class tblRegistration
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "User Name is required.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "User Name must be between 4 and 50 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Gaming Name is required.")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Gaming Name must be between 4 and 50 characters.")]
        public string GamingName { get; set; }

        [Required(ErrorMessage = "Favorite Game is required.")]
        public string FavoriteGame { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public int Country { get; set; } // Foreign key to Country table

        public int State { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public int Gender { get; set; } // Foreign key to Gender table

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Password is required.")]
        //[RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        //    ErrorMessage = "Password must contain at least 1 uppercase letter, 4 digits, 1 special character, and be 8 characters long.")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
    }
}