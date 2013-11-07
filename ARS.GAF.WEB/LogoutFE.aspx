<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LogoutFE.aspx.vb" Inherits="arsflussi.LogoutFE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <script type="text/javascript" language="javascript">
        document.execCommand("ClearAuthenticationCache");
        window.location = "./default.aspx"
    </script>
    <button type="button" id="home" onclick="self.location = './default.aspx';">Home</button>
</body>
</html>
