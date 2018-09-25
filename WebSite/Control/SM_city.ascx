﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SM_city.ascx.cs" Inherits="Control_SM_city" %>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" Height="285px" 
            onrowcancelingedit="GridView1_RowCancelingEdit" 
            onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
            onrowupdating="GridView1_RowUpdating" Width="771px">
            <FooterStyle BackColor="#268cbd" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="cityname" HeaderText="城市名称" />
                <asp:BoundField DataField="sort" HeaderText="排序" />
                <asp:CheckBoxField DataField="isused" HeaderText="有效" />
                <asp:CommandField HeaderText="编辑 " ShowEditButton="True" />
                <asp:TemplateField HeaderText="删除 " ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandName="Delete" Text="删除" OnClientClick="return confirm('你确定要删除吗？')"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
<asp:Button ID="Button_add" runat="server" OnClick="Button_add_Click" Text="add" />
