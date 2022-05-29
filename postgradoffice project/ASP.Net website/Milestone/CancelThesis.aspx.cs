using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milestone
{
    public partial class CancelThesis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        protected void BackButton(object sender, EventArgs e)
        {
            Response.Redirect("supervisor.aspx");
        }

        protected void CancelButton(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int ThesisSerialNo = Int16.Parse(TextBox1.Text);
            


            SqlCommand CancelThesis = new SqlCommand("CancelThesis", conn);
            CancelThesis.CommandType = CommandType.StoredProcedure;
            CancelThesis.Parameters.Add(new SqlParameter("@ThesisSerialNo", ThesisSerialNo));
            

            conn.Open();
            CancelThesis.ExecuteNonQuery();
            conn.Close();
        }
    }
}