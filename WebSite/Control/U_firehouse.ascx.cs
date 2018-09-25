using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.BLL;
using ttxy.Model;

public partial class Control_U_firehouse : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SysFunc sf = new SysFunc();
            IList<Area> list = new List<Area>();
            if (Session["Type"].ToString() == "0")//my.Type == 0)
            {
                list = sf.GetAreaList(false);
            }
            else
            {
                Area area = sf.GetArea(short.Parse(Session["Areaid"].ToString()));
                if (area.Type == true)
                {
                    list = sf.GetAreaList(area.Cid, false);
                }
                else
                {
                    list.Add(area);
                }
            }
            bind(list);
        }
    }

    public void bind(IList<Area> tmp)
    {
        PagedDataSource pds = new PagedDataSource();
        if (tmp != null)
        {
            pds.DataSource = tmp;
            this.DropDownList_area.DataSource = pds;
            this.DropDownList_area.DataTextField = "Name";
            this.DropDownList_area.DataValueField = "Id";
            this.DropDownList_area.DataBind();
        }
    }

    public FireHouse firehouse
    {
        get
        {
            FireHouse info = new FireHouse();

            info.Aid = short.Parse(this.DropDownList_area.SelectedValue);
            info.Name = this.TextBox_building.Text;
            info.Description = this.TextBox_address.Text;
            info.Lng = this.S_LocalSelect1.Lng;
            info.Lat = this.S_LocalSelect1.Lat;
            return info;
        }
        set
        {
            SysFunc sf = new SysFunc();
            Area area = sf.GetArea(value.Aid);
            this.S_LocalSelect1.SetCenter(area.Lng, area.Lat, area.Zoom);
        }
    }

    protected void Button_submit_Click(object sender, EventArgs e)
    {
        long result = 0;
        ExcFunc ef = new ExcFunc();
        result = ef.Addfirehouse(firehouse, int.Parse(Session["Userid"].ToString()));
        if (result > 0)
        {
            this.Label_fix_tip.Text = "数据成功提交";

            //Session["Lanid"] = result;
            this.Response.Redirect("InsertFirehouse.aspx");
        }
        else
        {
            this.Label_fix_tip.Text = "数据提交失败";
        }
    }
}