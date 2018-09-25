using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.BLL;
using ttxy.Model;
public partial class SysnewslistShow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UseFunc uf = new UseFunc();
        IList<News> mynewslist = uf.GetNews(false);
        bind(mynewslist);
    }
    public void bind(IList<News> newslist)
    {
        PagedDataSource pds = new PagedDataSource();
        if (newslist != null)
        {
            pds.DataSource = newslist;
            this.Repeater_newstitlelist.DataSource = pds;
            this.Repeater_newstitlelist.DataBind();
        }
    }

    protected void show_newstitle(object sender, CommandEventArgs e)
    {
        Session["newsid"] = e.CommandName.ToString();
        Response.Redirect("NewsShow.aspx");
    }
}