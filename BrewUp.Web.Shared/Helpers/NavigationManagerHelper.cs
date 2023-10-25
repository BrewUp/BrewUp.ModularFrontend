using Microsoft.AspNetCore.Components;
using System.Collections.Specialized;
using System.Web;

namespace BrewUp.Web.Shared.Helpers
{
    public static class NavigationManagerHelper
    {
        public static NameValueCollection QueryString(this NavigationManager navigationManager) =>
            HttpUtility.ParseQueryString(new Uri(navigationManager.Uri).Query);

        public static string QueryString(this NavigationManager navigationManager, string key) =>
            navigationManager.QueryString()[key];
    }
}