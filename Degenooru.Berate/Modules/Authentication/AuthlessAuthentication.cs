using System.Collections.Generic;

namespace Degenooru.Berate.Modules.Authentication
{
    /// <summary>
    ///     An <see cref="IModuleAuthentication"/> implementation with zero authentication.
    /// </summary>
    public class AuthlessAuthentication : IModuleAuthentication
    {
        public List<IApiModule> AuthenticatedModules { get; } = new();
    }
}