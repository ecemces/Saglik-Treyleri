using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Web.Helpers;
using static System.Net.Mime.MediaTypeNames;

namespace saglik_treyleri.web1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
       
        SqlConnection connect = new SqlConnection("Data Source=localhost;Initial Catalog=SaglikTreyleri;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void submitbutton_Click(object sender, EventArgs e)
        {
                connect.Open();
                string checkusername = "select * from [kullanicilar] where kullanici = @username ";
                SqlCommand command = new SqlCommand(checkusername, connect);
                command.Parameters.AddWithValue("@username", usernametxt.Text);
                SqlDataReader reader = command.ExecuteReader();

                if (passwordtxt.Text == "" || usernametxt.Text == "")
                {
                    reader.Close();
                    InvalidLabel.Visible = true;
                    InvalidLabel.Text = "Kullanıcı adı ve şifre boş olamaz.";
                    InvalidLabel.ForeColor = System.Drawing.Color.Red;
                }
                else if (!reader.HasRows && passwordtxt0.Text == passwordtxt.Text)
                {
                    reader.Close();
                    var hash = BCrypt.Net.BCrypt.HashPassword(passwordtxt.Text);
                    string createUser = "insert into [kullanicilar]  (kullanici, sifre,yetki) values(@kullanici, @sifre,@yetki)";
                    SqlCommand addCommand = new SqlCommand(createUser, connect);
                    addCommand.Parameters.AddWithValue("@kullanici", usernametxt.Text);
                    addCommand.Parameters.AddWithValue("@sifre", hash);
                    if (CheckBox3.Checked)
                    {
                        addCommand.Parameters.AddWithValue("@yetki", 1);
                    }
                    else if (!CheckBox3.Checked)
                    {
                        addCommand.Parameters.AddWithValue("@yetki", 0);
                    }

                    addCommand.ExecuteNonQuery();
                    connect.Close();
                    InvalidLabel.Visible = true;
                    InvalidLabel.Text = "Kullanıcı eklendi.";
                    InvalidLabel.ForeColor = System.Drawing.Color.Blue;

                    //Response.Redirect("adminpage.aspx");
                }
                else if (reader.HasRows)

                {
                    reader.Close();
                    InvalidLabel.Visible = true;
                    InvalidLabel.Text = "Bu kullanıcı adı kullanılmaktadır.";
                    InvalidLabel.ForeColor = System.Drawing.Color.Red;
                }
                else if (!reader.HasRows && passwordtxt0.Text != passwordtxt.Text)

                {
                    reader.Close();
                    InvalidLabel.Visible = true;
                    InvalidLabel.Text = "Lütfen şifrenizi doğrulayın.";
                    InvalidLabel.ForeColor = System.Drawing.Color.Red;
                }
            
        }
        protected void usernametxt_TextChanged(object sender, EventArgs e)
        {

        }

        protected void logoutbutton_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

