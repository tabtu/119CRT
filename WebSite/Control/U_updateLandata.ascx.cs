using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy;
using ttxy.BLL;
using ttxy.Model;

public partial class Control_U_updateLandata : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SysFunc sf = new SysFunc();
            bindcate(sf.GetLanCate());
            bindtype(sf.GetLanType());
            bindmaintenance(sf.GetMaintenance());
            bindproperty(sf.GetProperty());
            //EpControl ec = new EpControl();
            //this.DropDownList_state.SelectedValue = ec.gethost(landata.ID).STATE.ToString();
        }
        this.Label_fix_tip.Text = "";
    }

    public void bindcate(IList<LanCate> tmp)
    {
        PagedDataSource pds = new PagedDataSource();
        if (tmp != null)
        {
            pds.DataSource = tmp;
            this.DropDownList_cate.DataSource = pds;
            this.DropDownList_cate.DataTextField = "Name";
            this.DropDownList_cate.DataValueField = "Id";
            this.DropDownList_cate.DataBind();
        }
    }

    public void bindtype(IList<LanType> tmp)
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

    public void bindmaintenance(IList<Maintenance> tmp)
    {
        PagedDataSource pds = new PagedDataSource();
        if (tmp != null)
        {
            pds.DataSource = tmp;
            this.DropDownList_mid.DataSource = pds;
            this.DropDownList_mid.DataTextField = "Name";
            this.DropDownList_mid.DataValueField = "Id";
            this.DropDownList_mid.DataBind();
        }
    }

    public void bindproperty(IList<Property> tmp)
    {
        PagedDataSource pds = new PagedDataSource();
        if (tmp != null)
        {
            pds.DataSource = tmp;
            this.DropDownList_pid.DataSource = pds;
            this.DropDownList_pid.DataTextField = "Name";
            this.DropDownList_pid.DataValueField = "Id";
            this.DropDownList_pid.DataBind();
        }
    }

    public LanData landata
    {
        get
        {
            LanData info = new LanData();
            info.ID = int.Parse(this.Label_hide_lid.Text);
            info.AreaData = short.Parse(this.Label_hide_areaid.Text);
            info.Building = this.TextBox_building.Text;
            info.Address = this.TextBox_address.Text;
            info.Lng = this.S_LocalSelect1.Lng;
            info.Lat = this.S_LocalSelect1.Lat;
            info.Ptid = short.Parse(this.DropDownList_pid.SelectedValue);
            info.Mtid = short.Parse(this.DropDownList_mid.SelectedValue);
            info.Manager = this.TextBox_manager.Text;
            info.Cate = short.Parse(this.DropDownList_cate.SelectedValue);
            info.Type = short.Parse(this.DropDownList_type.SelectedValue);

            info.HOST_CODE = this.TextBox_hostcode.Text;
            info.ACTIVE = char.Parse(this.DropDownList_active.SelectedValue);
            info.PASSWD = this.TextBox_passwd.Text;

            return info;
        }
        set
        {
            SysFunc sf = new SysFunc();
            Area area = sf.GetArea(value.AreaData);
            this.Label_hide_lid.Text = value.ID.ToString();
            this.Label_area.Text = area.Name;
            this.Label_hide_areaid.Text = area.ID.ToString();
            this.TextBox_building.Text = value.Building;
            this.TextBox_address.Text = value.Address;
            this.S_LocalSelect1.SetPoint(value.Lng, value.Lat);
            this.DropDownList_cate.SelectedValue = value.Cate.ToString();
            this.DropDownList_type.SelectedValue = value.Type.ToString();
            this.TextBox_manager.Text = value.Manager;
            this.DropDownList_mid.SelectedValue = value.Mtid.ToString();
            this.DropDownList_pid.SelectedValue = value.Ptid.ToString();

            this.TextBox_hostcode.Text = value.HOST_CODE;
            this.DropDownList_active.SelectedValue = value.ACTIVE.ToString();
            this.TextBox_passwd.Text = "";
        }
    }

    protected void Button_submit_Click(object sender, EventArgs e)
    {
        long result = 0;

        // LanData tmp = eu.getLandata_by_name(this.TextBox_building.Text);
        // if (tmp != null && tmp.ID != int.Parse(this.Label_hide_lid.Text))
        //{
        //    this.Label_fix_tip.Text = "该小区已有信息，请勿重复添加";
        //    return;
        //}

        ExcFunc ef = new ExcFunc();
        result = ef.EditLandata(landata, int.Parse(Session["Userid"].ToString()));
        
        if (result > 0)
        {
            //this.Label_fix_tip.Text = "数据成功更新";
            Session["Lanid"] = landata.ID;
            //Response.Redirect("InsertNode.aspx");
            Response.Write("<script language='javascript'>alert('数据成功更新.'); location.href='InsertNode.aspx'</script>");
        }
        else
        {
            this.Label_fix_tip.Text = "数据提交失败";
        }
    }

    //private string[] cutgps(string gpspoint)
    //{
    //    try
    //    {
    //        return gpspoint.Split(',');
    //    }
    //    catch
    //    {
    //        return null;
    //    }
    //}

    ////检查是否为合法GPS
    //private int isrealgps(string lng, string lat)
    //{
    //    //string s = "106.70601,26.560574";
    //    try
    //    {
    //        //string[] s1 = s.Split(',');
    //        double x = double.Parse(lng);
    //        double y = double.Parse(lat);
    //        if (x > 105 && x < 108 && y > 25 && y < 28)
    //        {
    //            return 1; //gps信息正常
    //        }
    //        else
    //        {
    //            return -1;//gps信息不在贵阳范围
    //        }
    //    }
    //    catch
    //    {
    //        return -2; //GPS信息输入格式不合法
    //    }
    //}

    //// 替换分隔符（提供GPS数据坐标采取）
    //private string gpsreplace(string s)
    //{
    //    s = s.Replace(",", "|");
    //    return s;
    //}

    protected void Button_node_Click(object sender, EventArgs e)
    {
        Session["Lanid"] = landata.ID;
        Response.Redirect("InsertNode.aspx");
    }

    protected void Button_check_Click(object sender, EventArgs e)
    {
        string[] temp = FileUpload_xml.FileName.Split('.');
        string filename = DateTime.Now.ToBinary().ToString() + Session["Userid"].ToString() + "." + temp[temp.Length - 1]; //0landata.Building + "." + temp[temp.Length - 1];
        Service c = new Service();
        if (c.UploadStream(FileUpload_xml.PostedFile.InputStream, filename))
        {
            DataImport di = new DataImport();
            bool result = di.ImportXml(filename, landata);
            if (result == true)
            {
                Response.Write("<script language='javascript'>alert('数据批量导入成功.'); location.href='InsertQuota.aspx'</script>");
                //this.Label_fix_tip.Text = "数据批量导入成功";
            }
            else
            {
                Response.Write("<script language='javascript'>alert('导入失败，请检查xml文件.'); location.href='InsertQuota.aspx'</script>");
                //this.Label_fix_tip.Text = "导入失败，请检查xml文件";
            }
        }
        else
        {
            Response.Write("<script language='javascript'>alert('文件上传失败.'); location.href='InsertQuota.aspx'</script>");
            //this.Label_fix_tip.Text = "文件上传失败";
        }
        

        //UseFunc uf = new UseFunc();
        //Members m = uf.GetMembers(6, landata.ID);
        //Response.Write("<script language='javascript'>alert('" + m.Account +  "')</script>");
    }

    //protected void Button_updatehoststate_Click(object sender, EventArgs e)
    //{
    //    EpControl ec = new EpControl();
    //    SC_HOST sch = ec.gethost(landata.ID);
    //    sch.STATE = char.Parse(this.DropDownList_state.SelectedValue);
    //    int result = ec.exchost(sch);
    //    if (result != 0)
    //    {
    //        Response.Write("<script language='javascript'>alert('主机状态更新成功.'); location.href='InsertQuota.aspx'</script>");
    //    }
    //    else
    //    {
    //        Response.Write("<script language='javascript'>alert('主机状态更新失败.'); location.href='InsertQuota.aspx'</script>");
    //    }
    //}
}