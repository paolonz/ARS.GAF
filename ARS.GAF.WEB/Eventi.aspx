<%@ Page Language="vb" AutoEventWireup="false" Inherits="arsflussi.Eventi1" CodeFile="Eventi.aspx.vb" %>
<%@ Register TagPrefix="uc1" TagName="UClinks" Src="UClinks.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Eventi</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:label id="MyError" style="Z-INDEX: 110; LEFT: 16px; POSITION: absolute; TOP: 120px" runat="Server"
				Font-Size="XX-Small" Height="16px" Width="656px" Font-Names="Verdana" ForeColor="Red" BorderStyle="None"
				EnableViewState="false" CssClass="ErrorText"></asp:label>
			<asp:datagrid id="detailDataGrid" style="Z-INDEX: 113; LEFT: 16px; POSITION: absolute; TOP: 360px"
				tabIndex="6" runat="server" Height="50px" Width="752px" Font-Names="Verdana" BorderStyle="None"
				AllowSorting="True" AllowPaging="True" BorderWidth="1px" BorderColor="#CCCCCC" BackColor="White"
				AutoGenerateColumns="False" CellPadding="3">
				<FooterStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Italic="True" ForeColor="#000066"
					BackColor="White"></FooterStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
				<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Italic="True" ForeColor="#000066"></ItemStyle>
				<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Italic="True" Font-Bold="True" Height="10px"
					ForeColor="White" BackColor="#006699"></HeaderStyle>
				<PagerStyle NextPageText="Succ." Font-Size="XX-Small" Font-Names="Verdana" Font-Italic="True"
					PrevPageText="Prec." HorizontalAlign="Left" ForeColor="#000066" BackColor="White"></PagerStyle>
			</asp:datagrid>
			<asp:dropdownlist id="Periodo" style="Z-INDEX: 112; LEFT: 272px; POSITION: absolute; TOP: 272px" tabIndex="3"
				runat="server" Font-Size="XX-Small" Height="24px" Width="408px" Font-Names="Verdana" Visible="False"></asp:dropdownlist>
			<asp:label id="lflusso" style="Z-INDEX: 111; LEFT: 272px; POSITION: absolute; TOP: 216px; TEXT-ALIGN: left"
				runat="server" Font-Size="XX-Small" Height="8px" Width="402px" Font-Names="Verdana" Font-Bold="True"
				Visible="False"></asp:label>
			<asp:label id="Label1" style="Z-INDEX: 107; LEFT: 16px; POSITION: absolute; TOP: 144px; TEXT-ALIGN: left"
				runat="server" Font-Size="XX-Small" Height="8px" Width="248px" Font-Names="Verdana" Font-Bold="True">Ricerca eventi</asp:label>
			<asp:label id="lblFlusso" style="Z-INDEX: 102; LEFT: 16px; POSITION: absolute; TOP: 216px; TEXT-ALIGN: right"
				runat="server" Font-Size="XX-Small" Height="8px" Width="248px" Font-Names="Verdana" Visible="False">(Passo 1 di 3) Inserire flusso informativo:</asp:label>
			<asp:dropdownlist id="Flusso" style="Z-INDEX: 108; LEFT: 272px; POSITION: absolute; TOP: 216px" tabIndex="1"
				runat="server" Font-Size="XX-Small" Height="24px" Width="408px" Font-Names="Verdana" Visible="False"
				AutoPostBack="True"></asp:dropdownlist>
			<asp:linkbutton id="linkFlussosucc" style="Z-INDEX: 103; LEFT: 280px; POSITION: absolute; TOP: 248px"
				tabIndex="2" runat="server" Font-Size="XX-Small" Height="16px" Width="136px" Font-Names="Verdana"
				Visible="False">Vai al passo successivo</asp:linkbutton>
			<asp:label id="lblperiodo" style="Z-INDEX: 100; LEFT: 16px; POSITION: absolute; TOP: 272px; TEXT-ALIGN: right"
				runat="server" Font-Size="XX-Small" Height="8px" Width="248px" Font-Names="Verdana" Visible="False">(Passo 2 di 3)  Inserire periodo di riferimento:</asp:label>
			<asp:label id="lperiodo" style="Z-INDEX: 109; LEFT: 272px; POSITION: absolute; TOP: 272px; TEXT-ALIGN: left"
				runat="server" Font-Size="XX-Small" Height="8px" Width="402px" Font-Names="Verdana" Font-Bold="True"
				Visible="False"></asp:label>
			<asp:linkbutton id="linkperiodoprec" style="Z-INDEX: 104; LEFT: 128px; POSITION: absolute; TOP: 304px"
				tabIndex="4" runat="server" Font-Size="XX-Small" Height="16px" Width="136px" Font-Names="Verdana"
				Visible="False">Vai al passo precedente</asp:linkbutton>
			<asp:linkbutton id="linkperiodosucc" style="Z-INDEX: 105; LEFT: 280px; POSITION: absolute; TOP: 304px"
				tabIndex="5" runat="server" Font-Size="XX-Small" Height="16px" Width="288px" Font-Names="Verdana"
				Visible="False">(Passo 3 di 3) Visualizza eventi</asp:linkbutton>
			<asp:label class="ErrorText" id="Message" style="Z-INDEX: 106; LEFT: 24px; POSITION: absolute; TOP: 336px"
				runat="server" Font-Size="X-Small" Height="18px" Width="290px" Font-Names="Verdana" ForeColor="Red"
				Font-Bold="True" Font-Italic="True"></asp:label>
			<uc1:UClinks id="UClinks1" runat="server"></uc1:UClinks>
            <asp:HiddenField ID="hdUserID" runat="server" Value="0" />
        </form>
	</body>
</HTML>
