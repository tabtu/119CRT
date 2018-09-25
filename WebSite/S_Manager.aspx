<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="S_Manager.aspx.cs" Inherits="Default2" %>

<%@ Register src="Control/SM_area.ascx" tagname="SM_area" tagprefix="uc1" %>
<%@ Register src="Control/SM_city.ascx" tagname="SM_city" tagprefix="uc2" %>
<%@ Register src="Control/SM_controlcenter.ascx" tagname="SM_controlcenter" tagprefix="uc3" %>
<%@ Register src="Control/SM_equipstatus.ascx" tagname="SM_equipstatus" tagprefix="uc4" %>
<%@ Register src="Control/SM_lancate.ascx" tagname="SM_lancate" tagprefix="uc5" %>
<%@ Register src="Control/SM_lantype.ascx" tagname="SM_lantype" tagprefix="uc6" %>

<%@ Register src="Control/UM_equiptype.ascx" tagname="UM_equiptype" tagprefix="uc7" %>
<%@ Register src="Control/UM_firemanage.ascx" tagname="UM_firemanage" tagprefix="uc8" %>
<%@ Register src="Control/UM_maintenance.ascx" tagname="UM_maintenance" tagprefix="uc9" %>
<%@ Register src="Control/UM_property.ascx" tagname="UM_property" tagprefix="uc10" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">


    </style>

<link rel="stylesheet" type="text/css" href="Styles/Mastermanu.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <link rel="stylesheet" type="text/css" href="Styles/Mastermanu.css" />
    <table class="contenttable">
        <tr>
            <td>
                <asp:Button ID="Button_et" runat="server" CssClass ="submitbutton2" Text="设备类型" OnClick="Button_et_Click"/>
            </td>
            <td>
                <asp:Button ID="Button_es" runat="server" CssClass ="submitbutton2" Text="设备状态" OnClick="Button_es_Click" />
            </td>
            <td>
                <asp:Button ID="Button_lc" runat="server" CssClass ="submitbutton2" Text="大楼分类" OnClick="Button_lc_Click" />
            </td>
            <td>
                <asp:Button ID="Button_lt" runat="server" CssClass ="submitbutton2" Text="大楼属性" OnClick="Button_lt_Click" />
            </td>
            <td>
                <asp:Button ID="Button_c" runat="server" CssClass ="submitbutton2" Text="城市配置" OnClick="Button_c_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button_a" runat="server" CssClass ="submitbutton2" Text="区域设置" OnClick="Button_a_Click" />
            </td>
            <td>
                <asp:Button ID="Button_cc" runat="server" CssClass ="submitbutton2" Text="控制中心" OnClick="Button_cc_Click" />
            </td>
            <td>
                <asp:Button ID="Button_fm" runat="server" CssClass ="submitbutton2" Text="管理部门" OnClick="Button_fm_Click"/>
            </td>
            <td>
                <asp:Button ID="Button_m" runat="server" CssClass ="submitbutton2" Text="维护公司" OnClick="Button_m_Click"/>
            </td>
            <td>
                <asp:Button ID="Button_p" runat="server" CssClass ="submitbutton2" Text="物业公司" OnClick="Button_p_Click"/>
            </td>
        </tr>
    </table>
    <br />

    <uc1:SM_area ID="SM_area1" runat="server" />
    <uc2:SM_city ID="SM_city1" runat="server" />
    <uc3:SM_controlcenter ID="SM_controlcenter1" runat="server" />
    <uc4:SM_equipstatus ID="SM_equipstatus1" runat="server" />
    <uc5:SM_lancate ID="SM_lancate1" runat="server" />
    <uc6:SM_lantype ID="SM_lantype1" runat="server" />

    <uc7:UM_equiptype ID="UM_equiptype1" runat="server" />
    <uc8:UM_firemanage ID="UM_firemanage1" runat="server" />
    <uc9:UM_maintenance ID="UM_maintenance1" runat="server" />
    <uc10:UM_property ID="UM_property1" runat="server" />

    <br />

</asp:Content>

