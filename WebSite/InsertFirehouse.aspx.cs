using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.Model;
using ttxy.BLL;

public partial class InsertFirehouse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Areaid"] == null || Session["Type"] == null)
        {
            Response.Write("<script language='javascript'>alert('请重新登录.'); location.href='Loginpage.aspx'</script>");
            return;
        }
        short type = short.Parse(Session["Type"].ToString());
        if (type != 0 && type != 1 && type != 2)
        {
            Response.Write("<script language='javascript'>alert('该账号无此操作权限.'); location.href='HomePage.aspx'</script>");
            return;
        }
        if (!IsPostBack)
        {
            this.U_firehouse1.Visible = false;
            this.U_updateFirehouse1.Visible = false;
            IList<FireHouse> firelist = new List<FireHouse>();
            SysFunc sf = new SysFunc();
            Area currentarea = sf.GetArea(short.Parse(Session["Areaid"].ToString()));
            if (type == 0)  // 超级权限
            {
                firelist = sf.GetFireHouseList();
            }
            else
            {
                if (currentarea.Type == true)
                {
                    IList<Area> areas = sf.GetAreaList(currentarea.Cid, false);
                    for (int i = 0; i < areas.Count; i++)
                    {
                        IList<FireHouse> tmp = sf.GetFireHouseList(areas[i].ID);
                        for (int j = 0; j < tmp.Count; j++)
                        {
                            firelist.Add(tmp[j]);
                        }
                    }
                }
                else
                {
                    firelist = sf.GetFireHouseList(currentarea.ID);
                }
            }
            bindlist(firelist);
        }
        //this.Button_back.Attributes["onclick"] = "javascript:location.href='HomePage.aspx'";
        //this.ImageButton_submit.Attributes["onclick"] = "javascript:return confirm('确认提交？提交后无法更改');";
    }

    public void bindlist(IList<FireHouse> tmp)
    {
        PagedDataSource pds = new PagedDataSource();
        if (tmp != null)
        {
            pds.DataSource = tmp;
            this.Repeater_firehouselist.DataSource = pds;
            this.Repeater_firehouselist.DataBind();
        }
    }

    protected void show_firehouse(object sender, CommandEventArgs e)
    {
        this.U_firehouse1.Visible = false;
        this.U_updateFirehouse1.Visible = true;
        SysFunc sf = new SysFunc();
        this.U_updateFirehouse1.firehouse = sf.GetFireHouse(short.Parse(e.CommandName.ToString()));
    }

    protected void Button_addfirehouse_Click(object sender, EventArgs e)
    {
        this.U_updateFirehouse1.Visible = false;
        this.U_firehouse1.Visible = true;
        FireHouse fh = new FireHouse();
        fh.Aid = short.Parse(Session["Areaid"].ToString());
        this.U_firehouse1.firehouse = fh;
    }
}