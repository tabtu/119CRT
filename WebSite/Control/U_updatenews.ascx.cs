using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.Model;
using ttxy.BLL;
public partial class Control_U_updatenews : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UseFunc uf = new UseFunc();
        IList<Members> members = uf.GetMembers(true);
        //bind(members);

    }
    public News news
    {
        get
        {
            News info = new News();
            info.Id = int.Parse(this.Label_id.Text);
            if (this.DropDownList_newstype.SelectedValue == "1")
            {
                info.Cn = true;
            }
            else
            {
                info.Cn = false;
            }
            //info.Mid = int.Parse(this.DropDownList_author.SelectedValue);
            info.Mid = int.Parse(Session["Userid"].ToString());
            info.Title = this.TextBox_title.Text;
            info.Context = this.TextBox_context.Text;
            info.Isused = true;
            info.Datetime = DateTime.Now;
            return info;
        }
        set
        {
            UseFunc uf = new UseFunc();
            ExcFunc ef = new ExcFunc();
            this.Label_id.Text = value.Id.ToString();
            if (value.Cn == true)
            {
                this.DropDownList_newstype.SelectedValue = "1";
            }
            else
            {
                this.DropDownList_newstype.SelectedValue = "2";
            }
            //this.DropDownList_author.SelectedValue = uf.GetMembers(int.Parse(value.Mid.ToString())).Id.ToString();                 
            this.Label_author.Text = uf.GetMembers(int.Parse(value.Mid.ToString())).Name;
            this.TextBox_title.Text = value.Title;
            this.TextBox_context.Text = value.Context;
        }
    }

    protected void Button_submit_Click(object sender, EventArgs e)
    {
        long result = 0;
        ExcFunc ef = new ExcFunc();
        result = ef.EditNews(news, int.Parse(Session["Userid"].ToString()));
        if (result > 0)
        {
            this.Label_fix_tip.Text = "数据成功提交";
            this.Response.Redirect("NewslistShow.aspx");
        }
        else
        {
            this.Label_fix_tip.Text = "数据提交失败";
        }
    }

    //public void bind(IList<Members> tmp)
    //{
    //    PagedDataSource pds = new PagedDataSource();
    //    if (tmp != null)
    //    {
    //        pds.DataSource = tmp;
    //        this.DropDownList_author.DataSource = pds;
    //        this.DropDownList_author.DataTextField = "Name";
    //        this.DropDownList_author.DataValueField = "Id";
    //        this.DropDownList_author.DataBind();
    //    }
    //}
}