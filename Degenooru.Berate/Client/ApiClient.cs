using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Degenooru.Berate.Modules;

namespace Degenooru.Berate.Client
{
    /// <summary>
    ///     A simple client that supports the handling of API modules.
    /// </summary>
    public class ApiClient : IDisposable
    {
        protected List<IApiModule> ApiModules { get; } = new();

        public virtual async Task AddModule(IApiModule module)
        {
            await module.AuthenticateAsync();
            ApiModules.Add(module);
        }

        public virtual TApiModule GetRequiredModule<TApiModule>() where TApiModule : IApiModule =>
            (TApiModule) ApiModules.First(x => x.GetType() == typeof(TApiModule));

        public virtual TApiModule? GetModule<TApiModule>() where TApiModule : IApiModule =>
            (TApiModule?) ApiModules.First(x => x.GetType() == typeof(TApiModule));

        public virtual ApiResponse<T> Get<T, TEnum, TApiModule>(TEnum @enum, params object[] args)
            where TEnum : Enum where TApiModule : IApiModule =>
            GetRequiredModule<TApiModule>().Get<T, TEnum>(@enum, args);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            foreach (IApiModule module in ApiModules)
                module.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}