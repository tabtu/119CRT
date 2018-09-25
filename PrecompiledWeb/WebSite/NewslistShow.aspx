<%@ page title="" language="C#" autoeventwireup="true" inherits="NewslistShow, App_Web_lleqnx0p" %>

<%@ Register src="Control/U_newstitlelist.ascx" tagname="U_newstitlelist" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .tablefull {
            margin: 0px 0% 0px 0%; /*外围边框上右下左*/
            width: 100%;
            margin-top: 0px;
            text-align: center;
        }

        .imagestyle {
            margin: 0px 0px 0px 0px;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="~/Styles/DefaultStyle.css" />
    <link rel="stylesheet" type="text/css" href="Styles/Mastermanu.css" />
</head>
<body>
        <form runat="server" id="loginform">
        <div class="loginpage">
        <div style="height:500px;">

        <table class="contenttable" style="width:100%; text-align:center;">
        <tr class="listtitle2">
            <td>新闻</td>
        </tr>
        <tr>
         <td >
                    <asp:Panel ID="Panel_news" runat="server" ScrollBars="Vertical" BorderStyle="None" CssClass="panellist" style="width:99%; height:450px;">
                <asp:Repeater ID="Repeater_newstitlelist" runat="server" >
                    <HeaderTemplate>

                        <table >
                    </HeaderTemplate>

                    <ItemTemplate>
                        <tr class="listcontent" >
                            <td style="text-align:left">
                             <asp:LinkButton ID="show_newstitle" CommandName='<%#Eval("Id")%>' OnCommand="show_newstitle" runat="server" style="color: white;white-space: nowrap; text-decoration:none; margin-left:10px;" Width="100%" ><%#Eval("Title") %></asp:LinkButton>
                           </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </asp:Panel>
        </td>
        </tr>
        <tr>
        <td> <a href="javascript:history.go(-1)" class="logout" style="color:White; font-weight:bold;">返回</a></td></tr>
</table>
          
        
        
            
            
        </div>
    <div style="background-color: #777770; height: 60px;"></div>
            <div style="background-color: #de5a58; height: 40px;"></div>
            <footer style="background-color: #0099cc;">
                <table class="tablefull">
                    <tr>
                        <td>
                            <table class="tablefull" style="margin-top: 2px; height: 45px; text-align: justify">
                                <tr>
                                    <td style="width: 86%;">
                                        <p style="text-align: left; margin: 0px 0px 0px 50px; /*外围边框上右下左*/ line-height: 160%;">
                                            地址：贵州省贵阳市沙冲南路198号消防总队8楼 邮政编码：550007
                                <br />
                                            电话：0851-85605531 传真：0851-85605531 技术支持:18786692599
                                <br />
                                            网址：http://www.alarmcrt.com 邮箱：fanxq@cncbz.com
                                 <br />
                                            ©2015 贵州科盾消防事务有限公司 版权所有<asp:Image ID="companylogo" runat="server" CssClass="companylogo" />
                                        </p>
                                    </td>
                                    <td style="width: 14%;">
                                        <p style="text-align: center; margin: 0px 55px 0px 0px;">
                                            <asp:Image ID="zrz" runat="server" ImageUrl="~/Pic/zrz.png" CssClass="imagestyle" />
                                            <br />
                                            黔ICP备12001479号
                                        </p>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </footer>
    </div>
    </form>
</body>
</html>

