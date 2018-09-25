using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.Model;
using ttxy.BLL;

public partial class 密码修改 : System.Web.UI.Page
{
    //private ExUserFunction euf = new ExUserFunction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Userid"] == null)
        {
            Response.Write("<script language='javascript'>alert('请重新登录.'); location.href='Default.aspx'</script>");
        }
        else
        {
        }
        //this.Button_back.Attributes["onclick"] = "javascript:location.href='HomePage.aspx'";
    }
}