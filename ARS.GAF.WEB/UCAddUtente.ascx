<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UCAddUtente.ascx.vb" Inherits="arsflussi.AggiungiUtente" %>

<asp:HiddenField ID="hdnUserID" Value="" runat="server"/>

<asp:Label ID="lblNome" runat="server" Text="Nome:" Width="150px" Font-Size="Medium" ></asp:Label>
<asp:TextBox ID="txtNome" runat="server" Width="200px"></asp:TextBox><br />
<asp:Label ID="lblCognome" runat="server" Text="Cognome:" Width="150px" Font-Size="Medium" ></asp:Label>
<asp:TextBox ID="txtCognome" runat="server" Width="200px"></asp:TextBox><br />
<asp:Label ID="lblCF" runat="server" Text="Codice Fiscale:" Width="150px" Font-Size="Medium" ></asp:Label>
<asp:TextBox ID="txtCF" runat="server" Width="200px"></asp:TextBox><br />
<asp:Label ID="lblEmail" runat="server" Text="Email:" Width="150px" Font-Size="Medium" ></asp:Label>
<asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox><br />
<asp:Label ID="lblFax" runat="server" Text="Numero Fax:" Width="150px" Font-Size="Medium" ></asp:Label>
<asp:TextBox ID="txtFax" runat="server" Width="200px"></asp:TextBox><br />
<asp:Label ID="lblNumero" runat="server" Text="Numero:" Width="150px" Font-Size="Medium" ></asp:Label>
<asp:TextBox ID="txtNumero" runat="server" Width="200px"></asp:TextBox><br />
<asp:Label ID="lblCartella" runat="server" Text="Cartella:" Width="150px" Font-Size="Medium" ></asp:Label>
<asp:TextBox ID="txtCartella" runat="server" Width="200px"></asp:TextBox><br />
<asp:Label ID="lblCartellaFTP" runat="server" Text="Cartella FTP:" Width="150px" Font-Size="Medium" ></asp:Label>
<asp:TextBox ID="txtCartellaFTP" runat="server" Width="200px"></asp:TextBox><br />
<asp:Label ID="lblPercorsoUtente" runat="server" Text="Percorso Utente:" Width="150px" Font-Size="Medium" ></asp:Label>
<asp:TextBox ID="txtPercorsoUtente" runat="server" Width="200px"></asp:TextBox><br />

<asp:Label ID="lblRuolo" runat="server" Text="Ruolo:" Width="150px" Font-Size="Medium"></asp:Label>
<asp:DropDownList ID="ddlRuolo" runat="server" Width="200px" /><br />
<asp:Label ID="lblAttivo" runat="server" Text="Attivo:" Width="150px" Font-Size="Medium" ></asp:Label>
<asp:CheckBox ID="chkAttivo" runat="server" Text="Attivo" Checked="false" Width="100px" />
<asp:Button ID="btnSalva" Text="SALVA" runat="server" Width="100px" />

<p>
    <asp:Label ID="lblResult" runat="server" style="Z-INDEX: 112; LEFT: 14px; POSITION: absolute; TOP: 359px"
        CssClass="ErrorText" EnableViewState="false" BorderStyle="None" ForeColor="Red"
        Font-Names="Verdana" Width="656px" Height="16px" Font-Size="X-Large"></asp:Label>
</p>