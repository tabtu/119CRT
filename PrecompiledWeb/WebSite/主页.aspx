<%@ page title="" language="C#" masterpagefile="~/Master.master" autoeventwireup="true" inherits="主页, App_Web_i3xfczi0" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">

    </style>

<link rel="stylesheet" type="text/css" href="Styles/Mastermanu.css" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
    <table  class="contenttable">
        <tr class="listtitle2">
            <td>
                小区显示
            </td>
        </tr>
<tr class="listcontent">
    <td style="text-align:center">
        <div style="margin-left:190px">
    <asp:Literal ID="Literal_map" runat="server"></asp:Literal>
        <br />
        <asp:Label ID="Label_notic" runat="server" ForeColor="Red" Text="" CssClass="label"></asp:Label>
            </div>
    </td>
</tr>
    </table>

</asp:Content>

