using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class SearchPlan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Session["planno_topo"] = null;
            Session["tv_topo"] = null;

            if (Session["planno_perimeter"] != null && Session["tv_perimeter"] != null)
            {
                result.Visible = true;
            }
            else
            {
                result.Visible = false;
            }
        }
        
    }
    protected void search_planno_Click(object sender, EventArgs e)
    {
        if(String.IsNullOrEmpty(planno.Text))
        {
            Response.Write("<script> alert('Insert Plan No.!');</script>");
            planno.Focus();
        }
        else
        {
            string connectionString = "datasource=localhost; port= 3306; username=root; password=; database=survey";

            string query = "SELECT * FROM plan WHERE planNo LIKE '%" + planno.Text + "%' AND type = 'perimeter'";

            MySqlConnection databaseConnect = new MySqlConnection(connectionString);

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnect);

            commandDatabase.CommandTimeout = 60;

            databaseConnect.Open();

            MySqlDataReader read = commandDatabase.ExecuteReader();

            read.Read();

            if (read.HasRows)
            {
                result.Visible = true;

                planNumber.Text = read.GetString(0);
                plan_url.ImageUrl = read.GetString(1);
                district.Text = read.GetString(2);
                estate.Text = read.GetString(3);
                tvName.Text = read.GetString(4);
                tvpage.Text = read.GetString(5);

                Session["planno_perimeter"] = plan_url.ImageUrl;
            }
            else
            {
                Response.Write("<script> alert('No record!');</script>");
                result.Visible = false;
                planno.Focus();
            }

            databaseConnect.Close();
        }
    }
    protected void backbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchPerimeterSelection.aspx");
    }
    protected void deletebtn_Click(object sender, EventArgs e)
    {
        Session["planno_perimeter"] = null;
        planNumber.Text = string.Empty;
        plan_url.ImageUrl = string.Empty;
        district.Text = string.Empty;
        estate.Text = string.Empty;
        tvName.Text = string.Empty;
        tvpage.Text = string.Empty;
        result.Visible = false;
        planno.Text = string.Empty;
        planno.Focus();
    }
}