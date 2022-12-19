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
using Microsoft.Ajax.Utilities;

namespace saglik_treyleri.web1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection connect = new SqlConnection("Data Source=localhost;Initial Catalog=SaglikTreyleri;Integrated Security=True;MultipleActiveResultSets=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }  
        protected void loginbutton_Click(object sender, EventArgs e)
        {           
            connect.Open();
            //şifre çekildi
            string password = "select sifre from [kullanicilar] where kullanici = @username ";
            SqlCommand command = new SqlCommand(password, connect);
            command.Parameters.AddWithValue("@username", usernametxt.Text);
            string result = (string)command.ExecuteScalar();
            //yetki çekildi
            string yetki = "select yetki from [kullanicilar] where kullanici = @username ";
            SqlCommand command2 = new SqlCommand(yetki, connect);
            command2.Parameters.AddWithValue("@username", usernametxt.Text);
            //reader hazırlanıyor
            string reader_icin= "select yetki from [kullanicilar] where kullanici = @username ";
            SqlCommand reader_command = new SqlCommand(reader_icin, connect);
            reader_command.Parameters.AddWithValue("@username", usernametxt.Text);
            SqlDataReader dr =reader_command.ExecuteReader();
            bool verified = false;
            if (dr.HasRows)
            {
                int yetki_int= (int)command2.ExecuteScalar();
                try { 
                    verified = BCrypt.Net.BCrypt.Verify(passwordtxt.Text, result); 
                }
                catch (BCrypt.Net.SaltParseException ex)
                {
                    verified = false;
                }
                if ((verified == true) & (yetki_int == 1))
                {
                    Response.Redirect("adminpage.aspx");
                    Session["User"] = usernametxt.Text;
                }
                else if ((verified == true) & (yetki_int != 1))
                { // şu an adminin ismi erz imiş gibi düşeneceğiz ama veritabanında yetki columnu eklenecek (yetki_table==1)

                    InvalidLoginLabel.Visible = true;
                    InvalidLoginLabel.Text = "Kullanıcının yetkisi yok.";
                    InvalidLoginLabel.ForeColor = System.Drawing.Color.Red;
                }
                else if (verified==false) {
                    InvalidLoginLabel.Visible = true;
                    InvalidLoginLabel.Text = "Kullanıcı adı veya şifre yanlış.";
                    InvalidLoginLabel.ForeColor = System.Drawing.Color.Red;
                }

            }
            
            else
            {
                InvalidLoginLabel.Visible = true;
                InvalidLoginLabel.Text = "Kullanıcı adı veya şifre yanlış.";
                InvalidLoginLabel.ForeColor = System.Drawing.Color.Red;
            }

            dr.Close();
            connect.Close();
        }
    }
}
