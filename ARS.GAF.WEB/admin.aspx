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
                <asp:GridView ID="gridUtenti" runat="server" DataSourceID="UsersDS" 
                    EnableModelValidation="True" AutoGenerateColumns="false" DataKeyNames="ID">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:ImageButton ID="addUser" runat="server" ImageUrl="~/images/add.png" CommandName="AggiungiUtente" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="editUser" runat="server" ImageUrl="~/images/Detail.png" CommandName="ModificaUtente" />
                                <asp:ImageButton ID="delUser" runat="server" ImageUrl="~/images/delete.png" CommandName="EliminaUtente" OnClientClick="return confirm('Sei sicuro di voler eliminare l utente selezionato?');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CodiceFiscale" HeaderText="C.F." />
                        <asp:BoundField DataField="Nome" HeaderText="Nome" />
                        <asp:BoundField DataField="Cognome" HeaderText="Cognome" />
                        <asp:BoundField DataField="Ruolo" HeaderText="Ruolo" />
                        
                    </Columns>
                </asp:GridView>

                <asp:DetailsView ID="DetailsView" runat="server" Height="50px" Width="125px" 
                    DataSourceID="UserDS" EnableModelValidation="True" 
                    Visible="false" AutoGenerateRows="false" DataKeyNames="ID"
                    >
                    <Fields>
                        <asp:TemplateField HeaderText="Nome">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNome" runat="server" Text='<%# Bind("Nome") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqNome" runat="server" ControlToValidate="txtNome" ErrorMessage="Campo nome obbligatorio"  Display="Dynamic" >*</asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Cognome" HeaderText="Cognome"/>
                        <asp:TemplateField HeaderText="Ruolo">
                            <ItemTemplate>

                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlRoles" runat="server" DataSourceID="RolesDS" DataTextField="Descrizione" DataValueField="ID">
                                    </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="True" 
                                    CommandName="Update" Text="Salva"></asp:LinkButton>
                                <asp:LinkButton ID="btnInsert" runat="server" CausesValidation="True" 
                                    CommandName="Insert" Text="Salva"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Fields>
                </asp:DetailsView>

                <asp:SqlDataSource ID="UsersDS" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:CS %>" 
                    SelectCommand="SELECT U.[ID], U.[CodiceFiscale], U.[Nome], U.[Cognome], R.[Descrizione] as Ruolo FROM [Utenti] U JOIN [Ruoli] R on U.CodiceRuolo = R.ID "
                    ></asp:SqlDataSource>
                <asp:SqlDataSource ID="UserDS" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:CS %>" 
                    SelectCommand="SELECT U.[ID], U.[CodiceFiscale], U.[Nome], U.[Cognome],R.[ID] as CodiceRuolo, R.[Descrizione] as Ruolo FROM [Utenti] U JOIN [Ruoli] R on U.CodiceRuolo = R.ID WHERE U.[ID] = @ID"
                    UpdateCommand="UPDATE Utenti SET Nome=@NOME,Cognome=@Cognome,CodiceRuolo=@Ruolo WHERE ID=@ID"
                    InsertCommand="INSERT INTO UTENTI (CodiceFiscale,CodiceRuolo,Nome,Cognome,Email,Fax,Numero,PercorsoUtente) VALUES(@CodiceFiscale,@CodiceRuolo,@Nome,@Cognome,@Email,@Fax,@Numero,@PercorsoUtente)"
                    >
                    <SelectParameters>
                        <asp:ControlParameter ControlID="gridUtenti" Name="ID" PropertyName="SelectedValue" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:ControlParameter ControlID="DetailsView$ddlRoles" Name="Ruolo" PropertyName="SelectedValue" />
                        <asp:Parameter Name="ID" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:ControlParameter ControlID="DetailsView$ddlRoles" Name="Ruolo" PropertyName="SelectedValue" />
                    </InsertParameters>
                    </asp:SqlDataSource>
                <asp:SqlDataSource ID="RolesDS" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:CS %>" 
                    SelectCommand="SELECT [ID], [Descrizione] FROM [Ruoli]"
                    ></asp:SqlDataSource>
            </div>
        </form>
    </body>
</html>