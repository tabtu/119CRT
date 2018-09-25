<%@ page title="" language="C#" masterpagefile="~/Master.master" autoeventwireup="true" inherits="指标录入, App_Web_lmud1zlv" %>

<%@ Register Src="~/Control/U_landdata.ascx" TagPrefix="uc1" TagName="U_landdata" %>
<%@ Register Src="~/Control/U_updateLandata.ascx" TagPrefix="uc1" TagName="U_updateLandata" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
    </style>
    <link rel="stylesheet" type="text/css" href="Styles/Mastermanu.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table class="contenttable" style="width:100%">
        <tr class="listtitle2">
            <td>楼栋主机管理</td>
        </tr>
        <tr class="listcontent2">
            <td style="text-align: center">
                <asp:TextBox ID="TextBox_key" runat="server" CssClass="textbox" BorderStyle="Solid" Width="40%"></asp:TextBox>
                <asp:Button ID="Button_search" runat="server" Text="搜索" BorderStyle="None" CssClass="submitbutton" Style="margin-left: 20px; font-size: 14px;" Height="25px" OnClick="Button_search_Click" />
                <%--<asp:Button ID="Button_back" runat="server" Text="返回" CssClass="submitbutton" BorderStyle="None" Style="margin-left: 20px; font-size: 14px;" Height="25px" OnClick="Button_back_Click" />--%>

            </td>
        </tr>
        <tr>
            <td>
               <table>
                   <tr>
                       <td style="vertical-align: top; text-align: center;">
<table class="contenttable">
                    <tr class="listtitle" style="padding: 0px 30px 0px 30px; border: 1px solid white;">
                        <td>
                            <asp:Button ID="Button_addlandata" runat="server" Text="添加主机" BorderStyle="None" Width="100%" Font-Bold="True" Font-Size="15px" OnClick="Button_addlandata_Click" BackColor="#0099cc" ForeColor="White" />
                        </td>
                    </tr>
                    <tr class="listtitle" style="padding: 0px 30px 0px 30px; border: 1px solid white;">
                        <td>已有主机</td>
                    </tr>
                    <tr>
                        <td style="display: table-header-group;">
                            <asp:Panel ID="Panel_area" runat="server" ScrollBars="Vertical" BorderStyle="None" CssClass="panellist" Height="500px" Width="220px">
                                <asp:Repeater ID="Repeater_landatalist" runat="server">
                                    <HeaderTemplate>
                                        <table class="contenttable">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr class="listcontent">
                                            <td>
                                                <asp:LinkButton ID="show_landataid" CommandName='<%#Eval("Id")%>' OnCommand="show_landata" runat="server" style="white-space: nowrap; text-decoration:none; " Width="100%" ForeColor="#1ea0b9"><%#Eval("Building") %></asp:LinkButton></td>
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
                             <div style="margin:0px 0px 0px 0px">
                            <uc1:U_landdata ID="U_landdata1" runat="server" Visible="False" style="display: inline-block" />
                            <uc1:U_updateLandata ID="U_updateLandata1" runat="server" Visible="False" style="display: inline-block" />
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

