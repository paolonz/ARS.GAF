<%@ Register TagPrefix="uc1" TagName="UClinks" Src="UClinks.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Inherits="arsflussi.Welcome" CodeFile="Welcome.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Benvenuto</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:UClinks id="UClinks1" runat="server"></uc1:UClinks>
			<asp:Label id="WelcomeMsg" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 168px; TEXT-ALIGN: center"
				runat="server" Width="716px" Height="112px" Font-Bold="True" Font-Italic="True" Font-Names="Verdana"
				Font-Size="Large"></asp:Label>
		</form>
	</body>
</HTML>