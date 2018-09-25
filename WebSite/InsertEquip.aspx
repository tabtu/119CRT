<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="InsertEquip.aspx.cs" Inherits="Default2" %>

<%@ Register Src="Control/U_equipdata.ascx" TagName="U_equipdata" TagPrefix="uc1" %>
<%@ Register Src="Control/U_updateEquipdata.ascx" TagName="U_updateEquipdata" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <table class="contenttable" style="width: 1360px">
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
                                        <asp:Button ID="Button_addequip" runat="server" Text="增加设备" BorderStyle="None" Width="100%" Font-Bold="True" Font-Size="15px" OnClick="Button_addequip_Click" BackColor="#0099cc" ForeColor="White" />
                                    </td>
                                </tr>
                                <tr class="listtitle" style="padding: 0px 30px 0px 30px; border: 1px solid white;">
                                    <td>现有设备</td>
                                </tr>
                                <tr>
                                    <td style="display: table-header-group;">
                                        <asp:Panel ID="Panel_area" runat="server" ScrollBars="Vertical" BorderStyle="None" CssClass="panellist" Height="528px" Width="220px">
                                            <asp:Repeater ID="Repeater_equiplist" runat="server">
                                                <HeaderTemplate>
                                                    <table class="contenttable">
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr class="listcontent">
                                                        <td>
                                                            <asp:LinkButton ID="show_equipid" CommandName='<%#Eval("Id")%>' OnCommand="show_equip" runat="server" Style="white-space: nowrap; text-decoration: none;" Width="100%" ForeColor="#1ea0b9"><%#Eval("Description") %></asp:LinkButton></td>
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
                            <div style="margin: 0px 0px 0px 0px">

                                 <uc1:U_equipdata ID="U_equipdata1" runat="server" />
                                 <br />
                                 <uc2:U_updateEquipdata ID="U_updateEquipdata1" runat="server" />

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

