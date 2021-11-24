# Degenooru
_Degenooru_ is a .NET 5.0+ library written in C#, designed for accessing the APIs of numerous different sites, namely image boards, all from a simplified module system.

Why image boards? Because I thought it was funny.

### Why "Degenooru"?
That's pretty simple, _Degenooru_ is a portmanteau of "degenerate" and "booru", a self-explanatory name if I do say so myself.

By extension, the back-end API of _Degenooru_ is called `Berate` because it consists of the missing letters from both original words (**b**ooru and degen**erate**). It was only by chance that it happened to spell out an actual word.

## Purpose
_Degenooru_—the back-end, that is—enables a developer to implement an API using a sort of module system, which can be plugged into an `ApiClient` object for easy usage.

Example:
```c#
class MyApiModule : IApiModule {
    // implementation...
}

class Program {
    static async Task Main() {
        using ApiClient client = new();
        client.AddModule(new MyApiModule(new AuthlessAuthentication());
        ApiResonse<MyResponse> response = client.Get<MyResponse, MyApiModule>(params);
        
        // and if you want to access the module directly...
        response = client.GetRequiredModule<MyApiModule>().ExampleMethodReturnsResponse(params);
        
        // responses are wrapped in an ApiResponse<T>, which contains information about any mishaps (errors) if one were to occur
    }
}
```

The reason for this is to unify large APIs into a more centralized system. If you, say, have an API with many calls but unique object types for each response, using them and simply parsing any given parameters is arguably more reasonable. You can define individual methods in your module for the retrieval of each type, but using an `ApiClient` with your module is as simple as calling `client.Get<ResponseType, ModuleType>(applicableParameters)`. All that is required is documentation.