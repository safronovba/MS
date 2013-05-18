<%@ Page Language="C#" AutoEventWireup="true" CodeFile="monitoring.aspx.cs" Inherits="monitoring" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>

        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Код" DataSourceID="AccessDataSource1" EmptyDataText="Нет записей для отображения." AllowSorting="True" CellPadding="3" meta:resourcekey="GridView1Resource1" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
            <Columns>
                <asp:BoundField DataField="ip" HeaderText="ip" SortExpression="ip" meta:resourcekey="BoundFieldResource1" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" meta:resourcekey="BoundFieldResource2" />
                <asp:BoundField DataField="nowstate" HeaderText="nowstate" SortExpression="nowstate" meta:resourcekey="BoundFieldResource3" />
                <asp:BoundField DataField="lasterror" HeaderText="lasterror" SortExpression="lasterror" meta:resourcekey="BoundFieldResource4" />
                <asp:BoundField DataField="lastsucces" HeaderText="lastsucces" SortExpression="lastsucces" meta:resourcekey="BoundFieldResource5" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="E:\hosts.accdb" DeleteCommand="DELETE FROM `hosts` WHERE `Код` = ?" InsertCommand="INSERT INTO `hosts` (`Код`, `ip`, `name`, `mac`, `scanint`, `nowstate`, `lasterror`, `lastsucces`) VALUES (?, ?, ?, ?, ?, ?, ?, ?)" SelectCommand="SELECT `Код`, `ip`, `name`, `mac`, `scanint`, `nowstate`, `lasterror`, `lastsucces` FROM `hosts`" UpdateCommand="UPDATE `hosts` SET `ip` = ?, `name` = ?, `mac` = ?, `scanint` = ?, `nowstate` = ?, `lasterror` = ?, `lastsucces` = ? WHERE `Код` = ?">
            <DeleteParameters>
                <asp:Parameter Name="Код" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Код" Type="Int32" />
                <asp:Parameter Name="ip" Type="String" />
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="mac" Type="String" />
                <asp:Parameter Name="scanint" Type="Int32" />
                <asp:Parameter Name="nowstate" Type="String" />
                <asp:Parameter Name="lasterror" Type="String" />
                <asp:Parameter Name="lastsucces" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="ip" Type="String" />
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="mac" Type="String" />
                <asp:Parameter Name="scanint" Type="Int32" />
                <asp:Parameter Name="nowstate" Type="String" />
                <asp:Parameter Name="lasterror" Type="String" />
                <asp:Parameter Name="lastsucces" Type="String" />
                <asp:Parameter Name="Код" Type="Int32" />
            </UpdateParameters>
        </asp:AccessDataSource>
        <br />

    </div>
</asp:Content>
