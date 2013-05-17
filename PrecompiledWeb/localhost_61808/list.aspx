<%@ page language="C#" autoeventwireup="true" inherits="_Default, App_Web_qzxhi3nv" %>

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
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Код" DataSourceID="AccessDataSource1" EmptyDataText="Нет записей для отображения.">
            <Columns>
                <asp:BoundField DataField="Код" HeaderText="Код" ReadOnly="True" SortExpression="Код" />
                <asp:BoundField DataField="ip" HeaderText="ip" SortExpression="ip" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="scanint" HeaderText="scanint" SortExpression="scanint" />
                <asp:BoundField DataField="mac" HeaderText="mac" SortExpression="mac" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
        </asp:GridView>
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="Z:\hosts.accdb" DeleteCommand="DELETE FROM `hosts` WHERE `Код` = ?" InsertCommand="INSERT INTO `hosts` (`Код`, `ip`, `name`, `mac`, `scanint`) VALUES (?, ?, ?, ?, ?)" SelectCommand="SELECT `Код`, `ip`, `name`, `mac`, `scanint` FROM `hosts`" UpdateCommand="UPDATE `hosts` SET `ip` = ?, `name` = ?, `mac` = ?, `scanint` = ? WHERE `Код` = ?">
            <DeleteParameters>
                <asp:Parameter Name="Код" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Код" Type="Int32" />
                <asp:Parameter Name="ip" Type="String" />
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="mac" Type="String" />
                <asp:Parameter Name="scanint" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="ip" Type="String" />
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="mac" Type="String" />
                <asp:Parameter Name="scanint" Type="Int32" />
                <asp:Parameter Name="Код" Type="Int32" />
            </UpdateParameters>
        </asp:AccessDataSource>
        <br />
    
    </div>
    </form>
</body>
</html>
