using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using ttxy.Model;
using ttxy.BLL;

public partial class 报表展示 : System.Web.UI.Page
{
    private UseFunc eu = new UseFunc();
    private SysFunc sf = new SysFunc();
    private ReportData rd = new ReportData();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            IList<Area> list = new List<Area>();
            Members my = eu.GetMembers(int.Parse(Session["Userid"].ToString()));
            if (my.Type == 0)
            {
                list = sf.GetAreaList();
            }
            else
            {
                Area area = sf.GetArea(my.Type);
                list.Add(area);
            }
            bind(list);
        }
    }

    public void bind(IList<Area> tmp)
    {
        PagedDataSource pds = new PagedDataSource();
        if (tmp != null)
        {
            pds.DataSource = tmp;
            this.DropDownList_area.DataSource = pds;
            this.DropDownList_area.DataTextField = "Name";
            this.DropDownList_area.DataValueField = "Id";
            this.DropDownList_area.DataBind();
        }
    }

    protected void Button_submit_Click(object sender, EventArgs e)
    {
        this.Label_notic.Text = "";
        IList<LanData> my = null;
        //筛选数据
        if (this.TextBox_rzllow.Text != "" && (double.Parse(this.TextBox_rzllow.Text) > 99.9 || double.Parse(this.TextBox_rzllow.Text) < 0))
        {
            this.Label_notic.Text = "请输入正确的入住率最低筛选值";
            return ;
        }

        if (this.TextBox_rzlhigh.Text != "" && this.TextBox_rzllow.Text != "" && double.Parse(this.TextBox_rzlhigh.Text) < double.Parse(this.TextBox_rzllow.Text))
        {
            this.Label_notic.Text = "请输入正确的入住率最高筛选值";
            return ;
        }

        if (this.TextBox_rzlhigh.Text != "" && (double.Parse(this.TextBox_rzlhigh.Text) > 100))
        {
            this.Label_notic.Text = "请输入正确的入住率最高筛选值";
            return;
        }
        my = Reports(short.Parse(this.DropDownList_area.SelectedValue), this.DropDownList_jzpj.SelectedValue, this.TextBox_rzllow.Text, this.TextBox_rzlhigh.Text);
        //显示下载控件
        if (my != null)
        {
            this.Button_download.Visible = true;
        }
        else
        {
            this.Label_notic.Text = "无数据";
        }

        // 填充数据
        DataTable mydata = rd.Show_Report(my);
        this.GridView_report.DataSource = mydata;
        this.GridView_report.DataBind();
    }



    protected void Button_download_Click(object sender, EventArgs e)
    {
        this.Label_notic.Text = "";
        ReportData rd = new ReportData();
        DataTable mydata = rd.Show_Report(Reports(short.Parse(this.DropDownList_area.SelectedValue), this.DropDownList_jzpj.SelectedValue, this.TextBox_rzllow.Text, this.TextBox_rzlhigh.Text));
        if (mydata.Rows.Count > 0)
        {
            // 填充数据
            DataTable2Excel(mydata, "挂图作战系统" + DateTime.Now + "导出报表");
        }
        else
        {
            this.Label_notic.Text = "无数据";
        }
    }

    /// <summary>
    /// bll中函数是double，屏蔽空串转码错误，避免静态全局变量，避免重复该段代码，单独提出来形成一个内部函数
    /// </summary>
    /// <param name="area">区域</param>
    /// <param name="jzpj">竞争评级选项</param>
    /// <param name="rzl_low">最低入住率字段</param>
    /// <param name="rzl_high">最高入住率字段</param>
    /// <returns></returns>
    private IList<LanData> Reports(short area, string jzpj, string rzl_low, string rzl_high)
    {
        ReportData rd = new ReportData();

        if (rzl_low == "" && rzl_high == "")
        {
            return rd.ResultDate(area, jzpj, 0, 100);
        }
        else if (rzl_low == "")
        {
            return rd.ResultDate(area, jzpj, 0, double.Parse(rzl_high));
        }
        else if (rzl_high == "")
        {
            return rd.ResultDate(area, jzpj, double.Parse(rzl_low), 100);
        }
        else
        {
            return rd.ResultDate(area, jzpj, double.Parse(rzl_low), double.Parse(rzl_high));
        }
    }

    /// <summary> 
    /// dtData是要导出为Excel的DataTable,FileName是要导出的Excel文件名(不加.xls) 
    /// </summary> 
    /// <param name="dtData"></param> 
    /// <param name="FileName"></param> 
    private void DataTable2Excel(DataTable dtData, String FileName)
    {
        System.Web.UI.WebControls.GridView dgExport = null;
        //当前对话 
        System.Web.HttpContext curContext = System.Web.HttpContext.Current;
        //IO用于导出并返回excel文件 
        System.IO.StringWriter strWriter = null;
        System.Web.UI.HtmlTextWriter htmlWriter = null;

        if (dtData != null)
        {
            //设置编码和附件格式 
            //System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8)作用是方式中文文件名乱码 
            curContext.Response.AddHeader("content-disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + ".xls");
            curContext.Response.ContentType = "application nd.ms-excel";
            curContext.Response.ContentEncoding = System.Text.Encoding.UTF8;
            curContext.Response.Charset = "GB2312";

            //导出Excel文件 
            strWriter = new System.IO.StringWriter();
            htmlWriter = new System.Web.UI.HtmlTextWriter(strWriter);

            //为了解决dgData中可能进行了分页的情况,需要重新定义一个无分页的GridView 
            dgExport = new System.Web.UI.WebControls.GridView();
            dgExport.DataSource = dtData.DefaultView;
            dgExport.AllowPaging = false;
            dgExport.DataBind();

            //下载到客户端 
            dgExport.RenderControl(htmlWriter);
            curContext.Response.Write(strWriter.ToString());
            curContext.Response.End();
        }
    }
}