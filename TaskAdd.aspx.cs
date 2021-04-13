using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

public partial class TaskAdd : System.Web.UI.Page
{
    string Empid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["EmpID"]) != null && Convert.ToString(Session["EmpID"]) != "")
        {
            Empid = Convert.ToString(Session["EmpID"]);
        }
        if (!IsPostBack)
        {
            string getEmp = "Select Fname,ID from Employee where isActive ='true'";
            if (Request.QueryString["project"] != "" && Request.QueryString["project"] != null)
            {
                getEmp = "Select b.Fname,b.ID  from ProjectAssign_Emp a join Employee b on a.EmpId=b.ID where ProjectId='" + Request.QueryString["project"].ToString() + "' and b.isActive ='true'";
            }
            BindDDLAssignby(getEmp);
            LoadRecord();
        }
    }

    protected void BindDDLAssignby(string getEmp)
    {
        try
        {

            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(getEmp);
            //ddlAssignedby.DataSource = dt;
            //ddlAssignedby.DataTextField = "Fname";
            //ddlAssignedby.DataValueField = "ID";
            //ddlAssignedby.DataBind();
            //ddlAssignedby.Items.Insert(0, new ListItem("Select Assigned To", ""));

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

    protected void LoadRecord()
    {
        try
        {
            lblId.InnerText = Request.QueryString["ID"];

            int id = 0;
            int.TryParse(lblId.InnerText, out id);

            string Query = "Select * from Task Where TaskID=" + id;

            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(Query);
            if (dt.Rows.Count > 0)
            {

                txtTaskname.Text = Convert.ToString(dt.Rows[0]["TaskTitle"]);
                txtDescription.Text = Convert.ToString(dt.Rows[0]["Description"]);
                //ddlPriority.Text = Convert.ToString(dt.Rows[0]["TaskPriority"]);

                ddlPriority.Items.FindByText(Convert.ToString(dt.Rows[0]["TaskPriority"])).Selected = true;

                //ddlProjectStatus.SelectedItem.Text = Convert.ToString(dt.Rows[0]["Projectstatus"]);

                ddlProjectStatus.Items.FindByText(Convert.ToString(dt.Rows[0]["Projectstatus"])).Selected = true;

                DateTime startdate;
                DateTime.TryParse(Convert.ToString(dt.Rows[0]["Start_Date_Time"]), out startdate);
                txtstartdate.Text = startdate.ToString("yyyy-MM-dd");
                DateTime duedate;
                DateTime.TryParse(Convert.ToString(dt.Rows[0]["Due_Date_Time"]), out duedate);
                txtduedate.Text = duedate.ToString("yyyy-MM-dd");
                //int empid = 0;
                //int.TryParse(Convert.ToString(dt.Rows[0]["Assignedby"]),out empid);
                //ddlAssignedby.SelectedValue = Convert.ToString(dt.Rows[0]["Assignedby"]);            
                bool status = false;
                bool.TryParse(dt.Rows[0]["status"].ToString(), out status);
                if (status == true)
                {
                    //ddlStatus.SelectedItem.Text = "Open";
                    ddlStatus.Items.FindByText("Open").Selected = true;
                }
                else
                {
                    //ddlStatus.SelectedItem.Text = "Close";
                    ddlStatus.Items.FindByText("Close").Selected = true;
                }

                string getassignto = "Select * from Task_Assign_Employee Where Task_ID='" + id + "'";
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

                //FileUpload1.FileName = Convert.ToString(dt.Rows[0]["Attachment"]);
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
            txtTaskname.Text = "";
            txtDescription.Text = "";
            ddlPriority.Text = "";
            ddlAssignedby.SelectedIndex = -1;
            ddlProjectStatus.Text = "";
            ddlStatus.Text = "";
            txtstartdate.Text = "";
            txtduedate.Text = "";
            Response.Redirect("ManageTask.aspx");
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On btnCancel_Click: " + ex.Message + "')", true);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int id = 0;
            int.TryParse(lblId.InnerText, out id);
            if (id > 0)
            {
                UpdateTask(id);
            }
            else
            {
                InsertTask();
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On btnSave_Click: " + ex.Message + "')", true);
        }
    }

    protected void UpdateTask(int taskid)
    {
        try
        {
            TaskDetails _taskDetails = null;
            if (_taskDetails == null)
                _taskDetails = new TaskDetails();
            _taskDetails.taskid = taskid;
            _taskDetails.tasktitle = txtTaskname.Text;
            _taskDetails.priority = ddlPriority.SelectedItem.Text;
            _taskDetails.description = txtDescription.Text;
            int empid = 0;
            //int.TryParse(ddlAssignedby.SelectedValue, out empid);
            int.TryParse(Empid, out empid);
            _taskDetails.assignby = empid;
            _taskDetails.projectstatus = ddlProjectStatus.SelectedItem.Text;
            if (ddlStatus.SelectedItem.Text == "Open")
            {
                _taskDetails.status = true;
            }
            else
            {
                _taskDetails.status = false;
            }
            if (txtstartdate.Text != null && txtstartdate.Text != "")
            {
                _taskDetails.startdate = DateTime.ParseExact(txtstartdate.Text, "dd/MM/yyyy", null);
            }
            if (txtduedate.Text != null && txtduedate.Text != "")
            {
                _taskDetails.duedate = DateTime.ParseExact(txtduedate.Text, "dd/MM/yyyy", null);
            }
            //_taskDetails.startdate = Convert.ToDateTime(txtstartdate.Text);
            //_taskDetails.duedate = Convert.ToDateTime(txtduedate.Text);

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

            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            if (filename != null && filename != "")
            {
                FileUpload1.SaveAs(Server.MapPath("~/FilesUpload/") + filename);
                string contentType = FileUpload1.PostedFile.ContentType;
                using (Stream fs = FileUpload1.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        _taskDetails.attachment = bytes;
                        _taskDetails.attachments = filename;
                    }
                }
            }
            int countid = 0;
            DataBase DB = new DataBase();
            string result = DB.UpdateTaskdetails(_taskDetails);
            if (result == "Success")
            {
                string query = "Delete from Task_Assign_Employee where Task_ID='" + _taskDetails.taskid + "'";
                DB.DeleteData(query);

                for (int i = 0; i < assignto.Length; i++)
                {
                    string instaskasgnemp = "Insert into Task_Assign_Employee(Task_ID,Emp_ID)Values" +
                                                "('" + _taskDetails.taskid + "','" + assignto[i] + "')  Select SCOPE_IDENTITY()";

                    int taskasgnempid = DB.ExcuteQuery(instaskasgnemp);
                    if (taskasgnempid > 0)
                    {
                        countid += 1;
                    }
                }
                if (assignto.Length == countid)
                {
                    txtTaskname.Text = "";
                    txtDescription.Text = "";
                    ddlPriority.Text = "";
                    ddlAssignedby.SelectedIndex = -1;
                    ddlProjectStatus.Text = "";
                    ddlStatus.Text = "";
                    txtstartdate.Text = "";
                    txtduedate.Text = "";
                    Response.Redirect("ManageTask.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On UpdateTask: " + ex.Message + "')", true);
        }
    }

    protected void InsertTask()
    {
        try
        {
            string ID = lblId.InnerText;
            int id = 0;
            int.TryParse(ID, out id);

            TaskDetails _taskDetails = null;
            if (_taskDetails == null)
                _taskDetails = new TaskDetails();
            _taskDetails.taskid = id;
            _taskDetails.tasktitle = txtTaskname.Text;
            _taskDetails.priority = ddlPriority.SelectedItem.Text;
            _taskDetails.description = txtDescription.Text;
            if (Request.QueryString["project"] != "" && Request.QueryString["project"] != null)
            {
                _taskDetails.ProjectId = Request.QueryString["project"].ToString();
            }

            int empid = 0;
            //int.TryParse(ddlAssignedby.SelectedValue, out empid);
            int.TryParse(Empid, out empid);
            _taskDetails.assignby = empid;
            _taskDetails.projectstatus = ddlProjectStatus.SelectedItem.Text;
            if (ddlStatus.SelectedItem.Text == "Open")
            {
                _taskDetails.status = true;
            }
            else
            {
                _taskDetails.status = false;
            }
            if (txtstartdate.Text != null && txtstartdate.Text != "")
            {
                _taskDetails.startdate = DateTime.ParseExact(txtstartdate.Text, "dd/MM/yyyy", null);
            }
            if (txtduedate.Text != null && txtduedate.Text != "")
            {
                _taskDetails.duedate = DateTime.ParseExact(txtduedate.Text, "dd/MM/yyyy", null);
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
            string[] assignto = selectedValues.Split(',');

            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            if (filename != null && filename != "")
            {
                FileUpload1.SaveAs(Server.MapPath("~/FilesUpload/") + filename);
                string contentType = FileUpload1.PostedFile.ContentType;
                using (Stream fs = FileUpload1.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        _taskDetails.attachment = bytes;
                        _taskDetails.attachments = filename;
                    }
                }
            }
            int countid = 0;
            DataBase DB = new DataBase();
            int taskid = DB.InsertTaskdetails(_taskDetails);
            //string result = DB.InsertTaskdetails(_taskDetails);
            for (int i = 0; i < assignto.Length; i++)
            {
                string instaskasgnemp = "Insert into Task_Assign_Employee(Task_ID,Emp_ID)Values" +
                                        "('" + taskid + "','" + assignto[i] + "')  Select SCOPE_IDENTITY()";
                int taskasgnempid = DB.ExcuteQuery(instaskasgnemp);
                if (taskasgnempid > 0)
                {
                    countid += 1;
                }
            }
            if (assignto.Length == countid)
            {
                txtTaskname.Text = "";
                txtDescription.Text = "";
                ddlPriority.Text = "";
                ddlAssignedby.SelectedIndex = -1;
                ddlProjectStatus.Text = "";
                ddlStatus.Text = "";
                txtstartdate.Text = "";
                txtduedate.Text = "";
                Response.Redirect("ManageTask.aspx");
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On InsertTask: " + ex.Message + "')", true);
        }
    }



}