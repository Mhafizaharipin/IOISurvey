using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

public partial class LocalityMap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["planno_perimeter"] = null;

        if (!IsPostBack)
        {
            string connectionString = "datasource=localhost; port= 3306; username=root; password=; database=survey";

            MySqlConnection conn = new MySqlConnection(connectionString);

            conn.Open();
            string query = "SELECT * FROM plan WHERE type = 'locality'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataList.DataSource = ds;
            DataList.DataBind();

            if (DataList.Items.Count == 0)
            {
                labelEmpty.Visible = true;
                labelEmpty.Text = "No record.";
            }
            conn.Close();
        }
    }

    protected void DataList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Label imgplan = (Label)e.Item.FindControl("map_url");
        Session["soil_plan"] = imgplan.Text;
    }
    protected void imageUrl_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        DataListItem item = (DataListItem)img.NamingContainer;
        ImageButton imageurl = (ImageButton)item.FindControl("imageUrl");
        Response.Redirect("DisplayLocalityPlan.aspx?url=" + imageurl.ImageUrl);
    }
}