using Routes = API.Objects.Route.CommonRoute;

namespace API.Objects.EndPoint
{
    public class CreateTokenEndPoint
    {
        public static string TOKEN = Routes.PEPP_GATE_WAY_API + "/logon/token";
    }

    public class BranchesEndPoint
    {
        public static string ACTIVE_BRANCHES = Routes.PEPP_GATE_WAY_API + "/lookups/GetActiveBranches";
    }
}