using API.Core.Base.Interface;
using API.Core.Reports;
using API.Core.Utils;
using AventStack.ExtentReports.MarkupUtils;
using Microsoft.Playwright;

namespace API.Core.Base
{
    public class PlaywrightBuilder : IPlaywrightBuilder
    {
        IAPIRequestContext _requestContext;
        APIRequestContextOptions? RequestOptions { get; set; }
        string? EndPoint { get; set; }

        public PlaywrightBuilder(IAPIRequestContext requestContext)
        {
            _requestContext = requestContext;
            RequestOptions = new APIRequestContextOptions();
        }

        public IPlaywrightBuilder WithEndPoint(string endPoint)
        {
            EndPoint = endPoint;
            return this;
        }

        public IPlaywrightBuilder WithFormData(IFormData formData)
        {
            RequestOptions!.Form = formData;
            return this;
        }

        public IPlaywrightBuilder WithHeader(string headerKey, string headerValue)
        {
            Dictionary<string, string> header = new()
            {
                { headerKey, headerValue }
            };

            RequestOptions!.Headers = header;
            return this;
        }

        public IPlaywrightBuilder WithHeaders(IEnumerable<KeyValuePair<string, string>> headers)
        {
            RequestOptions!.Headers = headers;
            return this;
        }

        public IPlaywrightBuilder WithPayLoad(string payload)
        {
            RequestOptions!.Data = payload;
            return this;
        }

        public IPlaywrightBuilder WithQueryParameter(string queryKey, object queryValue)
        {
            Dictionary<string, object> queryParameter = new Dictionary<string, object>
            {
                { queryKey, queryValue }
            };

            RequestOptions!.Params = queryParameter;
            return this;
        }

        public IPlaywrightBuilder WithQueryParameters(Dictionary<string, object> queryParameters)
        {
            RequestOptions!.Params = queryParameters;
            return this;
        }

        /**
         * REST API Methods...
         */
        public async Task<IAPIResponse> WithGet()
        {
            HelperClass.PrintBasicAPIDetails(EndPoint!, "GET");
            IAPIResponse response = await _requestContext!.GetAsync(EndPoint!, RequestOptions);
            await StepInfo.LogResponseInReportAsync(response);
            return response;
        }

        public async Task<IAPIResponse> WithPost()
        {
            HelperClass.PrintBasicAPIDetails(EndPoint!, "POST");
            return await _requestContext!.PostAsync(EndPoint!, RequestOptions);
        }

        public async Task<IAPIResponse> WithPut()
        {
            HelperClass.PrintBasicAPIDetails(EndPoint!, "PUT");
            return await _requestContext!.PutAsync(EndPoint!, RequestOptions);
        }

        public async Task<IAPIResponse> WithPatch()
        {
            HelperClass.PrintBasicAPIDetails(EndPoint!, "PATCH");
            return await _requestContext!.PatchAsync(EndPoint!, RequestOptions);
        }

        public async Task<IAPIResponse> WithDelete()
        {
            HelperClass.PrintBasicAPIDetails(EndPoint!, "DELETE");
            return await _requestContext!.DeleteAsync(EndPoint!, RequestOptions);
        }
    }
}