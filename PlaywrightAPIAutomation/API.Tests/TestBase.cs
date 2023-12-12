namespace API.Tests
{
    [TestFixture]
    public class TestBase
    {
        [OneTimeSetUp]
        public void BeforeSuite()
        {
            // Extent Manager Initialization...
            ExtentTestManager.CreateParentTest(TestContext.CurrentContext.Test.Name);
        }

        [SetUp]
        public async Task BeforeMethodAsync()
        {
            StepInfo.Child = ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name);
            StepInfo.Info("<b><<<<< Test Execution - Started >>>>></b>");
            StepInfo.LogTitleInExtentReport("<<< BASIC INFO >>>");
            StepInfo.Pass("Base URI : " + "<a href='" + PlaywrightFixture.Config!.BaseUrl
                + "'>" + PlaywrightFixture.Config!.BaseUrl + "</a>");

            // Token Creation...
            await TokenGenerator.CreateTokenAsync();
        }

        [OneTimeTearDown]
        public void AfterSuite()
        {
            // Flushing the Extent Report...
            StepInfo.Info("<b><<<<< Test Execution - Ended >>>>></b>");
            ExtentManager.GetInstance().Flush();
        }

        public PlaywrightBuilder Builder()
        {
            var playWrightFixture = new PlaywrightFixture();
            var builder = new PlaywrightBuilder(playWrightFixture!.CreateAsync().Result);
            return builder;
        }
    }
}