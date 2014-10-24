<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="XMLPage.aspx.cs" Inherits="XMLFiles_XMLPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" DataSourceID="XmlDataSource1"></asp:GridView>
    <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/XMLFiles/XMLDemo.xml" TransformFile="~/XMLFiles/XSLTDemo.xslt"></asp:XmlDataSource>
</asp:Content>

