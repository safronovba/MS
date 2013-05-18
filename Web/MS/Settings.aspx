<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Settings.aspx.cs" Inherits="_Default" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="Label1" runat="server" meta:resourcekey="Label1Resource1" Text="База данных:"></asp:Label>
        <asp:TextBox ID="addressbox" runat="server" meta:resourcekey="addressboxResource1" Width="133px">Z:\hosts.accdb</asp:TextBox>
    </p>
    <div>

        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Применить" meta:resourcekey="Button1Resource1" />

    </div>

</asp:Content>

