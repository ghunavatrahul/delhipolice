using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Notification : System.Web.UI.Page
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
            BindGrid();
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
            string SP = "Sp_GetNotificationWithtime ";
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcuteStoredProcedure(SP);
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
        Response.Redirect("NotificationAdd.aspx");
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
}