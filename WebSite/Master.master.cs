using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.BLL;

public partial class Master : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Userid"] != null && Session["Type"] != null)
        {
            if (Session["Account"] == Session["Password"] && Session["Name"] != null)
            {
                this.Label_user.Text = Session["Name"].ToString();
                //if (Session["ErrorHost"] == null)
                //{
                //    Session["ErrorHost"] = this.Label_state.Text;
                //}
                //btn_epn_Click(null, null);
                return;
            }
            else
            {
                Response.Write("<script language='javascript'>alert('认证失败, 请重新登录.'); location.href='Default.aspx'</script>");
            }
        }
        else
        {
            Response.Write("<script language='javascript'>alert('断开连接，请重新登录.'); location.href='Default.aspx'</script>");
        }
    }

    //protected void Button_logovisible_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (this.Manutree1.Visible == false)
    //    {
    //        this.Manutree1.Visible = true;
    //    }
    //    else
    //    {
    //        this.Manutree1.Visible = false;
    //    }
    //}

    //protected int CheckEquipments()
    //{
    //    EpControl ec = new EpControl();
    //    return ec.host_state_num('0');
    //}

    //protected void btn_epn_Click(object sender, ImageClickEventArgs e)
    //{
    //    EpControl ec = new EpControl();
    //    this.Label_state.Text = ec.host_state_num('0').ToString();
    //    if (this.Label_state.Text != Session["ErrorHost"].ToString())
    //    {
    //        Response.Write("<script language='javascript'>alert('当前告警主机数为：" + this.Label_state.Text + "');</script>");
    //        Session["ErrorHost"] = this.Label_state.Text;
    //    }
    //}
}
