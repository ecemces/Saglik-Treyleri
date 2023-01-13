using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Specialized;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;

namespace saglik_treyleri
{

    public partial class rapor : System.Web.UI.Page
    {

        SqlConnection connect = new SqlConnection("Data Source=localhost;Initial Catalog=SaglikTreyleri;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("login.aspx");
            }
            string myname = "";
            if (Session["User"] != null)
            {
                myname = Session["User"].ToString();
            }
            connect.Open();
            string checkusername = "select UPPER(LEFT(kullanici,1))+LOWER(SUBSTRING(kullanici,2,LEN(kullanici))) as Kullanıcı, + SPACE(9) + cekmece as Çekmece, CAST(tarih AS varchar) as Tarih,saat as Saat from [logKayit_] ";
            SqlCommand command = new SqlCommand(checkusername, connect);
            SqlDataReader reader = command.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
