namespace Degenooru.Berate.Modules.Authentication
{
    /// <summary>
    ///     Represents an <see cref="IModuleAuthentication"/> instance with a <c>password</c>.
    /// </summary>
    public interface IPasswordAuthentication : IModuleAuthentication
    {
        string Password { get; }
    }
}