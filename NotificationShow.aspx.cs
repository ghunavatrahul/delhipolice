using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class NotificationShow : System.Web.UI.Page
{
    string Empid;
    int taskid = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["EmpID"]) != null && Convert.ToString(Session["EmpID"]) != "")
        {
            Empid = Convert.ToString(Session["EmpID"]);
        }
        if (!IsPostBack)
        {
            BindlstNotifiedto();
            LoadRecord();

            string query = "Update notify Set Readfield='false' where id='" + Request.QueryString["ID"] + "'";
            DataBase db = new DataBase();
            db.UpdateData(query);
        }
    }

    protected void BindlstNotifiedto()
    {
        try
        {
            string getEmp = "Select * from Employee";
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(getEmp);
            lstBoxTest.DataSource = dt;
            lstBoxTest.DataTextField = "Fname";
            lstBoxTest.DataValueField = "ID";
            lstBoxTest.DataBind();            
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On BindDDLAssignby: " + ex.Message + "')", true);
        }
    }

    string subject;
    protected void LoadRecordfromTask()
    {
        try
        {            
            lbltask.InnerText = Request.QueryString["tasks"];
            int.TryParse(lbltask.InnerText, out taskid);

            string getassignto = "Select * from Task_Assign_Employee Where Task_ID='" + taskid + "'";
            DataBase DB = new DataBase();
            DataTable _dt = DB.ExcutesQuery(getassignto);
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (Convert.ToString(_dt.Rows[i]["Emp_ID"]) == null || Convert.ToString(_dt.Rows[i]["Emp_ID"]) == "")
                {
                    lstBoxTest.SelectedIndex = -1;
                }
                else
                {
                    lstBoxTest.Items.FindByValue(Convert.ToString(_dt.Rows[i]["Emp_ID"])).Selected = true;
                }
            }      
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On LoadRecordfromTask: " + ex.Message + "')", true);
        }
    }

    protected void LoadRecord()
    {
        try
        {
            lblId.InnerText = Request.QueryString["ID"];
            int id = 0;
            int.TryParse(lblId.InnerText, out id);
            string getnotify = "Select * from notify Where id='" + id + "'";
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(getnotify);
            if (dt.Rows.Count > 0)
            {                
                txtSubject.Text = Convert.ToString(dt.Rows[0]["Subject"]);
                txtDescription.Text = Convert.ToString(dt.Rows[0]["Description"]);
                lbltask.InnerText = Convert.ToString(dt.Rows[0]["TaskID"]);
                DateTime updatedate;
                DateTime.TryParse(Convert.ToString(dt.Rows[0]["Updated_date"]), out updatedate);
                //txtUpdateddate.Text = updatedate.ToString("yyyy-MM-dd");

                string getassignto = "Select * from Notified_Employee Where notify_ID='" + id + "'";
                DataTable _dt = DB.ExcutesQuery(getassignto);
                for (int i = 0; i < _dt.Rows.Count; i++)
                {
                    if (Convert.ToString(_dt.Rows[i]["notified_Empid"]) == null || Convert.ToString(_dt.Rows[i]["notified_Empid"]) == "")
                    {
                        lstBoxTest.SelectedIndex = -1;
                    }
                    else
                    {
                        lstBoxTest.Items.FindByValue(Convert.ToString(_dt.Rows[i]["notified_Empid"])).Selected = true;
                    }
                }               
            }

            if (lbltask.InnerText == null || lbltask.InnerText == "")
            {
                LoadRecordfromTask();
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On LoadRecord: " + ex.Message + "')", true);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            txtSubject.Text = "";
            txtDescription.Text = "";
            //txtUpdateddate.Text = "";
            lstBoxTest.SelectedIndex = -1;
            Response.Redirect("Notification.aspx");
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On btnCancel_Click: " + ex.Message + "')", true);
        }
    }

    protected void UpdateNotification(int id)
    {
        try
        {
            string empid = Empid;
            int.TryParse(lbltask.InnerText, out taskid);
            string subject = txtSubject.Text;
            string Description = txtDescription.Text;

            //DateTime Updatedate = Convert.ToDateTime(txtUpdateddate.Text);
            //string updateDate = Updatedate.ToString("yyyy-MM-dd h:mm tt");
            string updateDate = DateTime.Now.ToString("yyyy-MM-dd h:mm tt");
            string selectedValues = string.Empty;
            foreach (ListItem li in lstBoxTest.Items)
            {
                if (li.Selected == true)
                {
                    selectedValues += li.Value + ",";
                }
            }
            selectedValues = selectedValues.TrimEnd(',');
            string[] assignto = selectedValues.Split(',');
            int countid = 0;
            DataBase DB = new DataBase();


            string updatenotify = "Update notify Set empid='" + empid + "',TaskID='" + taskid + "',Subject='" + subject + "',Description='" + Description + "'," +
                                  "Updated_date='" + updateDate + "',Readfield='" + true + "' Where id='" + id + "'";
            string result = DB.UpdateData(updatenotify);
            if (result != null && result != "")
            {
                string query = "Delete from Notified_Employee where notify_ID='" + id + "'";
                DB.DeleteData(query);

                for (int i = 0; i < assignto.Length; i++)
                {
                    string insertnotifiedEmp = "Insert into Notified_Employee(notify_ID,notified_Empid)Values" +
                                                "('" + id + "','" + assignto[i] + "')  Select SCOPE_IDENTITY()";

                    int notifiedempid = DB.ExcuteQuery(insertnotifiedEmp);
                    if (notifiedempid > 0)
                    {
                        countid += 1;
                    }
                }
                if (assignto.Length == countid)
                {
                    txtSubject.Text = "";
                    txtDescription.Text = "";
                    //txtUpdateddate.Text = "";
                    lstBoxTest.SelectedIndex = -1;
                    if (taskid > 0)
                    {
                        Response.Redirect("TaskDetail.aspx?tasks=" + taskid);
                    }
                    else
                    {
                        Response.Redirect("Notification.aspx");
                    }
                }
            }            
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On Insert: " + ex.Message + "')", true);
        }
    }

    protected void InsertNotification()
    {
        try
        {
            string empid = Empid;
            int.TryParse(lbltask.InnerText, out taskid);
            string subject = txtSubject.Text;
            string Description = txtDescription.Text;

            //DateTime Updatedate = Convert.ToDateTime(txtUpdateddate.Text);
            //string updateDate = Updatedate.ToString("yyyy-MM-dd h:mm tt");
            string updateDate = DateTime.Now.ToString("yyyy-MM-dd h:mm tt");
            string selectedValues = string.Empty;
            foreach (ListItem li in lstBoxTest.Items)
            {
                if (li.Selected == true)
                {
                    selectedValues += li.Value + ",";
                }
            }
            selectedValues = selectedValues.TrimEnd(',');
            string[] assignto = selectedValues.Split(',');
            int countid = 0;
            DataBase DB = new DataBase();


            string insertnotify = "Insert into notify(empid,TaskID,Subject,Description,Updated_date,Readfield)Values" +
                                  "('" + empid + "','" + taskid + "','" + subject + "','" + Description + "','" + updateDate + "','" + true + "')  Select SCOPE_IDENTITY()";
            int notifyid = DB.ExcuteQuery(insertnotify);
            if (notifyid > 0)
            {
                for (int i = 0; i < assignto.Length; i++)
                {
                    string insertnotifiedEmp = "Insert into Notified_Employee(notify_ID,notified_Empid)Values" +
                                                "('" + notifyid + "','" + assignto[i] + "')  Select SCOPE_IDENTITY()";

                    int notifiedempid = DB.ExcuteQuery(insertnotifiedEmp);
                    if (notifiedempid > 0)
                    {
                        countid += 1;
                    }
                }

                if (assignto.Length == countid)
                {
                    txtSubject.Text = "";
                    txtDescription.Text = "";
                    //txtUpdateddate.Text = "";
                    lstBoxTest.SelectedIndex = -1;
                    if (taskid > 0)
                    {
                        Response.Redirect("TaskDetail.aspx?tasks=" + taskid);
                    }
                    else
                    {
                        Response.Redirect("Notification.aspx");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On Insert: " + ex.Message + "')", true);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int id = 0;
            int.TryParse(lblId.InnerText,out id);
            if (id > 0)
            {
                UpdateNotification(id);
            }
            else
            {
                InsertNotification();
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On btnSave_Click: " + ex.Message + "')", true);
        }
    }
}