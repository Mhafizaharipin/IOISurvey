using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        username.Focus();

        if(!IsPostBack)
        {
            Session.RemoveAll();
        }
    }
    protected void loginBtn_Click(object sender, EventArgs e)
    {
        if(String.IsNullOrEmpty(username.Text))
        {
            Response.Write("<script> alert('Please insert your Employee ID.');</script>");
            username.Focus();
        }
        else if(String.IsNullOrEmpty(password.Text))
        {
            Response.Write("<script> alert('Please insert your Password');</script>");
            password.Focus();
        }
        else
        {
            string strpass = encryptpass(password.Text);

            string connectionString = "datasource=localhost; port= 3306; username=root; password=; database=survey";

            string query = "SELECT * FROM user WHERE username ='" + username.Text + "' AND password = '" + strpass + "'";

            MySqlConnection databaseConnect = new MySqlConnection(connectionString);

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnect);

            commandDatabase.CommandTimeout = 60;

            databaseConnect.Open();

            MySqlDataReader read = commandDatabase.ExecuteReader();

            read.Read();

            if (read.HasRows)
            {
                Session["user"] = read.GetString(0);
                Session["username"] = read.GetString(2);

                if(Session["user"].ToString() == "admin")
                {
                    Response.Redirect("~/RegisterUser.aspx");
                }
                else
                {
                    Response.Redirect("~/FunctionSelection.aspx");
                }
            }
            else
            {
                Response.Write("<script> alert('Invalid Employee ID or Password');</script>");
            }

            databaseConnect.Close();
        }
    }

    public string encryptpass(string password)
    {
        string msg = "";
        byte[] encode = new byte[password.Length];
        encode = System.Text.Encoding.UTF8.GetBytes(password);
        msg = Convert.ToBase64String(encode);
        return msg;
    }
}