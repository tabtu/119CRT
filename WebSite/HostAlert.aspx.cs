using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.Model;
using ttxy.BLL;

public partial class HostAlarm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["curAreaid"] == null || Session["LinkId"] == null || Session["Type"] == null)
        {
            Response.Write("<script language='javascript'>alert('认证失败，请重新登录。'); location.href='Loginpage.aspx'</script>");
        }
        if (!IsPostBack)
        {
            Session["ErrorHost"] = this.Label_sumstate.Text;
            btn_epn_Click(null, null);
        }

    }

    public void bind_errorhost(IList<SC_HOST> list)
    {
        PagedDataSource pds = new PagedDataSource();
        if (list != null)
        {
            pds.DataSource = list;
            this.Repeater_errorhostlist.DataSource = pds;
            this.Repeater_errorhostlist.DataBind();
        }
    }

    protected int CheckEquipments()
    {
        EpControl ec = new EpControl();
        return ec.host_state_num('0');
    }


    private IList<LanData> get_my_lanlist()
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
            landatalist.Add(uf.GetLandata(short.Parse(Session["LinkId"].ToString())));
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
        return landatalist;
    }

    private IList<SC_HOST> get_my_schost(IList<LanData> lanlist, IList<SC_HOST> hosc)
    {
        IList<SC_HOST> result = new List<SC_HOST>();
        for (int i = 0; i < hosc.Count; i++)
        {
            for (int j = 0; j < lanlist.Count; j++)
            {
                if (lanlist[j].HOST_CODE == hosc[i].HOST_CODE)
                {
                    result.Add(hosc[i]);
                    break;
                }
            }
        }
        return result;
    }

    protected void btn_epn_Click(object sender, ImageClickEventArgs e)
    {
        EpControl ec = new EpControl();
        this.Label_sumstate.Text = ec.host_state_num('0').ToString();
        if (this.Label_sumstate.Text != Session["ErrorHost"].ToString())
        {
            IList<SC_HOST> lsh = get_my_schost(get_my_lanlist(), ec.host_state_control('0'));
            IList<SC_HOST> lsh_n = get_my_schost(get_my_lanlist(), ec.host_state_control('1'));
            
            this.Label_state.Text = lsh.Count.ToString();

            for (int i=0; i<lsh_n.Count; i++)
            {
                lsh.Add(lsh_n[i]);
            }
            bind_errorhost(lsh);
            Response.Write("<script language='javascript'>alert('当前告警主机数为：" + this.Label_state.Text + "');</script>");
            Session["ErrorHost"] = this.Label_sumstate.Text;
        }
    }

    protected void showhost(object sender, CommandEventArgs e)
    {

    }

    protected void showequip(object sender, CommandEventArgs e)
    {

    }

}