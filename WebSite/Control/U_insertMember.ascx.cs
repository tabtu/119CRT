using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.BLL;
using ttxy.Model;

public partial class Control_U_insertMember : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SysFunc esf = new SysFunc();
            this.DropDownList_type.SelectedValue = "1";
            this.TextBox_linkid.Visible = false;
            this.DropDownList_linkid.Visible = true;
            this.Label_title.Visible = true;
            this.Label_title.Text = "部门";
            this.DropDownList_linkid.DataSource = esf.GetFireManageList();
            this.DropDownList_linkid.DataTextField = "Name";
            this.DropDownList_linkid.DataValueField = "Id";
            this.DropDownList_linkid.DataBind();
        }
    }

    protected void DropDownList_limit_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.DropDownList_type.SelectedValue == "0")
        {
            //ExSysFunction esf = new ExSysFunction();
            //this.DropDownList_linkid.DataSource = esf.ge();
            //this.DropDownList_linkid.DataTextField = "Name";
            //this.DropDownList_linkid.DataValueField = "Id";
            //this.DropDownList_linkid.DataBind();
        }
        else if (this.DropDownList_type.SelectedValue == "1")
        {
            //管理部门
            SysFunc esf = new SysFunc();
            this.TextBox_linkid.Visible = false;
            this.DropDownList_linkid.Visible = true;
            this.Label_title.Visible = true;
            this.Label_title.Text = "部门";
            this.DropDownList_linkid.DataSource = esf.GetFireManageList();
            this.DropDownList_linkid.DataTextField = "Name";
            this.DropDownList_linkid.DataValueField = "Id";
            this.DropDownList_linkid.DataBind();
        }
        else if (this.DropDownList_type.SelectedValue == "2")
        {
            //战斗部队
            SysFunc esf = new SysFunc();
            this.TextBox_linkid.Visible = false;
            this.DropDownList_linkid.Visible = true;
            this.Label_title.Visible = true;
            this.Label_title.Text = "部门";
            this.DropDownList_linkid.DataSource = esf.GetFireHouseList();
            this.DropDownList_linkid.DataTextField = "Name";
            this.DropDownList_linkid.DataValueField = "Id";
            this.DropDownList_linkid.DataBind();
        }
        else if (this.DropDownList_type.SelectedValue == "3")
        {
            //监控中心
            SysFunc esf = new SysFunc();
            this.TextBox_linkid.Visible = false;
            this.DropDownList_linkid.Visible = true;
            this.Label_title.Visible = true;
            this.Label_title.Text = "部门";
            this.DropDownList_linkid.DataSource = esf.GetControlCenterList();
            this.DropDownList_linkid.DataTextField = "Name";
            this.DropDownList_linkid.DataValueField = "Id";
            this.DropDownList_linkid.DataBind();
        }
        else if (this.DropDownList_type.SelectedValue == "4")
        {
            //维护公司
            SysFunc esf = new SysFunc();
            this.TextBox_linkid.Visible = false;
            this.DropDownList_linkid.Visible = true;
            this.Label_title.Visible = true;
            this.Label_title.Text = "部门";
            this.DropDownList_linkid.DataSource = esf.GetMaintenance();
            this.DropDownList_linkid.DataTextField = "Name";
            this.DropDownList_linkid.DataValueField = "Id";
            this.DropDownList_linkid.DataBind();
        }
        else if (this.DropDownList_type.SelectedValue == "5")
        {
            //物业公司
            SysFunc esf = new SysFunc();
            this.TextBox_linkid.Visible = false;
            this.DropDownList_linkid.Visible = true;
            this.Label_title.Visible = true;
            this.Label_title.Text = "部门";
            this.DropDownList_linkid.DataSource = esf.GetProperty();
            this.DropDownList_linkid.DataTextField = "Name";
            this.DropDownList_linkid.DataValueField = "Id";
            this.DropDownList_linkid.DataBind();
        }
        else if (this.DropDownList_type.SelectedValue == "6")
        {
            //消防主机
            SysFunc esf = new SysFunc();
            this.TextBox_linkid.Visible = true;
            this.DropDownList_linkid.Visible = false;
            this.Label_title.Visible = true;
            this.Label_title.Text = "HOST_ID";
        }
        else
        {
            //this.Label_type.Text = "未知权限";
        }
    }

    public Members member
    {
        get
        {
            Members info = new Members();
            info.Account = this.TextBox_account.Text;
            info.Name = this.TextBox_name.Text;
            info.Tel = this.TextBox_tel.Text;
            info.Password = "123456";
            info.Type = short.Parse(this.DropDownList_type.SelectedValue);
            if (info.Type != 6)
            {
                info.LinkId = short.Parse(this.DropDownList_linkid.SelectedValue);
            }
            else
            {
                info.LinkId = short.Parse(this.TextBox_linkid.Text);
            }
            info.Isused = true;
            return info;
        }
    }

    protected void Button_submit_Click(object sender, EventArgs e)
    {
        int result = 0;
        UseFunc uf = new UseFunc();
        if (!uf.userCheck(member.Account))
        {
            this.Label_fix_tip.Text = "该账号已被占用";
            return;
        }
        ExcFunc ef = new ExcFunc();
        result = ef.Addmembers(member, int.Parse(Session["Userid"].ToString()));
        if (result > 0)
        {
            this.Label_fix_tip.Text = "数据成功提交";
            //Session["Lanid"] = result;
            this.Response.Redirect("U_Manager.aspx");
        }
        else
        {
            this.Label_fix_tip.Text = "数据提交失败";
        }
    }
}