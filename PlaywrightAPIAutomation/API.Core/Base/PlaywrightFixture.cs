using API.Core.Base.Interface;
using API.Core.Config;
using Microsoft.Playwright;

namespace API.Core.Base
{
    public class PlaywrightFixture : IPlaywrightFixture
    {
        public IPlaywright? _Playwright { get; set; }
        public IAPIRequestContext? RequestContext { get; set; }
        public IAPIResponse? Response { get; set; }
        public static TestConfiguration? Config = ConfigReader.ReadConfig();

        public async Task<IAPIRequestContext> CreateAsync()
        {
            // Initialization of Playwright object & Request Context...
            _Playwright = await Playwright.CreateAsync();
            RequestContext = await _Playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                BaseURL = Config!.BaseUrl,
                IgnoreHTTPSErrors = true,
            });
            return RequestContext;
        }
    }
}