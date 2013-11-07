Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace arsflussi

    Partial Class LogoutFE
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            Dim cohesionSSO As New Cohesion.SSO.CohesionSSO(Request, Response, Session)
            cohesionSSO.LogoutFE()
        End Sub

    End Class

End Namespace