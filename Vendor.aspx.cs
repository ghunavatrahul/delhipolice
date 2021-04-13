using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vendor : System.Web.UI.Page
{
    DataBase obj = new DataBase();
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
            string Query = "select *,'1'as dependancy from Vendor where VendorId in(select vendorid from items)union select *,'0'as dependancy from Vendor where VendorId not in (select isnull(vendorid,0)as vendorid from items)";
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

            string getsearch = "Select * from view_serchvendor where VendorName like '" + txtVendorName.Text.Trim() + "%' and EmailID like '" + txtEmailId.Text.Trim() + "%' and Status like '" + ddlActive.SelectedValue + "%'";

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
                txtVendorName.Text = "";
                txtEmailId.Text = "";
                ddlActive.SelectedValue = "";
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On btnSearch_Click: " + ex.Message + "')", true);
        }
        txtVendorName.Focus();
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
                string Query = "delete FROM Vendor where VendorId='" + id + "'" ;
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
        Response.Redirect("VendorAdd.aspx");
    }
    //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        LinkButton btn_check = (e.Row.FindControl("R1") as LinkButton);

    //        Label lbl_id = (e.Row.FindControl("lbl") as Label);
    //        int a = Convert.ToInt32(lbl_id.Text);

    //        DataTable chk = obj.vendordependacy(a);
    //        if (chk.Rows.Count > 0)
    //        {
    //            btn_check.Enabled = false;
    //            btn_check.ToolTip = "This is used any where";
    //            btn_check.Attributes["name"] = "true";
    //        }
    //        else
    //        {
    //            btn_check.Enabled = true;
    //            btn_check.ToolTip = "Delete";
    //            btn_check.Attributes["name"] = "false";
    //        }

    //    }
    //}
}