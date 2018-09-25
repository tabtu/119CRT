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
        if (Session["curAreaid"] == null || Session["LinkId"] == null || Session["Type"] == null)
        {
            Response.Write("<script language='javascript'>alert('请重新登录.'); location.href='Loginpage.aspx'</script>");
        }
        if (!IsPostBack)
        {
            //short type = short.Parse(Session["Type"].ToString());
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (this.DropDownList1.SelectedValue == "1")
        {
            SysFunc sf = new SysFunc();
            Area marea = sf.GetArea(short.Parse(Session["Areaid"].ToString()));

            ReportData rd = new ReportData();
            this.GridView1.DataSource = rd.Show_Report_1(marea);
            this.GridView1.DataBind();
 
        }
        else if (this.DropDownList1.SelectedValue == "2")
        {
            ReportData rd = new ReportData();
            this.GridView1.DataSource = rd.Show_Report_2(0);
            this.GridView1.DataBind();

        }
        else if (this.DropDownList1.SelectedValue == "3")
        {
            ReportData rd = new ReportData();
            this.GridView1.DataSource = rd.Show_Report_3(0);
            this.GridView1.DataBind();

        }
        else
        {
            this.GridView1.DataSource = null;
            this.GridView1.DataBind();
        }
    }
}