<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <p>
    
        <a href="hostadd.aspx">Add new host</a>&nbsp;&nbsp;&nbsp;<a href="scan.aspx">Scan for hosts</a>&nbsp;&nbsp;&nbsp;<a href="list.aspx">Device list</a>&nbsp;&nbsp;&nbsp;
        <a href="monitoring.aspx">State page</a>
    </p>
    <form id="form1" runat="server">
        <p>
            dbaddress:<asp:TextBox ID="addressbox" runat="server">Z:\hosts.accdb</asp:TextBox>
        </p>
    <div>

        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    
    </div>
    </form>
</body>
</html>
