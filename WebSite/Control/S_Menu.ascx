<%@ Control Language="C#" AutoEventWireup="true" CodeFile="S_Menu.ascx.cs" Inherits="Control_S_Menu" %>
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
        <td>
            <asp:Button ID="Button_Sys" runat="server" Text="系统配置" CssClass ="submitbutton2"  OnClick="Button_sys_Click" />
        </td>
        <td>
            <asp:Button ID="Button_Use" runat="server" Text="用户维护" CssClass = "submitbutton2"  OnClick="Button_use_Click" />
        </td>
        <td>
            <asp:Button ID="Button_news" runat="server" Text="新闻发布" CssClass = "submitbutton2"  OnClick="Button_news_Click" />
        </td>
        <td>
            <asp:Button ID="Button_Firehouse" runat="server" Text="消防队管理" CssClass = "submitbutton2"  OnClick="Button_firehouse_Click" />
        </td>
        <td>
            <asp:Button ID="Button_landata" runat="server" Text="数据管理" CssClass = "submitbutton2"  OnClick="Button_landata_Click" />
        </td>
        <td>

            <asp:DropDownList ID="DropDownList_area" runat="server" CssClass = "submitbutton2" OnSelectedIndexChanged="DropDownList_area_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>

        </td>
    </tr>
</table>