using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class admin_ChangePassword : System.Web.UI.Page
{
    string Empid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["EmpID"]) != null && Convert.ToString(Session["EmpID"]) != "")
        {
            Empid = Convert.ToString(Session["EmpID"]);
        }
       
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DataBase DB = new DataBase();
            string checkpswdQuery = "select * from Employee_Credentials where emp_id='" + Empid + "' and password='"+txtOldPassword.Text+"'";
            DataTable dt = DB.ExcutesQuery(checkpswdQuery);
            if (dt.Rows.Count > 0)
            {
                string UpdtQuery = "Update Employee_Credentials set password='" + txtNewPassword.Text.Replace("'", "''") + "'Where emp_id='" + Empid + "'";

                string result = DB.UpdateData(UpdtQuery);

                if (result != null && result != "")
                {
                    lblMsg.Text = "Password Change Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Visible = true;
                }
                else
                {
                    lblMsg.Text = "Password Not Change";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Visible = true;
                }
            }
            else
            {
                lblMsg.Text = "Wrong Old Password";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Visible = true;
                txtOldPassword.Focus();
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On btnSave_Click: " + ex.Message + "')", true);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Home.aspx");
    }
   
}
