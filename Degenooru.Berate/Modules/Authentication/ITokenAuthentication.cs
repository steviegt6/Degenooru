namespace Degenooru.Berate.Modules.Authentication
{
    /// <summary>
    ///     Represents an <see cref="IModuleAuthentication"/> instance with a <c>token</c>.
    /// </summary>
    public interface ITokenAuthentication : IModuleAuthentication
    {
        string Token { get; }
    }
}