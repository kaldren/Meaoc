namespace Meaoc_API.Helpers.Token
{
    public interface ITokenValidator
    {
        string ValidateExistingUserToken(string token);
    }
}