<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="WaiterCRUD.aspx.cs" Inherits="DemoPages_WaiterCRUD" %>

<%@ Register src="../UserControls/MessageUserControl.ascx" tagname="MessageUserControl" tagprefix="my" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table align="center" class="nav-justified">
        <tr align="center">
            <td colspan="2"> <asp:Label ID="Label1" runat="server" Text="Waiter Maintenance" Font-Bold="True" Font-Size="XX-Large"></asp:Label></td>
     
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:DropDownList ID="WaiterList" runat="server" DataSourceID="ODSWaiterList"
                     DataTextField="FullName" DataValueField="WaiterID" 
                    Height="24px" Width="276px">
                </asp:DropDownList>&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="FetchWaiter" runat="server" OnClick="FetchWaiter_Click">Fetch</asp:LinkButton>
                <asp:ObjectDataSource ID="ODSWaiterList" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Waiter_List" TypeName="eRestaurantSystem.BLL.eRestaurantController"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td align="right">ID:</td>
            <td>
                <asp:Label ID="WaiterID" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">First Name</td>
            <td>
                <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">Last Name</td>
            <td>
                <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">Phone</td>
            <td>
                <asp:TextBox ID="Phone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">Address</td>
            <td>
                <asp:TextBox ID="Address" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">Hire Date</td>
            <td>
                <asp:TextBox ID="HiredDate" runat="server"></asp:TextBox>
                <asp:ImageButton ID="HiredDateCalendarButton" runat="server" Height="24px" ImageUrl="~/Images/CalendarThumbnail.jpg" OnClick="HiredDateCalendarButton_Click" Width="24px" />
                <asp:Calendar ID="HiredCalendar" runat="server" Visible="false" OnSelectionChanged="HiredCalendar_SelectionChanged"></asp:Calendar>
            </td>
        </tr>
        <tr >
            <td align="right">Release Date</td>
            <td>
                <asp:TextBox ID="ReleaseDate" runat="server"></asp:TextBox>
                 <asp:ImageButton ID="ReleaseDateCalendarButton" runat="server" Height="24px" ImageUrl="~/Images/CalendarThumbnail.jpg" OnClick="ReleaseDateCalendarButton_Click" Width="24px" />
                <asp:Calendar ID="ReleaseCalendar" runat="server" Visible="false" OnSelectionChanged="ReleaseCalendar_SelectionChanged"></asp:Calendar>
            </td>
        </tr>

        <tr align="center" >
            <td colspan="2">&nbsp;</td>
            
        </tr>  
         <tr align="center" >
            <td colspan="2">
             <asp:LinkButton ID="InsertWaiter" runat="server" OnClick="InsertWaiter_Click">Insert</asp:LinkButton>&nbsp;&nbsp;
             <asp:LinkButton ID="UpdateWaiter" runat="server" OnClick="UpdateWaiter_Click">Update</asp:LinkButton></td>
        </tr> 
    </table> 
    <my:MessageUserControl ID="MessageUserControl" runat="server" />
</asp:Content>

