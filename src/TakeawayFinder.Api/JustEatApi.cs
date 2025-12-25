namespace TakeawayFinder.Api;

public class JustEatApi
{
    static HttpClient client = new HttpClient();

    public static async Task<string> GetData()
    {
        using HttpResponseMessage response = await client.GetAsync("https://uk.api.just-eat.io/restaurants/bypostcode/e62jj");
        
        string responseBody = await response.Content.ReadAsStringAsync();

        return responseBody;
    }
}