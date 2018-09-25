<%@ Control Language="C#" AutoEventWireup="true" CodeFile="S_Menutree.ascx.cs" Inherits="Control_Manutree" %>
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
<link rel="stylesheet" type="text/css" href="Styles/Mastermanu.css" />

<table class="contenttable">
    <tr>
        <td>
            <asp:Button ID="Button_user" runat="server" Text="更改密码" CssClass ="submitbutton2" OnClick="Button_usinfo_Click" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="Button_Sys" runat="server" Text="系统配置" CssClass ="submitbutton2"  OnClick="Button_sys_Click" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="Button_Use" runat="server" Text="用户维护" CssClass = "submitbutton2"  OnClick="Button_use_Click" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="Button_news" runat="server" Text="新闻发布" CssClass = "submitbutton2"  OnClick="Button_news_Click" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="Button_Firehouse" runat="server" Text="消防队管理" CssClass = "submitbutton2"  OnClick="Button_firehouse_Click" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="Button_landata" runat="server" Text="数据管理" CssClass = "submitbutton2"  OnClick="Button_landata_Click" />
        </td>
    </tr>
    
    <tr class="listtitle2" >
        <td>可选区域</td>
    </tr>
    <tr>
        <td style="height:440px">
            <asp:Panel ID="Panel_area" runat="server" ScrollBars="Vertical" BorderStyle="None" CssClass="panellist" Height="100%">
                <asp:Repeater ID="Repeater_orderlist" runat="server">
                    <HeaderTemplate>

                        <table class="contenttable">
                    </HeaderTemplate>

                    <ItemTemplate>
                        <tr class="listcontent" >
                            <td style="text-align:center">
                                <asp:LinkButton ID="show_organid" CommandName='<%#Eval("Id")%>' OnCommand="show_organ" runat="server" style="white-space: nowrap; text-decoration:none; " ForeColor="Black"><%#Eval("Name") %></asp:LinkButton>
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
</table>




