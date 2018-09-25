<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="NodeDetail.aspx.cs" Inherits="Default2" %>

<%@ Register src="Control/U_landetail.ascx" tagname="U_landetail" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table class="contenttable" style="width: 1250px">
        <tr class="listtitle2">
            <td>楼层平面图</td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td style="vertical-align: top; text-align: center;">
                            <table class="contenttable">
                                <tr class="listtitle" style="padding: 0px 30px 0px 30px; border: 1px solid white;">
                                    <td>可选楼层</td>
                                </tr>
                                <tr>
                                    <td style="display: table-header-group;">
                                        <asp:Panel ID="Panel_area" runat="server" ScrollBars="Vertical" BorderStyle="None" CssClass="panellist" Height="528px" Width="220px">
                                            <asp:Repeater ID="Detail_building" runat="server">
                                                <HeaderTemplate>
                                                    <table class="contenttable">
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr class="listcontent">
                                                        <td>
                                                            <asp:LinkButton ID="show_buildingid" CommandName='<%#Eval("Id")%>' OnCommand="show_building" runat="server" Style="white-space: nowrap; text-decoration: none;" Width="100%" ForeColor="#1ea0b9"><%#Eval("PicName") %></asp:LinkButton></td>
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
                            <div style="margin-left: 0px">
                                <asp:Label ID="Label_maptitle1" runat="server" Text=""></asp:Label>
                                <asp:Label ID="Label_maptitle2" runat="server" Text=""></asp:Label>
                                <br />
                                <asp:Literal ID="Literal_map" runat="server"></asp:Literal>
                                <uc1:U_landetail ID="U_landetail1" runat="server" />
                                <br />
                                <asp:Button ID="Button_submit" runat="server" BorderStyle="None" CssClass="submitbutton" Height="25px" OnClick="Button_submit_Click" Text="显示模拟警报地图" />
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

