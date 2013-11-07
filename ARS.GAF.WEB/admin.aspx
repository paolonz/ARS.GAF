<%@ Register TagPrefix="uc1" TagName="UClinks" Src="UClinks.ascx"  %>
<%@ Reference Control="UCAddUtente.ascx" %>
<%@ Page Language="VB" AutoEventWireup="false" CodeFile="admin.aspx.vb" Inherits="arsflussi.admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <uc1:UClinks ID="UClinks1" runat="server" />
            <asp:Label ID="lblMessage" style="Z-INDEX: 112; LEFT: 16px; POSITION: absolute; TOP: 120px"
                        runat="Server" CssClass="ErrorText" EnableViewState="false" BorderStyle="None"
                        ForeColor="Red" Font-Names="Verdana" Width="656px" Height="16px"
                        Font-Size="XX-Small" Visible="false"></asp:Label>
            <div>
                <asp:DropDownList ID="ddlSelectOption" runat="server">
                    <asp:ListItem Text="Aggiungi nuovo Utente" Value="1" />
                    <asp:ListItem Text="Edit" Value="2" />
                </asp:DropDownList><br />
                <p>
                    <asp:PlaceHolder ID="phContent" runat="server" />
                </p>
            </div>
        </form>
    </body>
</html>