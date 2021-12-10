using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

public partial class RegisterUser : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=(localdb)\Projects;Initial Catalog=survey;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");

    protected void Page_Load(object sender, EventArgs e)
    {

        if(IsPostBack)
        {
            //txtPassword.Text = Session["pass"].ToString();
            
        }
    }
    protected void registerbtn_Click(object sender, EventArgs e)
    {
        if(String.IsNullOrEmpty(txtUsername.Text))
        {
            Response.Write("<script> alert('Please insert Employee ID.');</script>");

            txtUsername.Focus();
        }
        else if(String.IsNullOrEmpty(txtPassword.Text))
        {
            Response.Write("<script> alert('Please insert Password.');</script>");

            txtPassword.Focus();
        }
        else if(String.IsNullOrEmpty(txtFullname.Text))
        {
            Response.Write("<script> alert('Please insert Full Name.');</script>");
            txtFullname.Focus();
        }
        else
        {
            string strpass = encryptpass(txtPassword.Text);

            string connectionString = "datasource=localhost; port= 3306; username=root; password=; database=survey";

            string query = "INSERT INTO user VALUES ('" + txtUsername.Text + "','" + strpass + "','" + txtFullname.Text + "')";

            MySqlConnection databaseConnect = new MySqlConnection(connectionString);

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnect);

            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnect.Open();

                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                Response.Write("<script> alert('Success.');</script>");

                txtUsername.Text = string.Empty;
                txtFullname.Text = string.Empty;
                txtPassword.Attributes["value"] = string.Empty;

                txtUsername.Focus();

                databaseConnect.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
        }
    }

    public string encryptpass (string password)
    {
        string msg = "";
        byte[] encode = new byte[password.Length];
        encode = System.Text.Encoding.UTF8.GetBytes(password);
        msg = Convert.ToBase64String(encode);
        return msg;
    }

    protected void ShowPassword_CheckedChanged(object sender, EventArgs e)
    {
        if(ShowPassword.Checked == true)
        {
            txtPassword.TextMode = TextBoxMode.SingleLine;
            Session["pass"] = txtPassword.Text;
        }
        else if(ShowPassword.Checked == false)
        {
            txtPassword.TextMode = TextBoxMode.Password;
            if (!(String.IsNullOrEmpty(txtPassword.Text.Trim())))
            {
                txtPassword.Attributes["value"] = txtPassword.Text;
                //or txtPwd.Attributes.Add("value",txtPwd.Text);
            }
        }
    }
}