namespace BookWise.Application.User.Queries.Login
{
    public sealed record TokenResponse(string accessToken, long expires, string tokenType);
}
