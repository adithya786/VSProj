using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleApp1
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadDepartments();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmit.Text == "Add Department")
                {

                }
                else if (btnSubmit.Text == "Edit Department")
                {

                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void grdDepartments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditDepartment")
            {
                lblErrorMessage.Text = "";
                int index=Convert.ToInt32(e.CommandArgument.ToString());
                int deptid =Convert.ToInt32(grdDepartments.DataKeys[index]["DeptID"]);
                DataClasses1DataContext dcdc = new DataClasses1DataContext();
                ///Home department = (from row in dcdc.Departments where row.DeptId == deptid select row).FirstOrDefault<Home>();
               /// txtDepartmentName.Text== 

            }
            else if (e.CommandName == "DeleteDepartment")
            {

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";
            if (btnSubmit.Text == "Edit Employee")
            {
                btnSubmit.Text = "Add Department";
                txtDepartmentId.Text = "";
                txtDepartmentName.Text = "";
                txtLocation.Text = "";
            }
            else
            {
                txtDepartmentName.Text = "";
                txtLocation.Text = "";
            }
        }
        public void loadDepartments()
        {
            DataClasses1DataContext dcdc = new DataClasses1DataContext();
            List<Department> department = (from row in dcdc.Departments select row).ToList<Department>();
            grdDepartments.DataSource = department;
            grdDepartments.DataBind();

        }

    }
}