<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SplitBill.aspx.cs" Inherits="Staff_SplitBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class ="row col-md-12">
        <h1>Split Bill</h1>
        Active Bills:
        <asp:DropDownList runat="server" ID="ActiveBills" DataSourceID="SplitBillDataSource" DataTextField="DisplayText" DataValueField="KeyValue">
            <asp:ListItem Value="0">[Select a bill]</asp:ListItem>
        </asp:DropDownList>
        <asp:LinkButton ID="SelectBill" runat="server" CssClass="btn btn-primary" OnClick="SelectBill_Click">Select Bill</asp:LinkButton>
        <asp:ObjectDataSource runat="server" ID="SplitBillDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListUnpaidBills" TypeName="eRestaurant.Framework.BLL.WaiterController"></asp:ObjectDataSource>
    </div>

    <div class="row">
        <div class ="col-md-6">
            <h2>Original Bill</h2>
            <asp:GridView ID="OriginalBillItems" runat="server" AutoGenerateColumns="false">

            </asp:GridView>
        </div>
        <div class="col-md-6">
            <h2>New Bill</h2>
            <asp:GridView ID="NewBillItems" runat="server" AutoGenerateColumns="false">
                <EmptyDataTemplate>
                    New bill is empty. Move an item from the other bill.
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

