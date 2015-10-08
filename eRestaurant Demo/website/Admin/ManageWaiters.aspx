<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ManageWaiters.aspx.cs" Inherits="Admin_ManageWaiters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row col-md-12">
        <h1> Manage Waiters
            <span class="glyphicon glyphicon-group"></span>
        </h1>
        <asp:ObjectDataSource ID="WaitersDataSource" runat="server" TypeName="eRestaurant.Framework.BLL.RestaurantAdminController"
            SelectMethod="ListAllWaiters" DataObjectTypeName ="eRestaurant.Framework.Entities.Waiters" OldValuesParameterFormatString="original_{0}"
            UpdateMethod="UpdateWaiter" DeleteMethod="DeleteWaiter" InsertMethod="InsertWaiter" >
        </asp:ObjectDataSource>
        <asp:Label ID="MessageLabel" runat="server"/>
        <asp:ListView ID="WaitersListView" runat="server" DataSourceID="WaitersDataSource" DataKeyNames="WaiterID"
            InsertItemPosition="LastItem">

        </asp:ListView>
    </div>


</asp:Content>

