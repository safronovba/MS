<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hostadd.aspx.cs" Inherits="hostadd" MasterPageFile="~/MasterPage.master" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Host ip:" meta:resourcekey="Label1Resource1"></asp:Label>
        <asp:TextBox ID="hostipform" runat="server" EnableTheming="True" OnTextChanged="hostipform_TextChanged" Width="171px" meta:resourcekey="hostipformResource1"></asp:TextBox>
        <br />
&nbsp;<br />
        <asp:Label ID="Label2" runat="server" Text="Host name:" meta:resourcekey="Label2Resource1"></asp:Label>
        <asp:TextBox ID="hostnameform" runat="server" OnTextChanged="hostnameform_TextChanged" Width="147px" meta:resourcekey="hostnameformResource1"></asp:TextBox>
        <br />
&nbsp;<br />
        <asp:Label ID="Label3" runat="server" Text="Host group:" meta:resourcekey="Label3Resource1"></asp:Label>
        <asp:TextBox ID="grouptextbox" runat="server" meta:resourcekey="grouptextboxResource1">default</asp:TextBox>
        <br />
&nbsp;<br />
                <asp:Label ID="Label4" runat="server" Text="Scan interval (s):" meta:resourcekey="Label4Resource1"></asp:Label>
                <asp:TextBox ID="hostscanint" runat="server" Width="106px" meta:resourcekey="hostscanintResource1">60</asp:TextBox>
        <br />
&nbsp;<br />
        <asp:TextBox ID="resulttextbox" runat="server" Height="16px" Width="228px" meta:resourcekey="resulttextboxResource1"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="resolvebutton" runat="server" OnClick="resolvebutton_Click" Text="Resolve" meta:resourcekey="resolvebuttonResource1" Width="90px" />  
        &nbsp;&nbsp;&nbsp;  
        <asp:Button ID="addbutton" runat="server" OnClick="addbutton_Click" Text="Add" meta:resourcekey="addbuttonResource1" Width="90px" />  
        <br />
        <asp:Button ID="testbutton" runat="server" OnClick="testbutton_Click" Text="test" meta:resourcekey="testbuttonResource1" Width="90px" />  
        &nbsp;&nbsp;&nbsp;  
        <asp:Button ID="clearbutton" runat="server" OnClick="clearbutton_Click" Text="Clear" meta:resourcekey="clearbuttonResource1" Width="90px" />  
        <br />
</asp:Content>