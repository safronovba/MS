<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hostadd.aspx.cs" Inherits="hostadd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
        <a href="hostadd.aspx">Add new host</a>&nbsp;&nbsp;&nbsp;<a href="scan.aspx">Scan for hosts</a>&nbsp;&nbsp;&nbsp;<a href="list.aspx">Device list</a>&nbsp;&nbsp;&nbsp;
        <a href="monitoring.aspx">State page</a>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Host ip:"></asp:Label>
        <asp:TextBox ID="hostipform" runat="server" EnableTheming="True" OnTextChanged="hostipform_TextChanged" Width="171px"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Host name:"></asp:Label>
        <asp:TextBox ID="hostnameform" runat="server" OnTextChanged="hostnameform_TextChanged" Width="147px"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Host mac:"></asp:Label>
        <asp:TextBox ID="hostmacform" runat="server" Width="154px"></asp:TextBox>
                <br />
                <asp:Label ID="Label4" runat="server" Text="Scan interval (s):"></asp:Label>
                <asp:TextBox ID="hostscanint" runat="server" Width="106px">0</asp:TextBox>
        <br />
        <asp:TextBox ID="resulttextbox" runat="server" Height="16px" Width="228px"></asp:TextBox>
        <br />
        <asp:Button ID="resolvebutton" runat="server" OnClick="resolvebutton_Click" Text="Resolve" />
        <asp:Button ID="addbutton" runat="server" OnClick="addbutton_Click" Text="Add" style="width: 39px" />
        <asp:Button ID="testbutton" runat="server" OnClick="testbutton_Click" Text="test" />
        <asp:Button ID="clearbutton" runat="server" OnClick="clearbutton_Click" Text="Clear" />
        <br />

    </form>
</body>
</html>
