using System.Net.Http.Headers;
using System.Text.Json;
using ArmoryWeb.Data.Records;
using Character = ArmoryWeb.Models.Character;
using Item = ArmoryWeb.Models.Item;

namespace ArmoryWeb.Data;

public class BattleNet : IBattleNet
{
    private readonly IConfiguration _config;
    private readonly string _apiKey;
    private readonly string _apiSecret;
    private static string _apiToken = String.Empty;
    private static DateTime? _apiTokenExpiration = null;

    public BattleNet(IConfiguration config)
    {
        _config = config;
        _apiKey = _config["APIKey"]!;
        _apiSecret = _config["APISecret"]!;
    }
    public Character GetCharacter(string name, string realm, int region)
    {
        string _dbPath = "/profile/wow/character/{realmSlug}/{characterName}/equipment?namespace=profile-us&locale=en_US";
        
        string queryString = _dbPath
            .Replace("{realmSlug}", realm.ToLower())
            .Replace("{characterName}", name.ToLower());

        string jsonResponse = CallAPI(queryString).GetAwaiter().GetResult();
        //string jsonResponse =
        //    File.ReadAllText(@"C:\Users\dzieg\Documents\projects\cs\WoW Armory\Armory.Data\example_character.json");

        var characterData = JsonSerializer.Deserialize<CharacterRecord>(jsonResponse)!;

        var gear = new List<Item>();

        foreach (var item in characterData.equipped_items)
        {
            gear.Add(new Item()
            {
                Armor = item.armor.value,
                Image = item.media.key.href,
                Id = item.item.id,
            });
        }
        
        var character = new Character()
        {
            Id = characterData.character.id,
            Name = characterData.character.name,
            Equipment = gear,
        };

        return character;
    }

    public Item GetItem(int id)
    {
        string _dbPath = "data/wow/item/{itemId}?namespace=static-10.0.2_46479-us";

        string queryString = _dbPath.Replace("{itemId}", id.ToString());
        
        string jsonResponse = CallAPI(queryString).GetAwaiter().GetResult();

        throw new NotImplementedException();
    }
    
    private async Task<string> RequestTokenToAuthorizationServer(Uri uriAuthorizationServer, string clientId, string scope, string clientSecret)
    {
        HttpResponseMessage responseMessage;
        using (HttpClient client = new HttpClient())
        {
            HttpRequestMessage tokenRequest = new HttpRequestMessage(HttpMethod.Post, uriAuthorizationServer);
            HttpContent httpContent = new FormUrlEncodedContent(
                new[]
                {
                    new KeyValuePair<string, string>("grant_type", "client_credentials"),
                    new KeyValuePair<string, string>("client_id", clientId),
                    new KeyValuePair<string, string>("scope", scope),
                    new KeyValuePair<string, string>("client_secret", clientSecret)
                });
            tokenRequest.Content = httpContent;
            responseMessage = await client.SendAsync(tokenRequest);
        }

        return await responseMessage.Content.ReadAsStringAsync();
    }
    
    private async Task<string> CallAPI(string endpoint)
    {
        if (_apiKey == String.Empty || _apiSecret == String.Empty)
            throw new Exception("Client not initialized");

        HttpResponseMessage response;

        using (HttpClient client = new())
        {
            if (_apiToken == String.Empty || _apiTokenExpiration is null ||
                DateTime.Now.CompareTo(_apiTokenExpiration) > 0)
            {
                var TokenReply = await RequestTokenToAuthorizationServer(new Uri($"{GetOAuthEndpoint(1)}oauth/token"), 
                                                                                _apiKey, 
                                                                                "scope", 
                                                                                _apiSecret);
                //var TokenReply = await response.Content.ReadAsStringAsync();
                var OAuthToken = JsonSerializer.Deserialize<OAuth2Token>(TokenReply);

                _apiToken = OAuthToken?.access_token;
                _apiTokenExpiration = DateTime.Now.AddSeconds(OAuthToken.expires_in);
            }
        }

        using (HttpClient client = new())
        {
            client.BaseAddress = new Uri(GetAPIEndpoint(1));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken);

            response = client.GetAsync($"{endpoint}&access_token={_apiToken}").GetAwaiter().GetResult();

            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }
    }
    
    private string GetOAuthEndpoint(int region)
    {
        return region switch
        {
            1 => "https://us.battle.net/",
            2 => "https://eu.battle.net/",
            3 => "https://kr.battle.net/",
            4 => "https://tw.battle.net/",
            5 => "https://gateway.battlenet.com.cn/",
            _ => throw new Exception("Invalid Region")
        };
    }
    
    internal static string GetAPIEndpoint(int region)
    {
        return region switch
        {
            1 => "https://us.api.blizzard.com/",
            2 => "https://eu.api.blizzard.com/",
            3 => "https://kr.api.blizzard.com/",
            4 => "https://tw.api.blizzard.com/",
            5 => "https://gateway.battlenet.com.cn/",
            _ => throw new Exception("Invalid Region")
        };
    }
}