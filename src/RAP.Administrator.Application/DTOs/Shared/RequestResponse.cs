namespace RAP.Administrator.Application.DTOs.Shared;


public class RequestResponse
{
    public string StatusCode { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public bool IsSuccess { get; set; }
    public object? Data { get; set; }
}
