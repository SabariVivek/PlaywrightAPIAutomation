using Microsoft.Playwright;

namespace API.Objects.Payload
{
    public class CommonPayload
    {
        public static IEnumerable<KeyValuePair<string, string>> BearerToken()
        {
            KeyValuePair<string, string> header = new KeyValuePair<string, string>
                ("Authorization", "Bearer " + Entity.CreateTokenEntity.Token);
            yield return header;
        }
    }
}