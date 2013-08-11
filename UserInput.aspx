<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="UserInput.aspx.cs" Inherits="ProjectForNeuralab._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <br />
    <br />
    <p>
        Name:
        <asp:TextBox ID="txtBoxName" runat="server" MaxLength="50"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtBoxName" ErrorMessage="Cannot be empty!" ForeColor="Red" 
            ValidationGroup="NameEmailNote"></asp:RequiredFieldValidator>
    </p>
    <p>
        Email:
        <asp:TextBox ID="txtBoxEmail" runat="server" MaxLength="50"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txtBoxEmail" ErrorMessage="Cannot be empty!" ForeColor="Red" 
            ValidationGroup="NameEmailNote"></asp:RequiredFieldValidator>
    </p>
    <p>
        Note:
        <asp:TextBox ID="txtBoxNote" runat="server" MaxLength="50" Rows="5" 
            TextMode="MultiLine"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="txtBoxNote" ErrorMessage="Cannot be empty!" ForeColor="Red" 
            ValidationGroup="NameEmailNote"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Button ID="btnSend" runat="server" onclick="btnSend_Click" Text="Send" 
            ValidationGroup="NameEmail" />
    </p>
    <p>
        <asp:Label ID="lblResult" runat="server" Text="Label" Visible="False"></asp:Label>
    </p>
        
</asp:Content>
