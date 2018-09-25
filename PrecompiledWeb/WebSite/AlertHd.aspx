<%@ page title="" language="C#" masterpagefile="~/MasterAlert.master" autoeventwireup="true" inherits="Default2, App_Web_5vy54w34" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br />
    <asp:Repeater ID="Repeater_errornodelist" runat="server" >
                <HeaderTemplate>
                    <table >
                        <tr>
                            <td>设备逻辑地址</td>
                            <td>状态</td>
                            <td>状态更新时间</td>
                            <td></td>
                            <td></td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("ADDR_ID")%></td>
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
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
                </asp:Repeater>
</asp:Content>

