using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.Model;
using ttxy.BLL;

public partial class 指标录入 : System.Web.UI.Page
{
    //ExUserFunction eu = new ExUserFunction();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Areaid"] == null || Session["LinkId"] == null || Session["Type"] == null)
        {
            Response.Write("<script language='javascript'>alert('连接超时，请重新登录.'); location.href='Loginpage.aspx'</script>");
        }
        else
        {
            short type = short.Parse(Session["Type"].ToString());
            if (type != 0 && type!= 3 && type != 1 && type != 6)
            {
                Response.Write("<script language='javascript'>alert('该账号无此操作权限.'); location.href='HomePage.aspx'</script>");
                return;
            }
            if (!IsPostBack)
            {
                this.U_landdata1.Visible = false;
                IList<LanData> lanlist = new List<LanData>();
                SysFunc sf = new SysFunc();
                UseFunc uf = new UseFunc();
                Area currentarea = sf.GetArea(short.Parse(Session["Areaid"].ToString()));
                int linkid = int.Parse(Session["LinkId"].ToString());
                if (type == 0)  // 超级权限
                {
                    lanlist = uf.GetLandataList();
                }
                else if (type == 6)
                {
                    lanlist.Add(uf.GetLandata(short.Parse(Session["LinkId"].ToString())));
                }
                else
                {
                    if (currentarea.Type == true)
                    {
                        IList<Area> areas = sf.GetAreaList(currentarea.Cid, false);
                        for (int i = 0; i < areas.Count; i++)
                        {
                            IList<LanData> tmp = uf.GetLandataList(areas[i].ID);
                            for (int j = 0; j < tmp.Count; j++)
                            {
                                lanlist.Add(tmp[j]);
                            }
                        }
                    }
                    else
                    {
                        lanlist = uf.GetLandataList(currentarea.ID);
                    }
                }
                bindlist(lanlist);
            }
            //this.Button_back.Attributes["onclick"] = "javascript:location.href='HomePage.aspx'";
            //this.ImageButton_submit.Attributes["onclick"] = "javascript:return confirm('确认提交？提交后无法更改');";
        }
    }

    public void bindlist(IList<LanData> tmp)
    {
        PagedDataSource pds = new PagedDataSource();
        if (tmp != null)
        {
            pds.DataSource = tmp;
            this.Repeater_landatalist.DataSource = pds;
            this.Repeater_landatalist.DataBind();
        }
    }

    protected void show_landata(object sender, CommandEventArgs e)
    {
        this.U_landdata1.Visible = false;
        this.U_updateLandata1.Visible = true;
        UseFunc uf = new UseFunc();
        this.U_updateLandata1.landata = uf.GetLandata(int.Parse(e.CommandName.ToString()));
    }

    protected void Button_search_Click(object sender, EventArgs e)
    {
        this.U_landdata1.Visible = false;
        IList<LanData> lanlist = new List<LanData>();
        SysFunc sf = new SysFunc();
        UseFunc uf = new UseFunc();
        Area currentarea = sf.GetArea(short.Parse(Session["Areaid"].ToString()));
        if (Session["Type"].ToString() == "0")  // 超级权限
        {
            lanlist = uf.GetLandataList(this.TextBox_key.Text);
            //lanlist = uf.GetLandataList();
        }
        else
        {
            if (currentarea.Type == true)
            {
                IList<Area> areas = sf.GetAreaList(currentarea.Cid, false);
                for (int i = 0; i < areas.Count; i++)
                {
                    IList<LanData> tmp = uf.GetLandataList(this.TextBox_key.Text, areas[i].ID);
                    for (int j = 0; j < tmp.Count; j++)
                    {
                        lanlist.Add(tmp[j]);
                    }
                }
            }
            else
            {
                lanlist = uf.GetLandataList(this.TextBox_key.Text, short.Parse(Session["Areaid"].ToString()));
            }
        }
        bindlist(lanlist);
    }

    protected void Button_addlandata_Click(object sender, EventArgs e)
    {
        this.U_updateLandata1.Visible = false;
        this.U_landdata1.Visible = true;
        LanData ld = new LanData();
        ld.AreaData = short.Parse(Session["Areaid"].ToString());
        this.U_landdata1.landata = ld;
    }

    protected void Button_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("HomePage.aspx");
    }
}