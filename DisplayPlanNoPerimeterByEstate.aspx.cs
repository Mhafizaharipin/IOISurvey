using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DisplayPlanNoPerimeterByEstate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        image1.ImageUrl = Request.QueryString["planNo"].ToString();
    }
}