using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.BLL;
using ttxy.Model;

public partial class NewsShow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UseFunc uf = new UseFunc();
        News mynews = uf.GetNews(int.Parse(Session["newsid"].ToString()));
        this.Label_newstitle.Text = mynews.Title;
        this.Label_newsauthor.Text = "作者：" + uf.GetMembers(mynews.Mid).Name;
        this.Label_time.Text = "时间：" + mynews.Datetime;
        //this.Label_newscontext.Text = huanhang(mynews.Context);
        this.Label_newscontext.Text = mynews.Context.Replace("\r\n", "<br> "); 
    }
}