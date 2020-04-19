using System;
using System.Web.UI;
using Flovers.Web.Enums;
using FLovers.Log.Services.Logging;
using FLovers.Shared.Attributes;
using FLovers.Shared.Enums;
using FLovers.Shared.Extensions;
using Telerik.Web.UI;

namespace Flovers.Web.Extensions
{
    public static class PageExtensions
    {
        [Help("this.ShowMessageBox('Hello World!')")]
        public static void ShowMessageBox(this Page page, string message)
        {
            page.ClientScript.RegisterStartupScript(
                page.GetType(),
                "MessageBox",
                "<script language='javascript'>alert('" + message + "');</script>"
            );
        }

        /*-- BEGIN Toastr --*/
        public static void ShowToast(this Page page, ToastTypeEnum type, string msg, string title = "", ToastPositionEnum position = ToastPositionEnum.TopRight, bool showCloseButton = true, int timeout = 50000)
        {
            var strType = "";
            var strPosition = "";

            switch (type)
            {
                case ToastTypeEnum.Success:
                    strType = "success";
                    break;
                case ToastTypeEnum.Info:
                    strType = "info";
                    break;
                case ToastTypeEnum.Warning:
                    strType = "warning";
                    break;
                case ToastTypeEnum.Error:
                    strType = "error";
                    break;
            }

            //Set the position based on selected and change value to match toastr plug in
            switch (position)
            {
                case ToastPositionEnum.TopRight:
                    strPosition = "toast-top-right";
                    break;
                case ToastPositionEnum.TopLeft:
                    strPosition = "toast-top-left";
                    break;
                case ToastPositionEnum.TopCenter:
                    strPosition = "toast-top-center";
                    break;
                case ToastPositionEnum.TopStretch:
                    strPosition = "toast-top-full-width";
                    break;
                case ToastPositionEnum.BottomRight:
                    strPosition = "toast-bottom-right";
                    break;
                case ToastPositionEnum.BottomLeft:
                    strPosition = "toast-bottom-left";
                    break;
                case ToastPositionEnum.BottomCenter:
                    strPosition = "toast-bottom-center";
                    break;
                case ToastPositionEnum.BottomStretch:
                    strPosition = "toast-bottom-full-width";
                    break;
            }


            //Call the toastify() function in site.js
            var script =
                $"toastify(\'{strType}\', \'{CleanStr(msg)}\',\'{CleanStr(title)}\', \'{strPosition}\', \'{showCloseButton}\', \'{timeout}\');";
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastedMsg", script, true);
        }

        private static string CleanStr(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return "";
            //This function replaces ' with its html code equivalent
            //in order not to terminate the js statement string
            return text.Contains("'") ? text.Replace("'", "&#39;") : text;
            //return HttpContext.Current.Server.HtmlEncode(text);            
        }

        public static void ShowWarning(this Page page, string warningMessage)
        {
            page.ShowToast(ToastTypeEnum.Warning, warningMessage, "Warning!");
        }

        public static void ShowError(this Page page, string errorMessage)
        {
            page.ShowToast(ToastTypeEnum.Error, errorMessage, "Error!");
        }

        public static void ShowSuccess(this Page page, string successMessage)
        {
            page.ShowToast(ToastTypeEnum.Success, successMessage, "Success!");
        }

        //-->[END Toastr]


        //-->[BEGIN Rad Window Popups]
        [Help(@"this.RunPopupRadWindowScript(""openRadWindowReworkDealWindow"");")]
        public static void RunPopupRadWindowScript(this Page page, string javascriptFunctionThatOpensWindow)
        {
            var script = $@"function pop(){{{javascriptFunctionThatOpensWindow}(); Sys.Application.remove_load(pop);}}Sys.Application.add_load(pop);";
            page.ClientScript.RegisterStartupScript(page.GetType(), "pop", script, true);
        }

        [Help(@"this.ShowRadWindow(RadWindowReworkDealWindow);")]
        public static void ShowRadWindow(this Page page, RadWindow window)
        {
            var script = "function f(){setTimeout(function(){$find(\"" + window.ClientID + "\").show(); },111);Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            page.ClientScript.RegisterStartupScript(page.GetType(), "f", script, true);
        }

        //-->[END Rad Window Popups]

        public static void HandleException(this Page page, Exception ex, bool redirect)
        {
            ErrorHandler.LogException(ex);
            if (redirect)
            {
                page.Server.Transfer("HttpGenericErrorPage.aspx", true);
            }
            page.ShowError(ErrorsEnum.ExceptionEncountered.FriendlyErrorMessage());
        }
    }
}