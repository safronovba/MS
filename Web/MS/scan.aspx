<%@ Page Language="C#" AutoEventWireup="true" CodeFile="scan.aspx.cs" Inherits="scan" MasterPageFile="~/MasterPage.master" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>

        <br />
        <asp:Label ID="Label1" runat="server" Text="Scan range:" meta:resourcekey="Label1Resource1"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="scanrangefrombox" runat="server" meta:resourcekey="scanrangefromboxResource1">10.0.0.1</asp:TextBox>
        -<asp:TextBox ID="scanrangetobox" runat="server" meta:resourcekey="scanrangetoboxResource1">10.0.0.4</asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Retry count:" Visible="False" meta:resourcekey="Label2Resource1"></asp:Label>
        <asp:TextBox ID="retrycountbox" runat="server" Width="57px" Visible="False" meta:resourcekey="retrycountboxResource1">1</asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Group:" meta:resourcekey="Label3Resource1"></asp:Label>
        <asp:TextBox ID="groupnamebox" runat="server" meta:resourcekey="groupnameboxResource1">default</asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="scanstate" runat="server" Width="359px" Style="margin-top: 0px" meta:resourcekey="scanstateResource1">scan it</asp:TextBox>
        <br />
        <br />
        <asp:Button ID="ButtonScan" runat="server" OnClick="Button1_Click" Text="Start scan" meta:resourcekey="ButtonScanResource1" />

    </div>
</asp:Content>
