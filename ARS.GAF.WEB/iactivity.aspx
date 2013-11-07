    <%@ Page Language="vb" AutoEventWireup="false" Inherits="arsflussi.iactivity" CodeFile="iactivity.aspx.vb" %>
<%@ Register TagPrefix="uc1" TagName="UClinks" Src="UClinks.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Inserimento attività da validare</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5"  name="vs_targetSchema"/>
        <script src="Scripts/jquery-1.8.1.min.js" type="text/javascript"></script>
        <script type="text/javascript" src="Scripts/Uploadify/swfobject.js"></script>
        <script type="text/javascript" src="Scripts/Uploadify/jquery.uploadify.v2.1.4.min.js"></script>
        <link href="Scripts/Uploadify/uploadify.css" rel="stylesheet" type="text/css" />   

	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
        <asp:ScriptManager ID="scriptManager" runat="server" EnablePageMethods="true"></asp:ScriptManager>
			<asp:label id="MyError" style="Z-INDEX: 112; LEFT: 16px; POSITION: absolute; TOP: 120px" runat="Server"
				CssClass="ErrorText" EnableViewState="false" BorderStyle="None" ForeColor="Red" Font-Names="Verdana"
				Width="656px" Height="16px" Font-Size="XX-Small"></asp:label>
			<asp:label id="lblBanner" style="Z-INDEX: 133; LEFT: 24px; POSITION: absolute; TOP: 374px; TEXT-ALIGN: left"
				runat="server" Font-Size="XX-Small" Height="52px" Width="648px" Font-Names="Verdana" ForeColor="Red"
				Font-Bold="True" Visible="False">SI RICORDA CHE INSERENDO IL VALORE 'Nessuna trasmissione(solo controllo)' I DATI NON SARANNO ACQUISITI NEL DATABASE CENTRALE ED I FILE NON SARANNO SALVATI NEL SERVER. PER ACCODARE I DATI NEL DB STORICO DELL'ARS UTILIZZARE GLI ALTRI VALORI: 'Nuovo Invio', 'Accodamento ad invio precedente' E 'Aggiornamento di un invio precedente' A SECONDA DELLE ESIGENZE DELL'UTENTE</asp:label>
			<asp:label id="Label1" style="Z-INDEX: 132; LEFT: 16px; POSITION: absolute; TOP: 144px; TEXT-ALIGN: left"
				runat="server" Font-Size="XX-Small" Height="8px" Width="248px" Font-Names="Verdana" Font-Bold="True">Inserimento attività</asp:label>
                <asp:linkbutton id="linkfineprec" style="Z-INDEX: 131; LEFT: 40px; POSITION: absolute; TOP: 650px"
				tabIndex="17" runat="server" Font-Names="Verdana" Width="136px" Height="16px" Font-Size="XX-Small" Visible="False">vai al passo precedente</asp:linkbutton>
                <asp:linkbutton id="linktrasmissionesucc" style="Z-INDEX: 129; LEFT: 280px; POSITION: absolute; TOP: 450px; right: 1177px;"
				tabIndex="16" runat="server" Font-Names="Verdana" Width="136px" Height="16px" 
                Font-Size="XX-Small" Visible="False">Vai al passo successivo</asp:linkbutton>
                <asp:linkbutton id="linktrasmissioneprec" style="Z-INDEX: 128; LEFT: 128px; POSITION: absolute; TOP: 450px"
				tabIndex="15" runat="server" Font-Names="Verdana" Width="136px" Height="16px" Font-Size="XX-Small" Visible="False">Vai al passo precedente</asp:linkbutton>
                <asp:label id="ltrasmissione" style="Z-INDEX: 127; LEFT: 272px; POSITION: absolute; TOP: 340px; TEXT-ALIGN: left"
				runat="server" Font-Names="Verdana" Width="402px" Height="8px" Font-Size="XX-Small" Visible="False" Font-Bold="True"></asp:label>
                <asp:label id="lcompressione" style="Z-INDEX: 126; LEFT: 272px; POSITION: absolute; TOP: 430px; TEXT-ALIGN: left"
				runat="server" Font-Names="Verdana" Width="402px" Height="8px" Font-Size="XX-Small" Visible="False" Font-Bold="True"></asp:label>
            <asp:linkbutton id="linkperiodosucc" style="Z-INDEX: 123; LEFT: 280px; POSITION: absolute; TOP: 304px"
				tabIndex="8" runat="server" Font-Names="Verdana" Width="136px" Height="16px" Font-Size="XX-Small" Visible="False">Vai al passo successivo</asp:linkbutton><asp:linkbutton id="linkperiodoprec" style="Z-INDEX: 122; LEFT: 128px; POSITION: absolute; TOP: 304px"
				tabIndex="7" runat="server" Font-Names="Verdana" Width="136px" Height="16px" Font-Size="XX-Small" Visible="False">Vai al passo precedente</asp:linkbutton><asp:label id="lperiodo" style="Z-INDEX: 121; LEFT: 272px; POSITION: absolute; TOP: 272px; TEXT-ALIGN: left"
				runat="server" Font-Names="Verdana" Width="402px" Height="8px" Font-Size="XX-Small" Visible="False" Font-Bold="True"></asp:label><asp:linkbutton id="linkFlussosucc" style="Z-INDEX: 119; LEFT: 280px; POSITION: absolute; TOP: 248px"
				tabIndex="5" runat="server" Font-Names="Verdana" Width="136px" Height="16px" Font-Size="XX-Small" Visible="False">Vai al passo successivo</asp:linkbutton><asp:label id="lflusso" style="Z-INDEX: 118; LEFT: 272px; POSITION: absolute; TOP: 216px; TEXT-ALIGN: left"
				runat="server" Font-Names="Verdana" Width="402px" Height="8px" Font-Size="XX-Small" Visible="False" Font-Bold="True"></asp:label>
                
                <asp:HiddenField id="hdnReferente" runat="server" />
                <asp:HiddenField id="hdnFlusso" runat="server" />
                <asp:HiddenField id="hdnTrasmissione" runat="server" />
                <asp:HiddenField id="hdnPeriodo" runat="server" />
                <asp:HiddenField id="hdnUploadGuid" runat="server" />

                <asp:HiddenField ID="hdUserID" runat="server" Value="0" />

                <asp:label id="lblperiodo" style="Z-INDEX: 100; LEFT: 16px; POSITION: absolute; TOP: 272px; TEXT-ALIGN: right"
				runat="server" Font-Names="Verdana" Width="248px" Height="8px" Font-Size="XX-Small" Visible="False">(Passo 2 di 5) Inserire periodo di riferimento:</asp:label>
                <asp:dropdownlist id="Periodo" style="Z-INDEX: 107; LEFT: 272px; POSITION: absolute; TOP: 272px" tabIndex="6"
				runat="server" Font-Names="Verdana" Width="408px" Height="24px" Font-Size="XX-Small" Visible="False"></asp:dropdownlist>
                <asp:label id="lblFlusso" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 216px; TEXT-ALIGN: right"
				runat="server" Font-Names="Verdana" Width="248px" Height="8px" Font-Size="XX-Small" Visible="True">(Passo 1 di 5) Inserire flusso informativo:</asp:label>
                <asp:dropdownlist id="Flusso" style="Z-INDEX: 102; LEFT: 272px; POSITION: absolute; TOP: 216px" tabIndex="3"
				runat="server" Font-Names="Verdana" Width="408px" Height="24px" Font-Size="XX-Small" Visible="False" AutoPostBack="True"></asp:dropdownlist>

                    <asp:label id="lblUpload" style="Z-INDEX: 100; LEFT: 16px; POSITION: absolute; TOP: 400px; TEXT-ALIGN: right"
				runat="server" Font-Names="Verdana" Width="248px" Height="8px" Font-Size="XX-Small" Visible="False">(Passo 4 di 5) Upload dei File:</asp:label>

                    <asp:label id="lblChooseFile" style="Z-INDEX: 100; LEFT: 123px; POSITION: absolute; TOP: 600px; TEXT-ALIGN: right; width: 141px;"
				runat="server" Font-Names="Verdana" Height="8px" Font-Size="XX-Small" 
            Visible="False">Seleziona i files da inviare:</asp:label>

                

               
               <div id="uploadDiv"  style="Z-INDEX: 100; LEFT: 272px; POSITION: absolute; TOP: 600px;" runat="server" Visible="False">
                    
                 <!--<asp:DropDownList ID="numberOfFile" runat="server" AutoPostBack="true" >
                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                </asp:DropDownList>-->
                     
                   <asp:Repeater ID="file_upload_repeater" runat=server>
                   <HeaderTemplate>
                    <table>
                        <thead>
                        <tr>
                            <th></th>
                            <th style="text-align:right"></th>
                        </tr>
                        </thead>
                        <tbody>
                   </HeaderTemplate>
                   <ItemTemplate>
                    <tr>
                        <td colspan="2">
                            <asp:FileUpload ID="file_upload" 
                            runat="server" 
                            />
                        </td>
                        <td>
                            <asp:Label ID="descrizione" runat="server" Text='<%# Container.DataItem("nomefile")%>'/>
                        </td>
                    </tr>                        
                   </ItemTemplate>
                   <FooterTemplate>
                   </tbody>
                   <tfoot>
                    
                   </tfoot>
                   </table>
                   </FooterTemplate>
                   </asp:Repeater> 

                   

                <asp:Button ID="InsertBtn" runat="server" Text="Inserisci" BorderStyle="Groove" Font-Names="Verdana" Width="104px" Height="24px" BackColor="Transparent" BorderColor="DodgerBlue"/>
                <br />
                <asp:Label ID="ErrorInsert" runat="server" style="color:Red" />
               </div>

            <asp:label id="lblTrasmissione" style="Z-INDEX: 103; LEFT: 16px; POSITION: absolute; TOP: 340px; TEXT-ALIGN: right; right: 1329px;"
				runat="server" Font-Names="Verdana" Width="248px" Height="11px" Font-Size="XX-Small" 
                Visible="False">(Passo 3 di 5) Trasmissione ARS:</asp:label>
            <asp:dropdownlist id="Trasmissione" style="Z-INDEX: 105; LEFT: 272px; POSITION: absolute; TOP: 340px"
				tabIndex="12" runat="server" Font-Names="Verdana" Width="408px" Height="24px" Font-Size="XX-Small" Visible="False"></asp:dropdownlist>
               <asp:label id="lblCompressione" style="Z-INDEX: 109; LEFT: 16px; POSITION: absolute; TOP: 430px; TEXT-ALIGN: right"
				runat="server" Font-Names="Verdana" Width="248px" Height="11px" Font-Size="XX-Small" Visible="False">Compressione utilizzata:</asp:label>
                <asp:dropdownlist id="Compressione" style="Z-INDEX: 108; LEFT: 272px; POSITION: absolute; TOP: 430px"
				tabIndex="13" runat="server" Font-Names="Verdana" Width="408px" Height="24px" Font-Size="XX-Small" Visible="False"></asp:dropdownlist>
                
                <asp:label id="lblnote" style="Z-INDEX: 111; LEFT: 16px; POSITION: absolute; TOP: 460px; text-align:right" runat="server"
				Font-Names="Verdana" Width="248px" Height="16px" Font-Size="XX-Small" Visible="False">Note(max 254 caratteri)</asp:label>
                <asp:textbox id="txtnote" style="Z-INDEX: 110; LEFT: 16px; POSITION: absolute; TOP: 480px" tabIndex="14"
				runat="server" Font-Names="Verdana" Width="664px" Height="78px" Font-Size="XX-Small" Visible="False"></asp:textbox>
            <uc1:uclinks id="UClinks1" runat="server"></uc1:uclinks>
		<script type="text/javascript">		    if (document.getElementById('linkfineprec') != null) { document.getElementById('linkfineprec').focus(); }</script>
        </form>
		</body>
</HTML>
