using System.Collections.Generic;

namespace Degenooru.Berate.Modules.Authentication
{
    /// <summary>
    ///     The interface implemented by all forms of authentication.
    /// </summary>
    public interface IModuleAuthentication
    {
        /// <summary>
        ///     An enumerable collection of all <see cref="IApiModule"/>s authenticated using this instance.
        /// </summary>
        List<IApiModule> AuthenticatedModules { get; }
    }
}