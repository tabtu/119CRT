<%@ Control Language="C#" AutoEventWireup="true" CodeFile="U_updateLandata.ascx.cs" Inherits="Control_U_updateLandata" %>

<%@ Register src="S_LocalSelect.ascx" tagname="S_LocalSelect" tagprefix="uc1" %>

<style type="text/css">
    .tdtitle {
        width: 90px;
    }
    .auto-style1 {
        font-size: small;
    }
</style>
<link rel="stylesheet" type="text/css" href="Styles/Mastermanu.css" />

<table class="contenttable">
    <tr>
        <td>

            <table class="contenttable">                
                <tr class="listcontent2">
                    <td>
                        <table class="contenttable">
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    主机地址</td>
                                <td>
                                    <asp:Label ID="Label_hide_lid" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    所属区域</td>
                                <td>
                                    <asp:Label ID="Label_area" runat="server"></asp:Label>
                                    <asp:Label ID="Label_hide_areaid" runat="server" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    位置信息</td>
                                <td>
                                        <uc1:S_LocalSelect ID="S_LocalSelect1" runat="server" />
                                    </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    楼宇名称</td>
                                <td>
                                    <asp:TextBox ID="TextBox_building" runat="server" MaxLength="100" BorderStyle="Solid" CssClass="textbox" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    详细地址</td>
                                <td>
                                    <asp:TextBox ID="TextBox_address" runat="server" MaxLength="200" BorderStyle="Solid" CssClass="textbox" Width="100%" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    建筑分类</td>
                                <td>
                                    <asp:DropDownList ID="DropDownList_cate" runat="server" BorderStyle="Solid" CssClass="textbox" Width="100%"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    使用性质</td>
                                <td>
                                    <asp:DropDownList ID="DropDownList_type" runat="server" BorderStyle="Solid" CssClass="textbox" Width="100%"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    管理部门</td>
                                <td>
                                    <asp:TextBox ID="TextBox_manager" runat="server" MaxLength="200" BorderStyle="Solid" CssClass="textbox" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    维护公司</td>
                                <td>
                                    <asp:DropDownList ID="DropDownList_mid" runat="server" BorderStyle="Solid" CssClass="textbox" Width="100%"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    物业公司</td>
                                <td>
                                    <asp:DropDownList ID="DropDownList_pid" runat="server" BorderStyle="Solid" CssClass="textbox" Width="100%"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    主机账号</td>
                                <td>
                                    <asp:TextBox ID="TextBox_hostcode" runat="server" MaxLength="200" BorderStyle="Solid" CssClass="textbox" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    账号激活</td>
                                <td>
                                    <asp:DropDownList ID="DropDownList_active" runat="server" BorderStyle="Solid" CssClass="textbox" Width="100%">
                                        <asp:ListItem Value="1">有效</asp:ListItem>
                                        <asp:ListItem Value="0">无效</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    主机密码</td>
                                <td>
                                    <asp:TextBox ID="TextBox_passwd" runat="server" MaxLength="200" BorderStyle="Solid" CssClass="textbox" Width="100%" Text=""></asp:TextBox><br /><span class="auto-style1">如不需要更改密码，请不填写主机密码项。</span>
                                </td>
                            </tr>
                            <%--<tr class="listcontent2">
                                <td class="tdtitle">
                                    主机状态</td>
                                <td>
                                    <asp:DropDownList ID="DropDownList_state" runat="server" BorderStyle="Solid" CssClass="textbox" Width="50%">
                                        <asp:ListItem Value="1">在线</asp:ListItem>
                                        <asp:ListItem Value="0">离线</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Button ID="Button_updatehoststate" runat="server" OnClick="Button_updatehoststate_Click" Text="更新主机状态" BorderStyle="None" CssClass="submitbutton" />
                                </td>
                            </tr>--%>
                            <tr>
                                <td>批量导入数据</td>
                                <td><asp:FileUpload ID="FileUpload_xml" runat="server" />
                                    <asp:Button ID="Button_import" runat="server" Text="上传导入" OnClick="Button_check_Click" BorderStyle="None" CssClass="submitbutton" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Button ID="Button_equip" runat="server" Text="楼层平面图" OnClick="Button_node_Click" BorderStyle="None" CssClass="submitbutton" />
                                </td>
                            </tr>
                        </table>

                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="text-align: center">
            <asp:Label ID="Label_fix_tip" runat="server" ForeColor="Red" Text="" CssClass="label"></asp:Label>
            <br />
            <asp:Button ID="Button_submit" runat="server" Text="提交" OnClick="Button_submit_Click" BorderStyle="None" CssClass="submitbutton" />

        </td>
    </tr>
</table>


