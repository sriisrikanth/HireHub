using DocumentFormat.OpenXml.Spreadsheet;
using HireHub.Core.Data.Models;

namespace HireHub.Core.Utils.Common;

public static class LogMessage
{
    public const string StartMethod = "Start - {Method}";
    public const string EndMethod = "End - {Method}";
    public const string EndMethodException = "End - {Method} - {Exception}";
    public const string UserNotFoundOnLogin = "Login failed: user not found: {Username}";
    public const string InvalidPassword = "Login failed: invalid password for {EmpId}";
    public const string NotActiveUser = "Login failed: {EmpId} is not a Active User";
    public const string UserNotFound = "User not found: {Username}";
    public const string OtpValidationFailed = "Otp validation failed for user: {Username}";
}

public static class ExceptionMessage
{
    public const string JwtNotConfigured = "JWT settings not configured";
    public const string ConnectionStringNotConfigured = "ConnectionString not configured";
    public const string AzureLogicAppNotConfigured = "Azure Logic App not configured";
    public const string UserIdNotSetOnMiddleware = "Middlerware failed: User Id not set";
    public const string UserRoleNotSetOnMiddleware = "Middlerware failed: User Role not set";
}

public static class ResponseMessage
{
    public const string NotActiveUser = "You are not a Active User";
    public const string PasswordSetRequire = "Password require to be set";
    public const string PasswordReSetRequire = "Password require to be re-set";
    public const string InvalidExperienceLevel = "Provided Candidate Experience Level is Invalid";
    public const string EmailOrPhoneAlreadyExist = "Email or Phone number already exist";
    public const string InvalidRole = "Provided Role is Invalid";
    public const string ExcelFileEmpty = "Excel file is empty";
    public const string CellValueConvertionFailed = "Cell value convertion failed";
    public const string UpdatedSuccessfully = "Updated Successfully";
    public const string EmailNotFound = "Email not found";
    public const string PasswordChangedSuccessfully = "Password Changed Successfully";
    public const string OtpValidationFailed = "Otp validation failed";
    public const string DuplicateRecordsFound = "Duplicate records found for email or phone";
    public const string NoHrs = "Minimum one HR should be add";
    public const string NoPanelMembers = "Minimum one Panel member should be add";
    public const string NoMentors = "Minimum one Mentor should be add";
    public const string SomeUserNotFound = "Some user not found";
    public const string SomeInactiveUsersFound = "Some users are Inactive";
    public const string SomeUserNotInSpecifiedRole = "Some user not in a Specified Role";
    public const string SomeUsersAssignedToAnotherActiveDriveOnSameDate = "Some users are assigned to another active Drive on same Date";
    public const string SomeDuplicateUsersFoundIn = "Some duplicate users found in {0} list";
    public const string UserNotFound = "User not found";
    public const string DriveNotFound = "Drive not found";
    public const string SomeDriveNotFound = "Some Drive not found";
    public const string CandidateNotFound = "Candidate not found";
    public const string UserNotInSpecifiedRole = "User not in a Specified Role";
}

public static class FieldName
{
    //public const string Password = "Password";
    //public const string Username = "Username";
    //public const string Email = "Email";
    //public const string Role = "Role";
}

public static class PropertyName
{
    public const string Main = "Main";
}

public static class AppSettingKey
{
    public const string DefaultConnection = "DefaultConnection";
    public const string JwtSettings = "JwtSettings";
    public const string AzureLogicApp = "AzureLogicApp";
}

public static class EmailAddress
{
    //public const string DisplayName = "Darkwolf Org";
    //public const string NoReplyDarkwolf = "noreply@darkwolf.com";
}

public static class Key
{
    public const string UserId = "UserId";
    public const string Role = "Role";
}

public static class RoleName
{
    public const string Mentor = nameof(UserRole.Mentor);
    public const string Hr = nameof(UserRole.HR);
    public const string Panel = nameof(UserRole.Panel);
    public const string Admin = nameof(UserRole.Admin);
}

public static class UserAction
{
    public const string Drive = "Drive";
}

public static class ActionType
{
    public const string View = "View";
    public const string Add = "Add";
    public const string Update = "Update";
    public const string Delete = "Delete";
}

public static class Options
{
    public static string[] Recommendations => [
        nameof(Recommendation.NoHire),
        nameof(Recommendation.Maybe),
        nameof(Recommendation.Hire)
    ];
    public static string[] ExperienceLevels => [
        nameof(CandidateExperienceLevel.Fresher),
        nameof(CandidateExperienceLevel.Intermediate),
        nameof(CandidateExperienceLevel.Experienced)
    ];
    public static string[] RoleNames => [
        nameof(UserRole.Mentor),
        nameof(UserRole.HR),
        nameof(UserRole.Panel),
        nameof(UserRole.Admin)
    ];
}

public static class Otp
{
    public const string Prefix = "OTP_";
}

public static class EmailSubject
{
    public const string ForgotPasswordOTP = "Forgot Password OTP";
}

public static class EmailBody
{
    public const string ForgotPasswordOTP =
@"Hello {0},

We received a request to reset your password.

Your One-Time Password (OTP) is: {1}

This OTP is valid for 5 minutes.
Please do not share this OTP with anyone.

If you did not request a password reset, please ignore this email.

Regards,
Your Application Team";
}