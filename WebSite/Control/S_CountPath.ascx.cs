using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Control_S_CountPath : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public double s1_Lng;
    public double s1_Lat;

    public double s2_Lng;
    public double s2_Lat;

    public double e_Lng;
    public double e_Lat;

    public string Get_s1_Lng()
    {
        return s1_Lng.ToString();
    }

    public string Get_s1_Lat()
    {
        return s1_Lat.ToString();
    }

    public string Get_s2_Lng()
    {
        return s2_Lng.ToString();
    }

    public string Get_s2_Lat()
    {
        return s2_Lat.ToString();
    }

    public string Get_e_Lng()
    {
        return e_Lng.ToString();
    }

    public string Get_e_Lat()
    {
        return e_Lat.ToString();
    }
}