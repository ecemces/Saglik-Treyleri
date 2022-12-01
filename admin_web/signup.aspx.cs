using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace saglik_treyleri.web1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection connect = new SqlConnection("Data Source=localhost;Initial Catalog=SaglikTreyleri;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitbutton_Click(object sender, EventArgs e)
        {
            connect.Open();
            string checkusername = "select * from [kullanicilar] where kullanici = @username ";
            SqlCommand command = new SqlCommand(checkusername, connect);
            command.Parameters.AddWithValue("@username", usernametxt.Text);
            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows && passwordtxt0.Text==passwordtxt.Text)
            {
                reader.Close();
                string createUser = "insert into [kullanicilar]  (kullanici, sifre) values(@kullanici, @sifre)";
                SqlCommand addCommand = new SqlCommand(createUser, connect);
                addCommand.Parameters.AddWithValue("@kullanici", usernametxt.Text);
                addCommand.Parameters.AddWithValue("@sifre", passwordtxt.Text);
                addCommand.ExecuteNonQuery();
                connect.Close();
                InvalidLabel.Visible = true;
                InvalidLabel.Text = "Kullanıcı eklendi.";
                InvalidLabel.ForeColor = System.Drawing.Color.Blue;

                //Response.Redirect("adminpage.aspx");
            }
            else if (reader.HasRows)
            {
                InvalidLabel.Visible = true;
                InvalidLabel.Text = "Bu kullanıcı adı kullanılmaktadır.";
                InvalidLabel.ForeColor = System.Drawing.Color.Red;
            }
            else if (!reader.HasRows && passwordtxt0.Text != passwordtxt.Text)
            {
                InvalidLabel.Visible = true;
                InvalidLabel.Text = "Lütfen şifrenizi doğrulayın.";
                InvalidLabel.ForeColor = System.Drawing.Color.Red;
            }


        }
    }
}

