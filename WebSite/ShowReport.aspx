<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="ShowReport.aspx.cs" Inherits="报表展示" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" type="text/css" href="Styles/Mastermanu.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table class="contenttable" style="width: 1250px">
        <tr class="listtitle2">
            <td>报表展示</td>
        </tr>
        <tr class="listcontent2">
            <td style="text-align: center">
                <asp:Label ID="Label_diqu_dis" runat="server" Text="区域" Width="60px" BorderStyle="None" CssClass="label2" Style="margin: 0px 20px 0px 40px; font-size: 16px;" Height="25px"></asp:Label>
                <asp:DropDownList ID="DropDownList_area" runat="server" BorderStyle="Solid" CssClass="textbox" Width="10%">
                </asp:DropDownList>

                <asp:Label ID="Label_jzpj_dis" runat="server" Text="竞争评级:" Width="60px" BorderStyle="None" CssClass="label2" Style="margin: 0px 20px 0px 40px; font-size: 16px;" Height="25px"></asp:Label>
                <asp:DropDownList ID="DropDownList_jzpj" runat="server" CssClass="textbox" BorderStyle="Solid" Width="10%">
                    <asp:ListItem Value="-1">全部</asp:ListItem>
                    <asp:ListItem Value="0">优秀</asp:ListItem>
                    <asp:ListItem Value="1">合格</asp:ListItem>
                    <asp:ListItem Value="2">较差</asp:ListItem>
                </asp:DropDownList>

                <asp:Label ID="Label_rzl_dis" runat="server" Text="入住率:" Width="60px" BorderStyle="None" CssClass="label2" Style="margin: 0px 20px 0px 40px; font-size: 16px;" Height="25px"></asp:Label>
                <asp:TextBox ID="TextBox_rzllow" runat="server" MaxLength="7" BorderStyle="Solid" CssClass="textbox" Width="6%" Style="ime-mode: disabled" Onkeyup="value=value.replace(/[\W]/g,'')" onkeypress="if (event.keyCode < 48 || event.keyCode >57) event.returnValue = false;"></asp:TextBox>
                <asp:Label ID="Label_dis_bfh1" runat="server" Text="%&nbsp — &nbsp" Width="20px" BorderStyle="None" CssClass="label2" Style="font-size: 16px;" Height="25px"></asp:Label>
                <asp:TextBox ID="TextBox_rzlhigh" runat="server" MaxLength="7" BorderStyle="Solid" CssClass="textbox" Width="6%" Style="margin: 0px 0px 0px 30px; ime-mode: disabled" Onkeyup="value=value.replace(/[\W]/g,'')" onkeypress="if (event.keyCode < 48 || event.keyCode >57) event.returnValue = false;"></asp:TextBox>
                <asp:Label ID="Label_dis_bfh2" runat="server" Text="%" Width="20px" BorderStyle="None" CssClass="label2" Style="font-size: 16px;" Height="25px"></asp:Label>
                
                <asp:Button ID="Button_submit" runat="server" OnClick="Button_submit_Click" Text="查询" Width="50px" BorderStyle="None" CssClass="submitbutton" Style="margin: 0px 20px 0px 40px; font-size: 14px;" Height="25px" />

                <asp:Button ID="Button_download" runat="server" Text="下载报表" OnClick="Button_download_Click" Visible="False" BorderStyle="None" CssClass="submitbutton" Style="margin: 0px 20px 0px 40px; font-size: 14px;" Height="25px" />

            </td>
        </tr>
        <tr class="listtitle">
            <td>
                <asp:Label ID="Label_date_dis" runat="server" Text="结果数据:"></asp:Label>
            </td>
        </tr>
        <tr class="listcontent">
            <td>
                <asp:Panel ID="Panel_landate" runat="server" Height="570px" Width="100%" ScrollBars="Both" BackColor="White" Font-Underline="False">
                     <asp:Label ID="Label_notic" runat="server" ForeColor="Red" Text="" CssClass="label"></asp:Label>
                <asp:GridView ID="GridView_report" runat="server" Width="99%" GridLines="Both" HeaderStyle-Width="100%">
                        <HeaderStyle HorizontalAlign="Center" />
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle Wrap="False" />
                    </asp:GridView>
                   </asp:Panel>
            </td>
        </tr>
    </table>

</asp:Content>

