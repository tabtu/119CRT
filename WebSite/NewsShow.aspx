<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsShow.aspx.cs" Inherits="NewsShow" %>

<%@ Register Src="Control/U_newstitlelist.ascx" TagName="U_newstitlelist" TagPrefix="uc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .tablefull
        {
            margin: 0px 0% 0px 0%; /*外围边框上右下左*/
            width: 100%;
            margin-top: 0px;
            text-align: center;
        }
        .imagestyle
        {
            margin: 0px 0px 0px 0px;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="~/Styles/DefaultStyle.css" />
    <link rel="stylesheet" type="text/css" href="~/Styles/Mastermanu.css" />
</head>
<body style="margin-top: 0px;">
    <form runat="server" id="loginform">
    <div class="loginpage">
        <div class="login">
            <table class="tablefull">
                <tr>
                    <td style="text-align: left; margin-top: 10px">
                        <a class="mastertitle">智慧消防管理系统</a>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="contenttable" style="width: 100%; background-color: White;">
                <tr class="listtitle">
                    <td>
                        <asp:Label ID="Label_newstitle" runat="server" Text="" CssClass="label" Style="font-size: 25px;"></asp:Label>
                    </td>
                </tr>
                <tr class="listcontent">
                    <td style="text-align: right">
                        <asp:Label ID="Label_newsauthor" runat="server" Text="" CssClass="label" ForeColor="Black"
                            Style="margin: 0px 20px 0px 20px;"></asp:Label>
                        <asp:Label ID="Label_time" runat="server" Text="" CssClass="label" ForeColor="Black"
                            Style="margin: 0px 20px 0px 20px;"></asp:Label>
                    </td>
                </tr>
                <tr class="listcontent">
                    <td >
                    <table  style="width:100%;">
                    <tr  style="height: 560px; text-indent: 2; text-align: center;vertical-align: top;">
                    <td  style="text-align:left" ><asp:Label ID="Label_newscontext" runat="server" CssClass="label" 
                            ForeColor="Black" style="font-size:20px; margin:20px 40px 20px 40px; " ></asp:Label>
                        </td></tr>
                        <tr>
                        <td>  <a href="javascript:history.go(-1)" class="logout" style="font-weight:bold;">返回</a></td></tr></table>
                       
                  
                    </td>
                </tr>
                <tr class="listcontent">
                    <td>
                        <asp:Label ID="Label_notic" runat="server" ForeColor="Red" Text="" CssClass="label"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <footer>
                <table  class="tablefull">

                    <tr>
                        <td>
                <table class="tablefull" style="margin-top: 2px; height: 45px;text-align:justify">
                    <tr>
                        <td style="width:86%;" >
                            <p style="text-align:left; margin: 0px 0px 0px 50px; /*外围边框上右下左*/ line-height:160%;">
                                地址：贵州省贵阳市沙冲南路198号消防总队8楼 邮政编码：550007
                                <br />
                                电话：0851-85605531 传真：0851-85605531 技术支持:18786692599
                                <br />
                                网址：http://www.alarmcrt.com 邮箱：fanxq@cncbz.com
                                 <br />
                               <a href="http://www.119crt.com" style="color:white; text-decoration: none">©2015 贵州科盾消防事务有限公司 版权所有</a></p>
                        </td>
                        <td style="width:14%;">
                            <p style="text-align:center;margin: 0px 55px 0px 0px;" ">
                            <asp:Image ID="zrz" runat="server" ImageUrl="~/Pic/zrz.png" CssClass="imagestyle"/>
                            <br />黔ICP备12001479号</p>                        
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
