<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Settings.aspx.cs" Inherits="_Default" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<p>
        <asp:Label ID="Label1" runat="server" meta:resourcekey="Label1Resource1" Text="База данных:"></asp:Label>
        <asp:TextBox ID="addressbox" runat="server" meta:resourcekey="addressboxResource1" Width="133px" Text="E:\hosts.accdb"></asp:TextBox>
    </p>
<p>
        <asp:Label ID="Label2" runat="server" Text="Эта база доступна и содержит таблицу с узлами."></asp:Label>
    </p>
    <div>

        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Применить" meta:resourcekey="Button1Resource1" />

    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Создать" Width="102px" />

    </div>

</asp:Content>

