<%@ control language="C#" autoeventwireup="true" inherits="Control_U_errorhostlist, App_Web_4kv54lqz" %>
<asp:Repeater ID="Repeater_errorhostlist" runat="server">
    <HeaderTemplate>
        <table class="contenttable">
            <tr class="contenttable">
                                    <td>主机编码
                                    </td>
                                    <td>
                                        通信时间
                                    </td>
                <td>
                                        状态
                                    </td>
                <td>
                                        状态更新时间
                                    </td>
                                </tr>
        </table>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class="listcontent">
            <td><%#Eval("HOST_ID") %></td>
            <td><%#Eval("COMM_DATE") %></td>
            <td><%#Eval("STATE") %></td>
            <td><%#Eval("STATE_DATE") %></td>
            <td><asp:LinkButton ID="showhostdetail" runat="server" CommandName='<%#Eval("HOST_ID")%>' OnCommand="showhost">查看主机资源</asp:LinkButton></td>
            <td><asp:LinkButton ID="showequiplist" runat="server" CommandName='<%#Eval("HOST_ID")%>' OnCommand="showequip">显示详细设备列表</asp:LinkButton></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>