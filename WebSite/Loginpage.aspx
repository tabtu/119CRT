<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Loginpage.aspx.cs" Inherits="登陆页面" %>

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
</head>
<body>
    <script type="text/javascript">

        function oldloginlogo() {
            document.getElementById('loginlogo').src = "Pic/loginlogo.png";
        }
        function newloginlogo() {
            document.getElementById('loginlogo').src = "Pic/loginlogo1.png";
        }

    </script>
    <form runat="server" id="loginform">
        <div class="loginpage">
            <div style="background-color: black; height: 60px;">
                <table>
                    <tr>
                        <td style="text-align: left; margin-top: 10px">
                            <a class="logintitle">智慧消防管理系统&nbsp;&nbsp; ——</a>
                            <a class="logintitle" style="font-size:25px;color:#de5a58;">登陆界面</a>
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <table class="tablefull">
                    <tr>
                        <td>
                            
                            <asp:Image ID="loginlogo" runat="server" ImageUrl="Pic/loginlogo.png" onmouseout="oldloginlogo();" onmouseover="newloginlogo();" /></td>
                        <td style="text-align: center;">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label_account" runat="server" Text="账号" CssClass="account-password-lable1" ></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox_account" runat="server" MaxLength="30" BorderStyle="Solid" CssClass="account-password1" BorderColor="#195b7b" BorderWidth="1px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>

                                        <asp:Label ID="Label_password" runat="server" Text="密码" CssClass="account-password-lable1 " ></asp:Label>

                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox_password" runat="server" TextMode="Password" BorderStyle="Solid" CssClass="account-password1" MaxLength="30" BorderColor="#195b7b" BorderWidth="1px" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <asp:Button ID="Button_submit" runat="server" Text="登  录" CssClass="loginbutton1" BorderStyle="None" OnClick="Button_submit_Click" Style="margin-left: 10px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
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
                        </td>
                    </tr>
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
                                            ©2015 贵州科盾技防科技有限公司 版权所有<asp:Image ID="companylogo" runat="server" CssClass="companylogo" />
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
