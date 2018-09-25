using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.Model;
using ttxy.BLL;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Nodeid"] == null)
        {
            Response.Write("<script language='javascript'>alert('连接超时，请重新登录.'); location.href='Loginpage.aspx'</script>");
        }
        if (!IsPostBack)
        {
            this.U_equipdata1.Visible = false;
            this.U_updateEquipdata1.Visible = false;
            UseFunc uf = new UseFunc();
            IList<EquipData> ed = uf.GetEquipdataList(int.Parse(Session["Nodeid"].ToString()));
            bindlist(ed);
        }
    }

    public void bindlist(IList<EquipData> tmp)
    {
        PagedDataSource pds = new PagedDataSource();
        if (tmp != null)
        {
            pds.DataSource = tmp;
            this.Repeater_equiplist.DataSource = pds;
            this.Repeater_equiplist.DataBind();
        }
    }


    protected void show_equip(object sender, CommandEventArgs e)
    {
        this.U_equipdata1.Visible = false;
        this.U_updateEquipdata1.Visible = true;
        UseFunc uf = new UseFunc();
        this.U_updateEquipdata1.equipdata = uf.GetEquipdata(long.Parse(e.CommandName.ToString()));
    }

    protected void Button_addequip_Click(object sender, EventArgs e)
    {
        this.U_updateEquipdata1.Visible = false;
        this.U_equipdata1.Visible = true;
        EquipData ed = new EquipData();
        ed.Nid = int.Parse(Session["Nodeid"].ToString());
        this.U_equipdata1.equipdata = ed;
    }
}