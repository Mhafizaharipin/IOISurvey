using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

public partial class SearchTopoN : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["planno_perimeter"] = null;

        if (!IsPostBack)
        {
            string connectionString = "datasource=localhost; port= 3306; username=root; password=; database=survey";

            MySqlConnection conn = new MySqlConnection(connectionString);

            conn.Open();
            string query = "SELECT * FROM plan WHERE type = 'topo_n'";
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
       
    }
   
    protected void imageUrl_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        DataListItem item = (DataListItem)img.NamingContainer;
        ImageButton imageurl = (ImageButton)item.FindControl("imageUrl");

        Server.Transfer("DisplayPlanNoTopo.aspx?url="+ imageurl.ImageUrl);
    }

    protected void backbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchSelection.aspx");
    }
}