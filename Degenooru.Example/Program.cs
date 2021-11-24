using System;
using System.Collections.Generic;
using Degenooru.Berate.Client;
using Degenooru.Berate.Modules;
using Degenooru.Berate.Modules.Authentication;
using Degenooru.Example;

Console.WriteLine("Please enter your XinCraft API key:");
string? apiKey = Console.ReadLine();

if (apiKey is null)
    throw new Exception("Null API key.");

Console.WriteLine("Please enter the name of the player you wish to retrieve the stats of:");
string? username = Console.ReadLine();

if (username is null)
    throw new Exception("Null username");

ApiClient client = new();
await client.AddModule(new XinCraftApiModule(new TokenAuth
{
    Token = apiKey
}));
ApiResponse<UserInfo> response = await client.Get<UserInfo, XinCraftApiModule>("username", username);

if (response.Error is not null)
{
    Console.WriteLine(response.Error.Value.ErrorCode);
    Console.WriteLine(response.Error.Value.ErrorReason);
}
else if (response.Value is not null)
{
    Console.WriteLine(response.Value.Name);
    Console.WriteLine(response.Value.Title);
    Console.WriteLine(response.Value.Uuid);
    Console.WriteLine(response.Value.RankColor);
}

internal class TokenAuth : ITokenAuthentication
{
    public List<IApiModule> AuthenticatedModules { get; } = new();

    public string Token { get; init; } = "";
}