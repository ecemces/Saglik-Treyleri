using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace saglik_treyleri.web1
{
    public partial class adminpage : System.Web.UI.Page

    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void raporButton_Click(object sender, EventArgs e)
        {   
            string myname = "";
            if (Session["User"] != null)
            {
                myname = Session["User"].ToString();
            }
           
            Response.Redirect("rapor.aspx");
        }
        protected void kullanıcıEkle_Click(object sender, EventArgs e)
        {
            string myname = "";
            if (Session["User"] != null)
            {
                myname = Session["User"].ToString();
            }

            Response.Redirect("signup.aspx");
        }

        protected void desciptionTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
