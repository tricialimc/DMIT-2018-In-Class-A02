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

    <!-- Showing the reservations for a particular date -->
    <div class="pull-right col-md-5">
        <details open>
            <summary>Reservations by Date/Time</summary>
            <h4>Today's Reservations</h4>
            <asp:Repeater ID="ReservationsRepeater" runat="server" DataSourceID="ReservationDataSource" ItemType="eRestaurant.Framework.Entities.DTOs.ReservationCollection">
                <ItemTemplate>
                    <h4><%# Item.Hour %></h4>
                    <asp:ListView ID="ReservationSummaryListView" runat="server" ItemType="eRestaurant.Framework.Entities.DTOs.ReservationSummary"
                        DataSource="<%# Item.Reservations %>">
                        <LayoutTemplate>
                            <div class ="seating">
                                <span runat="server" id="itemPlaceholder" />
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div>
                                <%# Item.Name %> -
                                <%# Item.NumberInParty %> -
                                <%# Item.Status %> -
                                <%# Item.Event %> 
                                <%# Item.Contact %>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource runat="server" ID="ReservationDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ReservationsForDate" TypeName="eRestaurant.Framework.BLL.SeatingController">
                <SelectParameters>
                    <asp:ControlParameter ControlID="SearchDate" PropertyName="Text" Name="date" Type="DateTime"></asp:ControlParameter>
                </SelectParameters>
            </asp:ObjectDataSource>
        </details>
    </div>

    <div class="col-md-7">
        <h3>Tables</h3>
        <asp:GridView runat="server" ID="SeatingGridView" AutoGenerateColumns="False" DataSourceID="SeatingObjectDataSource">
            <Columns>
                <asp:BoundField DataField="Table" HeaderText="Table" SortExpression="Table"></asp:BoundField>
                <asp:BoundField DataField="Seating" HeaderText="Seating" SortExpression="Seating"></asp:BoundField>
                <asp:CheckBoxField DataField="Taken" HeaderText="Taken" SortExpression="Taken"></asp:CheckBoxField>
                <asp:BoundField DataField="BillID" HeaderText="BillID" SortExpression="BillID"></asp:BoundField>
                <asp:BoundField DataField="BillTotal" HeaderText="BillTotal" SortExpression="BillTotal"></asp:BoundField>
                <asp:BoundField DataField="Waiter" HeaderText="Waiter" SortExpression="Waiter"></asp:BoundField>
                <asp:BoundField DataField="ReservationName" HeaderText="ReservationName" SortExpression="ReservationName"></asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="SeatingObjectDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SeatingByDateTime" TypeName="eRestaurant.Framework.BLL.SeatingController">
            <SelectParameters>
                <asp:ControlParameter ControlID="SearchDate" PropertyName="Text" Name="date" Type="DateTime"></asp:ControlParameter>
                <asp:ControlParameter ControlID="SearchTime" PropertyName="Text" DbType="Time" Name="time"></asp:ControlParameter>
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>

