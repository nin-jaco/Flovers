<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageDistribution.aspx.cs" Inherits="Flovers.Web.ManageDistribution" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Select a 
    <telerik:RadDropDownList runat="server" ID="ddlBranches" DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="ddlBranches_OnSelectedIndexChanged"></telerik:RadDropDownList>
</asp:Content>
