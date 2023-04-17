using System.Security.Principal;

namespace Nhom1_DeTai1
{
    public static class GlobalVariables
    {
        public static bool MyGlobalVariable { get; set; }
        public static IPrincipal CurrentPrinciple { get; set; }
    }
}
