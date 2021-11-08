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

public partial class AddMap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        type.Focus();

        if(!IsPostBack)
        {
            type_SelectedIndexChanged(sender, e);

            if (Session["planno"] != null)
            {
                image2.Visible = true;
            }
            else
            {
                image2.Visible = false;
                plan_no.Text = string.Empty;
            }
            if (Session["planno_perimeter"] != null)
            {
                ImageButton1.Visible = true;
            }
            else
            {
                ImageButton1.Visible = false;
                planno_p.Text = string.Empty;
            }
        }
        
    }
    protected void savePlan_Click(object sender, EventArgs e)
    {
        //add perimeter survey map to database
        if (type.SelectedItem.Value == "perimeter")
        {
            if(String.IsNullOrEmpty(planno_p.Text))
            {
                Response.Write("<script> alert('Please upload Plan No.');</script>");
            }
            else
            {
                string currentTime = String.Format("{0:HH:mm:ss}", DateTime.Now);

                TimeSpan entrytime = TimeSpan.Parse(currentTime);

                string connectionString = "datasource=localhost; port= 3306; username=root; password=; database=survey";

                string checkPlanNo = "SELECT COUNT(planNo) from plan WHERE planNo ='" + planno_p.Text + "'";

                string query = "INSERT INTO plan(planNo, planNo_image, district, estate, type, tv, page, username, entrydate, entrytime) ";
                query += "VALUES ('" + planno_p.Text + "','" + Session["planno_perimeter"].ToString() + "','";
                query += district_p.Text + "','" + estate_p.Text + "','" + type.SelectedItem.Value + "','";
                query += tv.Text + "','" + tvpage.Text + "','" + Session["username"].ToString() + "','"+ DateTime.Now.ToString("yyyy-MM-dd") +"','"+ entrytime +"')";

                MySqlConnection databaseConnect = new MySqlConnection(connectionString);

                MySqlCommand countplan = new MySqlCommand(checkPlanNo, databaseConnect);

                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnect);

                databaseConnect.Open();

                int intplan = Convert.ToInt32(countplan.ExecuteScalar());

                if (intplan > 0)
                {
                    Response.Write("<script> alert('Plan No. already exist.');</script>");
                    plan_no.Focus();
                    Session["planno_perimeter"] = null;

                    planno_p.Text = string.Empty;
                    ImageButton1.Visible = false;
                }
                else
                {
                    MySqlDataReader myReader = commandDatabase.ExecuteReader();

                    Response.Write("<script> alert('Plan No. added successfully.');</script>");

                    databaseConnect.Close();

                    Session["planno_perimeter"] = null;

                    district_p.Text = string.Empty;
                    estate_p.Text = string.Empty;
                    planno_p.Text = string.Empty;
                    type.SelectedItem.Value = "perimeter";
                    ImageButton1.Visible = false;
                    tv.Text = string.Empty;
                    tvpage.Text = string.Empty;
                }
            
            }
                
        }
        //add other map 
        else
        {
            if (String.IsNullOrEmpty(plan_no.Text))
            {
                Response.Write("<script> alert('Please upload Plan No.');</script>");
            }
            else
            {
                string currentTime = String.Format("{0:HH:mm:ss}", DateTime.Now);

                TimeSpan entrytime = TimeSpan.Parse(currentTime);

                string connectionString = "datasource=localhost; port= 3306; username=root; password=; database=survey";

                string checkPlanNo = "SELECT COUNT(planNo) from plan WHERE planNo ='" + plan_no.Text + "'";

                string query = "INSERT INTO plan(planNo, planNo_image, district, estate, type, username, entrydate, entrytime) ";
                query += " VALUES ('" + plan_no.Text + "','" + Session["planno"].ToString() + "','";
                query += district.Text + "','" + estate.Text + "','" + type.SelectedItem.Value + "','";
                query += Session["username"].ToString() + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "','" + entrytime + "')";

                MySqlConnection databaseConnect = new MySqlConnection(connectionString);

                MySqlCommand countplan = new MySqlCommand(checkPlanNo, databaseConnect);

                databaseConnect.Open();

                int intplan = Convert.ToInt32(countplan.ExecuteScalar());

                if (intplan > 0)
                {
                    Response.Write("<script> alert('Plan No. already exist.');</script>");
                    plan_no.Focus();

                    Session["planno"] = null;

                    plan_no.Text = string.Empty;
                    image2.Visible = false;

                }
                else
                {
                    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnect);

                    MySqlDataReader myReader = commandDatabase.ExecuteReader();

                    Response.Write("<script> alert('Plan No. added successfully.');</script>");

                    databaseConnect.Close();

                    Session["planno"] = null;

                    district.Text = string.Empty;
                    estate.Text = string.Empty;
                    plan_no.Text = string.Empty;
                    image2.Visible = false;
                }
            }
        }
    }
    protected void btnUploadPlan_Click(object sender, EventArgs e)
    {
        if (!planno.HasFile)
        {
            Response.Write("<script> alert('Please upload Plan No.');</script>");
        }
        else
        {
            foreach (HttpPostedFile uploadedFile in planno.PostedFiles)
            {
                image2.Visible = true;
                string folderPath = Server.MapPath("~/images/");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                planno.SaveAs(folderPath + Path.GetFileName(planno.FileName));

                image2.ImageUrl = "~/images/" + Path.GetFileName(planno.FileName);

                Session["planno"] = image2.ImageUrl;

                plan_no.Text = Path.GetFileNameWithoutExtension(planno.FileName);
            }
        }
    }

    protected void btnUploadPlanP_Click(object sender, EventArgs e)   
    {
        if (!FileUpload1.HasFile)
        {
            Response.Write("<script> alert('Please upload Plan No.');</script>");
        }
        else
        {
            foreach (HttpPostedFile uploadedFile in FileUpload1.PostedFiles)
            {
                ImageButton1.Visible = true;
                string folderPath = Server.MapPath("~/images/");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                FileUpload1.SaveAs(folderPath + Path.GetFileName(FileUpload1.FileName));

                ImageButton1.ImageUrl = "~/images/" + Path.GetFileName(FileUpload1.FileName);

                Session["planno_perimeter"] = ImageButton1.ImageUrl;

                planno_p.Text = Path.GetFileNameWithoutExtension(FileUpload1.FileName);
            }
        }
    }

    protected void type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(type.SelectedItem.Value == "perimeter")
        {
            map_perimeter.Visible = true;
            map_add.Visible = false;
            button.Visible = true;
            deletePlan.Visible = true;
            exitPlan.Visible = true;
            savePlan.Visible = true;
        }
        else if(type.SelectedItem.Value == "0")
        {
            map_perimeter.Visible = false;
            map_add.Visible = false;
            deletePlan.Visible = false;
            exitPlan.Visible = true;
            savePlan.Visible = false;
        }
        else
        {
            map_perimeter.Visible = false;
            map_add.Visible = true;
            button.Visible = true;
            deletePlan.Visible = true;
            exitPlan.Visible = true;
            savePlan.Visible = true;
        }
    }

    protected void deletePlan_Click(object sender, EventArgs e)
    {
        Session["planno"] = null;
        Session["planno_perimeter"] = null;
        plan_no.Text = string.Empty;
        planno_p.Text = string.Empty;
        district.Text = string.Empty;
        estate.Text = string.Empty;
        district_p.Text = string.Empty;
        estate_p.Text = string.Empty;
        image2.Visible = false;
        tv.Text = string.Empty;
        tvpage.Text = string.Empty;
        ImageButton1.Visible = false;
    }

    protected void exitPlan_Click(object sender, EventArgs e)
    {
        Session["planno"] = null;
        Session["planno_perimeter"] = null;
        plan_no.Text = string.Empty;
        planno_p.Text = string.Empty;
        district.Text = string.Empty;
        estate.Text = string.Empty;
        district_p.Text = string.Empty;
        estate_p.Text = string.Empty;
        Response.Redirect("FunctionSelection.aspx");
    }
}