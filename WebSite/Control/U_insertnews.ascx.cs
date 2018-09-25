using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ttxy.BLL;
using ttxy.Model;

public partial class Control_U_insertnews : System.Web.UI.UserControl
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
            if(this.DropDownList_newstype.SelectedValue == "1")
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
            info.Datetime =  DateTime.Now;
            
            return info;
        }
    }

    protected void Button_submit_Click(object sender, EventArgs e)
    {
        long result = 0;
        UseFunc uf = new UseFunc();
        ExcFunc ef = new ExcFunc();
        result = ef.AddNews(news, int.Parse(Session["Userid"].ToString()));
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

    //    public void bind(IList<Members> tmp)
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