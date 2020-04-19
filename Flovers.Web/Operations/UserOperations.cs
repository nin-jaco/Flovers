using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using FLovers.Shared.BaseClasses;

namespace Flovers.Web.Operations
{
    public static class UserOperations
    {
        public static string GetBrowserVersion()
        {
            return HttpContext.Current.Request.Browser.Version;
        }

        public static string GetBrowser()
        {
            return HttpContext.Current.Request.Browser.Browser;
        }

        public static string GetUserAgent()
        {
            return HttpContext.Current.Request.UserAgent;
        }

        public static string GetRequestUrl()
        {
            return HttpContext.Current.Request.Url?.AbsoluteUri;
        }

        public static string GetUserIp()
        {
            string ipList = HttpContext.Current.Request.ServerVariables["HTTP_X_CLUSTER_CLIENT_IP"];

            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }

            ipList = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }

            return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        public static RequestBase GetRequestBaseFromSession()
        {

            return HttpContext.Current.Session["RequestBase"] as RequestBase ?? new RequestBase
            {
                IdBranch = 1,
                BranchName = "HeadOffice",
                Browser = GetBrowser(),
                BrowserVersion = GetBrowserVersion(),
                IdUser = 1,
                SenderComputerIp = GetUserIp(),
                SentFromUrl = GetRequestUrl(),
                UserAgent = GetUserAgent(),
                Username = "Martin"
            };
        }
    }
}