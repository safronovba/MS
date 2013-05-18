<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="_Default" MasterPageFile="~/MasterPage.master" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>

        <br />
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Код" DataSourceID="AccessDataSource1" EmptyDataText="Нет записей для отображения." ForeColor="#333333" GridLines="None" meta:resourcekey="GridView1Resource1">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Код" HeaderText="Код" ReadOnly="True" SortExpression="Код" meta:resourcekey="BoundFieldResource1" />
                <asp:BoundField DataField="ip" HeaderText="ip" SortExpression="ip" meta:resourcekey="BoundFieldResource2" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" meta:resourcekey="BoundFieldResource3" />
                <asp:BoundField DataField="scanint" HeaderText="scanint" SortExpression="scanint" meta:resourcekey="BoundFieldResource4" />
                <asp:BoundField DataField="nowstate" HeaderText="nowstate" SortExpression="nowstate" meta:resourcekey="BoundFieldResource5" />
                <asp:BoundField DataField="lasttime" HeaderText="lasttime" SortExpression="lasttime" meta:resourcekey="BoundFieldResource6" />
                <asp:BoundField DataField="grp" HeaderText="grp" SortExpression="grp" meta:resourcekey="BoundFieldResource7" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" meta:resourcekey="CommandFieldResource1" />
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
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="E:\hosts.accdb" DeleteCommand="DELETE FROM `hosts` WHERE `Код` = ?" InsertCommand="INSERT INTO `hosts` (`Код`, `ip`, `name`, `mac`, `scanint`, `nowstate`, `lasterror`, `lastsucces`, `lasttime`, `grp`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)" SelectCommand="SELECT `Код`, `ip`, `name`, `mac`, `scanint`, `nowstate`, `lasterror`, `lastsucces`, `lasttime`, `grp` FROM `hosts`" UpdateCommand="UPDATE `hosts` SET `ip` = ?, `name` = ?, `mac` = ?, `scanint` = ?, `nowstate` = ?, `lasterror` = ?, `lastsucces` = ?, `lasttime` = ?, `grp` = ? WHERE `Код` = ?">
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
                <asp:Parameter Name="lasttime" Type="DateTime" />
                <asp:Parameter Name="grp" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="ip" Type="String" />
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="mac" Type="String" />
                <asp:Parameter Name="scanint" Type="Int32" />
                <asp:Parameter Name="nowstate" Type="String" />
                <asp:Parameter Name="lasterror" Type="String" />
                <asp:Parameter Name="lastsucces" Type="String" />
                <asp:Parameter Name="lasttime" Type="DateTime" />
                <asp:Parameter Name="grp" Type="String" />
                <asp:Parameter Name="Код" Type="Int32" />
            </UpdateParameters>
        </asp:AccessDataSource>

    </div>
</asp:Content>
