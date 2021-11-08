using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

public partial class SearchPerimeterEstate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void search_estate_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(estate.Text))
        {
            Response.Write("<script> alert('Insert Estate');</script>"); 
            estate.Focus();
        }
        else
        {
            string connectionString = "datasource=localhost; port= 3306; username=root; password=; database=survey";

            string query = "SELECT * FROM plan WHERE estate ='" + estate.Text + "' AND type = 'perimeter'";

            MySqlConnection databaseConnect = new MySqlConnection(connectionString);

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnect);

            commandDatabase.CommandTimeout = 60;

            databaseConnect.Open();

            MySqlDataAdapter da = new MySqlDataAdapter(commandDatabase);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataList.DataSource = ds;
            DataList.DataBind();

            if (DataList.Items.Count == 0)
            {
                labelEmpty.Visible = true;
                labelEmpty.Text = "No record.";
                estate.Focus();
            }
            
            databaseConnect.Close();
        }
    }

    protected void DataList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
       
    }

    protected void deletebtn_Click(object sender, EventArgs e)
    {
        DataList.DataSource = null;
        DataList.DataBind();
        estate.Text = string.Empty;
        labelEmpty.Text = string.Empty;
        estate.Focus();
    }

    protected void imageUrl_Click(object sender, ImageClickEventArgs e)
    {
        /*
        ImageButton img = (ImageButton)sender;
        DataListItem item = (DataListItem)img.NamingContainer;
        ImageButton imageurl = (ImageButton)item.FindControl("imageUrl");

        Response.Redirect("DisplayMarinePlan.aspx?url=" + imageurl.ImageUrl);
        */
    }
}