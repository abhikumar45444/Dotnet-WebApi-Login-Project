using System.ComponentModel.DataAnnotations;

namespace LoginApi.DTOs.Auth;

public class SignupRequest
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name {get; set;} = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(255)]
    public string Email {get; set;} = string.Empty;

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Password {get; set;} = string.Empty;

}