using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ttxy.BLL;
using ttxy.Model;

public partial class Simulation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UseFunc uf = new UseFunc();
            LanData ld = uf.GetLandata(int.Parse(Session["Lanid"].ToString()));
            //LanData ld = uf.GetLandata(36);
            IList<FireHouse> fhlist = uf.GetFirehouse(ld.AreaData);

            this.Label_building.Text = ld.Building + "," + ld.Address;

            IList<double> result = new List<double>();
            for (int i = 0; i < fhlist.Count; i++)
            {
                double tmp = (fhlist[i].Lng - ld.Lng) * (fhlist[i].Lng - ld.Lng) + (fhlist[i].Lat - ld.Lat) * (fhlist[i].Lat - ld.Lat);
                result.Add(tmp);
            }
            if (result.Count > 2)
            {

            }
            int first = 0;
            for (int j = 1; j < result.Count; j++)
            {
                if (result[first] > result[j])
                {
                    first = j;
                }
            }


            int second = 1;

            this.S_CountPath1.s1_Lng = fhlist[first].Lng;
            this.S_CountPath1.s1_Lat = fhlist[first].Lat;
            this.S_CountPath1.s2_Lng = fhlist[second].Lng;
            this.S_CountPath1.s2_Lat = fhlist[second].Lat;
            this.S_CountPath1.e_Lng = ld.Lng;
            this.S_CountPath1.e_Lat = ld.Lat;
        }
    }
}