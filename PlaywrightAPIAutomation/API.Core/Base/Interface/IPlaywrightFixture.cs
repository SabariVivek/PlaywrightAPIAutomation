using Microsoft.Playwright;

namespace API.Core.Base.Interface
{
    public interface IPlaywrightFixture
    {
        IPlaywright? _Playwright { get; set; }
        IAPIRequestContext? RequestContext { get; set; }
        IAPIResponse? Response { get; set; }
        Task<IAPIRequestContext> CreateAsync();
    }
}