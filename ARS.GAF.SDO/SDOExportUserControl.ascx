<%@ Control Language="vb" AutoEventWireup="True" CodeBehind="SDOExportUserControl.ascx.vb" Inherits="ARS.GAF.SDO.SDOExportUserControl" %>
<script type="text/javascript">
    $(document).ready(function () {
        $(".date").datepicker();
    });
</script>

<asp:Panel ID="pnlExport" runat="server">
<table>
<tr>
    <td>
        <asp:Label ID="lblDateStart" runat="server" Text="Data Inizio Estrazione"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtDateStart" runat="server" CssClass="date"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqDateStart" runat="server" ControlToValidate="txtDateStart" EnableClientScript="true">*</asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
    <td>
        <asp:Label ID="lblDateEnd" runat="server" Text="Data Fine Estrazione"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtDateEnd" runat="server" CssClass="date"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqDateEnd" runat="server" ControlToValidate="txtDateEnd" EnableClientScript="true">*</asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
    <td colspan="2">
        <asp:Button ID="btnExport" runat="server" Text="Estrai dati" CausesValidation="true"  style="float:right;margin-right:20px;" />
    </td>
</tr>
</table>
</asp:Panel>

<asp:Panel ID="pnlResult" runat="server" Visible="false">
    <asp:Label ID="lblResult" runat="server"></asp:Label>
</asp:Panel>