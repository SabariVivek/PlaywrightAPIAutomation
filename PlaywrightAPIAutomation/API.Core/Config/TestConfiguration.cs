namespace API.Core.Config
{
    public class TestConfiguration : ITestConfiguration
    {
        public required string BaseUrl { get; set; }
        public required string Organisation { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string HomeRealmUri { get; set; }
    }
}