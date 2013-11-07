<%@ Page Language="vb" AutoEventWireup="false" Inherits="arsflussi.Documentazione1" CodeFile="Documentazione.aspx.vb" %>
<%@ Register TagPrefix="uc1" TagName="UClinks" Src="UClinks.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Documentazione</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:label id="MyError" style="Z-INDEX: 110; LEFT: 16px; POSITION: absolute; TOP: 120px" runat="Server"
				CssClass="ErrorText" EnableViewState="false" BorderStyle="None" ForeColor="Red" Font-Names="Verdana"
				Width="656px" Height="16px" Font-Size="XX-Small"></asp:label><asp:label id="lperiodo" style="Z-INDEX: 113; LEFT: 272px; POSITION: absolute; TOP: 272px; TEXT-ALIGN: left"
				runat="server" Font-Names="Verdana" Width="402px" Height="8px" Font-Size="XX-Small" Font-Bold="True" Visible="False"></asp:label><asp:dropdownlist id="Flusso" style="Z-INDEX: 112; LEFT: 272px; POSITION: absolute; TOP: 216px" tabIndex="1"
				runat="server" Font-Names="Verdana" Width="408px" Height="24px" Font-Size="XX-Small" Visible="False" AutoPostBack="True"></asp:dropdownlist><asp:datagrid id="detailDataGrid" style="Z-INDEX: 111; LEFT: 16px; POSITION: absolute; TOP: 360px"
				tabIndex="6" runat="server" BorderStyle="None" Font-Names="Verdana" Width="752px" Height="50px" AllowSorting="True" CellPadding="3" DataMember="T_Documenti" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px"
				AllowPaging="True">
				<FooterStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Italic="True" ForeColor="#000066"
					BackColor="White"></FooterStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
				<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Italic="True" ForeColor="#000066"></ItemStyle>
				<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Italic="True" Font-Bold="True" Height="10px"
					ForeColor="White" BackColor="#006699"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="titolo" HeaderText="Titolo documento"></asp:BoundColumn>
					<asp:BoundColumn DataField="descrizione" HeaderText="Descrizione"></asp:BoundColumn>
					<asp:BoundColumn DataField="datadoc" HeaderText="Data documento" DataFormatString="{0:d}"></asp:BoundColumn>
					<asp:HyperLinkColumn Text="Scarica" DataNavigateUrlField="percorso" HeaderText="Link"></asp:HyperLinkColumn>
				</Columns>
				<PagerStyle NextPageText="Succ." Font-Size="XX-Small" Font-Names="Verdana" Font-Italic="True"
					PrevPageText="Prec." HorizontalAlign="Left" ForeColor="#000066" BackColor="White"></PagerStyle>
			</asp:datagrid><asp:label id="Label1" style="Z-INDEX: 109; LEFT: 16px; POSITION: absolute; TOP: 144px; TEXT-ALIGN: left"
				runat="server" Font-Names="Verdana" Width="248px" Height="8px" Font-Size="XX-Small" Font-Bold="True">Ricerca documentazione</asp:label><asp:label id="lblFlusso" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 216px; TEXT-ALIGN: right"
				runat="server" Font-Names="Verdana" Width="248px" Height="8px" Font-Size="XX-Small" Visible="False">(Passo 1 di 3) Inserire flusso informativo:</asp:label><asp:label id="lflusso" style="Z-INDEX: 102; LEFT: 272px; POSITION: absolute; TOP: 216px; TEXT-ALIGN: left"
				runat="server" Font-Names="Verdana" Width="402px" Height="8px" Font-Size="XX-Small" Font-Bold="True" Visible="False"></asp:label><asp:linkbutton id="linkFlussosucc" style="Z-INDEX: 103; LEFT: 280px; POSITION: absolute; TOP: 248px"
				tabIndex="2" runat="server" Font-Names="Verdana" Width="136px" Height="16px" Font-Size="XX-Small" Visible="False">Vai al passo successivo</asp:linkbutton><asp:label id="lblperiodo" style="Z-INDEX: 100; LEFT: 16px; POSITION: absolute; TOP: 272px; TEXT-ALIGN: right"
				runat="server" Font-Names="Verdana" Width="248px" Height="8px" Font-Size="XX-Small" Visible="False">(Passo 2 di 3) Inserire tipo di documento:</asp:label><asp:dropdownlist id="Periodo" style="Z-INDEX: 107; LEFT: 272px; POSITION: absolute; TOP: 272px" tabIndex="3"
				runat="server" Font-Names="Verdana" Width="408px" Height="24px" Font-Size="XX-Small" Visible="False"></asp:dropdownlist><asp:linkbutton id="linkperiodoprec" style="Z-INDEX: 104; LEFT: 128px; POSITION: absolute; TOP: 304px"
				tabIndex="4" runat="server" Font-Names="Verdana" Width="136px" Height="16px" Font-Size="XX-Small" Visible="False">Vai al passo precedente</asp:linkbutton><asp:linkbutton id="linkperiodosucc" style="Z-INDEX: 105; LEFT: 280px; POSITION: absolute; TOP: 304px"
				tabIndex="5" runat="server" Font-Names="Verdana" Width="288px" Height="16px" Font-Size="XX-Small" Visible="False">(Passo 3 di 3) Visualizza documentazione</asp:linkbutton><asp:label class="ErrorText" id="Message" style="Z-INDEX: 108; LEFT: 16px; POSITION: absolute; TOP: 336px"
				runat="server" ForeColor="Red" Font-Names="Verdana" Width="290px" Height="18px" Font-Size="X-Small" Font-Bold="True" Font-Italic="True"></asp:label><uc1:uclinks id="UClinks1" runat="server"></uc1:uclinks></form>
	</body>
</HTML>
