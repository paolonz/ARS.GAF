<%@ Page Language="vb" AutoEventWireup="false" Inherits="arsflussi.Contatti" CodeFile="Contatti.aspx.vb" %>
<%@ Register TagPrefix="uc1" TagName="UClinks" Src="UClinks.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Contatti</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:label class="ErrorText" id="Message" style="Z-INDEX: 107; LEFT: 8px; POSITION: absolute; TOP: 342px"
				runat="server" Height="18px" Width="290px" Font-Names="Verdana" ForeColor="Red" Font-Italic="True"
				Font-Size="X-Small" Font-Bold="True"></asp:label><uc1:uclinks id="UClinks1" runat="server"></uc1:uclinks><BR>
			<asp:datagrid id=masterDataGrid style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 144px" runat="server" DataKeyField="progrgestore" PageSize="5" AutoGenerateColumns="False" Height="174px" Width="752px" DataMember="T_Gestori" CellPadding="3" DataSource="<%# objGestoriFlussi %>" BackColor="White" Font-Names="Verdana" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" GridLines="None" AllowPaging="True">
				<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
				<SelectedItemStyle Font-Size="X-Small" Font-Names="Verdana" Font-Italic="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
				<ItemStyle Font-Size="X-Small" Font-Names="Verdana" Font-Italic="True" ForeColor="#000066"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Names="Verdana" Font-Italic="True" Font-Bold="True" Height="10px"
					ForeColor="White" BackColor="#006699"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="gestore" HeaderText="Referente ARS"></asp:BoundColumn>
					<asp:BoundColumn DataField="telefono" HeaderText="Telefono"></asp:BoundColumn>
					<asp:BoundColumn DataField="fax" HeaderText="Fax"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Indirizzo posta elettronica">
						<ItemTemplate>
							<asp:HyperLink id=HyperLink1 runat="server" NavigateUrl='<%#DataBinder.Eval(Container, "DataItem.email", "MailTo:{0}") %>' Target="_blank">
								<%# DataBinder.Eval(Container, "DataItem.email")%>
							</asp:HyperLink>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:ButtonColumn Text="Flussi di competenza" CommandName="Select"></asp:ButtonColumn>
				</Columns>
				<PagerStyle NextPageText="Succ." Font-Size="XX-Small" Font-Names="Verdana" Font-Italic="True"
					PrevPageText="Prec." HorizontalAlign="Left" ForeColor="#000066" BackColor="White"></PagerStyle>
			</asp:datagrid><asp:datagrid id="detailDataGrid" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 360px"
				runat="server" DataKeyField="flusso" PageSize="5" AutoGenerateColumns="False" Height="50px" Width="752px"
				DataMember="V_GestoriFlussi" CellPadding="3" BackColor="White" Font-Names="Verdana" BorderColor="#CCCCCC"
				BorderStyle="None" BorderWidth="1px" GridLines="None">
				<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
				<ItemStyle Font-Size="X-Small" Font-Names="Verdana" Font-Italic="True" ForeColor="#000066"></ItemStyle>
				<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Italic="True" Font-Bold="True" Height="10px"
					ForeColor="White" BackColor="#006699"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="flusso" HeaderText="Flussi di competenza"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
			</asp:datagrid></form>
	</body>
</HTML>
