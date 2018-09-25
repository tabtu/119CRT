using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.Security;
using ttxy.Model;
using ttxy.BLL;

public partial class Control_U_chengepassword : System.Web.UI.UserControl
{
    public Members member
    {
        get
        {
            if (Session["Userid"] == null)
            {
                Response.Write("<script language='javascript'>alert('身份认证失效，请重新登录。'); location.href='Default.aspx'</script>");
            }
            UseFunc uf = new UseFunc();
            Members mbs = uf.GetMembers(int.Parse(Session["Userid"].ToString()));
            mbs.Password = this.TextBox_newpw.Text;
            return mbs;
            //temp.Id = int.Parse(Session["Userid"].ToString());
            //temp.Account = Session["Account"].ToString();
            //temp.Name = Session["Name"].ToString();
            //temp.Password = this.TextBox_newpw.Text;
            //return temp;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button_submit_Click(object sender, EventArgs e)
    {
        if (this.TextBox_newpw.Text != this.TextBox_checkpw.Text)
        {
            this.Label_result.Text = "两次输入密码不一致，请重新输入。";
            return;
        }
        UseFunc uf = new UseFunc();
        Members mbs = uf.GetMembers(int.Parse(Session["Userid"].ToString()));
        if (md5.Md5Encode(this.TextBox_oldpw.Text) != mbs.Password)
        {
            this.Label_result.Text = "原始密码错误，请重新输入。";
            return;
        }
        ExcFunc euf = new ExcFunc();
        int result = euf.Editmembers(member, int.Parse(Session["Userid"].ToString()));
        if (result != 0)
        {
            Response.Write("<script language='javascript'>alert('密码更改成功，请重新登录。'); location.href='LoginOut.aspx'</script>");
        }
    }
}