<%@ page language="C#" autoeventwireup="true" inherits="scan, App_Web_qzxhi3nv" %>

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
        <asp:Label ID="Label2" runat="server" Text="Retry count:"></asp:Label>
        <asp:TextBox ID="retrycountbox" runat="server" Width="57px">1</asp:TextBox>
        <br />
        <asp:TextBox ID="scanstate" runat="server" Width="359px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="ButtonScan" runat="server" OnClick="Button1_Click" Text="Start scan" />
    
    </div>
    </form>
</body>
</html>
