namespace TrackingCompanies.Api.Models;

public class BaseResponse<T>
{
    public T? Data { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; } =  string.Empty;
    public string StatusCode { get; set; } = string.Empty;
}