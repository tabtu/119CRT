<%@ control language="C#" autoeventwireup="true" inherits="Control_U_equipdata, App_Web_nw3enn3a" %>

<%@ Register src="S_MapSelect.ascx" tagname="S_MapSelect" tagprefix="uc1" %>

<table class="contenttable">
    <tr>
        <td>
            <table class="contenttable">
                <tr class="listcontent2">
                    <td>
                        <table class="contenttable">
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    所属建筑楼层</td>
                                <td>
                                    <asp:Label ID="Label_building" runat="server"></asp:Label>
                                    <asp:Label ID="Label_node" runat="server"></asp:Label>
                                    <asp:Label ID="Label_hide_nid" runat="server" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    设备类型</td>
                                <td>
                                    <asp:DropDownList ID="DropDownList_type" runat="server" CssClass="textbox1"></asp:DropDownList>
                                    <br />
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    设备位置</td>
                                <td>
                                    <uc1:S_MapSelect ID="S_MapSelect1" runat="server" />
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    设备描述</td>
                                <td>
                                    <asp:TextBox ID="TextBox_des" runat="server" MaxLength="100"  CssClass="textbox1" Style="ime-mode: disabled" TextMode="MultiLine"></asp:TextBox>
                                    <br />
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    当前状态</td>
                                <td>
                                    <asp:DropDownList ID="DropDownList_status" runat="server"  CssClass="textbox1"></asp:DropDownList>
                                    <br />
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    串码编码</td>
                                <td>
                                    <asp:TextBox ID="TextBox_logicid" runat="server" MaxLength="10"  CssClass="textbox1" Style="ime-mode: disabled"></asp:TextBox>
                                    <br />
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    外连接</td>
                                <td>
                                    <asp:TextBox ID="TextBox_url" runat="server" MaxLength="200"  CssClass="textbox1" Style="ime-mode: disabled"></asp:TextBox>
                                    <br />
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