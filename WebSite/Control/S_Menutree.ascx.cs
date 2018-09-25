using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.BLL;
using ttxy.Model;


public partial class Control_Manutree : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Areaid"] == null || Session["Type"].ToString() == null)
        {
            Response.Write("<script language='javascript'>alert('请重新登录.'); location.href='Default.aspx'</script>");
        }
        else
        {    
            IList<Area> list = new List<Area>();
            SysFunc sf = new SysFunc();
            if (Session["Type"].ToString() == "0")
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
        }
    }

    public void bind(IList<Area> tmp)
    {
        PagedDataSource pds = new PagedDataSource();
        if (tmp != null)
        {
            pds.DataSource = tmp;
            this.Repeater_orderlist.DataSource = pds;
            this.Repeater_orderlist.DataBind();
        }
    }

    protected void show_organ(object sender, CommandEventArgs e)
    {
        //if (Session["ClickTime"] != null)
        //{
        //    if (getSecondIntEnd(DateTime.Now) - int.Parse(Session["ClickTime"].ToString()) > 3)
        //    {
        //        Session["Areaid"] = short.Parse(e.CommandName.ToString());
        //        Session["ClickTime"] = getSecondIntEnd(DateTime.Now);
        //        Response.Redirect("HomePage.aspx");
        //    }
        //}
        //else
        //{
        Session["curAreaid"] = short.Parse(e.CommandName.ToString());
        Session["ClickTime"] = getSecondIntEnd(DateTime.Now);
        Response.Redirect("HomePage.aspx");
        //}
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

    //protected void Button_report_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("ShowReport.aspx");
    //}

    // DateTime转10位int
    private int getSecondIntEnd(DateTime end)
    {
        int result = 0;
        DateTime startdate = new DateTime(1970, 1, 1, 8, 0, 0);
        TimeSpan seconds = end.AddDays(0) - startdate;
        result = Convert.ToInt32(seconds.TotalSeconds);
        return result;
    }

}