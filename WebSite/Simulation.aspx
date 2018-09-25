<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Simulation.aspx.cs" Inherits="Simulation" %>

<%@ Register src="Control/S_CountPath.ascx" tagname="S_CountPath" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label_building" runat="server" Text="Label"></asp:Label>
        <br />
           <uc1:S_CountPath ID="S_CountPath1" runat="server" />
    </form>
</body>
</html>
