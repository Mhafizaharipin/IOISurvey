using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;

public partial class AddPerimeterMap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Session["landmap_perimeter"] != null)
            {
                image2.Visible = true;
            }
            else
            {
                image2.Visible = false;
            }
        }
        
    }
    protected void savePlan_Click(object sender, EventArgs e)
    {
        string currentTime = String.Format("{0:HH:mm:ss}", DateTime.Now);

        TimeSpan entrytime = TimeSpan.Parse(currentTime);

        string connectionString = "datasource=localhost; port= 3306; username=root; password=; database=survey";

        string checkPlanNo = "SELECT COUNT(map_name) from perimeter_map WHERE map_name ='" + land_title.Text + "'";

        string query = "INSERT INTO perimeter_map(estate, map_url, map_name, username, entrydate, entrytime) ";
        query += "VALUES ('" + estate.Text + "','" + Session["landmap_perimeter"].ToString() + "','";
        query += land_title.Text + "','";
        query += Session["username"].ToString() + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + entrytime + "')";

        MySqlConnection databaseConnect = new MySqlConnection(connectionString);

        MySqlCommand countplan = new MySqlCommand(checkPlanNo, databaseConnect);

        MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnect);

        databaseConnect.Open();

        int intplan = Convert.ToInt32(countplan.ExecuteScalar());

        if (intplan > 0)
        {
            Response.Write("<script> alert('Map already exist.');</script>");
            Session["landmap_perimeter"] = null;

        }
        else
        {
            MySqlDataReader myReader = commandDatabase.ExecuteReader();

            Response.Write("<script> alert('Map added successfully.');</script>");

            databaseConnect.Close();

            Session["landmap_perimeter"] = null;
            estate.Text = string.Empty;
            land_title.Text = string.Empty;
            image2.Visible = false;
        }
    }
       
    protected void btnUploadPlan_Click(object sender, EventArgs e)
    {
        if (!map.HasFile)
        {
            Response.Write("<script> alert('Please upload Map');</script>");
        }
        else
        {
            foreach (HttpPostedFile uploadedFile in map.PostedFiles)
            {
                image2.Visible = true;
                string folderPath = Server.MapPath("~/images/");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                map.SaveAs(folderPath + Path.GetFileName(map.FileName));

                image2.ImageUrl = "~/images/" + Path.GetFileName(map.FileName);

                Session["landmap_perimeter"] = image2.ImageUrl;

                land_title.Text = Path.GetFileNameWithoutExtension(map.FileName);
            }
        }
    }


    protected void deletePlan_Click(object sender, EventArgs e)
    {
        Session["landmap_perimeter"] = null;
        estate.Text = string.Empty;
        land_title.Text = string.Empty;
        image2.Visible = false;
    }

    protected void exitPlan_Click(object sender, EventArgs e)
    {
        Session["landmap_perimeter"] = null;
        estate.Text = string.Empty;
        land_title.Text = string.Empty;
        Response.Redirect("AddMapSelection.aspx");
    }
    protected void btnUploadMap_Click(object sender, EventArgs e)
    {
        if (!map.HasFile)
        {
            Response.Write("<script> alert('Please upload Map');</script>");
        }
        else
        {
            foreach (HttpPostedFile uploadedFile in map.PostedFiles)
            {
                image2.Visible = true;
                string folderPath = Server.MapPath("~/images/");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                map.SaveAs(folderPath + Path.GetFileName(map.FileName));

                image2.ImageUrl = "~/images/" + Path.GetFileName(map.FileName);

                Session["landmap_perimeter"] = image2.ImageUrl;

                land_title.Text = Path.GetFileNameWithoutExtension(map.FileName);
            }
        }
    }
}