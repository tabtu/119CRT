using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.Model;
using ttxy.BLL;

public partial class MasterAlert : System.Web.UI.MasterPage
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

    protected int CheckEquipments()
    {
        EpControl ec = new EpControl();
        return ec.host_state_num('0');
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
            IList<SC_HOST> lsh_0 = get_my_schost(get_my_lanlist(), ec.host_state_control('0'));
            IList<SC_HOST> lsh_1 = get_my_schost(get_my_lanlist(), ec.host_state_control('1'));
            IList<SC_HOST> lsh_2 = get_my_schost(get_my_lanlist(), ec.host_state_control('2'));
            IList<SC_HOST> lsh_3 = get_my_schost(get_my_lanlist(), ec.host_state_control('3'));
            IList<SC_HOST> lsh_4 = get_my_schost(get_my_lanlist(), ec.host_state_control('4'));
            IList<SC_HOST> lsh_5 = get_my_schost(get_my_lanlist(), ec.host_state_control('5'));
            IList<SC_HOST> lsh_6 = get_my_schost(get_my_lanlist(), ec.host_state_control('6'));


            this.Label_state.Text = (lsh_1.Count + lsh_2.Count + lsh_3.Count + lsh_4.Count + lsh_5.Count + lsh_6.Count).ToString();
            int i = 0;
            for (i = 0; i < lsh_2.Count; i++)
            {
                lsh_1.Add(lsh_2[i]);
            }
            for (i = 0; i < lsh_3.Count; i++)
            {
                lsh_1.Add(lsh_3[i]);
            }
            for (i = 0; i < lsh_4.Count; i++)
            {
                lsh_1.Add(lsh_4[i]);
            }
            for (i = 0; i < lsh_5.Count; i++)
            {
                lsh_1.Add(lsh_5[i]);
            }
            for (i = 0; i < lsh_6.Count; i++)
            {
                lsh_1.Add(lsh_6[i]);
            }
            for (i = 0; i < lsh_0.Count; i++)
            {
                lsh_1.Add(lsh_0[i]);
            }

            bind_errorhost(lsh_1);
            Response.Write("<script language='javascript'>alert('当前告警主机数为：" + this.Label_state.Text + "');</script>");
            Session["ErrorHost"] = this.Label_sumstate.Text;
        }
    }

    protected void showhost(object sender, CommandEventArgs e)
    {
        Response.Redirect("NodeDetail.aspx?" + e.CommandName.ToString());
    }

    protected void showequip(object sender, CommandEventArgs e)
    {
        Response.Redirect("AlertHd.aspx?" + e.CommandName.ToString());
    }
}
