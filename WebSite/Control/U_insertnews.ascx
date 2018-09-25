<%@ Control Language="C#" AutoEventWireup="true" CodeFile="U_insertnews.ascx.cs" Inherits="Control_U_insertnews" %>

<style type="text/css">
    .tdtitle {
        width: 90px;
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
                                <td class="tdtitle">新闻类型：</td>
                                <td>
                                    <asp:DropDownList ID="DropDownList_newstype" runat="server"  BorderStyle="None" CssClass="text" ForeColor="#268cbd" Width="100%">
                                        <asp:ListItem Value="1">新闻</asp:ListItem>
                                        <asp:ListItem Value="2">系统动态</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <%--<tr class="listcontent2">
                                <td class="tdtitle">作者：</td>
                                <td>
                                <asp:Label ID="Label_author" runat="server" BorderStyle="None" CssClass="text" ForeColor=White Width="100%"></asp:Label>
                                    <asp:DropDownList ID="DropDownList_author" runat="server" BorderStyle="None" CssClass="text" ForeColor="#268cbd" Width="100%"></asp:DropDownList>
                                </td>
                            </tr>--%>
                            <tr class="listcontent2">
                                <td class="tdtitle">标题：</td>
                                <td>
                                    <asp:TextBox ID="TextBox_title" runat="server" MaxLength="50" CssClass="textbox1"></asp:TextBox>
                                    <asp:Label ID="Label_id" runat="server" Visible="False"></asp:Label>
                                </td>
                            </tr>

                            <tr class="listcontent2">
                                <td class="tdtitle">内容：</td>
                                <td >
                                    <asp:TextBox ID="TextBox_context" runat="server" MaxLength="500" CssClass="textbox1" Height="300px" style="text-align:left" TextMode="MultiLine"></asp:TextBox>                                  
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

            </table>
            <tr>
                <td style="text-align: center">
                    <asp:Label ID="Label_fix_tip" runat="server" ForeColor="Red" Text="" CssClass="label"></asp:Label>
                    <br />
                    <asp:Button ID="Button_submit" runat="server" Text="提交" OnClick="Button_submit_Click" BorderStyle="None" CssClass="submitbutton" />
                </td>
            </tr>
</table>
