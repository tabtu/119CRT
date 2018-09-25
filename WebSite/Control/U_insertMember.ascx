<%@ Control Language="C#" AutoEventWireup="true" CodeFile="U_insertMember.ascx.cs" Inherits="Control_U_insertMember" %>

<style type="text/css">
        .tdtitle {
            width: 60px;
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
                                    <td class="tdtitle">账号：</td>
                                    <td>
                                        <asp:TextBox ID="TextBox_account" runat="server" MaxLength="15"  CssClass="textbox1"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator_account" runat="server"
                                            ErrorMessage="*" ForeColor="Red" ControlToValidate="TextBox_account"
                                            Font-Size="Medium"></asp:RequiredFieldValidator>--%>
                                    </td>
                                </tr>

                                <tr class="listcontent2">
                                    <td class="tdtitle">姓名：</td>
                                    <td>
                                        <asp:TextBox ID="TextBox_name" runat="server" MaxLength="15"  CssClass="textbox1"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="R_TextBox_name" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="TextBox_name"></asp:RequiredFieldValidator>--%>
                                    </td>
                                </tr>


                                <tr class="listcontent2">
                                    <td class="tdtitle">权限：</td>
                                    <td>
                                        <asp:DropDownList ID="DropDownList_type" runat="server" BorderStyle="None" CssClass="text" ForeColor="#268cbd" Width="100%" OnSelectedIndexChanged="DropDownList_limit_SelectedIndexChanged" AutoPostBack="True" >
                                            <%--<asp:ListItem Value="0">超级权限</asp:ListItem>--%>
                                            <asp:ListItem Value="1">管理部门</asp:ListItem>
                                            <asp:ListItem Value="2">战斗部队</asp:ListItem>
                                            <asp:ListItem Value="3">监控中心</asp:ListItem>
                                            <asp:ListItem Value="4">维护公司</asp:ListItem>
                                            <asp:ListItem Value="5">物业公司</asp:ListItem>
                                            <asp:ListItem Value="6">消防主机</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr class="listcontent2">
                                    <td class="tdtitle"><asp:Label ID="Label_title" runat="server" Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox_linkid" runat="server" Width="100%" Visible="False"></asp:TextBox>
                                        <asp:DropDownList ID="DropDownList_linkid" runat="server" BorderStyle="None" 
                                            CssClass="text" ForeColor="#268cbd" Width="100%" Visible="False" ></asp:DropDownList>
                                    </td>
                                </tr>

                                <tr class="listcontent2">
                                    <td class="tdtitle">电话</td>
                                    <td>
                                        <asp:TextBox ID="TextBox_tel" runat="server" BorderStyle="Solid" CssClass="textbox"  Width="100%"
                                            EnableTheming="True" MaxLength="20" sonpaste="return false " Style="ime-mode: disabled"
                                            onkeypress="if ((event.keyCode<48 || event.keyCode>57) && event.keyCode!=46) event.returnValue=false;"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
            </td>
        </tr>
                    <tr>
        <td style="text-align: center">
            <asp:Label ID="Label_fix_tip" runat="server" ForeColor="Red" Text="" CssClass="label"></asp:Label>
            <br />
            <asp:Button ID="Button_submit" runat="server" Text="提交" OnClick="Button_submit_Click" BorderStyle="None" CssClass="submitbutton"/>
        </td>
    </tr>
    </table>
