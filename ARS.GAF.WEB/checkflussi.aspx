<%@ Register TagPrefix="uc1" TagName="UClinks" Src="UClinks.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Inherits="arsflussi.checkflussi" CodeFile="checkflussi.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>checkflussi</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<FORM id="Form1" method="post" runat="server">
			<asp:label id="MyError" style="Z-INDEX: 133; LEFT: 16px; POSITION: absolute; TOP: 120px" runat="Server"
				CssClass="ErrorText" EnableViewState="false" BorderStyle="None" ForeColor="Red" Font-Names="Verdana"
				Width="656px" Height="16px" Font-Size="XX-Small"></asp:label>
			<asp:label id="Label1" style="Z-INDEX: 134; LEFT: 16px; POSITION: absolute; TOP: 144px; TEXT-ALIGN: left"
				runat="server" Font-Names="Verdana" Width="464px" Height="8px" Font-Size="XX-Small" Font-Bold="True">Visualizzazione dati caricati nel DB regionale per flusso e periodo</asp:label>
			<asp:label class="ErrorText" id="Message" style="Z-INDEX: 117; LEFT: 8px; POSITION: absolute; TOP: 336px"
				runat="server" ForeColor="Red" Font-Names="Verdana" Width="290px" Height="18px" Font-Size="X-Small"
				Font-Bold="True" Font-Italic="True"></asp:label>
			<asp:datagrid id="Listatt" style="Z-INDEX: 116; LEFT: 8px; POSITION: absolute; TOP: 360px" tabIndex="9"
				runat="server" BorderStyle="None" Font-Names="Verdana" Width="664px" Font-Size="X-Small" AllowSorting="True"
				AutoGenerateColumns="False" AllowPaging="True" BorderColor="#CCCCCC" BorderWidth="1px" BackColor="White"
				CellPadding="3" PageSize="20">
				<FooterStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Italic="True" ForeColor="#000066"
					BackColor="White"></FooterStyle>
				<SelectedItemStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Italic="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
				<EditItemStyle Font-Size="XX-Small" Font-Names="Verdana"></EditItemStyle>
				<AlternatingItemStyle Font-Size="XX-Small" Font-Names="Verdana"></AlternatingItemStyle>
				<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Italic="True" Height="10px" ForeColor="#000066"></ItemStyle>
				<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Italic="True" Font-Bold="True" Height="30px"
					ForeColor="White" BackColor="#006699"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="azienda" HeaderText="Erogatore"></asp:BoundColumn>
					<asp:BoundColumn DataField="mese" HeaderText="Mese"></asp:BoundColumn>
					<asp:BoundColumn DataField="record" HeaderText="N. record"></asp:BoundColumn>
				</Columns>
				<PagerStyle NextPageText="Succ." Height="20px" Font-Size="XX-Small" Font-Names="Verdana" Font-Italic="True"
					PrevPageText="Prec." HorizontalAlign="Left" ForeColor="#000066" BackColor="White"></PagerStyle>
			</asp:datagrid>
			<asp:dropdownlist id="Periodo" style="Z-INDEX: 115; LEFT: 272px; POSITION: absolute; TOP: 272px" tabIndex="6"
				runat="server" Font-Names="Verdana" Width="408px" Height="24px" Font-Size="XX-Small" Visible="False"></asp:dropdownlist>
			<asp:dropdownlist id="Flusso" style="Z-INDEX: 102; LEFT: 272px; POSITION: absolute; TOP: 216px" tabIndex="3"
				runat="server" Font-Names="Verdana" Width="408px" Height="24px" Font-Size="XX-Small" AutoPostBack="True"></asp:dropdownlist>
			<asp:label id="lblFlusso" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 216px; TEXT-ALIGN: right"
				runat="server" Font-Names="Verdana" Width="248px" Height="8px" Font-Size="XX-Small">(Passo 1 di 3) Inserire flusso informativo:</asp:label>
			<asp:label id="lflusso" style="Z-INDEX: 107; LEFT: 272px; POSITION: absolute; TOP: 216px; TEXT-ALIGN: left"
				runat="server" Font-Names="Verdana" Width="402px" Height="8px" Font-Size="XX-Small" Font-Bold="True"></asp:label>
			<asp:linkbutton id="linkFlussosucc" style="Z-INDEX: 109; LEFT: 280px; POSITION: absolute; TOP: 248px"
				tabIndex="5" runat="server" Font-Names="Verdana" Width="136px" Height="16px" Font-Size="XX-Small">Vai al passo successivo</asp:linkbutton>
			<asp:label id="lblperiodo" style="Z-INDEX: 100; LEFT: 16px; POSITION: absolute; TOP: 272px; TEXT-ALIGN: right"
				runat="server" Font-Names="Verdana" Width="248px" Height="8px" Font-Size="XX-Small" Visible="False">(Passo 2 di 3) Inserire periodo di riferimento:</asp:label>
			<asp:label id="lperiodo" style="Z-INDEX: 111; LEFT: 272px; POSITION: absolute; TOP: 272px; TEXT-ALIGN: left"
				runat="server" Font-Names="Verdana" Width="402px" Height="8px" Font-Size="XX-Small" Font-Bold="True"
				Visible="False"></asp:label>
			<asp:linkbutton id="linkperiodoprec" style="Z-INDEX: 112; LEFT: 128px; POSITION: absolute; TOP: 304px"
				tabIndex="7" runat="server" Font-Names="Verdana" Width="136px" Height="16px" Font-Size="XX-Small"
				Visible="False">Vai al passo precedente</asp:linkbutton>
			<asp:linkbutton id="linkperiodosucc" style="Z-INDEX: 113; LEFT: 280px; POSITION: absolute; TOP: 304px"
				tabIndex="8" runat="server" Font-Names="Verdana" Width="192px" Height="16px" Font-Size="XX-Small"
				Visible="False">(Passo 3 di 3) Visualizza attività</asp:linkbutton>
			<uc1:UClinks id="UClinks1" runat="server"></uc1:UClinks>
            <asp:HiddenField ID="hdUserID" runat="server" Value="0" />
        </FORM>
	</body>
</HTML>
