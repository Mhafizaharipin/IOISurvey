using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

public partial class SearchPerimeterEstate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            displayMap.Visible = false;
            estate.Focus();
        }
        
        if(Session["landtitle"] != null)
        {
            getLandTitle();
            getPlanNoByEstate();
            //getPlanNoListByEstate();
        }
        if(Request.QueryString["estateName"] != null)
        {
            string connectionString = "datasource=localhost; port= 3306; username=root; password=; database=survey";

            string query = "SELECT map_url, estate FROM perimeter_map  WHERE estate LIKE '%" + Request.QueryString["estateName"].Replace("+","").Replace("%","") + "%'";

            MySqlConnection databaseConnect = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnect);

            commandDatabase.CommandTimeout = 60;

            databaseConnect.Open();

             MySqlDataReader reader = commandDatabase.ExecuteReader();

                reader.Read();

                if (reader.HasRows)
                {
                    plan_url.ImageUrl = reader.GetString(0);
                    lblEst.InnerText = "Estate Name: " + reader.GetString(1);
                    estateName.Text = reader.GetString(1);
                    landtitlemaptxt.InnerText = "Land Title Map";
                    Session["landtitle"] = plan_url.ImageUrl;

                    reader.Close();

                    string query2 = "SELECT planNo FROM plan WHERE estate = '" + Request.QueryString["estateName"].Replace("+", "") + "' AND type = 'perimeter'";

                    MySqlCommand getPlanNo = new MySqlCommand(query2, databaseConnect);

                    MySqlDataReader readPlanNo = getPlanNo.ExecuteReader();

                    readPlanNo.Read();

                    if(readPlanNo.HasRows)
                    {
                        displayMap.Visible = true;

                        getLandTitle();
                        getPlanNoByEstate();
                        getPlanNoListByEstate();

                        /*
                        DataTable dt = this.getPlanNoByEstate();

                        //Building an HTML string.
                        StringBuilder html = new StringBuilder();

                        html.Append("<div style='overflow-y: auto; height: 150px;'>");
                        //Table start.
                        html.Append("<table border = '1' style='border-collapse: collapse; width: 30%; height: 150px;'>");

                        //Building the Header row.
                        html.Append("<thead>");
                       
                        //Building the Header row.
                        html.Append("<tr>");
                        foreach (DataColumn column in dt.Columns)
                        {
                            html.Append("<th style='position: sticky; top: 0; height: 35px;'>");
                            html.Append(column.ColumnName);
                            html.Append("</th>");
                        }
                        html.Append("</tr>");
                        html.Append("</thead>");
                        html.Append("<tbody>");

                        //Building the Data rows.
                        foreach (DataRow row in dt.Rows)
                        {
                            html.Append("<tr>");
                            foreach (DataColumn column in dt.Columns)
                            {
                                html.Append("<td style='padding: 8px 16px; border: 1px solid #ccc;'>");
                                html.Append("<a href='SearchPerimeterEstate.aspx?PlanNo=" + row[column.ColumnName] + "'>" + row[column.ColumnName] + "</a>");
                                html.Append("</td>");
                            }
                            html.Append("</tr>");
                        }

                        html.Append("</tbody>");
                        //Table end.
                        html.Append("</table>");

                        html.Append("</div>");

                        //Append the HTML string to Placeholder.
                        PlaceHolder2.Controls.Add(new Literal { Text = html.ToString() });
                        */
                        plan_url.Visible = true;
                        readPlanNo.Close();
                    }
                    else
                    {
                        displayMap.Visible = true;
                        //placeholder2empty.Text = "Plan No for this estate does not exist";
                    }
                }
                else
                {
                    labelEmpty.Text = "No Record Found!";
                    estate.Focus();
                }
        }
        
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

            string query = "SELECT map_url, estate FROM perimeter_map  WHERE estate LIKE '%" + estate.Text + "%'";

            MySqlConnection databaseConnect = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnect);

            commandDatabase.CommandTimeout = 60;

            databaseConnect.Open();

            //check if estate exist in perimeter_map 
            string getEstate = "SELECT COUNT(estate) FROM perimeter_map WHERE estate LIKE '%" + estate.Text + "%'";

            MySqlCommand cmdGetestate = new MySqlCommand(getEstate, databaseConnect);

            int countEst = Convert.ToInt32(cmdGetestate.ExecuteScalar());

            //if estate > 1
            if(countEst > 1)
            {
                displayMap.Visible = false;


                DataTable dt = this.getEstateList();

                //Building an HTML string.
                StringBuilder html = new StringBuilder();

                html.Append("<div style='overflow-y: auto; height: 150px;'>");
                //Table start.
                html.Append("<table border = '1' style='border-collapse: collapse; width: 15%; height: 150px;'>");

                //Building the Header row.
                html.Append("<thead>");

                //Building the Header row.
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<th style='position: sticky; top: 0; text-align:center;'>");
                    html.Append(column.ColumnName);
                    html.Append("</th>");
                }

                html.Append("</tr>");
                html.Append("</thead>");
                html.Append("<tbody>");

                //Building the Data rows.
                foreach (DataRow row in dt.Rows)
                {
                    html.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        html.Append("<td style='border: 1px solid #ccc; text-align:center;'>");
                        html.Append("<a href='SearchPerimeterEstate.aspx?estateName=" + row[column.ColumnName] + "'>" + row[column.ColumnName] + "</a>");
                        html.Append("</td>");
                    }
                    html.Append("</tr>");
                }

                html.Append("</tbody>");
                //Table end.
                html.Append("</table>");

                html.Append("</div>");

                //Append the HTML string to Placeholder.
                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

            }
            //else if estate = 1
            else if (countEst == 1)
            {
                MySqlDataReader reader = commandDatabase.ExecuteReader();

                reader.Read();

                if (reader.HasRows)
                {
                    plan_url.ImageUrl = reader.GetString(0);
                    lblEst.InnerText = "Estate Name: " + reader.GetString(1);
                    estateName.Text = reader.GetString(1);
                    landtitlemaptxt.InnerText = "Land Title Map";
                    Session["landtitle"] = plan_url.ImageUrl;

                    reader.Close();

                    string query2 = "SELECT planNo, planNo_image FROM plan WHERE estate = '" + estateName.Text + "' AND type = 'perimeter'";

                    MySqlCommand getPlanNo = new MySqlCommand(query2, databaseConnect);

                    MySqlDataReader readPlanNo = getPlanNo.ExecuteReader();

                    readPlanNo.Read();

                    if(readPlanNo.HasRows)
                    {
                        getPlanNoListByEstate();
                        plan_url.Visible = true;
                        displayMap.Visible = true;
                        getLandTitle();
                        getGVDS();
                    }
                    else
                    {
                        displayMap.Visible = true;
                        labelEmpty.Text = "Plan No for this estate does not exist";
                    }
                    
                    plan_url.Visible = true;
                    
                    readPlanNo.Close();
                }
                else
                {
                    labelEmpty.Text = "No Record Found!";
                    estate.Focus();
                }
            }
            //else if estate = 0
            else if(countEst == 0)
            {
                labelEmpty.Text = "No record found";
                estate.Focus();
            }

            databaseConnect.Close();
        }
    }

    private void getGVDS()
    {
        string connectionString = "datasource=localhost; port= 3306; username=root; password=; database=survey";

        string query = "SELECT planNo, planNo_image, district, estate, tv, page FROM plan WHERE estate = '" + estateName.Text + "' and type = 'perimeter'";

        MySqlConnection databaseConnect = new MySqlConnection(connectionString);
        MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnect);

        databaseConnect.Open();

        MySqlDataReader sdr = commandDatabase.ExecuteReader();
        GridView1.DataSource = sdr;
        GridView1.DataBind();
        plannolabel.InnerText = "Plan No List";
        databaseConnect.Close();

    }
    private void getPlanNoListByEstate()
    {
        string connectionString = "datasource=localhost; port= 3306; username=root; password=; database=survey";

        string query = "SELECT planNo_image, estate FROM plan  WHERE estate = '" + estateName.Text + "'";

        MySqlConnection databaseConnect = new MySqlConnection(connectionString);
        MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnect);

        commandDatabase.CommandTimeout = 60;

        databaseConnect.Open();

        MySqlDataReader reader = commandDatabase.ExecuteReader();

        reader.Read();

        if(reader.HasRows)
        {
            DataTable dt = this.getPlanNoByEstate();

            //Building an HTML string.
            StringBuilder html = new StringBuilder();

            //table title
            html.Append("<h3>Plan No list</h3>");

            //Table start.
            html.Append("<div style='overflow-y: auto; height: 150px;'>");
            //Table start.
            html.Append("<table border = '1' style='border-collapse: collapse; width: 30%; height: 100px;'>");

            //Building the Header row.
            html.Append("<thead>");

            //Building the Header row.
            html.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                html.Append("<th style='position: sticky; top: 0; height: 35px;'>");
                html.Append(column.ColumnName);
                html.Append("</th>");
            }
            html.Append("</tr>");
            html.Append("</thead>");
            html.Append("<tbody>");

            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td style='padding: 8px 16px; border: 1px solid #ccc;'>");
                    html.Append("<a href='#' onclick='DisplayDIV();' style='text-align: center; padding: 5px; margin: 0; '>" + row[column.ColumnName] + "</a>");
                    //html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                    
                }
                html.Append("</tr>");
                html.Append("<script> function DisplayDIV() { window.open('DisplayPlanNoPerimeterByEstate.aspx?planNo=" + reader.GetString(0) + "', 'open_window', 'width=1500, height=1000, left = 0, top = 0, center=yes, scrollbars=1'); }</script>");

            }

            html.Append("</tbody>");
            //Table end.
            html.Append("</table>");

            html.Append("</div>");

            //display plan no image after click plan no image link.
            
            //Append the HTML string to Placeholder.
            PlaceHolder2.Controls.Add(new Literal { Text = html.ToString() });
        }
        //else
        //{
           // placeholder2empty.Text = "No Plan No exist for this estate";
        //}
        

        reader.Close();
    }
    private void getLandTitle()
    {
        string connectionString = "datasource=localhost; port= 3306; username=root; password=; database=survey";

        string query = "SELECT estate FROM land_title WHERE estate = '" + estateName.Text + "'";

        MySqlConnection databaseConnect = new MySqlConnection(connectionString);
        MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnect);

        commandDatabase.CommandTimeout = 60;

        databaseConnect.Open();

        MySqlDataReader reader = commandDatabase.ExecuteReader();

        reader.Read();

        if (reader.HasRows)
        {
            //check if land title is exist
            DataTable dt = this.getLandTitleList();

            //Building an HTML string.
            StringBuilder html = new StringBuilder();

            //table title
            html.Append("<h3>Land Title List</h3>");

            html.Append("<div style='overflow-y: auto; width:80%; height: 150px;'>");
            //Table start.
            html.Append("<table border = '1' style='border-collapse: collapse; width: 100%; height: 150px;'>");

            //Building the Header row.
            html.Append("<thead style='background: #fff;'>");

            //Building the Header row.
            html.Append("<tr style='background: #fff;'>");
            foreach (DataColumn column in dt.Columns)
            {
                html.Append("<th style='position: sticky; top: 0; background: #fff; height: 35px;'>");
                html.Append(column.ColumnName);
                html.Append("</th>");
            }
            html.Append("</tr>");
            html.Append("</thead>");

            html.Append("<tbody>");

            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td style='padding: 8px 16px; border: 1px solid #ccc;'>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }

            html.Append("</tbody>");
            //Table end.
            html.Append("</table>");

            html.Append("</div>");

            //Append the HTML string to Placeholder.
            PlaceHolder3.Controls.Add(new Literal { Text = html.ToString() });
        }
        else
        {
            //placeholder3empty.Text = "No Land Title List exist for this estate";
        }
        reader.Close();
    }

    private DataTable getEstateList()
    {
        //get data from database
         string constr = "datasource=localhost; port= 3306; username=root; password=; database=survey";
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT estate AS Estate FROM perimeter_map WHERE estate LIKE '%" + estate.Text + "%'"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
    }

    private DataTable getLandTitleList()
    {
        //get data from database
        string constr = "datasource=localhost; port= 3306; username=root; password=; database=survey";
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT no AS 'NO', beneficiary_owner AS 'Beneficiary Owner', title_no AS 'Title No', locality AS 'Locality', as_per_land_title_acres AS 'As Per Land Title (Acres)', as_per_land_title_ha AS 'As Per Land Title (Ha)', weighted_avg_ha AS 'Weighted Average (Ha)', GIS_data_ha AS 'GIS Data (Ha)', area_adjustment AS 'Area Adjustment' FROM land_title WHERE estate LIKE '%" + estateName.Text + "%'"))
            {
                using (MySqlDataAdapter sda = new MySqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }

    private DataTable getPlanNoByEstate()
    {
        string constr = "datasource=localhost; port= 3306; username=root; password=; database=survey";
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT planNo AS 'Plan No', district AS 'District', estate AS 'Estate', tv as 'Traverse Volume', page AS 'Page' FROM plan WHERE estate = '" + estateName.Text + "' AND type = 'perimeter'"))
            {
                using (MySqlDataAdapter sda = new MySqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
    
    protected void DataList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
       
    }

    protected void deletebtn_Click(object sender, EventArgs e)
    {
        estate.Text = string.Empty;
        labelEmpty.Text = string.Empty;
        estate.Focus();
        plan_url.Visible = false;
        estateName.Visible = false;
        estateName.Text = string.Empty;
        lblEst.InnerText = string.Empty;
        Session["landtitle"] = null;
        Response.Redirect("~/SearchPerimeterEstate.aspx");
    }

    protected void imageUrl_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        DataListItem item = (DataListItem)img.NamingContainer;
        ImageButton imageurl = (ImageButton)item.FindControl("Image1");

        Server.Transfer("DisplayLandTitleMap.aspx?url=" + imageurl.ImageUrl);
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            //Determine the RowIndex of the Row whose LinkButton was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            //Reference the GridView Row.
            GridViewRow row = GridView1.Rows[rowIndex];

            //Fetch value of Country
            string plannoimage = row.Cells[1].Text;
            
             StringBuilder html = new StringBuilder();

             html.Append("<script> function DisplayDIV() { window.open('DisplayPlanNoPerimeterByEstate.aspx?planNo=" + plannoimage + "', 'open_window', 'width=1500, height=1000, left = 0, top = 0, center=yes, scrollbars=1'); }</script>");

        }
    }
}