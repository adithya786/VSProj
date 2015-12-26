using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleApp
{
    /// <summary>
    /// this class is for perfom all employee operations.
    /// </summary>
    public partial class MyEmployee : System.Web.UI.Page
    {

        #region "Control Events"
       
        /// <summary>
        /// This event is to load the employee details.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            loadEmployeees();
        }

        /// <summary>
        /// This event is to add or update the employee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmit.Text == "Add Employee")
                {
                    MySampleDataContext mySampleDataContext = new MySampleDataContext();
                    Employee emp = new Employee();
                    emp.EmpName = txtEmployeeName.Text;
                    emp.Designation = txtDesignation.Text;
                    mySampleDataContext.Employees.InsertOnSubmit(emp);
                    mySampleDataContext.SubmitChanges();
                    lblErrorMessage.Text = "Employee Added Succesfully";
                    lblErrorMessage.ForeColor = System.Drawing.Color.Green;
                    txtEmployeeName.Text = "";
                    txtDesignation.Text = "";
                    loadEmployeees();
                }
                else if(btnSubmit.Text=="Edit Employee")
                {
                    MySampleDataContext msdc = new MySampleDataContext();
                    int empID = Convert.ToInt32(txtEmployeeId.Text);
                    Employee emp = (from row in msdc.Employees where row.EmpId == empID select row).FirstOrDefault<Employee>();
                    emp.EmpName = txtEmployeeName.Text;
                    emp.Designation = txtDesignation.Text;                   
                    msdc.SubmitChanges();
                    lblErrorMessage.Text = "Employee Updated Succesfully";
                    lblErrorMessage.ForeColor = System.Drawing.Color.Green;
                    txtEmployeeName.Text = "";
                    txtEmployeeId.Text = "";
                    txtDesignation.Text = "";
                    btnSubmit.Text = "Add Employee";
                    loadEmployeees();

                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            }

        }
        
        /// <summary>
        /// This method is to update or delete data in grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdEmployees_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditEmployee")
            {
                lblErrorMessage.Text = "";
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                int empID = Convert.ToInt32(grdEmployees.DataKeys[index]["EmpID"]);
                MySampleDataContext msdc = new MySampleDataContext();
                Employee employee = (from row in msdc.Employees where row.EmpId == empID select row).FirstOrDefault<Employee>();
                txtEmployeeName.Text = employee.EmpName;
                txtEmployeeId.Text = employee.EmpId.ToString();
                txtDesignation.Text = employee.Designation;
                btnSubmit.Text = "Edit Employee";
            }
            else if(e.CommandName == "DeleteEmployee")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                int empID = Convert.ToInt32(grdEmployees.DataKeys[index]["EmpID"]);
                MySampleDataContext msdc = new MySampleDataContext();
                Employee employee = (from row in msdc.Employees where row.EmpId == empID select row).FirstOrDefault<Employee>();
                msdc.Employees.DeleteOnSubmit(employee);
                msdc.SubmitChanges();
                lblErrorMessage.Text = "Employee Deleted Succesfully";
                loadEmployeees();
            }
        }

        /// <summary>
        /// this event is to clear the control values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";
            if (btnSubmit.Text == "Edit Employee")
            {
                btnSubmit.Text = "Add Employee";
                txtEmployeeId.Text = "";
                txtEmployeeName.Text = "";
                txtDesignation.Text = "";
            }
            else
            {
                txtEmployeeName.Text = "";
                txtDesignation.Text = "";
            }
        }

        #endregion

        #region Internal methods
        /// <summary>
        /// This method is to load employee in grid.
        /// </summary>
        private void loadEmployeees()
        {
            MySampleDataContext msdc = new MySampleDataContext();
            List<Employee> employees = (from row in msdc.Employees select row).ToList<Employee>();
            grdEmployees.DataSource = employees;
            grdEmployees.DataBind();
        }
        #endregion
    }
}