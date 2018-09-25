<%@ page title="" language="C#" masterpagefile="~/Master.master" autoeventwireup="true" inherits="密码修改, App_Web_jz3qqgas" %>

<%@ Register Src="Control/U_Member.ascx" TagName="U_Member" TagPrefix="uc1" %>

<%@ Register src="Control/U_chengepassword.ascx" tagname="U_chengepassword" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" type="text/css" href="Styles/Mastermanu.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
 
    <table class="contenttable">
        <tr class="listtitle2">
            <td>密码修改</td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: center;height:550px">
               <div style="margin: 0px 90px 0px 90px">
                    <uc2:U_chengepassword ID="U_chengepassword1" runat="server" />
               </div>
            </td>
        </tr>
    </table>

</asp:Content>

