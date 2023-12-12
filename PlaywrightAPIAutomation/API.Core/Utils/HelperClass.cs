using API.Core.Reports;
using Microsoft.Playwright;
using System.Text.Json;

namespace API.Core.Utils
{
    public class HelperClass
    {
        public static object ExtractJsonDataAsync(object ApiResponse, string Data)
        {
            var jsonDocument = JsonDocument.Parse(Convert.ToString(ApiResponse)!);
            var jsonData = jsonDocument.RootElement.GetProperty(Data);
            return jsonData;
        }

        public static string JSONReaderAsync(string FilePath)
        {
            string JsonFilePath = FilePath;
            return File.ReadAllText(JsonFilePath);
        }

        public static Task AssertResponseCodeAsync(int ExpectedStatusCode, IAPIResponse Response)
        {
            if (ExpectedStatusCode == Response.Status)
            {
                Console.WriteLine("Given assert code (" + ExpectedStatusCode + ") is matched...");
            }
            else
            {
                Console.WriteLine("Given assert code (Expected : " + ExpectedStatusCode + ", Actual : " + Response.Status + " ) is not matched...");
            }

            return Task.CompletedTask;
        }

        public static async Task PrintResponseAsync(IAPIResponse Response, ExtractResponseBodyType Type)
        {
            switch (Type)
            {
                case ExtractResponseBodyType.JSON:
                    Console.WriteLine(await Response.JsonAsync());
                    break;
                case ExtractResponseBodyType.TEXT:
                    Console.WriteLine(await Response.TextAsync());
                    break;
                case ExtractResponseBodyType.BODY:
                    Console.WriteLine(await Response.BodyAsync());
                    break;
                case ExtractResponseBodyType.HEADERS:
                    Console.WriteLine(Response.HeadersArray);
                    break;
                case ExtractResponseBodyType.STATUS_TEXT:
                    Console.WriteLine(Response.StatusText);
                    break;
                case ExtractResponseBodyType.STATUS_CODE:
                    Console.WriteLine(Response.Status);
                    break;
            }
        }

        public static void PrintBasicAPIDetails(string EndPoint, string MethodType)
        {
            StepInfo.Pass("End Point : " + "<a href='" + EndPoint + "'>" + EndPoint + "</a>");
            StepInfo.Pass("Method Type : " + "<a href='" + MethodType + "'>" + MethodType + "</a>");
        }
    }
}