<%@ Register TagPrefix="uc1" TagName="UClinks" Src="UClinks.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Inherits="arsflussi.dactivity" CodeFile="dactivity.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Dettaglio attività</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:label id="myError" style="Z-INDEX: 108; LEFT: 112px; POSITION: absolute; TOP: 152px" tabIndex="-1"
				runat="server" Height="16px" Width="576px" EnableViewState="False" Font-Names="Verdana"
				Font-Size="XX-Small" ForeColor="Red"></asp:label>
			<asp:button id="EliminaN" style="Z-INDEX: 111; LEFT: 240px; POSITION: absolute; TOP: 512px"
				tabIndex="6" runat="server" Height="24px" Width="104px" Font-Names="Verdana" Visible="False"
				Text="No" BorderColor="DodgerBlue" BackColor="Transparent" BorderStyle="Groove"></asp:button>
			<asp:button id="EliminaY" style="Z-INDEX: 110; LEFT: 112px; POSITION: absolute; TOP: 512px"
				tabIndex="5" runat="server" Height="24px" Width="104px" Font-Names="Verdana" Visible="False"
				Text="Si" BorderColor="DodgerBlue" BackColor="Transparent" BorderStyle="Groove"></asp:button>
			<asp:button id="Elimina" style="Z-INDEX: 109; LEFT: 272px; POSITION: absolute; TOP: 448px" tabIndex="4"
				runat="server" Height="24px" Width="104px" Font-Names="Verdana" Text="Elimina" BorderColor="DodgerBlue"
				BackColor="Transparent" BorderStyle="Groove"></asp:button>
			<asp:Label id="Label1" style="Z-INDEX: 107; LEFT: 112px; POSITION: absolute; TOP: 192px" runat="server"
				Height="24px" Width="72px" Font-Names="Verdana" Font-Size="XX-Small" Font-Bold="True">Attivita' n.</asp:Label>
			<asp:label id="lAtt" style="Z-INDEX: 106; LEFT: 192px; POSITION: absolute; TOP: 192px" runat="server"
				Height="24px" Width="148px" Font-Names="Verdana" Font-Size="XX-Small" Font-Bold="True"></asp:label>
			<asp:datagrid id="ListFile" style="Z-INDEX: 100; LEFT: 112px; POSITION: absolute; TOP: 232px"
				runat="server" Height="128px" Width="500px" Font-Names="Verdana" Font-Size="XX-Small" AutoGenerateColumns="False">
				<FooterStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Italic="True"></FooterStyle>
				<SelectedItemStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Italic="True"></SelectedItemStyle>
				<EditItemStyle Font-Size="XX-Small" Font-Names="Tahoma"></EditItemStyle>
				<AlternatingItemStyle Font-Size="XX-Small" Font-Names="Tahoma"></AlternatingItemStyle>
				<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Italic="True"></ItemStyle>
				<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Italic="True" Font-Bold="True"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="posizione" HeaderText="Posizione">
						<HeaderStyle Width="100px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="nomefile" HeaderText="Tipo File">
						<HeaderStyle Width="100px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="nome" HeaderText="File">
						<HeaderStyle Width="300px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="controllofile" HeaderText="controllofile"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="datacontrollo" HeaderText="datacontrollo"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="filererrori" HeaderText="filererrori"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="filederrori" HeaderText="filederrori"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="filericevuta" HeaderText="filericevuta"></asp:BoundColumn>
				</Columns>
				<PagerStyle Font-Size="XX-Small" Font-Names="Verdana"></PagerStyle>
			</asp:datagrid>
			<asp:label id="Validazione" style="Z-INDEX: 101; LEFT: 112px; POSITION: absolute; TOP: 376px"
				runat="server" Height="24px" Width="336px" Font-Names="Verdana" Font-Size="XX-Small"></asp:label>
			<asp:hyperlink id="hlRicevuta" style="Z-INDEX: 102; LEFT: 112px; POSITION: absolute; TOP: 408px"
				runat="server" Height="24px" Width="136px" Font-Names="Verdana" Font-Size="XX-Small" tabIndex="1">File Ricevuta Controllo</asp:hyperlink>
			<asp:hyperlink id="hlRErrori" style="Z-INDEX: 103; LEFT: 264px; POSITION: absolute; TOP: 408px"
				runat="server" Height="24px" Width="120px" Font-Names="Verdana" Font-Size="XX-Small" tabIndex="2">File Riepilogo Errori</asp:hyperlink>
			<asp:hyperlink id="hlDErrori" style="Z-INDEX: 104; LEFT: 400px; POSITION: absolute; TOP: 408px"
				runat="server" Height="24px" Width="120px" Font-Names="Verdana" Font-Size="XX-Small" tabIndex="3">File Dettaglio Errori</asp:hyperlink>
			<asp:label id="Risposta" style="Z-INDEX: 105; LEFT: 112px; POSITION: absolute; TOP: 488px"
				runat="server" Height="16px" Width="234px" Font-Names="Verdana" Font-Size="XX-Small" Visible="False"
				Font-Bold="True">Sei sicuro di voler eliminare l'attivita'?</asp:label>
			<uc1:UClinks id="UClinks1" runat="server"></uc1:UClinks>
		</form>
	</body>
</HTML>
