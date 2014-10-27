<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ClockPicker.aspx.cs" Inherits="DemoPages_ClockPicker" %>

<%@ Register src="../UserControls/MessageUserControl.ascx" tagname="MessageUserControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="well">
        <div class="pull-right col-md-5">
            <h4>
                <small>Last Billed Date/Time:</small>
                <asp:Repeater ID="BillDateRepeater" runat="server" DataSourceID="ODSRepeater"
                    ItemType="System.DateTime">
                    <ItemTemplate>
                        <b class="label label-primary">
                            <%# Item.ToShortDateString() %>
                        </b>
                        <b class="label label-info">
                            <%# Item.ToShortTimeString() %>
                        </b>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:ObjectDataSource ID="ODSRepeater" runat="server" 
                    OldValuesParameterFormatString="original_{0}" 
                    SelectMethod="GetLastBillDateTime" 
                    TypeName="eRestaurantSystem.BLL.eRestaurantController">
                </asp:ObjectDataSource>
            </h4>
            <uc1:MessageUserControl ID="MessageUserControl" runat="server" />
        </div>
        <h4>Mock Date/Time</h4>
        <asp:LinkButton ID="MockDateTime" runat="server"
            CssClass="btn btn-primary">Post-Back new date/time</asp:LinkButton>
        <asp:LinkButton ID="MockLastBillingDateTime" runat="server" CssClass="btn btn-default" OnClick="MockLastBillingDateTime_Click">
            set to Last-Bill-date/time:
        </asp:LinkButton>
        &nbsp;&nbsp;
        <asp:TextBox ID="SearchDate" runat="server"
             TextMode="Date" Text="2014-10-27"></asp:TextBox>
        <asp:TextBox ID="SearchTime" runat="server"
             TextMode="Time" Text="15:00"
             CssClass="clockpicker"></asp:TextBox>
        <%--add clock picker --%>
        <script src="../Scripts/clockpicker.js"></script>
        <script type="text/javascript">
            $('.clockpicker').clockpicker({ donetext: 'Accept' });
        </script>
        <link itemprop="url" href="../Content/standalone.css" rel="stylesheet" />
        <link itemprop="url" href="../Content/clockpicker.css" rel="stylesheet" />
    </div>
</asp:Content>

