using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;

public partial class TaskDetail : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadRecord();
        }
    }

    protected void LoadRecord()
    {
        try
        {
            lblId.InnerText=Request.QueryString["tasks"];
            int taskid = 0;
            int.TryParse(lblId.InnerText,out taskid);
            BindGrid(taskid);
            string gettask = "Select * from Task where TaskID='" + taskid + "'";
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(gettask);
            if (dt.Rows.Count > 0)
            {
                txtTask.Text = Convert.ToString(dt.Rows[0]["TaskTitle"]);
                txtDescription.Text = Convert.ToString(dt.Rows[0]["Description"]);
                txtPriority.Text = Convert.ToString(dt.Rows[0]["TaskPriority"]);
                txtProjectStatus.Text = Convert.ToString(dt.Rows[0]["Projectstatus"]);                
                DateTime startdate;
                DateTime.TryParse(Convert.ToString(dt.Rows[0]["Start_Date_Time"]), out startdate);
                txtStartdate.Text = startdate.ToString("dd-MM-yyyy");
                DateTime duedate;
                DateTime.TryParse(Convert.ToString(dt.Rows[0]["Due_Date_Time"]), out duedate);
                txtDueDate.Text = duedate.ToString("dd-MM-yyyy");

                string filename=Convert.ToString(dt.Rows[0]["Attachment"]);
                if (filename != null && filename != "")
                {
                    txtAttachfiles.Text = filename;
                    LinkButton1.Visible = true;
                }
                else
                {
                    LinkButton1.Visible = false;
                }

                bool status = false;
                bool.TryParse(Convert.ToString(dt.Rows[0]["status"]), out status);
                if (status == true)
                {                    
                    txtStatus.Text = "Open";
                }
                else
                {
                    txtStatus.Text = "Close";                   
                }
               
                DataTable _dt = DB.ExcutesQuery(string.Format("Select b.Fname+' '+b.Mname+' ' + b.Lname+', ' from Task_Assign_Employee a join Employee b on a.Emp_ID=b.ID Where Task_ID='{0}' FOR XML PATH('')", taskid));
                string assignto = null;
                if (_dt.Rows.Count > 0)
                {
                    assignto = Convert.ToString(_dt.Rows[0][0]);
                    assignto = assignto.TrimEnd(' ');
                    assignto = assignto.TrimEnd(',');
                    txtAssignedto.Text = assignto;
                }
            }
           
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On LoadRecord: " + ex.Message + "')", true);
        }
    }

    protected void BindGrid(int taskid)
    {
        try
        {
            
            //string Query = "Select * from notify a join Employee c on a.empid=c.ID Where TaskID='" + taskid + "'";
            string Query = "Select a.id, a.Subject, CONVERT(VARCHAR(17), a.Updated_date, 113) as Updated_date, c.Fname, c.Mname,c.Lname  from notify a join Employee c on a.empid=c.ID Where TaskID='" + taskid + "'";
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(Query);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                Repeater1.DataSource = dt;
                Repeater1.DataBind();
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

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Deletes")
        {
            try
            {
                string id = e.CommandArgument.ToString();
                string Query = "delete FROM Notified_Employee where id=" + id + " delete FROM notify where id=" + id;
                DataBase DB = new DataBase();
                DB.DeleteData(Query);

                int taskid = 0;
                int.TryParse(lblId.InnerText, out taskid);
                BindGrid(taskid);
            }

            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On Delete: " + ex.Message + "')", true);

            }
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            lblId.InnerText = Request.QueryString["tasks"];
            int taskid = 0;
            int.TryParse(lblId.InnerText, out taskid);

            BindGrid(taskid);
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On GridView1_PageIndexChanging: " + ex.Message + "')", true);
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
                    Label gvnotifiedto = e.Row.FindControl("gvnotifiedto") as Label;
                    DataTable dt = DB.ExcutesQuery(string.Format("Select b.Fname + ' ' + b.Mname+ ' '+ b.Lname + ', '  from Notified_Employee a join Employee b on a.notified_Empid=b.ID where a.notify_ID='{0}' FOR XML PATH('')", Id));
                    string notifiedto = null;
                    if (dt.Rows.Count > 0)
                    {
                        notifiedto = Convert.ToString(dt.Rows[0][0]);
                        notifiedto = notifiedto.TrimEnd(' ');
                        notifiedto = notifiedto.TrimEnd(',');
                    }
                    gvnotifiedto.Text = notifiedto.Replace(", ", ",</br>");
                }
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On Notifiedtosbind in Gridview: " + ex.Message + "')", true);
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            string filename = txtAttachfiles.Text;
            if (filename != null && filename != "")
            {
                //Response.Redirect("~/FilesUpload/"+filename);

                string strURL = "~/FilesUpload/" + filename;
                WebClient req = new WebClient();
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.ClearContent();
                response.ClearHeaders();
                response.Buffer = true;
                response.AddHeader("Content-Disposition", "attachment;filename=\"" + Server.MapPath(strURL) + "\"");
                byte[] data = req.DownloadData(Server.MapPath(strURL));
                response.BinaryWrite(data);
                response.End();
            }           
        }
        catch(Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On Downloading files " + ex.Message + "')", true);
        }
    }
}