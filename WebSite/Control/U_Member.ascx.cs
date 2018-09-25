using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

using ttxy.BLL;
using ttxy.Model;

public partial class Control_U_Member : System.Web.UI.UserControl
{
    public Members member
    {
        //get
        //{
        //    if (this.TextBox_name.Text == "" || this.TextBox_account.Text == "")
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        Members tmp = new Members();
        //        tmp.Id = int.Parse(this.Label_id.Text);
        //        tmp.Name = this.TextBox_name.Text;
        //        tmp.Account = this.TextBox_account.Text;
        //        tmp.LinkId = short.Parse(this.DropDownList_linkid.SelectedValue);
        //        tmp.Tel = this.TextBox_tel.Text;
        //        tmp.Type = short.Parse(this.DropDownList_type.SelectedValue);
        //        tmp.Password = this.Label_pw.Text;
        //        if (this.DropDownList_isused.SelectedItem.Value == "True")
        //        {
        //            tmp.Isused = true;
        //        }
        //        else
        //        {
        //            tmp.Isused = false;
        //        }
        //       return tmp;
        //    }
        //}
        set
        {
            this.TextBox_name.Text = value.Name;
            this.TextBox_account.Text = value.Account;
            SysFunc esf = new SysFunc();
            //this.Label_linkid.Text = esf.GetOrgan(value.LinkId).Name;
            //this.Label_id.Text = value.Id.ToString();
            //this.Label_pw.Text = value.Password;
            //this.DropDownList_linkid.SelectedValue = value.LinkId.ToString();
            //this.DropDownList_isused.SelectedValue = value.Isused.ToString();
            //this.DropDownList_type.SelectedValue = value.Type.ToString();

            if (value.Tel == "")
            {
                this.TextBox_tel.Text = "0";
            }
            else
            {
                this.TextBox_tel.Text = value.Tel;
            }

            // 账号类型判断
            if (value.Type == 0)
            {
                this.Label_type.Text = "超级管理员";
            }
            else if (value.Type == 1)
            {
                this.Label_type.Text = "管理部门";
            }
            else if (value.Type == 2)
            {
                this.Label_type.Text = "战斗部队";
            }
            else if (value.Type == 3)
            {
                this.Label_type.Text = "监控中心";
            }
            else if (value.Type == 4)
            {
                this.Label_type.Text = "维护公司";
            }
            else if (value.Type == 5)
            {
                this.Label_type.Text = "物业公司";
            }
            else if (value.Type == 6)
            {
                this.Label_type.Text = "消防主机";
            }
            else
            {
                this.Label_type.Text = "未知权限";
            }


            if (value.Isused)
            {
                this.Label_isused.Text = "在用";
            }
            else
            {
                this.Label_isused.Text = "无效";
            }
        }
    }

    //public void Set_ReadOnly(bool suo)//只读设置
    //{
    //    this.TextBox_name.ReadOnly = suo;
    //    this.TextBox_tel.ReadOnly = suo;
    //    this.TextBox_account.ReadOnly = suo;
    //    this.Label_dis_pw.Visible = suo;

    //    this.Label_type.Visible = suo;
    //    this.DropDownList_type.Visible = !suo;

    //    this.Label_linkid.Visible = suo;
    //    this.DropDownList_linkid.Visible = !suo;

    //    this.Label_isused.Visible = suo;
    //    this.DropDownList_isused.Visible = !suo;

    //    if (!suo)
    //    {
    //        this.TextBox_name.ForeColor = Color.Black;
    //        this.TextBox_tel.ForeColor = Color.Black;
    //        this.TextBox_account.ForeColor = Color.Black;
    //    }
    //    else
    //    {
    //        this.TextBox_name.ForeColor = Color.FromName("#6aac9d");
    //        this.TextBox_tel.ForeColor = Color.FromName("#6aac9d");
    //        this.TextBox_account.ForeColor = Color.FromName("#6aac9d");
    //    }


    //}

    //protected void DropDownList_limit_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (this.DropDownList_type.SelectedValue == "0")
    //    {
    //        //ExSysFunction esf = new ExSysFunction();
    //        //this.DropDownList_linkid.DataSource = esf.ge();
    //        //this.DropDownList_linkid.DataTextField = "Name";
    //        //this.DropDownList_linkid.DataValueField = "Id";
    //        //this.DropDownList_linkid.DataBind();
    //        //this.Label_title.Visible = false;
    //        //this.DropDownList_linkid.Visible = false;

