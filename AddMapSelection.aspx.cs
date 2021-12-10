using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddMapSelection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void addBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddMap.aspx");
    }
    protected void addMap_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddPerimeterMap.aspx");
    }
    protected void backbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("FunctionSelection.aspx");
    }
}