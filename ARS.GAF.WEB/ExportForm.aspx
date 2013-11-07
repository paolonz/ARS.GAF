<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ExportForm.aspx.vb" Inherits="ExportForm" %>
<%@ Register TagPrefix="uc1" TagName="UClinks" Src="UClinks.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Export Firn</title>
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <script src="scripts/jquery-1.9.1.js" type="text/javascript"></script>
        <script src="scripts/jquery-ui.min.js" type="text/javascript"></script>
        <script src="scripts/jquery.ui.datepicker-it.js" type="text/javascript"></script>
        <link href="theme/jquery-ui.css" rel="stylesheet" type="text/css" />
	</HEAD>
	<body>
		<FORM id="Form1" method="post" runat="server">
			<uc1:UClinks id="UClinks1" runat="server"></uc1:UClinks>
            <h2>Esportazione tracciati</h2>

            <h3>1. Seleziona il tracciato</h3>
            <asp:DropDownList ID="ddl_flusso" runat="server" AutoPostBack="true"></asp:DropDownList>

            <asp:Panel ID="panelUC" runat="server">
            <asp:Label ID="lbl" runat="server" Text="NADA"></asp:Label>
            </asp:Panel>

        </FORM>
	</body>
</HTML>
