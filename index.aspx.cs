using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtUserName.Focus();
            lblMsg.Visible = false;
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            string Query = "select * from FieldWorkMgt_DB.dbo.Employee where EmailID='" + txtUserName.Text + "' and isActive='" + true + "'";
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(Query);
            if (dt.Rows.Count > 0)
            {
                string id = dt.Rows[0]["ID"].ToString();
                string Query1 = "select * from FieldWorkMgt_DB.dbo.Employee_Credentials where emp_id='" + id + "' and password='" + txtPassword.Text + "'";
                DataTable _dt = DB.ExcutesQuery(Query1);
                if (_dt.Rows.Count > 0)
                {
                    string getRoles = "Select Top 1 emp.role_id, emp.emp_id,rol.role_name from FieldWorkMgt_DB.dbo.Employee_Role emp " +
                                      " Left outer join FieldWorkMgt_DB.dbo.Role rol on emp.role_id=rol.role_id where emp.emp_id='" + id + "' ";
                    DataTable dtgetroles = DB.ExcutesQuery(getRoles);
                    if (dtgetroles.Rows.Count > 0)
                    {
                        Session["RoleID"] = Convert.ToString(dtgetroles.Rows[0]["role_id"].ToString());
                        Session["RoleName"] = Convert.ToString(dtgetroles.Rows[0]["role_name"].ToString());
                        string getPSCode = "select COALESCE(ps_code,0,0,'') as ps_code from FieldWorkMgt_DB.dbo.Employee where ID=" + id;
                        DataTable dtGetPSCode = DB.ExcutesQuery(getPSCode);
                        Session["PSCode"] = Convert.ToString(dtGetPSCode.Rows[0]["ps_code"].ToString());
                    }
                    else
                    {
                        lblMsg.Text = "Invalid User no Role assigned";
                        lblMsg.Visible = true;
                        return;
                    }

                    Session["flag"] = true;
                    Session["EmpID"] = _dt.Rows[0]["emp_id"].ToString();
                    lblMsg.Visible = false;
                    Response.Redirect("ps_home.aspx");
                }
                else
                {
                    lblMsg.Text = "Invalid User Name or Password";
                    lblMsg.Visible = true;
                    txtUserName.Focus();
                }
            }
            else
            {
                lblMsg.Text = "Invalid User Name or Inactive";
                lblMsg.Visible = true;
                txtUserName.Focus();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "Problem in Login: '" + ex + "'";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert(Problem in Login: '" + ex.Message + "')", true);
        }
    }    
}
