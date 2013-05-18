<%@ Page Language="C#" AutoEventWireup="true" CodeFile="monitoring.aspx.cs" Inherits="monitoring" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>

        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Код" DataSourceID="AccessDataSource1" EmptyDataText="Нет записей для отображения." AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" meta:resourcekey="GridView1Resource1">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ip" HeaderText="ip" SortExpression="ip" meta:resourcekey="BoundFieldResource1" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" meta:resourcekey="BoundFieldResource2" />
                <asp:BoundField DataField="nowstate" HeaderText="nowstate" SortExpression="nowstate" meta:resourcekey="BoundFieldResource3" />
                <asp:BoundField DataField="lasterror" HeaderText="lasterror" SortExpression="lasterror" meta:resourcekey="BoundFieldResource4" />
                <asp:BoundField DataField="lastsucces" HeaderText="lastsucces" SortExpression="lastsucces" meta:resourcekey="BoundFieldResource5" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
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
