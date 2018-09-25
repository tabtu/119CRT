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
        if (Session["Type"] == null)
        {
            Response.Write("<script language='javascript'>alert('连接超时，请重新登录.'); location.href='Loginpage.aspx'</script>");
        }
        if (int.Parse(Session["Type"].ToString()) != 0)
        {
            Response.Write("<script language='javascript'>alert('该账号无此操作权限.'); location.href='HomePage.aspx'</script>");
        }
        if (!IsPostBack)
        {
            this.U_insertMember1.Visible = false;
            this.U_Member1.Visible = false;
            UseFunc uf = new UseFunc();
            IList<Members> mlist = uf.GetMembers(true);
            bindlist(mlist);
        }
    }

    protected void Button_search_Click(object sender, EventArgs e)//tangniuzi
    {
        IList<Members> memberlist = new List<Members>();
        UseFunc uf = new UseFunc();
        if (this.TextBox_key.Text == "")
        {

            memberlist = uf.GetMembers(true);
        }
        else
        {
            memberlist = uf.GetMembersList(this.TextBox_key.Text);
        }
        bindlist(memberlist);
    }

    public void bindlist(IList<Members> tmp)
    {
        PagedDataSource pds = new PagedDataSource();
        if (tmp != null)
        {
            pds.DataSource = tmp;
            this.Repeater_landatalist.DataSource = pds;
            this.Repeater_landatalist.DataBind();
        }
    }

    protected void show_member(object sender, CommandEventArgs e)
    {
        this.U_insertMember1.Visible = false;
        this.U_Member1.Visible = true;
        UseFunc uf = new UseFunc();
        this.U_Member1.member = uf.GetMembers(int.Parse(e.CommandName.ToString()));
    }

    protected void Button_addmember_Click(object sender, EventArgs e)
    {
        this.U_Member1.Visible = false;
        this.U_insertMember1.Visible = true;
    }
}