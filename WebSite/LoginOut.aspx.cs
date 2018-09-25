using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.Model;
using ttxy.BLL;

public partial class 注销 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Userid"] = null;
        Session["Account"] = null;
        Session["Password"] = null;
        Session["Name"] = null;
        Session["Limit"] = null;
        Session["Key"] = null;
        Session["Employeeid"] = null;
        Session["Memberid"] = null;
        Session["WebType"] = null;
        Session["Extendguyid"] = null;
        Session["BackWeb"] = null;
        Response.Redirect("Default.aspx");
    }
}