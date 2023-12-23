using System.ComponentModel.DataAnnotations;

namespace EcommerceMVC.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(25)]

        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; } = null!;

        public bool Sex { get; set; } = true ;

        public DateTime? BirthDay { get; set; }
        [Required]
        [MaxLength(60)]
        public string Address { get; set; }
        [Required]
        [MaxLength(24)]
        [RegularExpression(@"0[9875]\d{8}")]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        public string? Image { get; set; }

    }
}
