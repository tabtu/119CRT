using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

using ttxy.BLL;
using ttxy.Model;

public partial class Control_U_equipdata : System.Web.UI.UserControl
{
    private static string mainurl = ConfigurationManager.AppSettings["hostname"];
    private string iconurl = mainurl + "Upload/icon/";
    private string mapurl = mainurl + "Upload/map/";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SysFunc sf = new SysFunc();

            bindtype(sf.GetEquipType());
            bindstatus(sf.GetEquipStatus());
        }
    }

    private void bindtype(IList<EquipType> tmp)
    {
        PagedDataSource pds = new PagedDataSource();
        if (tmp != null)
        {
            pds.DataSource = tmp;
            this.DropDownList_type.DataSource = pds;
            this.DropDownList_type.DataTextField = "Name";
            this.DropDownList_type.DataValueField = "Id";
            this.DropDownList_type.DataBind();
        }
    }

    private void bindstatus(IList<EquipStatus> tmp)
    {
        PagedDataSource pds = new PagedDataSource();
        if (tmp != null)
        {
            pds.DataSource = tmp;
            this.DropDownList_status.DataSource = pds;
            this.DropDownList_status.DataTextField = "Name";
            this.DropDownList_status.DataValueField = "Id";
            this.DropDownList_status.DataBind();
        }
    }

    public EquipData equipdata
    {
        get
        {
            EquipData info = new EquipData();
            info.Nid = int.Parse(this.Label_hide_nid.Text);
            info.Type = short.Parse(this.DropDownList_type.SelectedValue);
            info.X = this.S_MapSelect1.X;
            info.Y = this.S_MapSelect1.Y;
            info.Description = this.TextBox_des.Text;
            info.Status = short.Parse(this.DropDownList_status.SelectedValue);
            info.Logicid = this.TextBox_logicid.Text;
            info.Url = this.TextBox_url.Text;
            return info;
        }
        set
        {
            this.Label_hide_nid.Text = value.Nid.ToString();
            UseFunc uf = new UseFunc();
            NodeData nd = uf.GetNodedata(value.Nid);
            this.Label_node.Text = nd.PicName;
            this.Label_building.Text = uf.GetLandata(nd.Lid).Building;
            this.S_MapSelect1.SetImage(mapurl + nd.PicPath);
            this.S_MapSelect1.SetIcon(iconurl + "0.png");
        }
    }

    protected void Button_submit_Click(object sender, EventArgs e)
    {
        long result = 0;
        ExcFunc ef = new ExcFunc();
        result = ef.AddEquipdata(equipdata, int.Parse(Session["Userid"].ToString()));
        //if (eu.getLandata_by_name(this.TextBox_building.Text) != null)
        //{
        //    this.Label_fix_tip.Text = "该楼层已有信息，请勿重复添加";
        //    return;
        //}
        //result = eu.insert_landata(landata, int.Parse(Session["Userid"].ToString()));
        if (result > 0)
        {
            this.Label_fix_tip.Text = "数据成功提交";
            this.Response.Redirect("InsertEquip.aspx");
        }
        else
        {
            this.Label_fix_tip.Text = "数据提交失败";
        }
    }
}