<%@ Page Language="vb" AutoEventWireup="false" Inherits="arsflussi.cactivity" CodeFile="cactivity.aspx.vb" %>
<%@ Register TagPrefix="uc1" TagName="UClinks" Src="UClinks.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Conferma inserimento attività</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Check" style="Z-INDEX: 103; LEFT: 16px; POSITION: absolute; TOP: 168px; TEXT-ALIGN: center"
				runat="server" Width="584px" Height="64px" Font-Size="Small" Font-Names="Verdana" ForeColor="Red"
				Font-Bold="True"></asp:Label>
			<asp:HyperLink id="lactivity" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 240px; TEXT-ALIGN: right"
				runat="server" Width="592px" Height="16px" Font-Size="XX-Small" Font-Names="Verdana" NavigateUrl="sactivity.aspx">Visualizza l'elenco delle attivita' inserite</asp:HyperLink>
			<uc1:UClinks id="UClinks1" runat="server"></uc1:UClinks></form>
	</body>
</HTML>
