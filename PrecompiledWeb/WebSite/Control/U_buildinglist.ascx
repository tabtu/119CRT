<%@ control language="C#" autoeventwireup="true" inherits="Control_U_buildinglist, App_Web_4kv54lqz" %>

<style type="text/css">
    .manutree {
        letter-spacing: 1px;
        text-align: center;
        color: #37c8e4;
        font-family: "微软雅黑","黑体",'Times New Roman';
        font-size: 15px;
        font-style: normal;
        /*font-weight:600;*/
    }
</style>

<asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" BorderStyle="None" CssClass="panellist" Height="528px" Width="220px">
                                <asp:Repeater ID="Repeater_landatalist" runat="server">
                                    <HeaderTemplate>
                                        <table class="contenttable">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr class="listcontent">
                                            <td>
                                                <asp:LinkButton ID="show_landataid" CommandName='<%#Eval("Id")%>' OnCommand="show_landata" runat="server" style="white-space: nowrap; text-decoration:none; " Width="100%" ForeColor="#1ea0b9"><%#Eval("Building") %></asp:LinkButton></td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </asp:Panel>