using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.Model;

public partial class Control_U_errorhostlist : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void bind_errorhost(IList<SC_HOST> list)
    {
        PagedDataSource pds = new PagedDataSource();
        if (list != null)
        {
            pds.DataSource = list;
            this.Repeater_errorhostlist.DataSource = pds;
            this.Repeater_errorhostlist.DataBind();
        }
    }

    protected void showhost(object sender, CommandEventArgs e)
    {

    }

    protected void showequip(object sender, CommandEventArgs e)
    {

    }
}