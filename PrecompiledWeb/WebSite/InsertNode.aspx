<%@ page title="" language="C#" masterpagefile="~/Master.master" autoeventwireup="true" inherits="Default2, App_Web_wcxgfh0a" %>

<%@ Register src="Control/U_nodedata.ascx" tagname="U_nodedata" tagprefix="uc1" %>
<%@ Register src="Control/U_updateNodedata.ascx" tagname="U_updateNodedata" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="contenttable" style="width:1250px">
        <tr class="listtitle2">
            <td>楼栋主机管理</td>
        </tr>
      

         <tr>
            <td style="vertical-align: top; text-align: center;>
              <table>
                  <tr>
                      <td style="vertical-align: top; text-align: center;>
                          <table class="contenttable">
                    <tr class="listtitle" style="padding: 0px 30px 0px 30px; border: 1px solid white;">
                        <td>
                            <asp:Button ID="Button_addnode" runat="server" Text="添加楼层" BorderStyle="None" Width="100%" Font-Bold="True" Font-Size="15px" OnClick="Button_addnodedata_Click" BackColor="#0099cc" ForeColor="White" />
                        </td>
                    </tr>
                    <tr class="listtitle" style="padding: 0px 30px 0px 30px; border: 1px solid white;">
                        <td>现有数据</td>
                    </tr>
                    <tr>
                        <td style="display: table-header-group;">
                            <asp:Panel ID="Panel_area" runat="server" ScrollBars="Vertical" BorderStyle="None" CssClass="panellist" Height="528px" Width="220px">
                                <asp:Repeater ID="Repeater_nodelist" runat="server">
                                    <HeaderTemplate>
                                        <table class="contenttable">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr class="listcontent">
                                            <td>
                                                <asp:LinkButton ID="show_landataid" CommandName='<%#Eval("Id")%>' OnCommand="show_nodedata" runat="server" style="white-space: nowrap; text-decoration:none; " Width="100%" ForeColor="#1ea0b9"><%#Eval("PicName") %></asp:LinkButton></td>
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
                                 <uc1:U_nodedata ID="U_nodedata1" runat="server" />
                                 <br />
                                 <uc2:U_updateNodedata ID="U_updateNodedata1" runat="server" />
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

