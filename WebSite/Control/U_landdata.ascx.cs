using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.BLL;
using ttxy.Model;


public partial class Control_U_landdata : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SysFunc sf = new SysFunc();
            IList<Area> list = new List<Area>();
            if (Session["Type"] == null)
            {
                Response.Write("<script language='javascript'>alert('连接超时，请重新登录.'); location.href='Loginpage.aspx'</script>");
            }
            else if (Session["Type"].ToString() == "0")//my.Type == 0)
            {
                list = sf.GetAreaList(false);
            }
            else
            {
                if (Session["Areaid"] == null)
                {
                    Response.Write("<script language='javascript'>alert('连接超时，请重新登录.'); location.href='Loginpage.aspx'</script>");
                }
                Area area = sf.GetArea(short.Parse(Session["Areaid"].ToString()));
                if (area.Type == true)
                {
                    list = sf.GetAreaList(area.Cid, false);
                }
                else
                {
                    list.Add(area);
                }
            }
            bind(list);
            bindcate(sf.GetLanCate());
            bindtype(sf.GetLanType());
            bindmaintenance(sf.GetMaintenance());
            bindproperty(sf.GetProperty());
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

            info.AreaData = short.Parse(this.DropDownList_area.SelectedValue);
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
            info.ACTIVE = '1';
            info.PASSWD = this.TextBox_passwd.Text;

            //int real = isrealgps(gpstmp[0], gpstmp[1]);
            //if (real == 1)
            //{
            //    info.Lng = double.Parse(gpstmp[0]);
            //    info.Lat = double.Parse(gpstmp[1]);
            //    //info.GpsPoint = gpsreplace(this.TextBox_GPS.Text);
            //}
            //else if (real == -1)
            //{
            //    info.Lng = -1;
            //    info.Lat = -1;
            //}
            //else
            //{
            //    info.Lng = -2;
            //    info.Lat = -2;
            //}
            return info;
        }
        set
        {
            SysFunc sf = new SysFunc();
            Area area = sf.GetArea(value.AreaData);
            this.S_LocalSelect1.SetCenter(area.Lng, area.Lat, area.Zoom);
        }
    }
    protected void Button_submit_Click(object sender, EventArgs e)
    {
        long result = 0;
        ExcFunc ef = new ExcFunc();
        result = ef.AddLandata(landata, int.Parse(Session["Userid"].ToString()));
        //if (eu.getLandata_by_name(this.TextBox_building.Text) != null)
        //{
        //    this.Label_fix_tip.Text = "该小区已有信息，请勿重复添加";
        //    return;
        //}
        //result = eu.insert_landata(landata, int.Parse(Session["Userid"].ToString()));
        if (result > 0)
        {
            this.Label_fix_tip.Text = "数据成功提交";
            Session["Lanid"] = result;
            this.Response.Redirect("InsertNode.aspx");
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

    //检查是否为合法GPS
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

    // 替换分隔符（提供GPS数据坐标采取）
    //private string gpsreplace(string s)
    //{
    //    s = s.Replace(",", "|");
    //    return s;
    //}
}