using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using Microsoft.Playwright;

namespace API.Core.Reports
{
    public class StepInfo
    {
        public static ExtentTest? Child { get; set; }

        public static void Info(string Description)
        {
            Child!.Info(Description);
        }

        public static void Pass(string Description)
        {
            Child!.Pass(Description);
        }

        public static void Fail(string Description)
        {
            Child!.Fail(Description);
        }

        public static void Skip(string Description)
        {
            Child!.Skip(Description);
        }

        public static void LogTitleInExtentReport(string Description)
        {
            Child!.Info(MarkupHelper.CreateLabel("<<< " + Description + " >>>", ExtentColor.Brown));
        }

        public static async Task LogResponseInReportAsync(IAPIResponse response)
        {
            // Response Headers Logging...
            LogTitleInExtentReport("RESPONSE HEADERS");
            string tableAppender = "";
            foreach (Header header in response.HeadersArray)
            {
                string headerName = header.Name;
                string headerValue = header.Value;

                tableAppender = tableAppender + "<tr>\n" +
                        "    <td>" + headerName + "</td>\n" +
                        "    <td>" + headerValue.Substring(0, 100) + "</td>\n" +
                        "</tr>";
            }

            string headerCode = "<!DOCTYPE html>\n" +
                    "<html>\n" +
                    "<head>\n" +
                    "<details>\n" +
                    "<summary>Click here to view the \"Response Headers\"</summary>\n" +
                    "<table>\n" +
                    "<br>" +
                    "  <tr>\n" +
                    "    <th>Header</th>\n" +
                    "    <th>Value</th>\n" +
                    "  </tr>\n" +
                    "  " + tableAppender +
                    "</table>\n" +
                    "</details>\n" +
                    "</body>\n" +
                    "</html>\n";

            Child!.Info(headerCode);

            // Reponse Body Logging...
            LogTitleInExtentReport("RESPONSE BODY");
            var responseBody = await response.JsonAsync();
            if (responseBody.ToString() == null)
            {
                Child!.Pass("NO RESPONSE BODY !!!");
            }
            else
            {
                Child!.Info(MarkupHelper.CreateCodeBlock(responseBody.ToString(), CodeLanguage.Json));
            }
        }
    }
}