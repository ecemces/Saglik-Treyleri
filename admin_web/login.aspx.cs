using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.IO.Ports;
using System.Web.Helpers;
using System.Text;
namespace saglik_treyleri.web1
{
    public partial class WebForm2 : System.Web.UI.Page
    {        
        SqlConnection connect = new SqlConnection("Data Source=localhost;Initial Catalog=SaglikTreyleri;Integrated Security=True");     
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void loginbutton_Click(object sender, EventArgs e)
        {
            connect.Open();
            string password = "select sifre from [kullanicilar] where kullanici = @username ";
            SqlCommand command = new SqlCommand(password, connect);
            command.Parameters.AddWithValue("@username", usernametxt.Text);
            string result = (string)command.ExecuteScalar();
            string yetki = "select yetki from [kullanicilar] where kullanici = @username ";
            SqlCommand command2 = new SqlCommand(yetki, connect);
            command2.Parameters.AddWithValue("@username", usernametxt.Text);
            int yetki_int = (int)command2.ExecuteScalar();
            bool verified = Crypto.VerifyHashedPassword(result, passwordtxt.Text);
            connect.Close();
            
            if ((verified == true) & (yetki_int == 1))
            { 
                Response.Redirect("adminpage.aspx");
                Session["User"] = usernametxt.Text;
            }
            else if ((verified == true) & (yetki_int == 0))
            { 

                InvalidLoginLabel.Visible = true;
                InvalidLoginLabel.Text = "Kullanıcının yetkisi yok.";
                InvalidLoginLabel.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                InvalidLoginLabel.Visible = true;
                InvalidLoginLabel.Text = "Kullanıcı adı veya şifre yanlış.";
                InvalidLoginLabel.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