    //    }
    //    else if (this.DropDownList_type.SelectedValue == "1")
    //    {
    //        SysFunc esf = new SysFunc();
    //        this.TextBox_linkid.Visible = false;
    //        this.DropDownList_linkid.Visible = true;
    //        this.Label_title.Visible = true;
    //        this.Label_title.Text = "部门";
    //        this.DropDownList_linkid.DataSource = esf.GetFireManageList();
    //        this.DropDownList_linkid.DataTextField = "Name";
    //        this.DropDownList_linkid.DataValueField = "Id";
    //        this.DropDownList_linkid.DataBind();
    //    }
    //    else if (this.DropDownList_type.SelectedValue == "2")
    //    {
    //        SysFunc esf = new SysFunc();
    //        this.TextBox_linkid.Visible = false;
    //        this.DropDownList_linkid.Visible = true;
    //        this.Label_title.Visible = true;
    //        this.Label_title.Text = "部门";
    //        this.DropDownList_linkid.DataSource = esf.GetFireHouseList();
    //        this.DropDownList_linkid.DataTextField = "Name";
    //        this.DropDownList_linkid.DataValueField = "Id";
    //        this.DropDownList_linkid.DataBind();
    //    }
    //    else if (this.DropDownList_type.SelectedValue == "3")
    //    {
    //        SysFunc esf = new SysFunc();
    //        this.TextBox_linkid.Visible = false;
    //        this.DropDownList_linkid.Visible = true;
    //        this.Label_title.Visible = true;
    //        this.Label_title.Text = "部门";
    //        this.DropDownList_linkid.DataSource = esf.GetControlCenterList();
    //        this.DropDownList_linkid.DataTextField = "Name";
    //        this.DropDownList_linkid.DataValueField = "Id";
    //        this.DropDownList_linkid.DataBind();
    //    }
    //    else if (this.DropDownList_type.SelectedValue == "4")
    //    {
    //        //维护公司
    //        SysFunc esf = new SysFunc();
    //        this.TextBox_linkid.Visible = false;
    //        this.DropDownList_linkid.Visible = true;
    //        this.Label_title.Visible = true;
    //        this.Label_title.Text = "部门";
    //        this.DropDownList_linkid.DataSource = esf.GetMaintenance();
    //        this.DropDownList_linkid.DataTextField = "Name";
    //        this.DropDownList_linkid.DataValueField = "Id";
    //        this.DropDownList_linkid.DataBind();
    //    }
    //    else if (this.DropDownList_type.SelectedValue == "5")
    //    {
    //        //物业公司
    //        SysFunc esf = new SysFunc();
    //        this.TextBox_linkid.Visible = false;
    //        this.DropDownList_linkid.Visible = true;
    //        this.Label_title.Visible = true;
    //        this.Label_title.Text = "部门";
    //        this.DropDownList_linkid.DataSource = esf.GetProperty();
    //        this.DropDownList_linkid.DataTextField = "Name";
    //        this.DropDownList_linkid.DataValueField = "Id";
    //        this.DropDownList_linkid.DataBind();
    //    }
    //    else if (this.DropDownList_type.SelectedValue == "6")
    //    {
    //        //消防主机
    //        //SysFunc esf = new SysFunc();
    //        //this.DropDownList_linkid.DataSource = esf.GetFireManageList();
    //        //this.DropDownList_linkid.DataTextField = "Name";
    //        //this.DropDownList_linkid.DataValueField = "Id";
    //        //this.DropDownList_linkid.DataBind();
    //        this.Label_title.Visible = true;
    //        this.Label_title.Text = "HOST_ID";
    //        this.DropDownList_linkid.Visible = false;
    //        this.TextBox_linkid.Visible = true;
    //    }
    //    else
    //    {
    //        //this.Label_type.Text = "未知权限";
    //    }
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["Userid"] == null || Session["WebType"] == null)
        //{
        //    Response.Write("<script language='javascript'>alert('请重新登录.'); location.href='Default.aspx'</script>");
        //}

        if (!IsPostBack)
        {
        //    if (Session["WebType"].ToString() == "Myself")
        //    {
        //        this.Button_formatpw.Visible = false;
        //    }

        //    organbind();
            //this.Label_title.Visible = false;
            //this.TextBox_linkid.Visible = false;
            //this.DropDownList_linkid.Visible = false;
            //this.Label_title.Visible = false;
        }
    }

    protected void Button_formatpw_Click(object sender, EventArgs e)
    {
        //if (Session["Userid"] == null || Session["Memberid"] == null || Session["WebType"] == null)
        //{
        //    Response.Write("<script language='javascript'>alert('请重新登录.'); location.href='Default.aspx'</script>");
        //}

        if (this.Label_id.Text != "0")
        {
            ExcFunc euf = new ExcFunc();
            int result = euf.InitePassword(int.Parse(Session["Userid"].ToString()));

            //判断于底层返回值0重复，-1失败，other为id成功
            if (result > 0)
            {
                //if (Session["WebType"].ToString() == "Role")
                //{
                    Response.Write("<script language='javascript'>alert('初始化密码123456成功。'); location.href='U_Manager.aspx'</script>");
                //}
                //else
                //{
                //    Response.Write("<script language='javascript'>alert('初始化密码成功。'); location.href='用户信息.aspx'</script>");

                //}
            }
            else
            {
                //if (Session["WebType"].ToString() == "Role")
                //{
                    Response.Write("<script language='javascript'>alert('初始化密码123456失败。'); location.href='U_Manager.aspx'</script>");

                //}
                //else
                //{
                //    Response.Write("<script language='javascript'>alert('初始化密码失败。'); location.href='用户信息.aspx'</script>");

                //}

            }
        }
    }

    protected void Button_submit_Click(object sender, EventArgs e)
    {

    }
}