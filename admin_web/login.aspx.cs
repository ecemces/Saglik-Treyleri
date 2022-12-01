using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.IO.Ports;

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
           
            string checkusername = "select * from [kullanicilar] where kullanici = @username and sifre = @password";
            SqlCommand command = new SqlCommand(checkusername, connect);
            connect.Open();
            command.Parameters.AddWithValue("@username", usernametxt.Text);
            command.Parameters.AddWithValue("@password", passwordtxt.Text);
            SqlDataReader reader = command.ExecuteReader();

            //if ((reader.HasRows) & (usernametxt.Text != "admin") & (passwordtxt.Text != "adminim"))
            //{
                
                //reader.Close();
                //connect.Close();
                //Session["User"] = usernametxt.Text;
                //Response.Redirect("anasayfa.aspx");


            //}
            if ((reader.HasRows) & (usernametxt.Text == "admin") & (passwordtxt.Text=="adminim")) //boyle sorun olursa belki databasede yetki verilebilir
            {
                Response.Redirect("adminpage.aspx");
                Session["User"] = usernametxt.Text;
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