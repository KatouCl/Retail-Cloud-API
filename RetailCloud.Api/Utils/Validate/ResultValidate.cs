namespace RetailCloud.Api.Utils.Validate
{
    public record ResultValidation(bool Successful, string? ErrorMessage = null);
}