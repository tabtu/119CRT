using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.Model;
using ttxy.BLL;

public partial class 主页 : System.Web.UI.Page
{
    //private ExUserFunction eu = new ExUserFunction();
    //private LbsMaker lm = new LbsMaker();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["curAreaid"] == null || Session["LinkId"] == null || Session["Type"] == null)
        {
            Response.Write("<script language='javascript'>alert('请重新登录.'); location.href='Loginpage.aspx'</script>");
        }
        if (!IsPostBack)
        {
            IList<LanData> landatalist = new List<LanData>();
            SysFunc sf = new SysFunc();
            UseFunc uf = new UseFunc();
            Area currentarea = sf.GetArea(short.Parse(Session["curAreaid"].ToString()));
            short type = short.Parse(Session["Type"].ToString());
            if (type == 0)  // 超级权限
            {
                landatalist = uf.GetLandataList();
            }
            else if (type == 6)
            {
                landatalist.Add(uf.GetLandata(int.Parse(Session["LinkId"].ToString())));
            }
            else if (type == 5)
            {
                landatalist = uf.GetLandataListPt(short.Parse(Session["LinkId"].ToString()));
            }
            else if (type == 4)
            {
                landatalist = uf.GetLandataListMt(short.Parse(Session["LinkId"].ToString()));
            }
            else
            {
                if (currentarea.Type == true)
                {
                    IList<Area> areas = sf.GetAreaList(currentarea.Cid, false);
                    for (int i = 0; i < areas.Count; i++)
                    {
                        IList<LanData> tmp = uf.GetLandataList(areas[i].ID);
                        for (int j = 0; j < tmp.Count; j++)
                        {
                            landatalist.Add(tmp[j]);
                        }
                    }
                    //landatalist = eu.getLandatalist_by_areaid(short.Parse(Session["Areaid"].ToString()));
                }
                else
                {
                    landatalist = uf.GetLandataList(currentarea.ID);
                }
            }

            // 读取数据，制造地图
            if (landatalist.Count() > 0)
            {
                this.Label_notic.Text = "";
                string gpscenter = currentarea.Lng + "," + currentarea.Lat;
                string zoom = currentarea.Zoom.ToString();
                // 如果选择全部城区，则生成热力图
                if (currentarea.Type == true)
                {
                    //标记指标点

                    this.Literal_map.Text = LbsMaker.MakeMap(gpscenter, zoom, LbsMaker.MakeMapPoints(landatalist));

                    //区域标签
                    //this.Literal_map.Text = LbsMaker.MakeLabel(currentarea.GpsCenter, zoom, LbsMaker.MakeLabelPoints(landatalist, eu.getArea_All(true)));

                    //热力图
                    //this.Literal_map.Text = LbsMaker.MakeHeat(currentarea.GpsCenter, zoom, LbsMaker.MakeHeatPoints(landatalist));
                }
                else
                {
                    this.Literal_map.Text = LbsMaker.MakeMap(gpscenter, zoom, LbsMaker.MakeMapPoints(landatalist));
                }
            }
            else
            {
                this.Label_notic.Text = "暂无数据,请选择其他区域";
                this.Literal_map.Text = "";
            }
        }
    }
}