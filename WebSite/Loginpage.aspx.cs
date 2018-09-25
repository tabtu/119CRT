using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ttxy.BLL;
using ttxy.Model;

public partial class 登陆页面 : System.Web.UI.Page
{
    //private ExUserFunction ef = new ExUserFunction();
    protected void Page_Load(object sender, EventArgs e)
    {

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
                    Session["Areaid"] = Session["curAreaid"] = esf.GetFireHouse((short)member.LinkId).Aid;
                }
                else if (member.Type == 3)
                {
                    SysFunc esf = new SysFunc();
                    Session["Areaid"] = Session["curAreaid"] = esf.GetControlCenter((short)member.LinkId).Aid;
                }
                else if (member.Type == 4)
                {
                    Session["Areaid"] = Session["curAreaid"] = "0";
                }
                else if (member.Type == 5)
                {
                    Session["Areaid"] = Session["curAreaid"] = "0";
                }
                else if (member.Type == 6)
                {
                    Session["Areaid"] = Session["curAreaid"] = uf.GetLandata((short)member.LinkId).AreaData;
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