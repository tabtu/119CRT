<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="QuotaReport.aspx.cs" Inherits="Default2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="~/Styles/DefaultStyle.css" />
    <link rel="stylesheet" type="text/css" href="Styles/Mastermanu.css" />

 <style> 
table{ text-align:center} 
.div{ margin:0 auto; width:400px; height:100px; border:1px solid #F00} 
</style> 
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem Value="0">请选择</asp:ListItem>
        <asp:ListItem Value="1">按区域</asp:ListItem>
        <asp:ListItem Value="2">按维系单位</asp:ListItem>
        <asp:ListItem Value="3">按设备</asp:ListItem>
    </asp:DropDownList>
    <table class="div" style="width: 1250px">
        <tr>
            <td>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
                </td>
            </tr>
        </table>
</asp:Content>

