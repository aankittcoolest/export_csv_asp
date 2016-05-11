<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebForm1.aspx.cs" Inherits="WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="ddlExportFormat" runat="server">
            <asp:ListItem Text="COMMA DELIMITED" Value="COMMA DELIMETED"></asp:ListItem>
            <asp:ListItem Text="PIPE DELIMITED" Value="PIPE DELIMETED"></asp:ListItem>
        </asp:DropDownList>
    
    </div>
        <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" />
    </form>
</body>
</html>
