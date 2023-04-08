using System.ComponentModel.DataAnnotations;

namespace WebsiteConverter.Models
{
    public class ContactViewModel
    {
        //We can use data annotation to add validation to our model.
        //This is useful when we have required info or need certain types of info
        [Required(ErrorMessage = "* Name is Required")] //* Field is required
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "* Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required]
        public string Subject { get; set; } = null!;

        [Required(ErrorMessage = "* Message is Required")]
        [DataType(DataType.MultilineText)]//Makes a text area instead of a box
        public string Message { get; set; } = null!;

    }
}
