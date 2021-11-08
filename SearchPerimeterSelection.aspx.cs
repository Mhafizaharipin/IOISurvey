using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchPerimeterSelection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void byPlanNo_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchPerimeterPlan.aspx");

    }
    protected void byEstate_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchPerimeterEstate.aspx");
    }
}