using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EmployeeTracking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
            string gettracking = "Select * from EmployeeTracking a join Employee b on a.EmpID = b.ID ";
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(gettracking);
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
                    Label gvemp = e.Row.FindControl("gvemp") as Label;
                    DataTable dt = DB.ExcutesQuery(string.Format("Select b.Fname+' '+b.Mname+' '+b.Lname + ', ' from EmployeeTracking a join Employee  b on a.EmpID=b.ID Where a.ID='{0}' FOR XML PATH('')", Id));
                    string emp = null;
                    if (dt.Rows.Count > 0)
                    {
                        emp = dt.Rows[0][0].ToString();
                        emp = emp.TrimEnd(' ');
                        emp = emp.TrimEnd(',');
                    }
                    var text = emp.Split(',');
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
                                gvemp.Text = fname;
                            }
                            else
                            {
                                lname += text[z] + ",";
                            }
                        }
                        lname = lname.TrimEnd(',');
                        gvemp.ToolTip = lname;
                    }
                    else
                    {
                        gvemp.Text = emp.Replace(", ", ",</br>");
                    }

                }
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On Employeebind in Gridview: " + ex.Message + "')", true);
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Deletes")
        {
            try
            {
                //string id = e.CommandArgument.ToString();
                //string Query = "delete FROM ProjectAssign_Emp where ProjectId='" + id + "'" + " " + "delete FROM Project where ProjectId='" + id + "'";
                //DataBase DB = new DataBase();
                //DB.DeleteData(Query);
                //BindGrid();
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
}