using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADODOTNET_DEMO
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
            }

        }

        protected void btnRest_Click(object sender, EventArgs e)
        {
            reset_txtbox();
        }

        private void bindData()
        {
            string connectioString = @"Data Source=HIREN_PC\SQLEXPRESS; Initial Catalog=Employee_ADO_DEMO_DB; Integrated Security=true;";
            SqlConnection con = new SqlConnection(connectioString);

            //  string query = string.Format("SELECT * FROM tblEmpInfo ");

            SqlCommand cmd = new SqlCommand("sp_GetEmp", con);
            con.Open();
            gvEmpdata.DataSource = cmd.ExecuteReader();
            gvEmpdata.DataBind();
            con.Close();
        }

        private void reset_txtbox()
        {
            txtFname.Text = "";
            txtLname.Text = "";
            txtAge.Text = "";
            txtSalary.Text = "";
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string fname = txtFname.Text;
            string lname = txtLname.Text;
            int age = !String.IsNullOrEmpty(txtAge.Text) ? Convert.ToInt32(txtAge.Text) : 0;
            int salary = !String.IsNullOrEmpty(txtSalary.Text) ? Convert.ToInt32(txtSalary.Text) : 0;
            if (lname != null && !string.IsNullOrEmpty(fname) && age > 0 && salary > 0)
            {
                string connectioString = @"Data Source=HIREN_PC\SQLEXPRESS; Initial Catalog=Employee_ADO_DEMO_DB; Integrated Security=true;";
                SqlConnection con = new SqlConnection(connectioString);

                string query = string.Format("INSERT INTO tblEmpInfo(Emp_Fname,Emp_Lname,Salary,Age)values('{0}', '{1}', {2}, {3})", fname, lname, salary, age);

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "INSERT", "alert('Employee Added Successfully ')", true);
                reset_txtbox();
                bindData();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Error", "alert('plz ! Fill the data !!')", true);
            }


        }

        protected void gvEmpdata_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvEmpdata.DataKeys[e.RowIndex].Value);
            string connectioString = @"Data Source=HIREN_PC\SQLEXPRESS; Initial Catalog=Employee_ADO_DEMO_DB; Integrated Security=true;";
            SqlConnection con = new SqlConnection(connectioString);

            //  string query = string.Format("SELECT * FROM tblEmpInfo ");

            SqlCommand cmd = new SqlCommand("sp_removeEmp", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            bindData();

        }

        protected void gvEmpdata_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEmpdata.EditIndex = e.NewEditIndex;
            bindData();

        }

        protected void gvEmpdata_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEmpdata.EditIndex = -1;
            bindData();
        }

        protected void gvEmpdata_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvEmpdata.DataKeys[e.RowIndex].Value);
            string fname = (gvEmpdata.Rows[e.RowIndex].FindControl("txt_fname") as TextBox).Text;
            string lname = (gvEmpdata.Rows[e.RowIndex].FindControl("txt_lname") as TextBox).Text;

            string connectioString = @"Data Source=HIREN_PC\SQLEXPRESS; Initial Catalog=Employee_ADO_DEMO_DB; Integrated Security=true;";
            SqlConnection con = new SqlConnection(connectioString);
            SqlCommand cmd = new SqlCommand("sp_UpdateEmp", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@lname", lname);
            cmd.Parameters.AddWithValue("@empid", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            gvEmpdata.EditIndex = -1;
            bindData();

        }
    }
}