using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.BLL;
using ttxy.Model;

public partial class _Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UseFunc uf = new UseFunc();
            IList<News> mynewslist = uf.GetNews(true);
            this.U_newstitlelist1.bind(top8list(mynewslist));
            mynewslist = uf.GetNews(false);
            this.U_newstitlelist2.bind(top8list(mynewslist));   
        }
    }

    protected IList<News> top8list (IList<News> titlelist)
    {
        IList<News> tmp = new List<News>();
        if (titlelist != null)
        {
            if (titlelist.Count() > 8)
            {
                for (int i = 0; i < 8; i++)
                {
                    tmp.Add(titlelist[i]);
                }
                return tmp;
            }
            else
            {
                return titlelist;
            }
        }
        else
        {
            return null;
        }
    }

    protected void Button_submit_Click(object sender, EventArgs e)
    {
        Members my = new Members();
        my.Account = this.TextBox_account.Text;
        my.Password = this.TextBox_password.Text;
        UseFunc uf = new UseFunc();
        Members member = uf.userLogin(my);



        if (member == null)
        {
            this.Label_notic.Text = "无此用户！";
        }
        else
        {
            if (member.Password == member.Account)
            {
                this.Label_notic.Text = "登陆成功！";
                Session["Userid"] = member.Id;
                Session["Account"] = member.Account;
                Session["Password"] = member.Password;
                Session["Name"] = member.Name;
                Session["Type"] = member.Type;
                Session["LinkId"] = member.LinkId;
                //Session["WebType"] = "Myself";
                if (member.Type == 0)
                {
                    Session["Areaid"] = Session["curAreaid"] = "0";
                }
                else if (member.Type == 1)
                {
                    SysFunc esf = new SysFunc();
                    Session["Areaid"] = Session["curAreaid"] = esf.GetFireManage((short)member.LinkId).Aid;
                }
                else if (member.Type == 2)
                {
                    SysFunc esf = new SysFunc();
                    if (member.Type == 2)
                    {
                        Session["Areaid"] = Session["curAreaid"] = esf.GetFireHouse((short)member.LinkId).Aid;
                    }
                }
                else if (member.Type == 3)
                {
                    SysFunc esf = new SysFunc();
                    if (member.Type == 3)
                    {
                        Session["Areaid"] = Session["curAreaid"] = esf.GetControlCenter((short)member.LinkId).Aid;
                    }
                }
                else
                {
                    Session["Areaid"] = "7";
                }
                Response.Redirect("HomePage.aspx");

                //登陆日志
                Log info = new Log();

                Response.Redirect("HomePage.aspx");
            }
            else
            {
                this.Label_notic.Text = "密码错误！";
            }
        }
    }

    protected void ImageButton_whgs_Click(object sender, EventArgs e)
    {
        Response.Redirect("Loginpage.aspx");
    }

    protected void ImageButton_zdbm_Click(object sender, EventArgs e)
    {
        Response.Redirect("Loginpage.aspx");
    }
    protected void ImageButton_xfzj_Click(object sender, EventArgs e)
    {
        Response.Redirect("Loginpage.aspx");
    }
    protected void ImageButton_glbm_Click(object sender, EventArgs e)
    {
        Response.Redirect("Loginpage.aspx");
    }
    protected void ImageButton_jkzx_Click(object sender, EventArgs e)
    {
        Response.Redirect("Loginpage.aspx");
    }
    protected void ImageButton_wygs_Click(object sender, EventArgs e)
    {
        Response.Redirect("Loginpage.aspx");
    }

    //获取IP
    private string GetIp()
    {

        string ip = "";
        if (Context.Request.ServerVariables["HTTP_VIA"] != null)
        {
            ip = Context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
        }
        else
        {

            ip = Context.Request.ServerVariables["REMOTE_ADDR"].ToString();
        }

        return ip;

    }
}