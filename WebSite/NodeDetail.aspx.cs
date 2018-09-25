using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

using ttxy.BLL;
using ttxy.Model;

public partial class Default2 : System.Web.UI.Page
{
    private static string mainurl = StrUtil.mainurl;//ConfigurationManager.AppSettings["hostname"];

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string url = HttpContext.Current.Request.Url.Query;
            int id = int.Parse(url.Substring(1));

            Session["Lanid"] = id.ToString();
            UseFunc uf = new UseFunc();
            LanData ld = uf.GetLandata(id);
            this.Label_maptitle1.Text = ld.Building;
            IList<NodeData> nodelist = uf.GetNodedataList(id);

            bindlist(nodelist);
        }
    }

    public void bindlist(IList<NodeData> tmp)
    {
        PagedDataSource pds = new PagedDataSource();
        if (tmp != null)
        {
            pds.DataSource = tmp;
            this.Detail_building.DataSource = pds;
            this.Detail_building.DataBind();
        }
    }

    protected void show_building(object sender, CommandEventArgs e)
    {
        int nid = int.Parse(e.CommandName.ToString());
        UseFunc uf = new UseFunc();
        NodeData nd = uf.GetNodedata(nid);
        if (nd.PicName == "预案图")
        {
            this.U_landetail1.Visible = true;
        }
        else
        {
            this.U_landetail1.Visible = false;
        }
        IList<EquipData> eqlist = uf.GetEquipdataList(nid);
        this.Label_maptitle2.Text = nd.PicName;
        this.Literal_map.Text = LbsMaker.MakeEquipMap(nd, eqlist, int.Parse(Session["Lanid"].ToString()));
    }

    protected void Button_submit_Click(object sender, EventArgs e)
    {
        //string nid = Session["Nodeid"].ToString();
        Response.Write("<script language='javascript'>window.open('" + mainurl + "Simulation.aspx" + "');</script>");
        //Response.Write("<script>window.open(Simulation.aspx'',''_Simulation'')</script>");
    }
}