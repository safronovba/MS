<%@ Page Language="C#" AutoEventWireup="true" CodeFile="scan.aspx.cs" Inherits="scan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <a href="hostadd.aspx">Add new host</a>&nbsp;&nbsp;&nbsp;<a href="scan.aspx">Scan for hosts</a>&nbsp;&nbsp;&nbsp;<a href="list.aspx">Device list</a>&nbsp;&nbsp;&nbsp;
        <a href="monitoring.aspx">State page</a>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Scan range:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="scanrangefrombox" runat="server">10.0.0.1</asp:TextBox>
        -<asp:TextBox ID="scanrangetobox" runat="server">10.0.0.4</asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Retry count:" Visible="False"></asp:Label>
        <asp:TextBox ID="retrycountbox" runat="server" Width="57px" Visible="False">1</asp:TextBox>
        <br />
        Group:<asp:TextBox ID="groupnamebox" runat="server">default</asp:TextBox>
        <br />
        <asp:TextBox ID="scanstate" runat="server" Width="359px" style="margin-top: 0px">scan it</asp:TextBox>
        <br />
        <br />
        <asp:Button ID="ButtonScan" runat="server" OnClick="Button1_Click" Text="Start scan" />
    
    </div>
    </form>
</body>
</html>
