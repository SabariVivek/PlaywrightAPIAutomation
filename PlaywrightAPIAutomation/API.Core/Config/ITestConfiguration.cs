namespace API.Core.Config
{
    public interface ITestConfiguration
    {
        string BaseUrl { get; set; }
        string Organisation { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        string HomeRealmUri { get; set; }
    }
}