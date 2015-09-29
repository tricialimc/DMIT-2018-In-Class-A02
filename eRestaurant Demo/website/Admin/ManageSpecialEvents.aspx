﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ManageSpecialEvents.aspx.cs" Inherits="Admin_ManageSpecialEvents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row col-md-12">
        <h1> Manage Special Events
            <span class="glyphicon glyphicon-glass"></span>
        </h1>
    

    <!--ObjectDataSource control to do the underlying communication with my BLL and my ListView control -->
    <asp:ObjectDataSource ID="SpecialEventsDataSource" runat="server" TypeName ="eRestaurant.Framework.BLL.RestaurantAdminController"
        SelectMethod="ListAllSpecialEvents" DataObjectTypeName ="eRestaurant.Framework.Entities.SpecialEvent">
    </asp:ObjectDataSource>

    <%--<asp:gridview id="specialeventsgrid" runat="server" datasourceid="specialeventsdatasource"></asp:gridview>--%>
    <asp:ListView ID ="SpecialEventsListView" runat="server" DataSourceID="SpecialEventsDataSource">
        <LayoutTemplate>
            <fieldset runat="server" id="itemPlaceholderContainer">
                <div runat ="server" id ="itemPlaceholder" />
            </fieldset>
        </LayoutTemplate>

        <ItemTemplate>
            <div>
                <%--<asp:LinkButton runat="server" 
                    CommandName="Insert" ID="InsertButton">
                    Insert <span class="glyphicon glyphicon-plus"></span>
                </asp:LinkButton>
                &nbsp; &nbsp;--%>
                <asp:LinkButton runat="server"
                    CommandName="Delete" ID="DeleteButton">
                    Delete <span class ="glyphicon glyphicon-trash"></span>
                </asp:LinkButton>
                &nbsp; &nbsp;
                <asp:LinkButton runat="server"
                    CommandName="Edit" ID="EditButton">
                    Edit <span class ="glyphicon glyphicon-pencil"></span>
                </asp:LinkButton>

                <!-- # means it's repeating - doing it in every row-->
                <asp:CheckBox Checked='<%# Eval("Active") %>' 
                              runat="server" ID ="ActiveCheckBox"
                              Enabled="false" Text="Active" />
                <asp:Label ID="Label1" runat="server" 
                    &mdash;
                    AssociatedControlID="EventCodeLabel" CssClass="control-label">Event Code</asp:Label>
                
                <asp:Label ID="EventCodeLabel" runat="server" Text='<%# Eval("EventCode") %>' />
                &mdash;
                <asp:Label ID="DescriptionData" runat="server" Text='<%# Eval("Description") %>' />
            </div>
        </ItemTemplate>
    </asp:ListView>
</div>

</asp:Content>

