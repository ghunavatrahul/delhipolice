using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EmployeeAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRole();
            LoadRecord();
        }
    }

    protected void BindRole()
    {
        try
        {
            string Query = "Select * from Role where status='true'";
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(Query);

            lstBoxTest.DataSource = dt;
            lstBoxTest.DataTextField = "role_name";
            lstBoxTest.DataValueField = "role_id";
            lstBoxTest.DataBind();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On BindRole: " + ex.Message + "')", true);
        }
    }

    protected void LoadRecord()
    {
        try
        {
            lblId.InnerText = Request.QueryString["ID"];
            //lblId.InnerText =Convert.ToString(Session["ID"]);
            int id = 0;
            int.TryParse(lblId.InnerText, out id);

            string Query = "Select emp.ID,emp.Fname,emp.Mname,emp.Lname,emp.EmailID,emp.PhoneNO,emp.isActive,cred.password,cred.date_updated,rol.role_id " +
                            "from Employee emp " +
                            "Left join Employee_Credentials cred on emp.ID=cred.emp_id " +
                            "Left join Employee_Role rol on emp.ID=rol.emp_id " +
                            "Where emp.ID='" + id + "'";

            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(Query);
            if (dt.Rows.Count > 0)
            {
                txtEmailid.ReadOnly = true;
                divEmpcode.Visible = true;
                txtEmpcode.Text = Request.QueryString["ID"];
                txtEmailid.Text = dt.Rows[0]["EmailID"].ToString();
                txtFirstname.Text = dt.Rows[0]["Fname"].ToString();
                txtMiddlename.Text = dt.Rows[0]["Mname"].ToString();
                txtLastname.Text = dt.Rows[0]["Lname"].ToString();
                txtPassword.TextMode = TextBoxMode.SingleLine;
                txtPassword.Text = dt.Rows[0]["password"].ToString();
                txtConfirmPassword.TextMode = TextBoxMode.SingleLine;
                txtConfirmPassword.Text = dt.Rows[0]["password"].ToString();
                txtPhoneNumber.Text = dt.Rows[0]["PhoneNO"].ToString();

                bool active = false;
                bool.TryParse(dt.Rows[0]["isActive"].ToString(), out active);
                chkActive.Checked = active;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToString(dt.Rows[i]["role_id"]) == null || Convert.ToString(dt.Rows[i]["role_id"]) == "")
                    {
                        lstBoxTest.SelectedIndex = -1;
                    }
                    else
                    {
                        lstBoxTest.Items.FindByValue(Convert.ToString(dt.Rows[i]["role_id"])).Selected = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On LoadRecord: " + ex.Message + "')", true);
        }
    }

    protected void InsertEmpData()
    {
        try
        {
            string ID = lblId.InnerText;
            int id = 0;
            int.TryParse(ID, out id);

            string selectedValues = string.Empty;
            foreach (ListItem li in lstBoxTest.Items)
            {
                if (li.Selected == true)
                {
                    selectedValues += li.Value + ",";

                }
            }
            selectedValues = selectedValues.TrimEnd(',');
            empDetails _empDetails = null;
            if (_empDetails == null)
                _empDetails = new empDetails();
            _empDetails.id = id;
            _empDetails.Fname = txtFirstname.Text;
            _empDetails.Mname = txtMiddlename.Text;
            _empDetails.Lname = txtLastname.Text;
            _empDetails.email = txtEmailid.Text;
            _empDetails.phone = txtPhoneNumber.Text;
            _empDetails.Password = txtPassword.Text;
            _empDetails.Active = chkActive.Checked;
            _empDetails.dateupdated = DateTime.Now;

            _empDetails.Roles = selectedValues.Split(',');

            DataBase DB = new DataBase();
            if (id > 0)
            {
                string result = DB.InsertEmployeedetails(_empDetails, "sp_UpdateEmpDetails");
                if (result == "Success")
                {
                    txtEmailid.Text = "";
                    txtFirstname.Text = "";
                    txtMiddlename.Text = "";
                    txtLastname.Text = "";
                    txtPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    txtPhoneNumber.Text = "";
                    chkActive.Checked = false;
                    lstBoxTest.SelectedIndex = -1;
                    Session["ID"] = "";
                    Response.Redirect("Employee.aspx");                    
                }
            }
            else
            {
                string Query = "SELECT COUNT(EmailID) as Emailcount FROM Employee where EmailID='" + _empDetails.email + "' GROUP BY EmailID HAVING ( COUNT(EmailID) > 0 )";
                DataTable dt = DB.ExcutesQuery(Query);
                if (!(dt.Rows.Count > 0))
                {
                    string result = DB.InsertEmployeedetails(_empDetails, "sp_InsertEmpDetails");
                    if (result == "Success")
                    {
                        txtEmailid.Text = "";
                        txtFirstname.Text = "";
                        txtMiddlename.Text = "";
                        txtLastname.Text = "";
                        txtPassword.Text = "";
                        txtConfirmPassword.Text = "";
                        txtPhoneNumber.Text = "";
                        chkActive.Checked = false;
                        lstBoxTest.SelectedIndex = -1;
                        Session["ID"] = "";
                        Response.Redirect("Employee.aspx");                       
                    }
                }
                else
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email ID Exists')", true);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Email ID Exists')", true);
                }
            }
        }
        catch (Exception ex)
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error On Page')", true);
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On InsertEmpData: " + ex.Message + "')", true);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            InsertEmpData();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On btnSubmit_Click: " + ex.Message + "')", true);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            lblId.InnerText = "";
            txtEmailid.Text = "";
            txtFirstname.Text = "";
            txtMiddlename.Text = "";
            txtLastname.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtPhoneNumber.Text = "";
            chkActive.Checked = false;
            lstBoxTest.SelectedIndex = -1;
            Session["ID"] = "";
            Response.Redirect("Employee.aspx");            
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error on btnCancel_Click: " + ex.Message + "')", true);
        }
    }
}