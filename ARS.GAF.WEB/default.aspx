<%@ Register TagPrefix="uc1" TagName="UClinks" Src="UClinks.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Inherits="arsflussi.WebForm1" CodeFile="default.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Gestione Accoglienza Flussi - ARS Marche</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<DIV style="DISPLAY: inline; FONT-WEIGHT: bold; FONT-SIZE: large; Z-INDEX: 100; LEFT: 8px; VERTICAL-ALIGN: baseline; WIDTH: 752px; FONT-STYLE: italic; FONT-FAMILY: Verdana; POSITION: absolute; TOP: 200px; HEIGHT: 72px; BACKGROUND-COLOR: transparent; TEXT-ALIGN: center; FONT-VARIANT: normal">Benvenuti nel sito per la Gestione Accoglienza 
				Flussi dell'Agenzia Regionale Sanitaria - Regione Marche</DIV>
			<asp:HyperLink id="HyperLink3" style="Z-INDEX: 107; LEFT: 376px; POSITION: absolute; TOP: 392px; TEXT-ALIGN: right"
				tabIndex="4" runat="server" NavigateUrl="docs/arsflussi_nu.zip" Font-Size="XX-Small" Font-Names="Verdana"
				Width="376px">Scheda per la registrazione nuovo utente</asp:HyperLink>
			<asp:HyperLink id="HyperLink2" style="Z-INDEX: 105; LEFT: 376px; POSITION: absolute; TOP: 368px; TEXT-ALIGN: right"
				runat="server" Width="376px" Font-Names="Verdana" Font-Size="XX-Small" NavigateUrl="contatti.aspx"
				tabIndex="3">Contatti</asp:HyperLink><IMG style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 64px" src="images/home34.jpg"><IMG src="images/logo-ars2.gif">
			<asp:HyperLink id="HyperLink1" style="Z-INDEX: 102; LEFT: 376px; POSITION: absolute; TOP: 344px; TEXT-ALIGN: right"
				runat="server" Width="376px" Font-Names="Verdana" Font-Size="XX-Small" NavigateUrl="docs/Guida.zip"
				tabIndex="2">Download manuale utente</asp:HyperLink><IMG style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 176px" src="images/bar_blue.gif">
			<asp:Button id="Button1" style="FONT-WEIGHT: bold; Z-INDEX: 106; LEFT: 352px; POSITION: absolute; TOP: 280px"
				runat="server" Width="80px" Font-Names="Verdana" Font-Size="Small" Text="LogIn" BorderStyle="Groove"
				BackColor="Transparent" BorderColor="DodgerBlue" tabIndex="1"></asp:Button>
		</form>
	</body>
</HTML>
