using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DisplayTVPerimeter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        image1.ImageUrl = Session["tv_perimeter"].ToString();
    }
}