<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchCustomerDetails.aspx.cs" Inherits="PROJECT_NEW.ALMAS.SearchCustomerDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <head>
        <link href="../Content/Site.css" rel="stylesheet" />
    </head>
 

    <center>
     <h2>Search Customer Documents by Expiry Date</h2>
  <%--  <asp:TextBox ID="txtFromDate" runat="server" TextMode="Date"   Width="300px" placeholder="From Date (yyyy-mm-dd)"></asp:TextBox><br />
    <asp:TextBox ID="txtToDate" runat="server" TextMode="Date" Width="300px" placeholder="To Date (yyyy-mm-dd)"></asp:TextBox><br />
    --%>

   <div style="text-align: center;">
    <div style="display: flex; justify-content: center; align-items: center; margin-bottom: 15px;">
        <asp:Label ID="lblFromDate" runat="server" Text="From Date:" AssociatedControlID="txtFromDate" style="margin-right: 10px;"></asp:Label>
        <asp:TextBox ID="txtFromDate" runat="server" TextMode="Date" Width="300px" placeholder="yyyy-mm-dd"></asp:TextBox>
    </div>
    
    <div style="display: flex; justify-content: center; align-items: center;">
        <asp:Label ID="lblToDate" runat="server" Text="To Date:" AssociatedControlID="txtToDate" style="margin-right: 10px;"></asp:Label>
        <asp:TextBox ID="txtToDate" runat="server" TextMode="Date" Width="300px" placeholder="yyyy-mm-dd"></asp:TextBox>
    </div>
</div>


    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />  
    <asp:Button ID="btnExportToExcel" runat="server" Text="Export to Excel" OnClick="btnExportToExcel_Click" /> 
    <br /><br />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="gridview">
        <Columns>
            <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
            <asp:BoundField DataField="DocumentType" HeaderText="Document Type" />
            <asp:BoundField DataField="ExpiryDate" HeaderText="Expiry Date" DataFormatString="{0:yyyy-MM-dd}" />
<asp:TemplateField HeaderText="Document Link">
    <ItemTemplate>
        <a href='<%# Eval("DocumentFilePath").ToString().Substring(Eval("DocumentFilePath").ToString().IndexOf(@"\Uploads\")).Replace(@"\", "/") %>' target="_blank">
            View Document
        </a>
    </ItemTemplate>
</asp:TemplateField>

      </Columns>
    </asp:GridView>




      <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></center>

    <br /><br /><br /><br />
</asp:Content>
