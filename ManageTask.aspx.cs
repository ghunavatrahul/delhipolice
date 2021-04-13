using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ManageTask : System.Web.UI.Page
{
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
        }
    }

    protected void BindGrid()
    {
        try
        {
            //string Query = "Select * from Task";
            string Query = "Select TaskID, TaskTitle,CONVERT(VARCHAR(11), Due_Date_Time,113) as Due_Date_Time,TaskPriority,status from Task join Employee on Task.Assignedby=Employee.ID Order by CONVERT(DateTime, Due_Date_Time,101) asc";
            //string Query = "Select * from Task join Employee on Task.Assignedby=Employee.ID";
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
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
        BindGrid(); 
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            string priority = "";
            if (ddlPriority.SelectedItem.Text == "-- Select Priority --")
            {
                priority = "";
            }
            else
            {
                priority = ddlPriority.SelectedItem.Text;
            }
            string getsearch = "Select a.TaskID, a.TaskTitle,CONVERT(VARCHAR(11), a.Due_Date_Time,113) as Due_Date_Time,a.TaskPriority,a.status,c.Fname,c.Mname,c.Lname" +
                                " from Task a " +
                                " join Task_Assign_Employee b on a.TaskID=b.Task_ID " +
                                " join Employee c on b.Emp_ID=c.ID  " +
                                " where a.TaskTitle like '" + txtSearch.Text + "%' and a.TaskPriority like '" + priority + "%' and a.status like '" + ddlActive.SelectedValue + "%' and c.Fname like '" + txtAssigned.Text + "%' " +
                                " Order by CONVERT(DateTime, Due_Date_Time,101) asc";    

            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(getsearch);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                //return;
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('No Records Found')", true);
                txtSearch.Text = "";
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
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On btnSearch_Click: " + ex.Message + "')", true);
        }
        txtSearch.Focus();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Deletes")
        {
            try
            {
                string id = e.CommandArgument.ToString();
                string Query = "delete FROM Task where TaskID=" + id ;
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

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGrid();
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("TaskAdd.aspx");
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
                    Label gvassignto = e.Row.FindControl("gvassignto") as Label;
                    DataTable dt = DB.ExcutesQuery(string.Format("Select b.Fname + ' ' + b.Mname+ ' '+ b.Lname + ', '  from Task_Assign_Employee a join Employee b on a.Emp_ID=b.ID where a.Task_ID='{0}' FOR XML PATH('')", Id));
                    string assignto = null;
                    if (dt.Rows.Count > 0)
                    {
                        assignto = Convert.ToString(dt.Rows[0][0]);
                        assignto = assignto.TrimEnd(' ');
                        assignto = assignto.TrimEnd(',');
                    }
                    var text = assignto.Split(',');
                    int more = text.Count();
                    string fname = "";
                    string lname = "";
                    if (more > 1)
                    {
                        for (int z = 0; z < more; z++)
                        {
                            if (z == 0)
                            {
                                int count = more - 1;
                                fname = text[z] + " + " + count + " more</b>";
                                gvassignto.Text = fname;
                            }
                            else
                            {
                                lname += text[z] + ",";
                                //gvassignto.ToolTip = lname;
                            }
                        }
                        //Label lblassignto = e.Row.FindControl("lblassignto") as Label;
                        lname = lname.TrimEnd(',');
                        gvassignto.ToolTip = lname; 
                    }
                    else
                    {
                        gvassignto.Text = assignto.Replace(", ", ",</br>");
                    }                                       
                }
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On Notifiedtosbind in Gridview: " + ex.Message + "')", true);
        }
    }

    //protected void btnNotify_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("Notification.aspx");
    //}
}