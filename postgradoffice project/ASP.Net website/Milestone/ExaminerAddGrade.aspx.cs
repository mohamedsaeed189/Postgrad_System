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
    public partial class ExaminerAddGrade : System.Web.UI.Page
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
            decimal grade = decimal.Parse(gradeBox.Text);

            SqlCommand AddDefenseGrade = new SqlCommand("AddDefenseGrade", conn);
            AddDefenseGrade.CommandType = CommandType.StoredProcedure;
            AddDefenseGrade.Parameters.Add(new SqlParameter("@ThesisSerialNo", thesisSerialNumber));
            AddDefenseGrade.Parameters.Add(new SqlParameter("@DefenseDate", defenseDate));
            AddDefenseGrade.Parameters.Add(new SqlParameter("@grade", grade));

            conn.Open();
            AddDefenseGrade.ExecuteNonQuery();
            conn.Close();
        }
    }
}