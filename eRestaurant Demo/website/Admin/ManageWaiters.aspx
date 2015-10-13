<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ManageWaiters.aspx.cs" Inherits="Admin_ManageWaiters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row col-md-12">
        <h1> Manage Waiters
            <span class="glyphicon glyphicon-user"></span>
        </h1>
        <asp:ObjectDataSource ID="WaitersDataSource" runat="server" TypeName="eRestaurant.Framework.BLL.RestaurantAdminController"
            SelectMethod="ListAllWaiters" DataObjectTypeName ="eRestaurant.Framework.Entities.Waiters" OldValuesParameterFormatString="original_{0}"
            UpdateMethod="UpdateWaiter" DeleteMethod="DeleteWaiter" InsertMethod="InsertWaiter" OnDeleted="ProcessException" OnInserted="ProcessException" OnUpdated="ProcessException" >
        </asp:ObjectDataSource>
        <asp:Label ID="MessageLabel" runat="server"/>
        <asp:ListView ID="WaitersListView" runat="server" DataSourceID="WaitersDataSource" DataKeyNames="WaiterID"
         InsertItemPosition="LastItem">
        <LayoutTemplate>
            <fieldset runat="server" id="itemPlaceholderContainer">
                <div runat="server" id ="itemPlaceholder" />
            </fieldset>
        </LayoutTemplate>

        <ItemTemplate>
            <div>
                <asp:LinkButton runat="server" CommandName="Delete" ID="DeleteButton">
                    Delete <span class ="glyphicon glyphicon-trash"></span>
                </asp:LinkButton>
                &nbsp; &nbsp;
                <asp:LinkButton runat="server" CommandName="Edit" ID="EditButton">
                    Edit <span class ="glyphicon glyphicon-pencil"></span>
                </asp:LinkButton>

                <asp:Label ID="Label1" runat="server" AssociatedControlID="WaiterIdLabel" CssClass="control-label">Waiter ID: </asp:Label>
                <asp:Label ID="WaiterIdLabel" runat="server" Text='<%# Eval("WaiterID") %>' />
                &mdash;
                <asp:Label ID="Label2" runat="server" AssociatedControlID="WaiterFirstName" CssClass="control-label">First Name: </asp:Label>
                <asp:Label ID="WaiterFirstName" runat="server" Text='<%# Eval("FirstName") %>' />
                &nbsp;
                <asp:Label ID="Label3" runat="server" AssociatedControlID="WaiterLastName" CssClass="control-label">Last Name: </asp:Label>
                <asp:Label ID="WaiterLastName" runat="server" Text='<%# Eval("LastName") %>' />
                 &mdash;
                <asp:Label ID="Label4" runat="server" AssociatedControlID="WaiterPhone" CssClass="control-label">Phone: </asp:Label>
                <asp:Label ID="WaiterPhone" runat="server" Text='<%# Eval("Phone") %>' />
                 &mdash;
                <asp:Label ID="Label5" runat="server" AssociatedControlID="WaiterAddress" CssClass="control-label">Address: </asp:Label>
                <asp:Label ID="WaiterAddress" runat="server" Text='<%# Eval("Address") %>' />
                 &mdash;
                <asp:Label ID="Label6" runat="server" AssociatedControlID="WaiterHireDate" CssClass="control-label">Hire Date: </asp:Label>
                <asp:Label ID="WaiterHireDate" runat="server" Text='<%# Eval("HireDate") %>' />
                 &mdash;
                <asp:Label ID="Label7" runat="server" AssociatedControlID="WaiterReleaseDate" CssClass="control-label">Release Date: </asp:Label>
                <asp:Label ID="WaiterReleaseDate" runat="server" Text='<%# Eval("ReleaseDate") %>' />
            </div>
        </ItemTemplate>
        <EditItemTemplate>
            <div>
                <asp:LinkButton runat="server" CommandName="Update" Text="Update" ID="UpdateButton" />
                &nbsp; &nbsp;
                <asp:LinkButton runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" />
                &nbsp; &nbsp;

                Waiter ID:
                <asp:TextBox runat="server" ID="WaiterIdTextBox" Text='<%# Bind("WaiterID") %>' Enabled="false" />
                 First Name: 
                <asp:TextBox runat="server" ID="WaiterFirstNameTB" Text='<%# Bind("FirstName") %>' Enabled="true" />
                 Last Name: 
                <asp:TextBox runat="server" ID="WaiterLastNameTB" Text='<%# Bind("LastName") %>' Enabled="true" />
                 Phone: 
                <asp:TextBox runat="server" ID="WaiterPhoneTextBox" Text='<%# Bind("Phone") %>' Enabled="true" />
                 Address: 
                <asp:TextBox runat="server" ID="WaiterAddressTB" Text='<%# Bind("Address") %>' Enabled="true" />
                 Hire Date: 
                <asp:TextBox runat="server" ID="WaiterHireDateTB" Text='<%# Bind("HireDate") %>' Enabled="true" />
                 Release Date: 
                <asp:TextBox runat="server" ID="WaiterReleaseDateTB" Text='<%# Bind("ReleaseDate") %>' Enabled="true" />
            </div>
        </EditItemTemplate>
        <InsertItemTemplate>
            <div>
                <asp:LinkButton runat="server" ID="InsertButton" CommandName="Insert">
                    Insert <span class="glyphicon glyphicon-plus"></span>
                </asp:LinkButton>
                &nbsp;
                <asp:LinkButton runat="server" ID="CancelButton" CommandName="Cancel">
                    Clear <span class="glyphicon glyphicon-refresh"></span>
                </asp:LinkButton>
                &nbsp; 
                
                <asp:Label ID="Label3" runat="server" CssClass="control-label" AssociatedControlID="FirstNameTextBox">
                    First Name
                </asp:Label>
                <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                &mdash;

                <asp:Label ID="Label4" runat="server" CssClass="control-label" AssociatedControlID="LastNameTextBox">
                    Last Name
                </asp:Label>
                <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' />
                &mdash;

                <asp:Label ID="Label8" runat="server" CssClass="control-label" AssociatedControlID="PhoneTextBox">
                    Description
                </asp:Label>
                <asp:TextBox ID="PhoneTextBox" runat="server" Text='<%# Bind("Phone") %>' />
                &mdash;

                <asp:Label ID="Label9" runat="server" CssClass="control-label" AssociatedControlID="AddressTextBox">
                    Address
                </asp:Label>
                <asp:TextBox ID="AddressTextBox" runat="server" Text='<%# Bind("Address") %>' />
                &mdash;

                <asp:Label ID="Label10" runat="server" CssClass="control-label" AssociatedControlID="HireDateTextBox">
                    Hire Date
                </asp:Label>
                <asp:TextBox ID="HireDateTextBox" runat="server" Text='<%# Bind("HireDate") %>' />
                &mdash;

                <asp:Label ID="Label11" runat="server" CssClass="control-label" AssociatedControlID="ReleaseDateTextBox">
                    Release Date
                </asp:Label>
                <asp:TextBox ID="ReleaseDateTextBox" runat="server" Text='<%# Bind("ReleaseDate") %>' />
            </div>
        </InsertItemTemplate>
        </asp:ListView>
    </div>


</asp:Content>

