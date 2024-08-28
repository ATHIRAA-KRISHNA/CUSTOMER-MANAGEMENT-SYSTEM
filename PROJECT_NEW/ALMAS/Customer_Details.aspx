<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customer_Details.aspx.cs" Inherits="PROJECT_NEW.ALMAS.Customer_Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <head>
        <link href="../Content/Site.css" rel="stylesheet" />

    </head>

    <h2>Add Customer Details</h2>
    <asp:TextBox ID="txtCustomerName" runat="server" Width="575px" placeholder="Enter Customer Name"></asp:TextBox>
        <asp:RequiredFieldValidator ID="custreq" ControlToValidate="txtCustomerName" runat="server" ErrorMessage="Customer Name Is Missing" ForeColor="Red"></asp:RequiredFieldValidator>

    <h3>Upload Documents</h3>
    <label>Visa:</label>
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:FileUpload ID="fuVisa" runat="server" Width="500px" /><br />
    <label>Visa Expiry Date:</label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtVisaExpiryDate" TextMode="Date"  Width="300px" runat="server" placeholder="yyyy-mm-dd"></asp:TextBox>    <asp:RequiredFieldValidator ID="visadtreq" ControlToValidate="txtVisaExpiryDate" runat="server" ErrorMessage="Visa Expiry Is Missing" ForeColor="Red"></asp:RequiredFieldValidator>
<br />
    <label>Passport:</label>
    <asp:FileUpload ID="fuPassport" runat="server" Width="500px"/><br />
    <label>Passport Expiry Date:</label>
    <asp:TextBox ID="txtPassportExpiryDate" TextMode="Date"  Width="300px" runat="server" placeholder="yyyy-mm-dd"></asp:TextBox>     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtPassportExpiryDate" runat="server" ErrorMessage="Passport Expiry Is Missing" ForeColor="Red"></asp:RequiredFieldValidator>
<br />

    <br /><br /><br /><br />

    <asp:Button ID="btnSave" runat="server" Text="Save Customer"  OnClick="btnSave_Click" />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

    <br /><br /><br />

</asp:Content>
