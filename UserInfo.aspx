<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="ProjectForNeuralab.Admin"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Filename:
        <asp:TextBox ID="txtFileName" runat="server"></asp:TextBox>
&nbsp;Email:
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnExportXML" runat="server" onclick="btnExportXML_Click" 
            Text="Export to XML" />
        <asp:Button ID="btnExportCSV" runat="server" onclick="btnExportCSV_Click" 
            Text="Export to CSV" />
        <br />
        <br />
        <asp:Label ID="lblResult" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnShow" runat="server" Text="Show User Data" 
            onclick="btnShow_Click" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" Visible="False" BackColor="White" 
            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
