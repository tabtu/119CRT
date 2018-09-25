using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.Model;
using ttxy.BLL;

public partial class Control_U_updateFirehouse : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
        this.Label_fix_tip.Text = "";
    }

    public FireHouse firehouse
    {
        get
        {
            FireHouse info = new FireHouse();
            info.Id = short.Parse(this.Label_hide_id.Text);
            info.Aid = short.Parse(this.Label_hide_areaid.Text);
            info.Name = this.TextBox_building.Text;
            info.Description = this.TextBox_address.Text;
            info.Lng = this.S_LocalSelect1.Lng;
            info.Lat = this.S_LocalSelect1.Lat;

            return info;
        }
        set
        {
            SysFunc sf = new SysFunc();
            this.Label_hide_id.Text = value.Id.ToString();
            Area area = sf.GetArea(value.Aid);
            this.Label_area.Text = area.Name;
            this.Label_hide_areaid.Text = area.ID.ToString();
            this.TextBox_building.Text = value.Name;
            this.TextBox_address.Text = value.Description;
            this.S_LocalSelect1.SetPoint(value.Lng, value.Lat);
        }
    }

    protected void Button_submit_Click(object sender, EventArgs e)
    {
        long result = 0;

        // LanData tmp = eu.getLandata_by_name(this.TextBox_building.Text);
        // if (tmp != null && tmp.ID != int.Parse(this.Label_hide_lid.Text))
        //{
        //    this.Label_fix_tip.Text = "该小区已有信息，请勿重复添加";
        //    return;
        //}

        ExcFunc ef = new ExcFunc();
        result = ef.EditFirehouse(firehouse, int.Parse(Session["Userid"].ToString()));
        if (result > 0)
        {
            this.Label_fix_tip.Text = "数据成功更新";

            this.Response.Redirect("InsertFirehouse.aspx");

        }
        else
        {
            this.Label_fix_tip.Text = "数据提交失败";
        }
    }
}