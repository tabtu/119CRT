using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.Model;
using ttxy.BLL;
public partial class NewsManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Type"] == null)
        {
            Response.Write("<script language='javascript'>alert('请重新登录.'); location.href='Loginpage.aspx'</script>");
            return;
        }
        short type = short.Parse(Session["Type"].ToString());
        if (type != 0)
        {
            Response.Write("<script language='javascript'>alert('该账号无此操作权限.'); location.href='HomePage.aspx'</script>");
            return;
        }
        if (!IsPostBack)
        {
            UseFunc uf = new UseFunc();
            this.Panel_news.Visible = true;
            IList<News> mynewslist = uf.GetNewsIsused(true);
            bind(mynewslist);
        }
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

    protected void Button_list_edit_Click(object sender, CommandEventArgs e)
    {
        UseFunc uf = new UseFunc();
        this.U_updatenews1.Visible = true;
        this.U_insertnews1.Visible = false;
        this.Panel_news.Visible = false;
        //this.Panel_news.Height = 30;
        this.U_updatenews1.news = uf.GetNews(int.Parse(e.CommandName.ToString()));
    }

    protected void Button_list_del_Click(object sender, CommandEventArgs e)
    {
        ExcFunc ef = new ExcFunc();
        ef.DeleteNews(long.Parse(e.CommandName.ToString()),int.Parse(Session["Userid"].ToString()));
        Response.Redirect("NewsManager.aspx");
    }

    protected void Button_add_Click(object sender, EventArgs e)
    {
        this.U_updatenews1.Visible = false;
        this.U_insertnews1.Visible = true;
        this.Panel_news.Visible = false;
    }

    protected void Button_choose_Click(object sender, EventArgs e)
    {
        this.U_updatenews1.Visible = false;
        this.U_insertnews1.Visible = false;
        this.Panel_news.Visible = true;
        IList<News> newslist = new List<News>();
        UseFunc uf = new UseFunc();
        if (this.TextBox_key.Text == "")
        {

            newslist = uf.GetNewsIsused(true);
        }
        else
        {
            newslist = uf.GetNewsList(this.TextBox_key.Text);
        }
        bind(newslist);
    }

    protected void show_newstitle(object sender, CommandEventArgs e)
    {
        Session["newsid"] = e.CommandName.ToString();
        Response.Redirect("NewsShow.aspx");
    }
}

    