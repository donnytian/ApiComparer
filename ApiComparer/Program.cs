using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Readers;

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var comparerSetting = configuration.GetSection(nameof(ComparerSetting)).Get<ComparerSetting>();

foreach (var apiSetting in comparerSetting.ApiSettings)
{
    var httpClient = new HttpClient
    {
        BaseAddress = new Uri(apiSetting.BaseAddress)
    };

    await using var stream = await httpClient.GetStreamAsync(apiSetting.SwaggerJsonPath);
    var api = new OpenApiStreamReader().Read(stream, out var diagnostic);

    foreach (var (key, value) in api.Paths)
    {
        Console.WriteLine("Key:" + key);
    }
}
