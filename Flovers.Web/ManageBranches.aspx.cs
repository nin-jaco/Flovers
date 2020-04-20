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
    public partial class ManageBranches : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();
            this.HandleException(ex, false);
        }

        protected void RadGrid1_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            RadGrid1.DataSource = BranchOperations.GetAll()?.ItemList;
        }

        protected void RadGrid1_OnItemCreated(object sender, GridItemEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void RadGrid1_OnItemDataBound(object sender, GridItemEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void RadGrid1_OnUpdateCommand(object sender, GridCommandEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void RadGrid1_OnInsertCommand(object sender, GridCommandEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void RadGrid1_OnDeleteCommand(object sender, GridCommandEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}