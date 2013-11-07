<%@ Page Language="vb" AutoEventWireup="false" Inherits="arsflussi.sactivity" CodeFile="sactivity.aspx.vb" %>
<%@ Register TagPrefix="uc1" TagName="UClinks" Src="UClinks.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Ricerca attività</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:label id="MyError" style="Z-INDEX: 114; LEFT: 16px; POSITION: absolute; TOP: 120px" runat="Server"
				CssClass="ErrorText" EnableViewState="false" BorderStyle="None" ForeColor="Red" Font-Names="Verdana"
				Width="656px" Height="16px" Font-Size="XX-Small"></asp:label>
			<asp:label id="Label1" style="Z-INDEX: 132; LEFT: 16px; POSITION: absolute; TOP: 144px; TEXT-ALIGN: left"
				runat="server" Font-Size="XX-Small" Height="8px" Width="248px" Font-Names="Verdana" Font-Bold="True">Ricerca attività</asp:label>
            <asp:label class="ErrorText" id="Message" style="Z-INDEX: 117; LEFT: 8px; POSITION: absolute; TOP: 289px"
				runat="server" ForeColor="Red" Font-Names="Verdana" Width="290px" Height="18px" 
                Font-Size="X-Small" Font-Bold="True" Font-Italic="True"></asp:label>
            <asp:datagrid id="Listatt" 
                style="Z-INDEX: 116; LEFT: 8px; POSITION: absolute; TOP: 320px" tabIndex="9"
				runat="server" BorderStyle="None" Font-Names="Verdana" Width="664px" 
                Font-Size="X-Small" AllowSorting="True" AutoGenerateColumns="False" 
                AllowPaging="True" BorderColor="#CCCCCC" BorderWidth="1px" BackColor="White" 
                CellPadding="3">
				<FooterStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Italic="True" ForeColor="#000066"
					BackColor="White"></FooterStyle>
				<SelectedItemStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Italic="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
				<EditItemStyle Font-Size="XX-Small" Font-Names="Verdana"></EditItemStyle>
				<AlternatingItemStyle Font-Size="XX-Small" Font-Names="Verdana"></AlternatingItemStyle>
				<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" Font-Italic="True" Height="10px" ForeColor="#000066"></ItemStyle>
				<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Italic="True" Font-Bold="True" Height="30px"
					ForeColor="White" BackColor="#006699"></HeaderStyle>
				<Columns>
					<asp:TemplateColumn HeaderText="N.">
						<HeaderStyle Font-Size="XX-Small" Font-Names="Tahoma"></HeaderStyle>
						<ItemStyle Font-Size="XX-Small"></ItemStyle>
						<ItemTemplate>
							<asp:Label id=lcodiceattivita runat="server" Font-Names="Verdana" Width="72px" Font-Size="XX-Small" Text='<%# DataBinder.Eval(Container.DataItem, "codiceattivita") %>' Font-Italic="True">
							</asp:Label>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="progrflusso" HeaderText="progrflusso"></asp:BoundColumn>
					<asp:BoundColumn DataField="flusso" HeaderText="Flusso"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="progrperiodo" HeaderText="progrperiodo"></asp:BoundColumn>
					<asp:BoundColumn DataField="periodo" HeaderText="Periodo"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="controllo" HeaderText="codcontrollo"></asp:BoundColumn>
					<asp:BoundColumn DataField="data" HeaderText="Data inserimento"></asp:BoundColumn>
					<asp:BoundColumn DataField="controllofile" HeaderText="Controllo"></asp:BoundColumn>
					<asp:ButtonColumn Text="Seleziona" CommandName="Select"></asp:ButtonColumn>
				</Columns>
				<PagerStyle NextPageText="Succ." Height="20px" Font-Size="XX-Small" Font-Names="Verdana" Font-Italic="True"
					PrevPageText="Prec." HorizontalAlign="Left" ForeColor="#000066" BackColor="White"></PagerStyle>
			</asp:datagrid><asp:dropdownlist id="Periodo" 
                style="Z-INDEX: 115; LEFT: 272px; POSITION: absolute; TOP: 231px" tabIndex="6"
				runat="server" Font-Names="Verdana" Width="408px" Height="24px" Font-Size="XX-Small" 
                Visible="False"></asp:dropdownlist><asp:dropdownlist id="Flusso" 
                style="Z-INDEX: 102; LEFT: 272px; POSITION: absolute; TOP: 168px" tabIndex="3"
				runat="server" Font-Names="Verdana" Width="408px" Height="24px" Font-Size="XX-Small" 
                Visible="False" AutoPostBack="True"></asp:dropdownlist>
            <asp:label id="lblFlusso" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 171px; TEXT-ALIGN: right"
				runat="server" Font-Names="Verdana" Width="248px" Height="8px" Font-Size="XX-Small" 
                Visible="False">(Passo 1 di 3) Inserire flusso informativo:</asp:label>
            <asp:label id="lflusso" style="Z-INDEX: 107; LEFT: 272px; POSITION: absolute; TOP: 171px; TEXT-ALIGN: left"
				runat="server" Font-Names="Verdana" Width="402px" Height="8px" Font-Size="XX-Small" 
                Font-Bold="True" Visible="False"></asp:label>
            <asp:linkbutton id="linkFlussosucc" style="Z-INDEX: 109; LEFT: 280px; POSITION: absolute; TOP: 195px"
				tabIndex="5" runat="server" Font-Names="Verdana" Width="136px" Height="16px" 
                Font-Size="XX-Small" Visible="False">Vai al passo successivo</asp:linkbutton>
            <asp:label id="lblperiodo" style="Z-INDEX: 100; LEFT: 16px; POSITION: absolute; TOP: 224px; TEXT-ALIGN: right"
				runat="server" Font-Names="Verdana" Width="248px" Height="8px" Font-Size="XX-Small" 
                Visible="False">(Passo 2 di 3) Inserire periodo di riferimento:</asp:label>
            <asp:label id="lperiodo" style="Z-INDEX: 111; LEFT: 272px; POSITION: absolute; TOP: 233px; TEXT-ALIGN: left"
				runat="server" Font-Names="Verdana" Width="402px" Height="8px" Font-Size="XX-Small" 
                Font-Bold="True" Visible="False"></asp:label>
            <asp:linkbutton id="linkperiodoprec" style="Z-INDEX: 112; LEFT: 128px; POSITION: absolute; TOP: 259px"
				tabIndex="7" runat="server" Font-Names="Verdana" Width="136px" Height="16px" 
                Font-Size="XX-Small" Visible="False">Vai al passo precedente</asp:linkbutton>
            <asp:linkbutton id="linkperiodosucc" style="Z-INDEX: 113; LEFT: 280px; POSITION: absolute; TOP: 260px"
				tabIndex="8" runat="server" Font-Names="Verdana" Width="192px" Height="16px" 
                Font-Size="XX-Small" Visible="False">(Passo 3 di 3) Visualizza attività</asp:linkbutton>
			<uc1:UClinks id="UClinks1" runat="server"></uc1:UClinks>
            <asp:HiddenField ID="hdUserID" runat="server" Value="0" />
        </form>
	</body>
</HTML>
