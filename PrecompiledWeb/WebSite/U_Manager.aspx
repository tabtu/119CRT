<%@ page title="" language="C#" masterpagefile="~/Master.master" autoeventwireup="true" inherits="Default2, App_Web_lmud1zlv" %>



<%@ Register src="Control/U_insertMember.ascx" tagname="U_insertMember" tagprefix="uc2" %>

<%@ Register src="Control/U_Member.ascx" tagname="U_Member" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
        <table class="contenttable" style="width:100%">
        <tr class="listtitle2">
            <td>用户资料管理</td>
        </tr>
        <tr class="listcontent2">
            <td style="text-align: center">
                <asp:TextBox ID="TextBox_key" runat="server" CssClass="textbox" BorderStyle="Solid" Width="40%"></asp:TextBox>
                <asp:Button ID="Button_search" runat="server" Text="搜索" BorderStyle="None" CssClass="submitbutton" Style="margin-left: 20px; font-size: 14px;" Height="25px" OnClick="Button_search_Click"/>

            </td>
        </tr>
        <tr>
            <td>
               <table>
                   <tr>
                       <td style="vertical-align: top; text-align: center;>
<table class="contenttable">
                    <tr class="listtitle" style="padding: 0px 30px 0px 30px; border: 1px solid white;">
                        <td>
                            <asp:Button ID="Button_addmember" runat="server" Text="添加用户" BorderStyle="None" Width="100%" Font-Bold="True" Font-Size="15px" BackColor="#0099cc" ForeColor="White" OnClick="Button_addmember_Click" />
                        </td>
                    </tr>
                    <tr class="listtitle" style="padding: 0px 30px 0px 30px; border: 1px solid white;">
                        <td>已有用户</td>
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
                                                <asp:LinkButton ID="show_memberid" CommandName='<%#Eval("Id")%>' OnCommand="show_member" runat="server" style="white-space: nowrap; text-decoration:none; " Width="100%" ForeColor="#1ea0b9"><%#Eval("Name") %></asp:LinkButton></td>
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
                                 
                                 <uc2:U_insertMember ID="U_insertMember1" runat="server" />
                                 <uc1:U_Member ID="U_Member1" runat="server" />
                                 
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

