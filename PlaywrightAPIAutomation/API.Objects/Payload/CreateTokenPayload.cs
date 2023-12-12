using API.Core.Base;
using API.Core.Config;
using Microsoft.Playwright;
using Microsoft.Playwright.Core;

namespace API.Objects.EndPoint
{
    public class CreateTokenPayload
    {
        public static IFormData GetTokenFormData()
        {
            var config = PlaywrightFixture.Config!;

            FormData formDataContent = new FormData();
            formDataContent.Set("Organisation", config.Organisation);
            formDataContent.Set("UserName", config.UserName);
            formDataContent.Set("Password", config.Password);
            formDataContent.Set("HomeRealmUri", config.HomeRealmUri);

            return formDataContent;
        }
    }
}