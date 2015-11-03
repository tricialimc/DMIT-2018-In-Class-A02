﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FrontDesk.aspx.cs" Inherits="Staff_FrontDesk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="well">
        <div class="pull-right col-md-5">
            <h4>
                <small>Last Billed Date/Time</small>
                <asp:Repeater ID="AdHocBillDateRepeater" runat="server" DataSourceID="AdHocBillDateDataSource" ItemType="System.DateTime">
                    <ItemTemplate>
                        <b class="label label-primary"><%# Item.ToShortDateString() %></b>
                        &ndash;
                        <b class="label label-info"> <%#Item.ToShortTimeString() %></b>
                    </ItemTemplate>
                </asp:Repeater>

                <asp:ObjectDataSource runat="server" ID="AdHocBillDateDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="GetLastBillDateTime" TypeName="eRestaurant.Framework.BLL.TempController"></asp:ObjectDataSource>

            </h4>
        </div>
        <h4>Mock Date/Time</h4>
        <asp:LinkButton ID="MockDateTime" runat="server" CssClass="btn btn-primary"> Post-back new date/time:</asp:LinkButton>
        <asp:LinkButton ID="MockLastBillingDateTime" runat="server" CssClass="btn btn-default" OnClick="MockLastBillingDateTime_Click">Set to Last-Billed date/time</asp:LinkButton>
        &nbsp;
        <asp:TextBox ID="SearchDate" runat="server" TextMode="Date" Text="2014-10-16"></asp:TextBox>
        <asp:TextBox id="SearchTime" runat="server" TextMode="Time" Text="13:00" CssClass="clockpicker"></asp:TextBox>


        <!--TODO-->
        <details style="display:inline-block; vertical-align: top;">
            <summary class="badge">About ClockPicker &hellip;</summary>
            <h4>Fancy Bootstrap <a href="http://weareoutman.github.io/clockpicker/">ClockPicker</a></h4>
            <p>The time uses the ClockPicker Bootstrap extension</p>
        </details>
    </div>
</asp:Content>

