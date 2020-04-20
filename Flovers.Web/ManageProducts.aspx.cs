using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Flovers.Web.Enums;
using Flovers.Web.Extensions;
using Flovers.Web.Operations;
using FLovers.DAL.Repository.Dtos;
using FLovers.Log.Services.Logging;
using Telerik.Web.UI;

namespace Flovers.Web
{
    public partial class ManageProducts : System.Web.UI.Page
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
            RadGrid1.DataSource = ProductOperations.GetAll()?.ItemList;
        }

        protected void RadGrid1_OnItemCreated(object sender, GridItemEventArgs e)
        {
            GridHeaderItem headerItem = e.Item as GridHeaderItem;
            if (headerItem != null)
            {
                headerItem["EditColumn"].Text = string.Empty;
                headerItem["DeleteColumn"].Text = string.Empty;
            }
        }

        protected void RadGrid1_OnItemDataBound(object sender, GridItemEventArgs e)
        {
        }

        protected void RadGrid1_OnUpdateCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                var editableItem = ((GridEditableItem)e.Item);
                var productId = (int)editableItem.GetDataKeyValue("Id");
                var product = new ProductDto();
                editableItem.UpdateValues(product);
                product.Id = productId;
                var result = ProductOperations.Update(product);
                if (result.IsSuccess)
                {
                    this.ShowToast(ToastTypeEnum.Success, "Successfully updated Item", "Success");
                    return;
                }
                ShowErrorMessage(result.ErrorMessage);
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex);
                ShowErrorMessage("There was a problem Updating the item.");
            }
        }

        /// <summary>
        /// Shows a <see cref="RadWindow"/> alert if an error occurs
        /// </summary>
        private void ShowErrorMessage(string message)
        {
            RadAjaxManager1.ResponseScripts.Add(string.Format($@"window.radalert(\""{message}"")"));
        }

        protected void RadGrid1_OnInsertCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                var editableItem = ((GridEditableItem)e.Item);
                var product = new ProductDto();
                editableItem.UpdateValues(product);
                var result = ProductOperations.Create(product);
                if (result.IsSuccess)
                {
                    this.ShowToast(ToastTypeEnum.Success, "Successfully created Item", "Success");
                    return;
                }
                ShowErrorMessage(result.ErrorMessage);
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex);
                ShowErrorMessage("There was a problem Updating the item.");
            }
        }

        protected void RadGrid1_OnDeleteCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                var editableItem = ((GridEditableItem)e.Item);
                var productId = (int)editableItem.GetDataKeyValue("Id");
                var product = new ProductDto();
                editableItem.UpdateValues(product);
                product.Id = productId;
                var result = ProductOperations.Delete(product);
                if (result.IsSuccess)
                {
                    this.ShowToast(ToastTypeEnum.Success, "Successfully delete Item", "Success");
                    return;
                }
                ShowErrorMessage(result.ErrorMessage);
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex);
                ShowErrorMessage("There was a problem Updating the item.");
            }
        }
    }
}