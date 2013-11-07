<%@ Register TagPrefix="uc1" TagName="UClinks" Src="UClinks.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Inherits="arsflussi.Register" CodeFile="Register.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Profilo utente</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:textbox id="oldPassword" style="Z-INDEX: 127; LEFT: 448px; POSITION: absolute; TOP: 496px"
				runat="server" Width="136px" Visible="False" TextMode="Password"></asp:textbox>
			<asp:HyperLink id="HyperLink2" style="Z-INDEX: 130; LEFT: 280px; POSITION: absolute; TOP: 352px; TEXT-ALIGN: right"
				tabIndex="3" runat="server" Visible="False" Width="280px" Font-Names="Verdana" Font-Size="XX-Small"
				NavigateUrl="admactivity.aspx">Visualizza elenco attività inserite</asp:HyperLink><asp:button id="RegisterBtn" style="Z-INDEX: 128; LEFT: 24px; POSITION: absolute; TOP: 496px"
				tabIndex="7" runat="server" Width="104px" Font-Names="Verdana" Height="24px" Text="Invia" BorderColor="DodgerBlue" BorderStyle="Groove" BackColor="Transparent"></asp:button><asp:label id="myPwd" style="Z-INDEX: 126; LEFT: 24px; POSITION: absolute; TOP: 560px" runat="server"
				Width="736px" EnableViewState="false" CssClass="ErrorText" Font-Size="XX-Small" Font-Names="Verdana" ForeColor="Red"></asp:label><asp:comparevalidator id="CompareValidator1" style="Z-INDEX: 125; LEFT: 176px; POSITION: absolute; TOP: 440px"
				runat="server" Width="218px" Font-Size="XX-Small" Font-Names="Tahoma" ErrorMessage="Le password non coincidono" Font-Name="verdana" Display="Dynamic" ControlToValidate="ConfirmPassword" ControlToCompare="Password" Enabled="False"></asp:comparevalidator><asp:comparevalidator id="CompareValidator2" style="Z-INDEX: 124; LEFT: 24px; POSITION: absolute; TOP: 464px"
				runat="server" Width="266px" Font-Size="XX-Small" Font-Names="Tahoma" ErrorMessage="La password è identica a quella precedente" Font-Name="verdana" Display="Dynamic" ControlToValidate="oldPassword" ControlToCompare="ConfirmPassword" Operator="NotEqual" Enabled="False"></asp:comparevalidator><asp:requiredfieldvalidator id="RequiredFieldValidator7" style="Z-INDEX: 123; LEFT: 176px; POSITION: absolute; TOP: 440px"
				runat="server" Width="155px" Font-Size="XX-Small" Font-Names="Tahoma" ErrorMessage="Inserire conferma password" Font-Name="verdana" Display="dynamic" ControlToValidate="ConfirmPassword" Enabled="False"></asp:requiredfieldvalidator><asp:label id="Label5" style="Z-INDEX: 122; LEFT: 24px; POSITION: absolute; TOP: 424px" runat="server"
				Width="160px" Font-Size="XX-Small" Font-Names="Tahoma" Enabled="False" Height="10px">Conferma Nuova Password</asp:label><asp:textbox id="ConfirmPassword" style="Z-INDEX: 107; LEFT: 24px; POSITION: absolute; TOP: 440px"
				tabIndex="6" runat="server" Width="139px" TextMode="Password" Font-Size="XX-Small" Font-Names="Tahoma" Enabled="False" size="25"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator6" style="Z-INDEX: 121; LEFT: 176px; POSITION: absolute; TOP: 392px"
				runat="server" Width="337px" Font-Size="XX-Small" Font-Names="Verdana" ErrorMessage='Password inserita con caratteri non validi (Range consentito: a-z, A-Z, 0-9, "_", "-")' Font-Name="verdana" Display="Dynamic" ControlToValidate="Password" Enabled="False"
				Height="28px" ValidationExpression="[\w\-]+(\+[\w-]*)?"></asp:regularexpressionvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator6" style="Z-INDEX: 120; LEFT: 176px; POSITION: absolute; TOP: 392px"
				runat="server" Width="139px" Font-Size="XX-Small" Font-Names="Verdana" ErrorMessage="Inserire Password" Font-Name="verdana" Display="dynamic" ControlToValidate="Password" Enabled="False"></asp:requiredfieldvalidator><asp:label id="Label4" style="Z-INDEX: 119; LEFT: 24px; POSITION: absolute; TOP: 376px" runat="server"
				Width="120px" Font-Size="XX-Small" Font-Names="Verdana" Enabled="False" Height="12px">Nuova Password</asp:label><asp:textbox id="Password" style="Z-INDEX: 106; LEFT: 24px; POSITION: absolute; TOP: 392px" tabIndex="5"
				runat="server" Width="139px" TextMode="Password" Font-Size="XX-Small" Font-Names="Verdana" Enabled="False" size="25"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator5" style="Z-INDEX: 118; LEFT: 288px; POSITION: absolute; TOP: 312px"
				runat="server" Font-Size="XX-Small" Font-Names="Verdana" ErrorMessage='Fax inserito con caratteri non validi (Range consentito: 0-9, "-")' Font-Name="verdana" Display="Dynamic" ControlToValidate="Fax" ValidationExpression="[\d\-]+(\+[\d-]*)?"></asp:regularexpressionvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator5" style="Z-INDEX: 117; LEFT: 288px; POSITION: absolute; TOP: 312px"
				runat="server" Width="80px" Font-Size="XX-Small" Font-Names="Verdana" ErrorMessage="Inserire Fax" Font-Name="verdana" Display="dynamic" ControlToValidate="Fax"></asp:requiredfieldvalidator><asp:label id="Label8" style="Z-INDEX: 116; LEFT: 24px; POSITION: absolute; TOP: 296px" runat="server"
				Width="120px" Font-Size="XX-Small" Font-Names="Verdana" Height="10px">Fax</asp:label><asp:textbox id="Fax" style="Z-INDEX: 112; LEFT: 24px; POSITION: absolute; TOP: 312px" tabIndex="3"
				runat="server" Width="256px" Font-Size="XX-Small" Font-Names="Verdana" size="25"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator4" style="Z-INDEX: 115; LEFT: 288px; POSITION: absolute; TOP: 272px"
				runat="server" Font-Size="XX-Small" Font-Names="Verdana" ErrorMessage="Inserire Indizzo e- mail" Font-Name="verdana" Display="dynamic" ControlToValidate="Mail"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="RegularExpressionValidator2" style="Z-INDEX: 114; LEFT: 288px; POSITION: absolute; TOP: 272px"
				runat="server" Font-Size="XX-Small" Font-Names="Verdana" ErrorMessage="Inserire l'indirizzo nella forma corretta" Font-Name="verdana" Display="Dynamic" ControlToValidate="Mail" ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+"></asp:regularexpressionvalidator><asp:label id="Label7" style="Z-INDEX: 113; LEFT: 24px; POSITION: absolute; TOP: 248px" runat="server"
				Width="120px" Font-Size="XX-Small" Font-Names="Verdana" Height="10px">E-Mail</asp:label><asp:textbox id="Mail" style="Z-INDEX: 110; LEFT: 24px; POSITION: absolute; TOP: 264px" tabIndex="2"
				runat="server" Width="256px" Font-Size="XX-Small" Font-Names="Verdana" size="25"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator4" style="Z-INDEX: 111; LEFT: 288px; POSITION: absolute; TOP: 216px"
				runat="server" Width="280px" Font-Size="XX-Small" Font-Names="Verdana" ErrorMessage='Telefono inserito con caratteri non validi (Range consentito: 0-9, "-")' Font-Name="verdana" Display="Dynamic" ControlToValidate="Telefono"
				Height="8px" ValidationExpression="[\d\-]+(\+[\d-]*)?"></asp:regularexpressionvalidator><asp:requiredfieldvalidator id="RequiredFieldValidator3" style="Z-INDEX: 109; LEFT: 288px; POSITION: absolute; TOP: 216px"
				runat="server" Font-Size="XX-Small" Font-Names="Verdana" ErrorMessage="Inserire Telefono" Font-Name="verdana" Display="dynamic" ControlToValidate="Telefono"></asp:requiredfieldvalidator><asp:label id="Label6" style="Z-INDEX: 108; LEFT: 24px; POSITION: absolute; TOP: 200px" runat="server"
				Width="120px" Font-Size="XX-Small" Font-Names="Verdana" Height="8px">Telefono</asp:label><asp:textbox id="Telefono" style="Z-INDEX: 103; LEFT: 24px; POSITION: absolute; TOP: 216px" tabIndex="1"
				runat="server" Width="256px" Font-Size="XX-Small" Font-Names="Verdana" size="25"></asp:textbox><asp:textbox id="Email" style="Z-INDEX: 102; LEFT: 280px; POSITION: absolute; TOP: 496px" runat="server"
				Width="163px" Visible="False" Font-Size="XX-Small" Font-Names="Verdana" Enabled="False" size="25"></asp:textbox><asp:label id="Label2" style="Z-INDEX: 105; LEFT: 24px; POSITION: absolute; TOP: 160px" runat="server"
				Width="112px" Font-Size="X-Small" Font-Names="Verdana" Height="25px" Font-Bold="True">Profilo Utente:</asp:label><asp:textbox id="Name" style="Z-INDEX: 101; LEFT: 136px; POSITION: absolute; TOP: 160px" tabIndex="1"
				runat="server" Width="440px" Font-Size="X-Small" Font-Names="Verdana" Enabled="False" Height="25px" size="25" BorderColor="White" BorderStyle="None" Font-Bold="True"></asp:textbox><asp:label id="MyError" style="Z-INDEX: 100; LEFT: 24px; POSITION: absolute; TOP: 536px" runat="Server"
				Width="736px" EnableViewState="false" CssClass="ErrorText" Font-Size="XX-Small" Font-Names="Verdana" ForeColor="Red"></asp:label><uc1:uclinks id="UClinks1" runat="server"></uc1:uclinks><asp:checkbox id="CheckBox1" style="Z-INDEX: 129; LEFT: 24px; POSITION: absolute; TOP: 344px"
				tabIndex="4" runat="server" Width="200px" Font-Size="XX-Small" Font-Names="Verdana" Height="16px" Text="Gestione Password" AutoPostBack="True"></asp:checkbox></form>
	</body>
</HTML>
