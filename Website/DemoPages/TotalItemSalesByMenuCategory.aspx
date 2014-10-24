<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TotalItemSalesByMenuCategory.aspx.cs" Inherits="DemoPages_TotalItemSalesByMenuCategory" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ObjectDataSource ID="ODSTotalItemSales" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="TotalItemSalesByMenuCategory" TypeName="eRestaurantSystem.BLL.eRestaurantController"></asp:ObjectDataSource>
    <rsweb:ReportViewer ID="TotalSalesViewer" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="800px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
        <LocalReport ReportPath="Reports\TotalItemSalesByMenuCategory.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ODSTotalItemSales" Name="ItemSalesDS" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
</asp:Content>

