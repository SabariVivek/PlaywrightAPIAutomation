using Endpoint = API.Objects.EndPoint.BranchesEndPoint;
using Payload = API.Objects.Payload.CommonPayload;

namespace API.Tests.Test
{
    [TestFixture]
    public class GET_ActiveBranches : TestBase
    {
        [Test]
        public async Task GetActiveBranches()
        {
            // Request...
            var response = await Builder().
                WithEndPoint(Endpoint.ACTIVE_BRANCHES).
                WithHeaders(Payload.BearerToken()).
                WithGet();

            // Validation...
            await HelperClass.PrintResponseAsync(response, ExtractResponseBodyType.JSON);
            await HelperClass.AssertResponseCodeAsync(ResponseUtils.CODE_200, response);
        }
    }
}