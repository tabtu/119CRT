using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Control_S_MapSelect : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public short X
    {
        get
        {
            return short.Parse(this.Request.Form["hidden_x"].ToString());
        }
    }

    public short Y
    {
        get
        {
            return short.Parse(this.Request.Form["hidden_y"].ToString());
        }
    }

    /// <summary>
    /// 初始化背景图片
    /// </summary>
    /// <param name="url">背景图片URL</param>
    public void SetImage(string url)
    {
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "setimage", "<script>setimage('" + url + "')</script>");
    }

    /// <summary>
    /// 初始化图标
    /// </summary>
    /// <param name="url">图标URL</param>
    public void SetIcon(string url)
    {
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "seticon", "<script>seticon('" + url + "')</script>");
    }

    /// <summary>
    /// 初始化坐标
    /// </summary>
    /// <param name="x">left</param>
    /// <param name="y">top</param>
    public void SetLocation(short x, short y)
    {
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "setXY", "<script>setXY('" + x.ToString() + "','" + y.ToString() + "')</script>");
    }
}