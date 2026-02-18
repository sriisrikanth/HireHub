namespace HireHub.Shared.Common.Models;

public class BaseResponse
{
    public List<object> Warnings { get; set; } = new List<object>();

    public List<object> Errors { get; set; } = new List<object>();
}
