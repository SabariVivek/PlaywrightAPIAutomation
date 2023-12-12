using Microsoft.Playwright;

namespace API.Core.Base.Interface
{
    public interface IPlaywrightBuilder
    {
        IPlaywrightBuilder WithEndPoint(string request);
        IPlaywrightBuilder WithHeader(string headerKey, string headerValue);
        IPlaywrightBuilder WithHeaders(IEnumerable<KeyValuePair<string, string>> headers);
        IPlaywrightBuilder WithFormData(IFormData formData);
        IPlaywrightBuilder WithPayLoad(string payload);
        IPlaywrightBuilder WithQueryParameter(string queryKey, object queryValue);
        IPlaywrightBuilder WithQueryParameters(Dictionary<string, object> queryParameters);
        Task<IAPIResponse> WithGet();
        Task<IAPIResponse> WithPost();
        Task<IAPIResponse> WithPut();
        Task<IAPIResponse> WithPatch();
        Task<IAPIResponse> WithDelete();
    }
}