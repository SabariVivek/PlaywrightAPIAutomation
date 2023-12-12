namespace API.Tests
{
    public class TokenGenerator : TestBase
    {
        public static async Task CreateTokenAsync()
        {
            // Initialization of Playwright object & Request Context...
            PlaywrightFixture playwrightFixture = new PlaywrightFixture();
            IAPIRequestContext context =  await playwrightFixture.CreateAsync();
            IAPIResponse response = await context.PostAsync(CreateTokenEndPoint.TOKEN, new APIRequestContextOptions()
            {
                Form = CreateTokenPayload.GetTokenFormData()
            });
            
            // Validation...
            CreateTokenEntity.Token = HelperClass.ExtractJsonDataAsync(await response.JsonAsync(), "access_token").ToString()!;

        }
    }
}