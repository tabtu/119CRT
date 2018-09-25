<%@ Control Language="C#" AutoEventWireup="true" CodeFile="U_chengepassword.ascx.cs" Inherits="Control_U_chengepassword" %>
<style type="text/css">
    .tdtitle {
        width: 80px;
    }
        .tdRfv {
        width: 30px;
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
                                <td class="tdtitle">原密码：</td>
                                <td>
                                    <asp:TextBox ID="TextBox_oldpw" runat="server"  MaxLength="30"  CssClass="textbox1" TextMode="Password"></asp:TextBox>
                                </td>
                                <td class="tdRfv">
                                    <%--<asp:RequiredFieldValidator ID="R_TextBox_name" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="TextBox_oldpw"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">新密码</td>
                                <td>
                                    <asp:TextBox ID="TextBox_newpw" runat="server"  CssClass="textbox1" MaxLength="30" TextMode="Password"></asp:TextBox>
                                </td>
                                <td class="tdRfv">
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="TextBox_newpw"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">确认新密码</td>
                                <td>
                                    <asp:TextBox ID="TextBox_checkpw" runat="server"  CssClass="textbox1" MaxLength="30" TextMode="Password"></asp:TextBox>
                                </td>
                                <td class="tdRfv">
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="TextBox_checkpw"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
            <td>
 <asp:Label ID="Label_result" runat="server" Font-Bold="False" Font-Overline="False" class="label" ForeColor="Red" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Button ID="Button_submit" runat="server" class="submitbutton" onclick="Button_submit_Click" BorderStyle="None" Text="提交" Height="25px" />
            </td>
        </tr>
</table>
