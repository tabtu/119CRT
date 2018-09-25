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
        if (!IsPostBack)
        {
            string url = HttpContext.Current.Request.Url.Query;
            int id = int.Parse(url.Substring(1));

            EpControl ec = new EpControl();
            bind_errornode(ec.getnodelist(id));
        }
    }



    public void bind_errornode(IList<SC_NODE> list)
    {
        PagedDataSource pds = new PagedDataSource();
        if (list != null)
        {
            pds.DataSource = list;
            this.Repeater_errornodelist.DataSource = pds;
            this.Repeater_errornodelist.DataBind();
        }
    }
}