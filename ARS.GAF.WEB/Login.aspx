<%@ Register TagPrefix="uc1" TagName="UClinks" Src="UClinks.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Inherits="arsflussi.Login" CodeFile="Login.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Login</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:regularexpressionvalidator id="Regularexpressionvalidator1" style="Z-INDEX: 109; LEFT: 280px; POSITION: absolute; TOP: 320px"
				runat="server" Width="288px" Height="16px" ErrorMessage='Password inserita con caratteri non validi (Range consentito: a-z, A-Z, 0-9, "_", "-")'
				ControlToValidate="password" Display="Dynamic" ValidationExpression="[\w\-]+(\+[\w-]*)?" Font-Size="XX-Small"
				Font-Names="Verdana"></asp:regularexpressionvalidator><asp:regularexpressionvalidator id="emailValid" style="Z-INDEX: 111; LEFT: 280px; POSITION: absolute; TOP: 240px"
				runat="server" Width="288px" Height="14px" ErrorMessage='Account inserito con caratteri non validi (Range consentito: a-z, A-Z, 0-9, "_", ".")' ControlToValidate="email"
				Display="Dynamic" ValidationExpression="[\w\.]+(\+[\w.]*)?" Font-Size="XX-Small" Font-Names="Tahoma"></asp:regularexpressionvalidator><asp:label class="ErrorText" id="Message" style="Z-INDEX: 107; LEFT: 280px; POSITION: absolute; TOP: 144px"
				runat="server" Width="290px" Height="48px" Font-Size="XX-Small" Font-Names="Verdana" ForeColor="Red"></asp:label><asp:requiredfieldvalidator id="passwordRequired" style="Z-INDEX: 106; LEFT: 424px; POSITION: absolute; TOP: 296px"
				runat="server" ErrorMessage="Inserire la Password" ControlToValidate="password" Display="Static" Font-Size="XX-Small" Font-Names="Verdana" Font-Name="verdana"></asp:requiredfieldvalidator><asp:requiredfieldvalidator id="emailRequired" style="Z-INDEX: 105; LEFT: 424px; POSITION: absolute; TOP: 216px"
				runat="server" ErrorMessage="Inserire l'Account" ControlToValidate="email" Display="dynamic" Font-Size="XX-Small" Font-Names="Verdana" Font-Name="verdana"></asp:requiredfieldvalidator><asp:label id="Label2" style="Z-INDEX: 104; LEFT: 280px; POSITION: absolute; TOP: 280px" runat="server"
				Width="120px" Height="16px" Font-Size="XX-Small" Font-Names="Verdana" Font-Bold="True">Password</asp:label><asp:textbox id="email" style="Z-INDEX: 101; LEFT: 280px; POSITION: absolute; TOP: 216px" tabIndex="1"
				runat="server" Font-Size="XX-Small" Font-Names="Verdana" size="25"></asp:textbox><asp:textbox id="password" style="Z-INDEX: 102; LEFT: 280px; POSITION: absolute; TOP: 296px"
				tabIndex="2" runat="server" Font-Size="XX-Small" Font-Names="Verdana" size="25" textmode="password"></asp:textbox><asp:label id="Label1" style="Z-INDEX: 103; LEFT: 280px; POSITION: absolute; TOP: 200px" runat="server"
				Width="120px" Height="16px" Font-Size="XX-Small" Font-Names="Verdana" Font-Bold="True">Account</asp:label><asp:checkbox id="RememberLogin" style="Z-INDEX: 108; LEFT: 280px; POSITION: absolute; TOP: 360px"
				tabIndex="3" runat="server" Width="109px" Font-Size="XX-Small" Font-Names="Verdana" Text="Registra Login"></asp:checkbox><asp:button id="LoginBtn" style="Z-INDEX: 110; LEFT: 280px; POSITION: absolute; TOP: 392px"
				tabIndex="4" runat="server" Width="104px" Height="24px" Font-Names="Verdana" Text="Accedi" BackColor="Transparent" BorderStyle="Groove" BorderColor="DodgerBlue"></asp:button><uc1:uclinks id="UClinks1" runat="server"></uc1:uclinks></form>
	</body>
</HTML>
