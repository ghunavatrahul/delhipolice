using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProjectAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindEmployee();
            Loadrecord();
        }
    }

    protected void BindEmployee()
    {
        try
        {
            string getemp = "Select ID, Fname+' '+Mname+' '+Lname as EmpName from Employee ";
            DataBase Db = new DataBase();
            DataTable dt = Db.ExcutesQuery(getemp);
            lstBoxTest.DataSource = dt;
            lstBoxTest.DataTextField = "EmpName";
            lstBoxTest.DataValueField = "ID";
            lstBoxTest.DataBind();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On BindEmployee: " + ex.Message + "')", true);
        }
    }

    protected void Loadrecord()
    {
        try
        {
            lblId.InnerText = Request.QueryString["ID"];            
            int id = 0;
            int.TryParse(lblId.InnerText, out id);

            string Query = "Select * from Project a Left join ProjectAssign_Emp b on a.ProjectId=b.ProjectId Where a.ProjectId='" + id + "'";

            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(Query);
            if (dt.Rows.Count > 0)
            {
                txtProjectname.Text = dt.Rows[0]["Project_Name"].ToString();

                bool active = false;
                bool.TryParse(dt.Rows[0]["Status"].ToString(), out active);
                chkActive.Checked = active;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int Empid = 0;
                    int.TryParse(Convert.ToString(dt.Rows[i]["EmpId"]), out Empid);
                    if (Empid==0)
                    {
                        lstBoxTest.SelectedIndex = -1;
                    }
                    else
                    {
                        lstBoxTest.Items.FindByValue(Empid.ToString()).Selected = true;
                    }
                }
                DateTime startdate;
                DateTime Duedate;
                DateTime.TryParse(Convert.ToString(dt.Rows[0]["Start_Date"]), out startdate);
                if (startdate == DateTime.MinValue)
                {
                    txtstartdate.Text = "";
                }
                else
                {
                    txtstartdate.Text = startdate.ToShortDateString();
                }
                DateTime.TryParse(Convert.ToString(dt.Rows[0]["Due_Date"]), out Duedate);
                if (Duedate == DateTime.MinValue)
                {
                    txtduedate.Text = "";
                }
                else
                {
                    txtduedate.Text = Duedate.ToShortDateString();
                }
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error on Loadrecord: " + ex.Message + "')", true);
        }
    }

    protected void InsertProject()
    {
        try
        {
            string project = txtProjectname.Text;
            bool active = false;
            if (chkActive.Checked)
            {
                active = true;
            }
            else
            {
                active = false;
            }

            string selectedValues = string.Empty;
            foreach (ListItem li in lstBoxTest.Items)
            {
                if (li.Selected == true)
                {
                    selectedValues += li.Value + ",";
                }
            }
            selectedValues = selectedValues.TrimEnd(',');
            string[] Employee = selectedValues.Split(',');
            DateTime startdate = new DateTime();
            DateTime duedate = new DateTime();
            if (txtstartdate.Text != null && txtstartdate.Text != "")
            {
                startdate = DateTime.ParseExact(txtstartdate.Text, "dd/MM/yyyy", null);
                //startdate = Convert.ToDateTime(txtstartdate.Text); 
            }
            if (txtduedate.Text != null && txtduedate.Text != "")
            {
                duedate = DateTime.ParseExact(txtduedate.Text, "dd/MM/yyyy", null); 
                //Convert.ToDateTime(txtduedate.Text);
            }
            int Countid = 0;
            DataBase DB = new DataBase();
            string insertproj = "Insert into Project(Project_Name, Status,Created_Date,Start_Date,Due_Date)Values('" + project + "','" + active + "',GETDATE(),'" + startdate.ToString("yyyy-MM-dd") + "','" + duedate.ToString("yyyy-MM-dd") +"') select SCOPE_IDENTITY()";
            int projectid = DB.ExcuteQuery(insertproj);
            if (projectid > 0)
            {
                for (int i = 0; i < Employee.Length; i++)
                {
                    string insertprojemp = "Insert into ProjectAssign_Emp(ProjectId,EmpId)Values('" + projectid + "', '" + Employee[i] + "') select SCOPE_IDENTITY()";
                    int projemp = DB.ExcuteQuery(insertprojemp);
                    
                    if (projemp > 0)
                    {
                        Countid += 1;
                    }
                }

                if (Countid == Employee.Length)
                {
                    txtProjectname.Text = "";
                    chkActive.Checked = false;
                    lstBoxTest.SelectedIndex = -1;
                    lblId.InnerText = "";
                    Response.Redirect("ManageProject.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On InsertProject: " + ex.Message + "')", true);
        }
    }

    protected void UpdateProject(int Projectid)
    {
        try
        {
            string project = txtProjectname.Text;
            bool active = false;
            if (chkActive.Checked)
            {
                active = true;
            }
            else
            {
                active = false;
            }

            string selectedValues = string.Empty;
            foreach (ListItem li in lstBoxTest.Items)
            {
                if (li.Selected == true)
                {
                    selectedValues += li.Value + ",";
                }
            }
            selectedValues = selectedValues.TrimEnd(',');
            string[] Employee = selectedValues.Split(',');

            int Countid = 0;
            DataBase DB = new DataBase();
            if (Projectid > 0)
            {
                DateTime startdate = new DateTime();
                DateTime duedate = new DateTime();
                if (txtstartdate.Text != null && txtstartdate.Text != "")
                {
                    startdate = DateTime.ParseExact(txtstartdate.Text, "dd/MM/yyyy", null);
                    //startdate = Convert.ToDateTime(txtstartdate.Text); 
                }
                if (txtduedate.Text != null && txtduedate.Text != "")
                {
                    duedate = DateTime.ParseExact(txtduedate.Text, "dd/MM/yyyy", null);
                    //Convert.ToDateTime(txtduedate.Text);
                }
                string updproj = "Update Project Set Project_Name='" + project + "', Start_Date='" + startdate.ToString("yyyy-MM-dd") + "', Due_Date='" + duedate.ToString("yyyy-MM-dd") + "', Status='" + active + "' Where ProjectId='" + Projectid + "' ";
                string result = DB.UpdateData(updproj);
                if (result != null)
                {
                    string query = "Delete from ProjectAssign_Emp where ProjectId='" + Projectid + "'";
                    DB.DeleteData(query);
                    for (int i = 0; i < Employee.Length; i++)
                    {
                        string insertprojemp = "Insert into ProjectAssign_Emp(ProjectId,EmpId)Values('" + Projectid + "', '" + Employee[i] + "') select SCOPE_IDENTITY()";
                        int projemp = DB.ExcuteQuery(insertprojemp);

                        if (projemp > 0)
                        {
                            Countid += 1;
                        }
                    }

                    if (Countid == Employee.Length)
                    {
                        txtProjectname.Text = "";
                        chkActive.Checked = false;
                        lstBoxTest.SelectedIndex = -1;
                        lblId.InnerText = "";
                        Response.Redirect("ManageProject.aspx");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On InsertProject: " + ex.Message + "')", true);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int id=0;
            int.TryParse(lblId.InnerText, out id);
            if (id > 0)
            {
                UpdateProject(id);
            }
            else
            {
                InsertProject();
            }
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
            txtProjectname.Text = "";
            chkActive.Checked = false;
            lstBoxTest.SelectedIndex = -1;
            Response.Redirect("ManageProject.aspx");
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error on btnCancel_Click: " + ex.Message + "')", true);
        }
    }
}