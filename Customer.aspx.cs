using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer : System.Web.UI.Page
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
            string Query = "Select * from Customer order by CustomerID desc";
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {

            string getsearch = "Select * from view_Customer where fullname like '" + txtCustomerName.Text.Trim() + "%' and EmailID like '" + txtEmailId.Text.Trim() + "%' and Status like '" + ddlActive.SelectedValue + "%'";

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
                txtCustomerName.Text = "";
                txtEmailId.Text = "";
                ddlActive.SelectedValue = "";               
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On btnSearch_Click: " + ex.Message + "')", true);
        }
        txtCustomerName.Focus();
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
                string Query = "delete FROM Customer_Details where CustomerID=" + id + "  delete FROM Customer where CustomerID=" + id;
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

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerAdd.aspx");
    }
}