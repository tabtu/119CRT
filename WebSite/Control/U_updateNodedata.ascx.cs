using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

using ttxy.Model;
using ttxy.BLL;
using ttxy;

public partial class Control_U_updateNodedata : System.Web.UI.UserControl
{

    private static string local = ConfigurationManager.AppSettings["hostname"];
    private string picurl = local + "Upload/map/";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }

    public NodeData nodedata
    {
        get
        {
            NodeData info = new NodeData();
            info.Id = int.Parse(this.Label_hide_nid.Text);
            info.Lid = int.Parse(this.Label_hide_lid.Text);
            info.PicPath = this.Label_hide_filename.Text;
            info.PicName = this.TextBox_picname.Text;
            info.PicDescription = this.TextBox_picdes.Text;
            info.Description = this.TextBox_des.Text;
            info.Mainmap = bool.Parse(this.Label_hide_mm.Text);
            info.Sort = short.Parse(this.TextBox_sort.Text);
            return info;
        }
        set
        {
            this.Label_hide_nid.Text = value.Id.ToString();
            this.Label_hide_lid.Text = value.Lid.ToString();
            UseFunc uf = new UseFunc();
            this.Label_building.Text = uf.GetLandata(int.Parse(this.Label_hide_lid.Text)).Building;
            this.Label_hide_mm.Text = value.Mainmap.ToString();
            this.Label_hide_filename.Text = value.PicPath;
            this.Image_map.ImageUrl = picurl + value.PicPath;
            this.TextBox_picname.Text = value.PicName;
            this.TextBox_picdes.Text = value.PicDescription;
            this.TextBox_des.Text = value.Description;
            this.TextBox_sort.Text = value.Sort.ToString();
        }
    }

    protected void Button_equip_Click(object sender, EventArgs e)
    {
        Session["Nodeid"] = this.Label_hide_nid.Text;
        Response.Redirect("InsertEquip.aspx");
    }

    protected void Button_upload_Click(object sender, EventArgs e)
    {
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
        result = ef.EditNodedata(nodedata, int.Parse(Session["Userid"].ToString()));
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