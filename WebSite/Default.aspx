<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default2" %>




<%@ Register src="Control/U_newstitlelist.ascx" tagname="U_newstitlelist" tagprefix="uc1" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智慧消防管理系统</title>
    <style type="text/css">
        .tablefull {
         margin: 0px 0% 0px 0%;/*外围边框上右下左*/
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
</head>
<body style="margin-top:0px;">
    <script type="text/javascript">

        function oldwhgs(){
            document.getElementById('whgs').src = "Pic/whgs1.png";
        }
        function newwhgs(){
            document.getElementById('whgs').src = "Pic/whgs2.png";
        }
        function oldzdbm(){
            document.getElementById('zdbm').src = "Pic/zdbm1.png";
        }
        function newzdbm(){
            document.getElementById('zdbm').src = "Pic/zdbm2.png";
        }
        function oldxfzj(){
            document.getElementById('xfzj').src = "Pic/xfzj1.png";
        }
        function newxfzj(){
            document.getElementById('xfzj').src = "Pic/xfzj2.png";
        }
        function oldglbm() {
            document.getElementById('glbm').src = "Pic/glbm1.png";
        }
        function newglbm() {
            document.getElementById('glbm').src = "Pic/glbm2.png";
        }
        function oldjkzx(){
            document.getElementById('jkzx').src = "Pic/jkzx1.png";
        }
        function newjkzx(){
            document.getElementById('jkzx').src = "Pic/jkzx2.png";
        }
        function oldwygs(){
            document.getElementById('wygs').src = "Pic/wygs1.png";
        }
        function newwygs(){
            document.getElementById('wygs').src = "Pic/wygs2.png";
        }

  </script>
    <form runat="server" id="loginform">
        <div class="loginpage">
            <div class="login">

                <table class="tablefull">
                    <tr>
                        <td style="text-align: left; margin-top: 10px">
                            <a class="mastertitle">智慧消防管理系统</a>
                        </td>
                        <td>
                            <asp:Label ID="Label_type" runat="server" Text="类型" CssClass="account-password-lable" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox_type" runat="server" MaxLength="30" BorderStyle="Solid" CssClass="account-password" BorderColor="#195b7b" BorderWidth="1px" Visible="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label_account" runat="server" Text="账号" CssClass="account-password-lable" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox_account" runat="server" MaxLength="30" BorderStyle="Solid" CssClass="account-password" BorderColor="#195b7b" BorderWidth="1px" Visible="False"></asp:TextBox>
                        </td>

                        <td>

                            <asp:Label ID="Label_password" runat="server" Text="密码" CssClass="account-password-lable " Visible="False"></asp:Label>

                        </td>
                        <td>
                            <asp:TextBox ID="TextBox_password" runat="server" TextMode="Password" BorderStyle="Solid" CssClass="account-password" MaxLength="30" BorderColor="#195b7b" BorderWidth="1px" Visible="False"></asp:TextBox>
                        </td>

                        <td>
                            <asp:Button ID="Button_submit" runat="server" Text="登录" CssClass="loginbutton" BorderStyle="None" OnClick="Button_submit_Click" Style="margin-left: 10px" Visible="False" />
                        </td>
                        <td style="width:110px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="TextBox_type" ErrorMessage="请选择类型" ForeColor="Red" Visible="False"></asp:RequiredFieldValidator>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_name" runat="server"
                                ControlToValidate="TextBox_account" ErrorMessage="请输入账户" ForeColor="Red" Visible="False"></asp:RequiredFieldValidator>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_pw" runat="server"
                                ControlToValidate="TextBox_password" ErrorMessage="请输入密码" ForeColor="Red" Visible="False"></asp:RequiredFieldValidator>

                            <asp:Label ID="Label_notic" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <table class="tablefull">
                    <tr>
                        <td class="mastertitle" style="background-image:url(Pic/mastlog.png); background-repeat: no-repeat;width:379px;height:470px;font-style:normal;font-size:100pt; color:#f1966e;font-family:'Bauhaus 93'";>                          
                        119
                        </td>
                        <td style="background-image:url(Pic/newsbackground.png); background-repeat: no-repeat;width:868px;height:470px;">
                            <table class="tablefull" style="height:100%;">
                                <tr>
                                    <td class="littertitle" style="font-weight:bolder;line-height:200%;">
                                        新<br />闻
                        
                                    </td>
                                    <td>
                                        <table class="tablefull">
                                            <tr>
                                                <td class="news">
                                                   
                                                    <uc1:U_newstitlelist ID="U_newstitlelist1" runat="server" />
                                                   
                                                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                                   
                                                </td>
                                            </tr>
                                            <tr class="textstylebase">
                                                <td style="text-align: right;">
                                                    <a href="NewslistShow.aspx" style="color: white;text-decoration: none;margin-right:25px;"> 
                                                        >>>更多
                                                    </a>
                                                </td>
                                            </tr>

                                        </table>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                      <table class="tablefull" >
                                            <tr>
                                                <td class="news" style="height: 140px;">
                                                    
                                                    <uc1:U_newstitlelist ID="U_newstitlelist2" runat="server" />
                                                    
                                                </td>
                                            </tr>
                                            <tr class="textstylebase">
                                                <td style="text-align: right;">
                                                       <a href="SysnewslistShow.aspx" style="color: white;text-decoration: none;margin-right:25px;"> >>>更多</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="littertitle" style="font-size: 20pt;width:60px;">
                                        <p style="margin:10px 0px 0px 0%;/*外围边框上右下左*/">系<br />统<br />动<br />态</p>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <footer>
                <table  class="tablefull" style="background-color:black;">
                                <tr>
                                    <td><asp:ImageButton ID="whgs" runat="server" ImageUrl="~/Pic/whgs1.png" CssClass="logo"  onmouseout="oldwhgs();" onmouseover="newwhgs();" OnClick="ImageButton_whgs_Click"/><br />维护公司</td>
                                    <td><asp:ImageButton ID="zdbm" runat="server" ImageUrl="~/Pic/zdbm1.png" CssClass="logo"  onmouseout="oldzdbm();" onmouseover="newzdbm();" OnClick="ImageButton_zdbm_Click"/><br />战斗部门</td>
                                    <td><asp:ImageButton ID="xfzj" runat="server" ImageUrl="~/Pic/xfzj1.png" CssClass="logo"  onmouseout="oldxfzj();" onmouseover="newxfzj();" OnClick="ImageButton_xfzj_Click"/><br />消防主机</td>
                                    <td><asp:ImageButton ID="glbm" runat="server" ImageUrl="~/Pic/glbm1.png" CssClass="logo"  onmouseout="oldglbm();" onmouseover="newglbm();" OnClick="ImageButton_glbm_Click"/><br />管理部门</td>
                                    <td><asp:ImageButton ID="jkzx" runat="server" ImageUrl="~/Pic/jkzx1.png" CssClass="logo"  onmouseout="oldjkzx();" onmouseover="newjkzx();" OnClick="ImageButton_jkzx_Click"/><br />监控中心</td>
                                    <td><asp:ImageButton ID="wygs" runat="server" ImageUrl="~/Pic/wygs1.png" CssClass="logo"  onmouseout="oldwygs();" onmouseover="newwygs();" OnClick="ImageButton_wygs_Click"/><br />物业公司</td>
                                </tr>
                            </table>
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
                               <a href="http://www.119crt.com" style="color:white; text-decoration: none">©2015 贵州科盾技防科技有限公司 版权所有</a></p>
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
