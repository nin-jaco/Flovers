using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Flovers.Web.Extensions;
using Flovers.Web.Operations;
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
            var allProducts = ProductOperations.GetAll()?.ItemList;
            
            RadListBoxSource.DataSource = 
        }
    }
}