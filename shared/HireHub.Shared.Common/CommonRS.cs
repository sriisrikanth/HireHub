using System.Globalization;

namespace HireHub.Shared.Common;

public class CommonRS
{
    public static CultureInfo Culture
    {
        get
        {
            return CommonRS.Culture;
        }
        set
        {
            CommonRS.Culture = value;
        }
    }

    /// <summary>
    ///   Looks up a localized string similar to Access denied for role {0} on resource {1}.
    /// </summary>
    public static string Auth_AccessDenied_Format_Message => Common.Auth_AccessDenied;
    public static string Auth_AccessDenied_Format(string role, string resource)
        => string.Format(Common.Auth_AccessDenied, role, resource);

    /// <summary>
    ///   Looks up a localized string similar to Invalid credentials for user {0}.
    /// </summary>
    public static string Auth_InvalidCredentials_Format_Message => Common.Auth_InvalidCredentials;
    public static string Auth_InvalidCredentials_Format(string username)
        => string.Format(Common.Auth_InvalidCredentials, username);

    /// <summary>
    ///   Looks up a localized string similar to User {0} has exceeded maximum login attempts ({1}).
    /// </summary>
    public static string Auth_MaxLoginAttemptsExceeded_Format_Message => Common.Auth_MaxLoginAttemptsExceeded;
    public static string Auth_MaxLoginAttemptsExceeded_Format(string username, string maxAttempts)
        => string.Format(Common.Auth_MaxLoginAttemptsExceeded, username, maxAttempts);

    /// <summary>
    ///   Looks up a localized string similar to Password must contain at least {0} uppercase, {1} lowercase, and {2} special characters.
    /// </summary>
    public static string Auth_PasswordComplexity_Format_Message => Common.Auth_PasswordComplexity;
    public static string Auth_PasswordComplexity_Format(string upper, string lower, string special)
        => string.Format(Common.Auth_PasswordComplexity, upper, lower, special);

    /// <summary>
    ///   Looks up a localized string similar to File {0} not found in directory {1}.
    /// </summary>
    public static string Error_FileNotFound_Format_Message => Common.Error_FileNotFound;
    public static string Error_FileNotFound_Format(string fileName, string directory)
        => string.Format(Common.Error_FileNotFound, fileName, directory);

    /// <summary>
    ///   Looks up a localized string similar to Operation {0} failed due to {1}.
    /// </summary>
    public static string Error_OperationFailed_Format_Message => Common.Error_OperationFailed;
    public static string Error_OperationFailed_Format(string operation, string reason)
        => string.Format(Common.Error_OperationFailed, operation, reason);

    /// <summary>
    ///   Looks up a localized string similar to An error occurred while processing {0}: {1}.
    /// </summary>
    public static string Error_ProcessingFailed_Format_Message => Common.Error_ProcessingFailed;
    public static string Error_ProcessingFailed_Format(string item, string reason)
        => string.Format(Common.Error_ProcessingFailed, item, reason);

    /// <summary>
    ///   Looks up a localized string similar to Service {0} returned status code {1}.
    /// </summary>
    public static string Error_ServiceResponse_Format_Message => Common.Error_ServiceResponse;
    public static string Error_ServiceResponse_Format(string service, string statusCode)
        => string.Format(Common.Error_ServiceResponse, service, statusCode);

    /// <summary>
    ///   Looks up a localized string similar to {0} must be a date after {1}.
    /// </summary>
    public static string Validation_DateAfter_Format_Message => Common.Validation_DateAfter;
    public static string Validation_DateAfter_Format(string field, string date)
        => string.Format(Common.Validation_DateAfter, field, date);

    /// <summary>
    ///   Looks up a localized string similar to {0} must be a date before {1}.
    /// </summary>
    public static string Validation_DateBefore_Format_Message => Common.Validation_DateBefore;
    public static string Validation_DateBefore_Format(string field, string date)
        => string.Format(Common.Validation_DateBefore, field, date);

    /// <summary>
    ///   Looks up a localized string similar to {0} must be within the range {1} to {2}.
    /// </summary>
    public static string Validation_DateRange_Format_Message => Common.Validation_DateRange;
    public static string Validation_DateRange_Format(string field, string startDate, string endDate)
        => string.Format(Common.Validation_DateRange, field, startDate, endDate);

    /// <summary>
    ///   Looks up a localized string similar to {0} cannot be earlier than {1}.
    /// </summary>
    public static string Validation_DateTooEarly_Format_Message => Common.Validation_DateTooEarly;
    public static string Validation_DateTooEarly_Format(string field, string earliestDate)
        => string.Format(Common.Validation_DateTooEarly, field, earliestDate);

    /// <summary>
    ///   Looks up a localized string similar to {0} should not exceed {1} characters.
    /// </summary>
    public static string Validation_MaxLengthExceeded_Format_Message => Common.Validation_MaxLengthExceeded;
    public static string Validation_MaxLengthExceeded_Format(string field, string maxLength)
        => string.Format(Common.Validation_MaxLengthExceeded, field, maxLength);

    /// <summary>
    ///   Looks up a localized string similar to {0} must be at least {1} characters long.
    /// </summary>
    public static string Validation_MinLengthRequired_Format_Message => Common.Validation_MinLengthRequired;
    public static string Validation_MinLengthRequired_Format(string field, string minLength)
        => string.Format(Common.Validation_MinLengthRequired, field, minLength);

    /// <summary>
    ///   Looks up a localized string similar to {0} must be a valid number between {1} and {2}.
    /// </summary>
    public static string Validation_NumberRange_Format_Message => Common.Validation_NumberRange;
    public static string Validation_NumberRange_Format(string field, string min, string max)
        => string.Format(Common.Validation_NumberRange, field, min, max);

    /// <summary>
    ///   Looks up a localized string similar to {0} cannot be less than {1} or greater than {2}.
    /// </summary>
    public static string Validation_OutOfBounds_Format_Message => Common.Validation_OutOfBounds;
    public static string Validation_OutOfBounds_Format(string field, string min, string max)
        => string.Format(Common.Validation_OutOfBounds, field, min, max);

    /// <summary>
    ///   Looks up a localized string similar to {0} must be between {1} and {2}.
    /// </summary>
    public static string Validation_RangeBetween_Format_Message => Common.Validation_RangeBetween;
    public static string Validation_RangeBetween_Format(string field, string min, string max)
        => string.Format(Common.Validation_RangeBetween, field, min, max);

    /// <summary>
    ///   Looks up a localized string similar to {0} must be a valid time format (e.g., {1}).
    /// </summary>
    public static string Validation_TimeFormat_Format_Message => Common.Validation_TimeFormat;
    public static string Validation_TimeFormat_Format(string field, string exampleFormat)
        => string.Format(Common.Validation_TimeFormat, field, exampleFormat);

}
