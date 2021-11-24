using System;
using System.Threading.Tasks;
using Degenooru.Berate.Modules.Authentication;

namespace Degenooru.Berate.Modules
{
    /// <summary>
    ///     The basic information required for a module.
    /// </summary>
    public interface IApiModule : IDisposable
    {
        /// <summary>
        ///     The authentication method this API uses.
        /// </summary>
        IModuleAuthentication Authentication { get; }

        /// <summary>
        ///     Authenticates the module using the <see cref="Authentication"/> property.
        /// </summary>
        Task AuthenticateAsync();
    }
}