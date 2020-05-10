using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HardysWebSystem.Server.Models
{
    public class ApplicationRole : IdentityRole
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} " +
                                         "characters long.", MinimumLength = 2)]
        public override string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} " +
                                          "characters long.", MinimumLength = 2)]
        public string Description { get; set; }
    }
}