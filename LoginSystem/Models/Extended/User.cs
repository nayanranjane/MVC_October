using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LoginSystem.Models
{
    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {
        public string ConfirmPassword { get; set; }

    }
    public class UserMetaData
    {
        [Display(Name = "FirstName")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        [Display(Name = "LastName")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastName is required")]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]

        public string EmailId { get; set; }

        [Display(Name = "DateOfBirth")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:mm/dd/yy}")]

        public System.DateTime DateOfBirth { get; set; }
        [Display(Name = "Password")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage ="Password must be atleast 6 character")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be atleast 6 character")]
        [Compare("Password",ErrorMessage ="Password are not matching")]
        public string ConfirmPassword { get; set; }
        public bool isEmailVerified { get; set; }
        public System.Guid ActivationCode { get; set; }
    }
}