using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace HardysWebSystem.Server.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} " +
                                         "characters long.", MinimumLength = 2)]
        public override string UserName { get; set; }

        /*[DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} " +
                                         "characters long.", MinimumLength = 2)]
        public string FirstName { get; set; }
        
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} " +
                                         "characters long.", MinimumLength = 2)]
        public string LastName { get; set; }*/
    }
}
