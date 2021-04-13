using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Delivery1 : System.Web.UI.Page
{
    public string listFilter = null;
    public string listProduct = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        listFilter = null;
        listFilter = BindCustomer();

        listProduct = null;
        listProduct = BindProduct();

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
    private string BindCustomer()
    {
        string getcustomer = "select CustomerID, Fname+' '+Mname+' '+Lname as Name from FieldWorkMgt_DB.dbo.customer ";
        DataBase DB = new DataBase();
        DataTable dt = DB.ExcutesQuery(getcustomer);

        StringBuilder output = new StringBuilder();
        output.Append("[");
        for (int i = 0; i < dt.Rows.Count; ++i)
        {
            output.Append("\"value:" + dt.Rows[i]["CustomerID"].ToString() + ", " + dt.Rows[i]["Name"].ToString() + "\"");
           
            if (i != (dt.Rows.Count - 1))
            {
                output.Append(",");
            }
        }
        output.Append("];");
        return output.ToString();
    }

    private string BindProduct()
    {
        string getproduct = "select Id,Title from FieldWorkMgt_DB.dbo.Items ";
        DataBase DB = new DataBase();
        DataTable dt = DB.ExcutesQuery(getproduct);

        StringBuilder output = new StringBuilder();
        output.Append("[");
        for (int i = 0; i < dt.Rows.Count; ++i)
        {
            output.Append("\"" + dt.Rows[i]["Title"].ToString() + "\"");

            if (i != (dt.Rows.Count - 1))
            {
                output.Append(",");
            }
        }
        output.Append("];");
        return output.ToString();
    }

    protected void BindGrid()
    {
        try
        {
            
            string Query = "  Select DeliveryID, case when b.Mname is null then  b.Fname+' '+b.Lname else  b.Fname+' '+b.Mname+' '+b.Lname end as Custname, c.Title, case when d.Mname is null then d.Fname+' '+d.Lname else d.Fname+' '+isnull(d.Mname,'')+' '+d.Lname end as empname, a.Addr1,a.Country,e.Name as state ,f.Name as city,a.Zipcode, " +
                            " a.Priority,a.Ordereddate,CONVERT(VARCHAR(11), a.Estimateddate,113) as Estimateddate,a.PickupAddr,a.PickCountry,a.Pickstate,a.Pickcity,a.PickZipcode from FieldWorkMgt_DB.dbo.Delivery a " +
                            " left outer join FieldWorkMgt_DB.dbo.Customer b on a.CustomerID=b.CustomerID " +
                            " left outer join FieldWorkMgt_DB.dbo.Items c on a.Itemid=c.Id" +
                            " left outer join FieldWorkMgt_DB.dbo.Employee d on a.Assignto=d.ID" +
                            " left outer join FieldWorkMgt_DB.dbo.State e on a.State=e.StateId" +
                            " left outer join FieldWorkMgt_DB.dbo.City f on a.City=f.CityId";
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
            string priority = "";
            if (ddlPriority.SelectedItem.Text == "-- Select Priority --")
            {
                priority = "";
            }
            else
            {
                priority = ddlPriority.SelectedItem.Text;
            }

            string getsearch = "Select DeliveryID,case when b.Mname is null then  b.Fname+' '+b.Lname else  b.Fname+' '+b.Mname+' '+b.Lname end as Custname, c.Title, case when d.Mname is null then d.Fname+' '+d.Lname else d.Fname+' '+d.Mname+' '+d.Lname end as empname, a.Addr1,a.Country,a.State,a.City,a.Zipcode,a.Priority,a.Ordereddate,CONVERT(VARCHAR(11), a.Estimateddate,113) as Estimateddate,a.PickupAddr,a.PickCountry,a.Pickstate,a.Pickcity,a.PickZipcode from FieldWorkMgt_DB.dbo.Delivery a " +
                            " join FieldWorkMgt_DB.dbo.view_customerforfullname b on a.CustomerID=b.CustomerID " +
                            " join FieldWorkMgt_DB.dbo.Items c on a.Itemid=c.Id" +
                            " join FieldWorkMgt_DB.dbo.Employee d on a.Assignto=d.ID " +
                            " where b.fullname like '" + txtCustomerName.Text.Trim() + "%' and Title like '" + txtProduct.Text.Trim() + "%' and Priority like '" + priority.Trim() + "%'";
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
                txtProduct.Text = "";
                ddlPriority.SelectedValue = "";
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
                string Query = "delete FROM FieldWorkMgt_DB.dbo.DeliveryStatus where DeliveryId='" + id + "'  delete FROM Delivery where DeliveryID='" + id + "'";
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
        Response.Redirect("Delivery.aspx");
    }
}