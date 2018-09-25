using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Type"] == null)
        {
            Response.Write("<script language='javascript'>alert('连接超时，请重新登录.'); location.href='Loginpage.aspx'</script>");
        }
        if (int.Parse(Session["Type"].ToString()) != 0)
        {
            Response.Write("<script language='javascript'>alert('该账号无此操作权限.'); location.href='HomePage.aspx'</script>");
        }
        if (!IsPostBack)
        {
            this.SM_area1.Visible = false;
            this.SM_city1.Visible = false;
            this.SM_controlcenter1.Visible = false;
            this.SM_equipstatus1.Visible = false;
            this.SM_lancate1.Visible = false;
            this.SM_lantype1.Visible = false;
            this.UM_equiptype1.Visible = false;
            this.UM_firemanage1.Visible = false;
            this.UM_maintenance1.Visible = false;
            this.UM_property1.Visible = false;
        }
    }

    protected void Button_cc_Click(object sender, EventArgs e)
    {
        this.SM_area1.Visible = false;
        this.SM_city1.Visible = false;
        this.SM_controlcenter1.Visible = true;
        this.SM_equipstatus1.Visible = false;
        this.SM_lancate1.Visible = false;
        this.SM_lantype1.Visible = false;
        this.UM_equiptype1.Visible = false;
        this.UM_firemanage1.Visible = false;
        this.UM_maintenance1.Visible = false;
        this.UM_property1.Visible = false;
    }

    protected void Button_es_Click(object sender, EventArgs e)
    {
        this.SM_area1.Visible = false;
        this.SM_city1.Visible = false;
        this.SM_controlcenter1.Visible = false;
        this.SM_equipstatus1.Visible = true;
        this.SM_lancate1.Visible = false;
        this.SM_lantype1.Visible = false;
        this.UM_equiptype1.Visible = false;
        this.UM_firemanage1.Visible = false;
        this.UM_maintenance1.Visible = false;
        this.UM_property1.Visible = false;
    }

    protected void Button_lc_Click(object sender, EventArgs e)
    {
        this.SM_area1.Visible = false;
        this.SM_city1.Visible = false;
        this.SM_controlcenter1.Visible = false;
        this.SM_equipstatus1.Visible = false;
        this.SM_lancate1.Visible = true;
        this.SM_lantype1.Visible = false;
        this.UM_equiptype1.Visible = false;
        this.UM_firemanage1.Visible = false;
        this.UM_maintenance1.Visible = false;
        this.UM_property1.Visible = false;
    }

    protected void Button_lt_Click(object sender, EventArgs e)
    {
        this.SM_area1.Visible = false;
        this.SM_city1.Visible = false;
        this.SM_controlcenter1.Visible = false;
        this.SM_equipstatus1.Visible = false;
        this.SM_lancate1.Visible = false;
        this.SM_lantype1.Visible = true;
        this.UM_equiptype1.Visible = false;
        this.UM_firemanage1.Visible = false;
        this.UM_maintenance1.Visible = false;
        this.UM_property1.Visible = false;
    }

    protected void Button_c_Click(object sender, EventArgs e)
    {
        this.SM_area1.Visible = false;
        this.SM_city1.Visible = true;
        this.SM_controlcenter1.Visible = false;
        this.SM_equipstatus1.Visible = false;
        this.SM_lancate1.Visible = false;
        this.SM_lantype1.Visible = false;
        this.UM_equiptype1.Visible = false;
        this.UM_firemanage1.Visible = false;
        this.UM_maintenance1.Visible = false;
        this.UM_property1.Visible = false;
    }

    protected void Button_a_Click(object sender, EventArgs e)
    {
        this.SM_area1.Visible = true;
        this.SM_city1.Visible = false;
        this.SM_controlcenter1.Visible = false;
        this.SM_equipstatus1.Visible = false;
        this.SM_lancate1.Visible = false;
        this.SM_lantype1.Visible = false;
        this.UM_equiptype1.Visible = false;
        this.UM_firemanage1.Visible = false;
        this.UM_maintenance1.Visible = false;
        this.UM_property1.Visible = false;
    }

    protected void Button_et_Click(object sender, EventArgs e)
    {
        this.SM_area1.Visible = false;
        this.SM_city1.Visible = false;
        this.SM_controlcenter1.Visible = false;
        this.SM_equipstatus1.Visible = false;
        this.SM_lancate1.Visible = false;
        this.SM_lantype1.Visible = false;
        this.UM_equiptype1.Visible = true;
        this.UM_firemanage1.Visible = false;
        this.UM_maintenance1.Visible = false;
        this.UM_property1.Visible = false;
    }

    protected void Button_fm_Click(object sender, EventArgs e)
    {
        this.SM_area1.Visible = false;
        this.SM_city1.Visible = false;
        this.SM_controlcenter1.Visible = false;
        this.SM_equipstatus1.Visible = false;
        this.SM_lancate1.Visible = false;
        this.SM_lantype1.Visible = false;
        this.UM_equiptype1.Visible = false;
        this.UM_firemanage1.Visible = true;
        this.UM_maintenance1.Visible = false;
        this.UM_property1.Visible = false;
    }

    protected void Button_m_Click(object sender, EventArgs e)
    {
        this.SM_area1.Visible = false;
        this.SM_city1.Visible = false;
        this.SM_controlcenter1.Visible = false;
        this.SM_equipstatus1.Visible = false;
        this.SM_lancate1.Visible = false;
        this.SM_lantype1.Visible = false;
        this.UM_equiptype1.Visible = false;
        this.UM_firemanage1.Visible = false;
        this.UM_maintenance1.Visible = true;
        this.UM_property1.Visible = false;
    }

    protected void Button_p_Click(object sender, EventArgs e)
    {
        this.SM_area1.Visible = false;
        this.SM_city1.Visible = false;
        this.SM_controlcenter1.Visible = false;
        this.SM_equipstatus1.Visible = false;
        this.SM_lancate1.Visible = false;
        this.SM_lantype1.Visible = false;
        this.UM_equiptype1.Visible = false;
        this.UM_firemanage1.Visible = false;
        this.UM_maintenance1.Visible = false;
        this.UM_property1.Visible = true;
    }
}