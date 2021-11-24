using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Degenooru.Berate.Client;
using Degenooru.Berate.Modules;
using Degenooru.Berate.Modules.Authentication;
using Newtonsoft.Json;

/*** Rate limiting not supported. ***/

namespace Degenooru.Example
{
    public class XinCraftApiModule : IApiModule
    {
        public const string BaseUrl = "https://xincraft.net/api/v1";

        private readonly HttpClient Client; 
        
        public IModuleAuthentication Authentication { get; }

        public XinCraftApiModule(IModuleAuthentication authentication)
        {
            Authentication = authentication;
            
            Client = new HttpClient();
        }

        public async Task<ApiResponse<T>> GetAsync<T>(params object[] args) => await HandleRequest<T>(args);

        private async Task<ApiResponse<T>> HandleRequest<T>(params object[] args)
        {
            ApiResponse<T> response = new(default, new ApiError(errorReason: ""));

            if (typeof(T) == typeof(UserInfo))
            {
                if (args.Length != 2)
                    return response;

                if (args[0] is not string type || args[1] is not string content)
                    return response;

                response = await GetFromEndpoint<T>($"/player/{type}/" + content);
            }

            return response;
        }

        private async Task<ApiResponse<T>> GetFromEndpoint<T>(string endpoint)
        {
            string url = BaseUrl + endpoint;
            using HttpResponseMessage response = await Client.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApiResponse<T>>(json);
        }

        // Only authentication we really need to do is handle checking the type.
        // We'll also properly add headers to our HTTP client here.
        // This may vary depending on your implementation.
        public async Task AuthenticateAsync()
        {
            if (Authentication is not ITokenAuthentication token)
                throw new Exception("Unacceptable authentication type.");
            
            ProductInfoHeaderValue userAgent = new("Degenooru.Example", "1.0.0.0");
            Client.DefaultRequestHeaders.UserAgent.Add(userAgent);
            Client.DefaultRequestHeaders.Add("xincraft-api", token.Token);
            
            await Task.CompletedTask;
        }
        
        public void Dispose()
        {
            Client.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}