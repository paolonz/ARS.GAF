<%@ Control Language="vb" AutoEventWireup="false" Inherits="arsflussi.UClinks" CodeFile="UClinks.ascx.vb" %>
<P>
	<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="images/logo-ars2.gif"></asp:ImageButton>
	<asp:Label id="Label1" runat="server" Font-Names="Verdana" Font-Size="Medium" Height="27px"
		Width="312px" Font-Bold="True" Font-Italic="True" ForeColor="DodgerBlue">Gestione Accoglienza Flussi</asp:Label></P>
<P><IMG src="images/box.gif">&nbsp;
	<asp:hyperlink id="hlLogin" NavigateUrl="LogoutFE.aspx" Width="32px" Height="24px" runat="server"
		Font-Size="XX-Small" Font-Names="Tahoma">Logout</asp:hyperlink><IMG src="images/box.gif">
    <asp:hyperlink id="hlAdmin" NavigateUrl="admin.aspx" Width="32px" Height="24px" runat="server"
		Font-Size="XX-Small" Font-Names="Tahoma">Admin</asp:hyperlink><IMG src="images/box.gif">
	<asp:hyperlink id="Hyperlink2" NavigateUrl="contatti.aspx" Width="48px" Height="24px" runat="server"
		Font-Size="XX-Small" Font-Names="Tahoma">Contatti</asp:hyperlink>
    <img src="images/box.gif" id="imgLogin">&nbsp;
	<asp:hyperlink id="hlProfilo" NavigateUrl="Register.aspx" Width="80px" Height="24px" runat="server"
		Font-Size="XX-Small" Font-Names="Tahoma">Profilo Utente</asp:hyperlink><IMG src="images/box.gif">&nbsp;
	<asp:hyperlink id="hlIActivity" NavigateUrl="iactivity.aspx" Width="96px" Height="24px" runat="server"
		Font-Size="XX-Small" Font-Names="Tahoma">Inserisci Attivita'</asp:hyperlink><IMG src="images/box.gif">&nbsp;
	<asp:hyperlink id="hlSActivity" NavigateUrl="sactivity.aspx" Width="104px" Height="24px" runat="server"
		Font-Size="XX-Small" Font-Names="Tahoma">Visualizza Attivita'</asp:hyperlink><IMG src="images/box.gif">&nbsp;
	<asp:hyperlink id="hlSDocs" NavigateUrl="eventi.aspx" Width="88px" Height="24px" runat="server"
		Font-Size="XX-Small" Font-Names="Tahoma">Visualizza Eventi</asp:hyperlink><IMG src="images/box.gif">
	<asp:hyperlink id="Hyperlink1" NavigateUrl="Documentazione.aspx" Width="88px" Height="24px" runat="server"
		Font-Size="XX-Small" Font-Names="Tahoma">Documentazione</asp:hyperlink></P>
<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</P>
