using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Degenooru.Berate.Client;
using Degenooru.Berate.Modules;
using Degenooru.Berate.Modules.Authentication;
using NUnit.Framework;

namespace Degenooru.Tests.BerateTests
{
    /// <summary>
    ///     Testing authentication implementation.
    /// </summary>
    public static class SimpleAuthenticationTest
    {
        private class SimpleApiModule : IApiModule
        {
            public IModuleAuthentication Authentication { get; }

            public SimpleApiModule(IModuleAuthentication authentication)
            {
                Authentication = authentication;
            }

            public ApiResponse<T> Get<T, TEnum>(TEnum @enum, params object[] args) where TEnum : Enum =>
                new ApiResponse<T>(default, new ApiError(errorReason: "Test class."));

            public async Task AuthenticateAsync()
            {
                if (Authentication is not (IUsernameAuthentication username and IPasswordAuthentication password))
                    throw new Exception("Incorrect authentication type.");

                Console.WriteLine("Received test username: " + username.Username);
                Console.WriteLine("Received test password: " + password.Password);

                if (username.Username != "degen" || password.Password != "1234")
                    throw new Exception("Incorrect authentication.");

                Authentication.AuthenticatedModules.Add(this);
                await Task.CompletedTask;
            }

            public void Dispose()
            {
            }
        }

        // It's fine to create combined classes like these, API implementations should check for individual implemented components.
        private class UsernameAndPasswordAuthentication : IUsernameAuthentication, IPasswordAuthentication
        {
            public List<IApiModule> AuthenticatedModules { get; } = new();

            public string Username { get; init; } = "";

            public string Password { get; init; } = "";
        }

        private class FailureAuthentication : IUsernameAuthentication
        {
            public List<IApiModule> AuthenticatedModules { get; } = new();

            public string Username { get; init; } = "";
        }

        [Test]
        public static void AuthenticationSuccessTest()
        {
            ApiClient client = new();
            client.AddModule(new SimpleApiModule(new UsernameAndPasswordAuthentication
            {
                Username = "degen",
                Password = "1234"
            }));
            Assert.Pass();
        }

        [Test]
        public static void AuthenticationImproperTypeTest()
        {
            try
            {
                ApiClient client = new();
                client.AddModule(new SimpleApiModule(new FailureAuthentication
                {
                    Username = "degen"
                }));
            }
            catch (Exception e)
            {
                if (e.Message == "Incorrect authentication type.")
                    Assert.Pass();
            }
        }

        [Test]
        public static void AuthenticationMisinfoTest()
        {
            try
            {
                ApiClient client = new();
                client.AddModule(new SimpleApiModule(new UsernameAndPasswordAuthentication
                {
                    Username = "1234",
                    Password = "degen"
                }));
            }
            catch (Exception e)
            {
                if (e.Message == "Incorrect authentication.")
                    Assert.Pass();
            }
        }
    }
}