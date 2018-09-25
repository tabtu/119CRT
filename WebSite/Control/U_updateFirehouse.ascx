<%@ Control Language="C#" AutoEventWireup="true" CodeFile="U_updateFirehouse.ascx.cs" Inherits="Control_U_updateFirehouse" %>

<%@ Register src="S_LocalSelect.ascx" tagname="S_LocalSelect" tagprefix="uc1" %>

<style type="text/css">
    .tdtitle {
        width: 90px;
    }
    .submitbutton {}
    .textbox {}
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
                                    所属地区</td>
                                <td>
                                    <asp:Label ID="Label_area" runat="server"></asp:Label>
                                    <asp:Label ID="Label_hide_areaid" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="Label_hide_id" runat="server" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    位置信息</td>
                                <td>
                                    <uc1:S_LocalSelect ID="S_LocalSelect1" runat="server" />
                                     </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    消防队名称</td>
                                <td>
                                    <asp:TextBox ID="TextBox_building" runat="server" MaxLength="100" BorderStyle="Solid" CssClass="textbox" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    备注信息</td>
                                <td>
                                    <asp:TextBox ID="TextBox_address" runat="server" MaxLength="200" BorderStyle="Solid" CssClass="textbox" Width="100%" TextMode="MultiLine" Height="100px"></asp:TextBox>
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
            <asp:Button ID="Button_submit" runat="server" Text="提交" OnClick="Button_submit_Click" BorderStyle="None" CssClass="submitbutton" Height="25px" />
        </td>
    </tr>
</table>