using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Drawing.Imaging;

public partial class SoilMapD : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["planno_perimeter"] = null;

        if (!IsPostBack)
        {
            string connectionString = "datasource=localhost; port= 3306; username=root; password=; database=survey";

            MySqlConnection conn = new MySqlConnection(connectionString);

            conn.Open();
            string query = "SELECT * FROM plan WHERE type = 'soil_d'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataList.DataSource = ds;
            DataList.DataBind();

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            reader.Read();

            if(DataList.Items.Count == 0)
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

       // Session["soil_plan"] = imageurl.ImageUrl;

        Server.Transfer("DisplaySoilPlan.aspx?url="+ imageurl.ImageUrl);
    }
}