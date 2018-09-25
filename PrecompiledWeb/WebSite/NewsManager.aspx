<%@ page title="" language="C#" masterpagefile="~/Master.master" autoeventwireup="true" inherits="NewsManager, App_Web_jz3qqgas" %>

<%@ Register Src="Control/U_insertnews.ascx" TagName="U_insertnews" TagPrefix="uc1" %>
<%@ Register Src="Control/U_updatenews.ascx" TagName="U_updatenews" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .controlwidth
        {
            width:80%;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="Styles/Mastermanu.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table class="contenttable">
        <tr class="listtitle2">
            <td>
                新闻管理
            </td>
        </tr>
        <tr>
            <td>
                <table class="contenttable">
                    <tr>
                        <td>
                            <asp:TextBox ID="TextBox_key" runat="server" MaxLength="50" CssClass="textbox1" Style="width: 300px;"></asp:TextBox>
                            <asp:Button ID="Button_add" runat="server" Text="添加" OnClick="Button_add_Click" BorderStyle="None"
                                CssClass="submitbutton" Style="margin: 0px 20px 0px 20px;" />
                            <asp:Button ID="Button_choose" runat="server" Text="查询" OnClick="Button_choose_Click"
                                BorderStyle="None" CssClass="submitbutton" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table class="contenttable" style="height: 500px;">
                    <tr>
                        <td>
                            <asp:Panel ID="Panel_news" runat="server" ScrollBars="Vertical" BorderStyle="None"
                                CssClass="panellist" Style="width: 100%; height: 500px;" Visible="False">
                                <asp:Repeater ID="Repeater_newstitlelist" runat="server">
                                    <HeaderTemplate>
                                        <table class="contenttable">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr class="listcontent">
                                            <td style="text-align: center">
                                                <asp:LinkButton ID="show_newstitle" CommandName='<%#Eval("Id")%>' OnCommand="show_newstitle"
                                                    runat="server" Style="color: black; white-space: nowrap; text-decoration: none;
                                                    margin-left: 10px;" Width="95%"><%#Eval("Title")%></asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:Button ID="Button_list_edit" CommandName='<%#Eval("Id")%>' runat="server" Text="修改"
                                                    BorderStyle="None" CssClass="submitbutton" Style="margin: 0px 10px 0px 10px;
                                                    font-size: 14px; height: 25px" OnCommand="Button_list_edit_Click" />
                                                <asp:Button ID="Button_list_del" CommandName='<%#Eval("Id")%>' runat="server" Text="删除"
                                                    BorderStyle="None" CssClass="submitbutton" Style="margin: 0px 10px 0px 10px;
                                                    font-size: 14px; height: 25px" OnCommand="Button_list_del_Click" />
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
                    <tr>
                        <td>
                        <div style="margin:0px 50px 0px 50px;vertical-align: top;">
                        <uc1:U_insertnews ID="U_insertnews1" runat="server" Visible="false"/>
                       <uc3:U_updatenews ID="U_updatenews1" runat="server" Visible="false" />
                        </div>
                        </td>     
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
