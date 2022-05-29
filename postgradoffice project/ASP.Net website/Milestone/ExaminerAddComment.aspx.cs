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
    public partial class ExaminerAddComment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Examiner.aspx");
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int thesisSerialNumber = Int16.Parse(thesisSerialNumberBox.Text);
            DateTime defenseDate = DateTime.Parse(defenseDateBox.Text);
            String commentValue = commentBox.Text;

            SqlCommand AddCommentsGrade = new SqlCommand("AddCommentsGrade", conn);
            AddCommentsGrade.CommandType = CommandType.StoredProcedure;
            AddCommentsGrade.Parameters.Add(new SqlParameter("@ThesisSerialNo", thesisSerialNumber));
            AddCommentsGrade.Parameters.Add(new SqlParameter("@DefenseDate", defenseDate));
            AddCommentsGrade.Parameters.Add(new SqlParameter("@comments", commentValue));

            conn.Open();
            AddCommentsGrade.ExecuteNonQuery();
            conn.Close();

        }
    }
}