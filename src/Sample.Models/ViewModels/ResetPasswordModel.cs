namespace Sample.Models.ViewModels;

public class ResetPasswordModel
{
    [LocalizedRequired("/ResetPassword/Form/Empty/NewPassword")]
    public string NewPassword { get; set; }

    [LocalizedRequired("/ResetPassword/Form/Empty/ConfirmPassword")]
    [LocalizedCompare("NewPassword", "/ResetPassword/Form/Error/InvalidConfirmPassword")]
    public string ConfirmNewPassword { get; set; }
    public string Token { get; set; }
    public string UserId { get; set; }
}