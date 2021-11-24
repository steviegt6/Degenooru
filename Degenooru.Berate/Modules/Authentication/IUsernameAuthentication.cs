namespace Degenooru.Berate.Modules.Authentication
{
    /// <summary>
    ///     Represents an <see cref="IModuleAuthentication"/> instance with a <c>username</c>.
    /// </summary>
    public interface IUsernameAuthentication : IModuleAuthentication
    {
        string Username { get; }
    }
}