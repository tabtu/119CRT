using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.BLL;
using ttxy.Model;

public partial class Control_S_Menu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Type"] == null || Session["Areaid"] == null)
        {
            Response.Write("<script language='javascript'>alert('连接超时，请重新登录.'); location.href='Loginpage.aspx'</script>");
        }
        if (!IsPostBack)
        {
            IList<Area> list = new List<Area>();
            SysFunc sf = new SysFunc();
            if (Session["Type"] == null)
            {
                Response.Write("<script language='javascript'>alert('连接超时，请重新登录.'); location.href='Loginpage.aspx'</script>");
            }
            else if (Session["Type"].ToString() == "0")
            {
                list = sf.GetAreaList();
            }
            else
            {
                Area area = sf.GetArea(short.Parse(Session["Areaid"].ToString()));
                if (area.Type == true)
                {
                    list = sf.GetAreaList(area.Cid);
                }
                else
                {
                    list.Add(area);
                }
            }
            bind(list);
            if (Session["curAreaid"] != null)
            {
                this.DropDownList_area.SelectedValue = Session["curAreaid"].ToString();
            }
        }
    }

    private void bind(IList<Area> tmp)
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

    protected void Button_usinfo_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChangePassword.aspx");
    }

    protected void Button_landata_Click(object sender, EventArgs e)
    {
        Response.Redirect("InsertQuota.aspx");
    }

    protected void Button_firehouse_Click(object sender, EventArgs e)
    {
        Response.Redirect("InsertFirehouse.aspx");
    }

    protected void Button_news_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewsManager.aspx");
    }

    protected void Button_use_Click(object sender, EventArgs e)
    {
        Response.Redirect("U_Manager.aspx");
    }

    protected void Button_sys_Click(object sender, EventArgs e)
    {
        Response.Redirect("S_Manager.aspx");
    }

    protected void DropDownList_area_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["curAreaid"] = short.Parse(this.DropDownList_area.SelectedItem.Value);
        Session["ClickTime"] = getSecondIntEnd(DateTime.Now);
        Response.Redirect("HomePage.aspx");
    }

    private int getSecondIntEnd(DateTime end)
    {
        int result = 0;
        DateTime startdate = new DateTime(1970, 1, 1, 8, 0, 0);
        TimeSpan seconds = end.AddDays(0) - startdate;
        result = Convert.ToInt32(seconds.TotalSeconds);
        return result;
    }
}