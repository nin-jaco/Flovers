<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageDistribution.aspx.cs" Inherits="Flovers.Web.ManageDistribution" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadPageLayout runat="server" ID="JumbotronLayout" CssClass="jumbotron" GridType="Fluid">
        <Rows>
            <telerik:LayoutRow>
                <Columns>
                    <telerik:LayoutColumn Span="10" SpanMd="12" SpanSm="12" SpanXs="12">
                        <h1>Manage Distribution.</h1>
                    </telerik:LayoutColumn>
                    <telerik:LayoutColumn Span="2" HiddenMd="true" HiddenSm="true" HiddenXs="true">
                        <img src="images/Thumbnails/Desert.jpg" />
                    </telerik:LayoutColumn>
                </Columns>
            </telerik:LayoutRow>
        </Rows>
    </telerik:RadPageLayout>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="true" />
    <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ConfigurationPanel1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="DemoContainer1" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="ConfigurationPanel1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel runat="server" ID="RadAjaxLoadingPanel1"></telerik:RadAjaxLoadingPanel>
    Select a Branch from the list below:
    <telerik:RadDropDownList runat="server" ID="ddlBranches" DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="ddlBranches_OnSelectedIndexChanged"></telerik:RadDropDownList>
    <div class="demo-container size-narrow" id="DemoContainer1" runat="server">
        <div class="wrapper">
            <telerik:RadListBox RenderMode="Lightweight" runat="server" ID="RadListBoxSource" Height="200px" Width="230px" DataTextField="Name" DataValueField="Id"
                AllowTransfer="true" TransferToID="RadListBoxDestination" AutoPostBackOnTransfer="True" OnTransferred="RadListBoxSource_OnTransferred"
                 ButtonSettings-AreaWidth="35px" >
            </telerik:RadListBox>
            <telerik:RadListBox RenderMode="Lightweight" runat="server" ID="RadListBoxDestination" Height="200px" Width="230px"
                 ButtonSettings-AreaWidth="35px" >
            </telerik:RadListBox>
        </div>
    </div>
</asp:Content>
