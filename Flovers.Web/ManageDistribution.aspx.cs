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
                ddlBranches.Items.Insert(0, new DropDownListItem("Please select", "0"));
                ddlBranches.SelectedIndex = 0;
                SetDataSources();
            }
        }

        protected void Page_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();
            this.HandleException(ex, false);
        }

        protected void ddlBranches_OnSelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            SetDataSources();
        }

        private void SetDataSources()
        {
            var allProducts = ProductOperations.GetAll()?.ItemList ?? new List<ProductDto>();
            var branchProducts = ddlBranches.SelectedValue == "0" ? allProducts : ProductOperations.GetAllByStoreId(int.Parse(ddlBranches.SelectedValue)) ?? new List<ProductDto>();

            RadListBoxSource.DataSource = branchProducts.Count > 0 ? branchProducts.Where(p => !branchProducts.Contains(p)) : allProducts;
            RadListBoxSource.DataBind();
            RadListBoxDestination.DataSource = branchProducts;
            RadListBoxDestination.DataBind();
        }

        protected void RadListBoxSource_OnTransferred(object sender, RadListBoxTransferredEventArgs e)
        {
            if (ddlBranches.SelectedValue == "0")
            {
                ShowErrorMessage("Please select a branch from the dropdown.");
                return;
            }
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