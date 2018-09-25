<%@ page language="C#" autoeventwireup="true" inherits="HostAlarm, App_Web_lleqnx0p" %>

<!DOCTYPE html>
<script type="text/javascript">

    window.setInterval(function () {
        CircleCheck();
    }, 30 * 1000);

    function CircleCheck() {
        document.getElementById("btn_epn").click();
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>智慧消防管理系统---监控系统</title>
    <link rel="stylesheet" type="text/css" href="~/Styles/DefaultStyle.css" />
    <link rel="stylesheet" type="text/css" href="~/Styles/Mastermanu.css" />
</head>
<body>
     <form runat="server" id="alertform">
        <div class="defualtpage">
            <div class="masterhead">
                <table>
                    <tr>
                        <td>
                            <div class="logotable">
                                <a id="spantitle2">智慧消防管理系统---监控系统</a>
                                </div>
                        </td>
                        <td class="seclogotable">
                            <table class="manuposition">
                                <tr>
                                    <td>
                                        <table class="loginuser">
                                            <tr>
                                                <td id="name">
                                                    <a href="ChangePassword.aspx">
                                                        <asp:Label ID="Label_user" runat="server" Text=""></asp:Label>
                                                        欢迎您</a>
                                                </td>
                                                <td>
                                                    <a href="HomePage.aspx" class="logout">首页</a>
                                                </td>
                                                <td>
                                                    <a href="LoginOut.aspx" class="logout">注销</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div>
               
            <asp:ImageButton ID="btn_epn" runat="server" ImageUrl="~/Pic/epn.png" OnClick="btn_epn_Click" />
    <br /><br />
                <asp:Label ID="Label_sumstate" runat="server" Visible="False">-1</asp:Label>
    当前异常主机数：<asp:Label ID="Label_state" runat="server" ForeColor="Red">-1</asp:Label>

    <asp:Repeater ID="Repeater_errorhostlist" runat="server" >
                <HeaderTemplate>
                    <table >
                        <tr>
                            <td>楼宇名称</td>
                            <td>主机编码</td>
                            <td>通信时间</td>
                            <td>状态</td>
                            <td>状态更新时间</td>
                            <td></td>
                            <td></td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("HostName")%></td>
                        <td><%#Eval("HOST_ID")%></td>
                        <td><%#Eval("COMM_DATE")%></td>
                        <td><script type="text/javascript">
                                document.write(getState(<%#Eval("STATE")%>));
                                function getState(stateid) {
                                    if (stateid == '0') {
                                        return "恢复(正常)";
                                    } else if (stateid == '1') {
                                        return "故障";
                                    } else if (stateid == '2') {
                                        return "火警";
                                    } else if (stateid == '3') {
                                        return "隔离";
                                    } else if (stateid == '4') {
                                        return "启动";
                                    } else if (stateid == '5') {
                                        return "预警";
                                    } else if (stateid == '6') {
                                        return "回答";
                                    } else if (stateid == '10') {
                                        return "在线";
                                    } else if (stateid == '12') {
                                        return "断线";
                                    } else {
                                        return "未知原因";
                                    }
                                }
                            </script></td>
                        <td><%#Eval("STATE_DATE")%></td>
                        <td><asp:LinkButton ID="showhostdetail" runat="server" CommandName='<%#Eval("HOST_ID")%>' OnCommand="showhost">查看主机资源</asp:LinkButton></td>
                        <td><asp:LinkButton ID="showequiplist" runat="server" CommandName='<%#Eval("HOST_ID")%>' OnCommand="showequip">显示详细设备列表</asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
                </asp:Repeater></div>
       
        <footer>
            <p class="footer">
                ®智慧消防管理系统 v1.5.22
                <br />
                ©2015 贵州科盾消防事务有限公司 版权所有</p>
        </footer>
        </div>
    </form>
</body>
</html>