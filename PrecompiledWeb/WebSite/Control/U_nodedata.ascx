<%@ control language="C#" autoeventwireup="true" inherits="Control_U_nodedata, App_Web_nw3enn3a" %>

<%@ Register src="S_MapSelect.ascx" tagname="S_MapSelect" tagprefix="uc1" %>

<style type="text/css">

    .tdtitle {
        width: 90px;
    }
</style>

<table class="contenttable">
    <tr>
        <td>
            <table class="contenttable">
                <tr class="listcontent2">
                    <td>
                        <table class="contenttable">
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    所属建筑</td>
                                <td>
                                    <asp:Label ID="Label_building" runat="server"></asp:Label>
                                    <asp:Label ID="Label_hide_lid" runat="server" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    楼层名称</td>
                                <td>
                                    <asp:TextBox ID="TextBox_picname" runat="server" MaxLength="32 "  CssClass="textbox1" Style="ime-mode: disabled"></asp:TextBox>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    建筑平面图</td>
                                <td>
                                    <asp:Image ID="Image_map" runat="server" />
                                    <br />
                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="textbox1" Width="95%" /> 
                                    <br />
                                    <asp:Button ID="Button_upload" runat="server" BorderStyle="None" CssClass="submitbutton1" Text="上传" OnClick="Button_upload_Click" />
                                    <asp:Label ID="Label_hide_filename" runat="server" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    图片描述</td>
                                <td>
                                    <asp:TextBox ID="TextBox_picdes" runat="server" MaxLength="200" CssClass="textbox1" Style="ime-mode: disabled"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="listcontent2">
                                <td class="tdtitle">
                                    楼层描述</td>
                                <td>
                                    <asp:TextBox ID="TextBox_des" runat="server" MaxLength="200"  CssClass="textbox1" Style="ime-mode: disabled"></asp:TextBox>
                                     <%--Onkeyup="value=value.replace(/[\W]/g,'')" onkeypress="if (event.keyCode < 48 || event.keyCode >57) event.returnValue = false;"--%>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="text-align: center">
            <asp:Label ID="Label_fix_tip" runat="server" ForeColor="Red" Text="" CssClass="label"></asp:Label>
            <br />
            <asp:Button ID="Button_submit" runat="server" Text="提交" OnClick="Button_submit_Click" BorderStyle="None" CssClass="submitbutton"/>
        </td>
    </tr>
</table>
