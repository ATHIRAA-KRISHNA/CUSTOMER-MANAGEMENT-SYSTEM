<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cust.aspx.cs" Inherits="PROJECT_NEW.ALMAS.cust" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Customer Details</h2>
    <asp:Panel ID="pnlCustomerDetails" runat="server">
        <div>
            <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name:"></asp:Label>
            <asp:TextBox ID="txtCustomerName" runat="server" />
        </div>
        <div>
            <asp:Label ID="lblVisaUpload" runat="server" Text="Visa Document (JPEG/PDF):"></asp:Label>
            <asp:FileUpload ID="fuVisaUpload" runat="server" />
        </div>
        <div>
            <asp:Label ID="lblPassportUpload" runat="server" Text="Passport Document (JPEG/PDF):"></asp:Label>
            <asp:FileUpload ID="fuPassportUpload" runat="server" />
        </div>
        <div>
            <asp:Label ID="lblOtherDocument" runat="server" Text="Other Document (JPEG/PDF):"></asp:Label>
            <asp:FileUpload ID="fuOtherDocument" runat="server" />
        </div>
        <div>
            <asp:Label ID="lblExpiryDate" runat="server" Text="Expiry Date:"></asp:Label>
            <asp:TextBox ID="txtExpiryDate" runat="server" TextMode="Date" />
        </div>
        <div>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
    </asp:Panel>
</asp:Content>
