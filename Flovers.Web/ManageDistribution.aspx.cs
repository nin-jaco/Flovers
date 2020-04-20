using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Flovers.Web.Extensions;
using Flovers.Web.Operations;
using FLovers.DAL.Repository.Dtos;
using Telerik.Web.UI;

namespace Flovers.Web
{
    public partial class ManageDistribution : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlBranches.DataSource = BranchOperations.GetAll()?.ItemList;
                ddlBranches.DataBind();
                ddlBranches.SelectedIndex = 0;
            }
        }

        protected void Page_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();
            this.HandleException(ex, false);
        }

        protected void ddlBranches_OnSelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            var allProducts = ProductOperations.GetAll()?.ItemList ?? new List<ProductDto>();
            var branchProducts = ProductOperations.GetAllByStoreId(int.Parse(ddlBranches.SelectedValue)) ?? new List<ProductDto>();

            RadListBoxSource.DataSource = allProducts.Where(p => !branchProducts.Contains(p));
            RadListBoxSource.DataBind();
            RadListBoxDestination.DataSource = branchProducts;
            RadListBoxDestination.DataBind();
        }

        protected void RadListBoxSource_OnTransferred(object sender, RadListBoxTransferredEventArgs e)
        {
            var itemIds =  new List<int>();
            foreach (var radListBoxItem in e.Items)
            {
                itemIds.Add(int.Parse(radListBoxItem.Value));
            }

            foreach (var itemId in itemIds)
            {
                var result = ProductOperations.AssignAProductToAStore(int.Parse(ddlBranches.SelectedValue), itemId);
                if (!result.IsSuccess)
                {
                    ShowErrorMessage("A problem occured while assigning one or more of the products.");
                }
            }
        }

        private void ShowErrorMessage(string message)
        {
            RadAjaxManager1.ResponseScripts.Add(string.Format($@"window.radalert(\""{message}"")"));
        }
    }
}