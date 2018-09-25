<%@ page title="" language="C#" masterpagefile="~/Master.master" autoeventwireup="true" inherits="InsertFirehouse, App_Web_dwdoc3y1" %>

<%@ Register Src="Control/U_updateFirehouse.ascx" TagName="U_updateFirehouse" TagPrefix="uc2" %>

<%@ Register Src="Control/U_firehouse.ascx" TagName="U_firehouse" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">


    </style>
    <link rel="stylesheet" type="text/css" href="Styles/Mastermanu.css" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
    <table class="contenttable" style="width:100%">
        <tr class="listtitle2">
            <td>设备管理</td>
        </tr>

        <tr>
            <td>
                <table>
                    <tr>
                        <td style="vertical-align: top; text-align: center;>
                            <table class="contenttable">
                                <tr class="listtitle" style="padding: 0px 30px 0px 30px; border: 1px solid white;">
                                    <td>
                                        <asp:Button ID="Button_addfirehouse" runat="server" Text="增加消防队" BorderStyle="None" Width="100%" Font-Bold="True" Font-Size="15px" OnClick="Button_addfirehouse_Click" BackColor="#0099cc" ForeColor="White" />
                                    </td>
                                </tr>
                                <tr class="listtitle" style="padding: 0px 30px 0px 30px; border: 1px solid white;">
                                    <td>消防队列表</td>
                                </tr>
                                <tr>
                                    <td style="display: table-header-group;">
                                        <asp:Panel ID="Panel_area" runat="server" ScrollBars="Vertical" BorderStyle="None" CssClass="panellist" Height="528px" Width="220px">
                                            <asp:Repeater ID="Repeater_firehouselist" runat="server">
                                                <HeaderTemplate>
                                                    <table class="contenttable">
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr class="listcontent">
                                                        <td>
                                                            <asp:LinkButton ID="show_equipid" CommandName='<%#Eval("Id")%>' OnCommand="show_firehouse" runat="server" Style="white-space: nowrap; text-decoration: none;" Width="100%" ForeColor="#1ea0b9"><%#Eval("Name") %></asp:LinkButton></td>
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
                        </td>
                        <td style="vertical-align: top; text-align: center; width:100%">
                            <div style="margin: 0px 0px 0px 0px;">

                                <uc1:U_firehouse ID="U_firehouse1" runat="server" />

                                <br />
                                <uc2:U_updateFirehouse ID="U_updateFirehouse1" runat="server" />
                            </div>
                        </td>
                    </tr>
                </table>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label_notic" runat="server" ForeColor="Red" Text="" CssClass="label" Font-Size="X-Large"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

