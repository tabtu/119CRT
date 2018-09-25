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
        if (Session["Lanid"] == null)
        {
            Response.Write("<script language='javascript'>alert('连接超时，请重新登录.'); location.href='Loginpage.aspx'</script>");
        }
        if (!IsPostBack)
        {
            this.U_nodedata1.Visible = false;
            this.U_updateNodedata1.Visible = true;
            UseFunc uf = new UseFunc();
            IList<NodeData> nd = uf.GetNodedataList(int.Parse(Session["Lanid"].ToString()));
            bindlist(nd);
            this.U_updateNodedata1.nodedata = uf.GetNodedata(nd[0].Id);
        }
    }

    public void bindlist(IList<NodeData> tmp)
    {
        PagedDataSource pds = new PagedDataSource();
        if (tmp != null)
        {
            pds.DataSource = tmp;
            this.Repeater_nodelist.DataSource = pds;
            this.Repeater_nodelist.DataBind();
        }
    }

    protected void Button_addnodedata_Click(object sender, EventArgs e)
    {
        this.U_updateNodedata1.Visible = false;
        this.U_nodedata1.Visible = true;
        NodeData nd = new NodeData();
        nd.Lid = int.Parse(Session["Lanid"].ToString());
        this.U_nodedata1.nodedata = nd;
    }

    protected void show_nodedata(object sender, CommandEventArgs e)
    {
        this.U_nodedata1.Visible = false;
        this.U_updateNodedata1.Visible = true;
        UseFunc uf = new UseFunc();
        this.U_updateNodedata1.nodedata = uf.GetNodedata(int.Parse(e.CommandName.ToString()));
    }
}