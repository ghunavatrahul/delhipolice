using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;


public partial class Employee : System.Web.UI.Page
{
    string role = "";
    string Empid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["EmpID"]) != null || Convert.ToString(Session["EmpID"]) != "")
        {
            Empid = Convert.ToString(Session["EmpID"]);
        }

        if (!IsPostBack)
        {
            BindGrid();
            //BindRole();
        }
    }
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
        BindGrid();
    }

    protected void BindGrid()
    {
        try
        {
            string Query = "Select * from Employee";
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(Query);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GridView1.DataSource = dt;
                GridView1.DataBind();
                int columncount = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                GridView1.Rows[0].Cells[0].Text = "No Records Found";
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On BindGrid: " + ex.Message + "')", true);
        }
    }
    string id = "";
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {

            string getsearch = "Select * from Employee e join Employee_Role er on e.ID=er.emp_id join Role r on er.role_id=r.role_id where e.Fname like'" + txtEmployeeName.Text + "%' and e.EmailID like '" + txtEmailId.Text + "%' and e.isActive like '" + ddlActive.SelectedValue + "%' and r.role_name like '" + txtRoles.Text + "%'";

            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(getsearch);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GridView1.DataSource = dt;
                GridView1.DataBind();
                int columncount = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                GridView1.Rows[0].Cells[0].Text = "No Records Found";

                ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('No Records Found')", true);
                txtEmployeeName.Text = "";
                txtEmailId.Text = "";
                ddlActive.SelectedValue = "";
                txtRoles.Text = "";
                //BindGrid();
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On btnSearch_Click: " + ex.Message + "')", true);
        }
        txtEmployeeName.Focus();
    }


    //protected void BindRole()
    //{
    //    try
    //    {
    //        string Query = "Select * from Role";
    //        DataBase DB = new DataBase();
    //        DataTable dt = DB.ExcutesQuery(Query);

    //        lstBoxTest.DataSource = dt;
    //        lstBoxTest.DataTextField = "role_name";
    //        lstBoxTest.DataValueField = "role_id";
    //        lstBoxTest.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On BindRole')", true);
    //    }
    //}       

    //protected void InsertEmpData()
    //{
    //    try
    //    {
    //        string ID = lblId.InnerText;
    //        int id = 0;
    //        int.TryParse(ID, out id);

    //        string selectedValues = string.Empty;
    //        foreach (ListItem li in lstBoxTest.Items)
    //        {
    //            if (li.Selected == true)
    //            {
    //                selectedValues += li.Value + ",";

    //            }
    //        }
    //        selectedValues = selectedValues.TrimEnd(',');
    //        empDetails _empDetails = null;
    //        if (_empDetails == null)
    //            _empDetails = new empDetails();
    //        _empDetails.id = id;            
    //        _empDetails.Fname = txtFirstname.Text;
    //        _empDetails.Mname = txtMiddlename.Text;
    //        _empDetails.Lname = txtLastname.Text;
    //        _empDetails.email = txtEmailid.Text;
    //        _empDetails.phone = txtPhoneNumber.Text;
    //        _empDetails.Password = txtPassword.Text;            
    //        _empDetails.Active = chkActive.Checked;
    //        _empDetails.dateupdated = DateTime.Now;

    //        _empDetails.Roles = selectedValues.Split(',');        

    //        DataBase DB = new DataBase();
    //        if (id > 0)
    //        {
    //            string result = DB.InsertEmployeedetails(_empDetails, "sp_UpdateEmpDetails");
    //            if (result == "Success")
    //            {
    //                txtEmailid.Text = "";
    //                txtFirstname.Text = "";
    //                txtMiddlename.Text = "";
    //                txtLastname.Text = "";
    //                txtPassword.Text = "";
    //                txtConfirmPassword.Text = "";                    
    //                txtPhoneNumber.Text = "";
    //                chkActive.Checked = false;
    //                lstBoxTest.SelectedIndex = -1;
    //                BindGrid();
    //            }
    //        }
    //        else
    //        {
    //            string Query = "SELECT COUNT(EmailID) as Emailcount FROM Employee where EmailID='" + _empDetails.email + "' GROUP BY EmailID HAVING ( COUNT(EmailID) > 0 )";
    //            DataTable dt = DB.ExcutesQuery(Query);
    //            if (!(dt.Rows.Count > 0))
    //            {
    //                string result = DB.InsertEmployeedetails(_empDetails, "sp_InsertEmpDetails");
    //                if (result == "Success")
    //                {                       
    //                    txtEmailid.Text = "";
    //                    txtFirstname.Text = "";
    //                    txtMiddlename.Text = "";
    //                    txtLastname.Text = "";
    //                    txtPassword.Text = "";
    //                    txtConfirmPassword.Text = "";                       
    //                    txtPhoneNumber.Text = "";
    //                    chkActive.Checked = false;
    //                    lstBoxTest.SelectedIndex = -1;
    //                    BindGrid();
    //                }
    //            }
    //            else
    //            {
    //                ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Email ID Exists')", true);
    //            }
    //        }
    //    }
    //    catch(Exception ex)
    //    {
    //        ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On Page')", true);
    //    }
    //}

    //protected void btnSubmit_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        InsertEmpData();
    //    }
    //    catch (Exception ex)
    //    {
    //        ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On Submit')", true);
    //    }
    //}

    //protected void btnCancel_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        lblId.InnerText = "";
    //        txtEmailid.Text = "";
    //        txtFirstname.Text = "";
    //        txtMiddlename.Text = "";
    //        txtLastname.Text = "";
    //        txtPassword.Text = "";
    //        txtConfirmPassword.Text = "";            
    //        txtPhoneNumber.Text = "";
    //        chkActive.Checked = false;
    //        lstBoxTest.SelectedIndex = -1;
    //        BindGrid();
    //    }
    //    catch (Exception ex)
    //    {
    //        ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On Cancel')", true);
    //    }
    //}



    //protected void Gridview1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        int selectedIndex = GridView1.SelectedIndex;
    //        string _id = GridView1.DataKeys[selectedIndex].Value.ToString();
    //        Request.QueryString["ID"] = _id;
    //        //Session["ID"] = _id;
    //        //Response.Redirect("EmployeeAdd.aspx");

    //        //lblId.InnerText = _id;
    //        //int id = 0;
    //        //int.TryParse(_id,out id);

    //        //string Query = "Select emp.ID,emp.Fname,emp.Mname,emp.Lname,emp.EmailID,emp.PhoneNO,emp.isActive,cred.password,cred.date_updated,rol.role_id "+
    //        //                "from Employee emp " +
    //        //                "Left join Employee_Credentials cred on emp.ID=cred.emp_id " +
    //        //                "Left join Employee_Role rol on emp.ID=rol.emp_id " +
    //        //                "Where emp.ID='" + id + "'";

    //        //DataBase DB = new DataBase();
    //        //DataTable dt = DB.ExcutesQuery(Query);
    //        //if (dt.Rows.Count > 0)
    //        //{
    //        //    txtEmailid.Text = dt.Rows[0]["EmailID"].ToString();
    //        //    txtFirstname.Text = dt.Rows[0]["Fname"].ToString();
    //        //    txtMiddlename.Text = dt.Rows[0]["Mname"].ToString();
    //        //    txtLastname.Text = dt.Rows[0]["Lname"].ToString();
    //        //    txtPassword.Text = dt.Rows[0]["password"].ToString();
    //        //    txtConfirmPassword.Text = dt.Rows[0]["password"].ToString();
    //        //    txtPhoneNumber.Text = dt.Rows[0]["PhoneNO"].ToString();               

    //        //    bool active = false;
    //        //    bool.TryParse(dt.Rows[0]["isActive"].ToString(), out active);
    //        //    chkActive.Checked = active;
    //        //    for (int i = 0; i < dt.Rows.Count; i++)
    //        //    {
    //        //        lstBoxTest.Items.FindByValue(dt.Rows[i]["role_id"].ToString()).Selected = true;                    
    //        //    }                
    //        //}
    //    }
    //    catch (Exception ex)
    //    {
    //        ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On GridView')", true);
    //    }
    //}    

   
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeAdd.aspx");
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGrid();
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Deletes")
        {
            try
            {
                string id = e.CommandArgument.ToString();
                string Query = "delete FROM Task_Assign_Employee where Emp_ID='" + id + "'" + " " + "delete FROM Notified_Employee where notified_Empid='" + id + "'" + " " + "delete FROM Employee_Credentials where emp_id='" + id + "'" + " " + "delete FROM Employee_Role where emp_id='" + id + "' " + " " + "delete FROM Employee where ID='" + id + "'";
                DataBase DB = new DataBase();
                DB.DeleteData(Query);
                BindGrid();
            }

            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On Delete: " + ex.Message + "')", true);

            }
        }
    }

    protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataBase DB = new DataBase();
                string Id = GridView1.DataKeys[e.Row.RowIndex].Value.ToString();
                if (Id != null && Id != "")
                {
                    Label gvrole = e.Row.FindControl("gvrole") as Label;
                    //DataTable dt = DB.ExcutesQuery(string.Format("Select * from Employee a join Employee_Role b on a.ID=b.emp_id join Role c on b.role_id=c.role_id Where a.ID='{0}'", Id));
                    DataTable dt = DB.ExcutesQuery(string.Format("Select c.role_name + ', ' from Employee a join Employee_Role b on a.ID=b.emp_id join Role c on b.role_id=c.role_id Where a.ID='{0}' FOR XML PATH('')", Id));
                    string roles = null;
                    if (dt.Rows.Count > 0)
                    {
                        roles = dt.Rows[0][0].ToString();
                        //for (int i = 0; i < dt.Rows.Count; i++)
                        //{
                        //    roles = Convert.ToString(dt.Rows[i]["role_name"]) + ", " + roles;
                        //}
                        roles = roles.TrimEnd(' ');
                        roles = roles.TrimEnd(',');
                    }
                    gvrole.Text = roles.Replace(", ", ",</br>");
                }
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On Rolesbind in Gridview: " + ex.Message + "')", true);
        }
    }
   
}