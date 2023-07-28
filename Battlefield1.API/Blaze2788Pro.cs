using RestSharp;

namespace Battlefield1.API;

public static class Blaze2788Pro
{
    private const string _host = "https://blaze.2788.pro/";

    private static readonly RestClient _client = null;

    static Blaze2788Pro()
    {
        if (_client != null)
            return;

        var options = new RestClientOptions(_host)
        {
            MaxTimeout = 5000,
            ThrowOnAnyError = false,
            ThrowOnDeserializationError = false
        };

        _client = new RestClient(options);
    }

    public static async Task<string> GetFullGameData(string gameId)
    {
        var reqBody = "{\"GIDL List<Integer>\":[" + gameId + "]}";

        var request = new RestRequest("GameManager.getFullGameData")
            .AddJsonBody(reqBody);

        var response = await _client.ExecutePostAsync(request);
        if (response.StatusCode == HttpStatusCode.OK)
            return response.Content;

        return null;
    }

    public static async Task<string> GetPlayerCore(string pidListStr)
    {
        var reqBody = "{\"CAT String\":\"player_core\",\"EID List<Integer>\":[" + pidListStr + "]}";

        var request = new RestRequest("Stats.getStats")
            .AddJsonBody(reqBody);

        var response = await _client.ExecutePostAsync(request);
        if (response.StatusCode == HttpStatusCode.OK)
            return response.Content;

        return null;
    }

    public static async Task<string> GetPlayerStatCategory(string pidListStr)
    {
        var reqBody = "{\"CAT String\":\"player_statcategory\",\"EID List<Integer>\":[" + pidListStr + "]}";

        var request = new RestRequest("Stats.getStats")
            .AddJsonBody(reqBody);

        var response = await _client.ExecutePostAsync(request);
        if (response.StatusCode == HttpStatusCode.OK)
            return response.Content;

        return null;
    }
}
