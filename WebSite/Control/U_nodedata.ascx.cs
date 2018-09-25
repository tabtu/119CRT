using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;

using ttxy.Model;
using ttxy.BLL;
using ttxy;

public partial class Control_U_nodedata : System.Web.UI.UserControl
{
    private static string local = ConfigurationManager.AppSettings["hostname"];
    private string picurl = local + "Upload/map/";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //this.Label_hide_lid.Text = Session["lanid"].ToString();
            //UseFunc uf = new UseFunc();
            //this.Label_building.Text = uf.GetLandata(int.Parse(this.Label_hide_lid.Text)).Building;
        }
    }

    public NodeData nodedata
    {
        get
        {
            NodeData info = new NodeData();
            info.Lid = int.Parse(this.Label_hide_lid.Text);
            info.PicPath = this.Label_hide_filename.Text;
            info.PicName = this.TextBox_picname.Text;
            info.PicDescription = this.TextBox_picdes.Text;
            info.Description = this.TextBox_des.Text;
            info.Mainmap = false;
            info.Sort = short.MaxValue;
            return info;
        }
        set
        {
            this.Label_hide_lid.Text = value.Lid.ToString();
            UseFunc uf = new UseFunc();
            this.Label_building.Text = uf.GetLandata(value.Lid).Building;
        }
    }

    protected void Button_upload_Click(object sender, EventArgs e)
    {
        //Bitmap mybmp = new Bitmap(FileUpload1.PostedFile.InputStream);
        //if (mybmp.Width > 900 || mybmp.Height > 600 || mybmp.Width < 150 || mybmp.Height < 100)
        //{
        //    Response.Write("<script language='javascript'>alert('图片大小不符合规范。');</script>");
        //    return;
        //}
        //else
        //{

        string[] temp = FileUpload1.FileName.Split('.');
        string filename = DateTime.Now.ToBinary().ToString() + Session["Userid"].ToString() + "." + temp[temp.Length - 1];
        Service c = new Service();
        if (c.UploadStream(FileUpload1.PostedFile.InputStream, filename))
        {
            this.Label_hide_filename.Text = filename;
            this.Image_map.ImageUrl = picurl + filename;
            this.Label_fix_tip.Text = "文件上传成功";
        }
        else
        {
            this.Label_fix_tip.Text = "文件上传失败";
        }
    }

    protected void Button_submit_Click(object sender, EventArgs e)
    {
        long result = 0;
        ExcFunc ef = new ExcFunc();
        result = ef.AddNodedata(nodedata, int.Parse(Session["Userid"].ToString()));
        //if (eu.getLandata_by_name(this.TextBox_building.Text) != null)
        //{
        //    this.Label_fix_tip.Text = "该楼层已有信息，请勿重复添加";
        //    return;
        //}
        //result = eu.insert_landata(landata, int.Parse(Session["Userid"].ToString()));
        if (result > 0)
        {
            this.Label_fix_tip.Text = "数据成功提交";
            Session["Nodeid"] = result;
            this.Response.Redirect("InsertNode.aspx");
        }
        else
        {
            this.Label_fix_tip.Text = "数据提交失败";
        }
    }
}