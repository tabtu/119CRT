<%@ control language="C#" autoeventwireup="true" inherits="Control_U_newstitlelist, App_Web_4kv54lqz" %>

<style type="text/css">
        .tablefull {
         margin: 0px 0% 0px 0%;/*外围边框上右下左*/
         width: 100%;
         margin-top: 0px;
         text-align: center;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="~/Styles/Mastermanu.css" />
            <asp:Panel ID="Panel_news" runat="server" ScrollBars="Vertical" BorderStyle="None" CssClass="panellist" style="width:99%">
                <asp:Repeater ID="Repeater_newstitlelist" runat="server">
                    <HeaderTemplate>

                        <table>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <tr class="listcontent">
                            <td style="text-align:left">
                             <asp:LinkButton ID="show_newstitle" CommandName='<%#Eval("Id")%>' OnCommand="show_newstitle" runat="server" style="color: white;white-space: nowrap; text-decoration:none; margin-left:10px;" Width="100%" ><%#Eval("Title") %></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </asp:Panel>