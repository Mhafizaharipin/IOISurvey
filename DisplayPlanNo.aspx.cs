using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DisplayPlanNo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        image1.ImageUrl = Session["planno"].ToString();
    }
}