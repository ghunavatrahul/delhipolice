using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridview1();
            BindgridDeliveryStatus();
            BindgridProductDelivery();
            
           // ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", " alert('gg');document.getElementById('prod').setAttribute('class', 'active'); ", true);
        }
    }

    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
        BindGridview1();
    }
    protected void ddldlvstatussize_SelectedIndexChanged(object sender, EventArgs e)
    {
        gridDeliveryStatus.PageSize = Convert.ToInt32(ddldlvstatussize.SelectedValue);
        BindgridDeliveryStatus();
    }

    protected void ddlproddlvsize_SelectedIndexChanged(object sender, EventArgs e)
    {
        gridProductdelivery.PageSize = Convert.ToInt32(ddlproddlvsize.SelectedValue);
        BindgridProductDelivery();
    }

    protected void BindGridview1()
    {
        try
        {
            string Query = "Select a.DeliveryID, g.Title, b.Fname+' '+b.Mname+' '+b.Lname as Assignto, a.Addr1, c.Name as Delvstate, d.Name as Delvcity, a.Zipcode, a.PickupAddr, e.Name as PickState, f.Name as PickCity, a.PickZipcode, " +
                           "CONVERT(VARCHAR(11), a.Estimateddate,113) as Estimateddate, h.DeliveryStatus,CONVERT(VARCHAR(11), a.Ordereddate,113) as Ordereddate" +
                           " from Delivery a" +
                           " join Employee b on a.Assignto=b.ID" +
                           " join State c on a.State=c.StateId" +
                           " join City d on a.City=d.CityId" +
                           " join State e on a.Pickstate=e.StateId" +
                           " join City f on a.Pickcity=f.CityId" +
                           " join Items g on a.Itemid=g.Id"+
                           " join DeliveryStatus h on a.DeliveryId=h.DeliveryId";

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

            string getsearch = " Select a.DeliveryID, g.Title, b.Fname+' '+b.Mname+' '+b.Lname as Assignto, a.Addr1, c.Name as Delvstate, d.Name as Delvcity, a.Zipcode, a.PickupAddr, e.Name as PickState, f.Name as PickCity, a.PickZipcode," +
                               " a.Ordereddate,a.Estimateddate" +
                               " from Delivery a" +
                               " join Employee b on a.Assignto=b.ID" +
                               " join State c on a.State=c.StateId" +
                               " join City d on a.City=d.CityId" +
                               " join State e on a.Pickstate=e.StateId" +
                               " join City f on a.Pickcity=f.CityId" +
                               " join Items g on a.Itemid=g.Id where b.Fname like '" + txtAssignto.Text.Trim() + "%' and g.Title like '" + txtProduct.Text.Trim() + "%'";

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
                txtAssignto.Text = "";
                txtProduct.Text = "";
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On btnSearch_Click: " + ex.Message + "')", true);
        }
        txtProduct.Focus();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGridview1();
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }

    protected void BindgridDeliveryStatus()
    {
        try
        {
            string Query = " Select a.DeliveryId, d.Title, c.Fname+' '+c.Mname+' '+c.Lname as Assignto,CONVERT(VARCHAR(11), b.Estimateddate,113) as Estimateddate, a.DeliveryStatus,CONVERT(VARCHAR(11), b.Ordereddate,113) as Ordereddate from DeliveryStatus a  " +
                           " join Delivery b on a.DeliveryId=b.DeliveryID"+
                           " join Employee c on b.Assignto=c.ID"+
                           " join Items d on b.Itemid=d.Id";

            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(Query);
            if (dt.Rows.Count > 0)
            {
                gridDeliveryStatus.DataSource = dt;
                gridDeliveryStatus.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Javascript", "Func('delivery','DeliveryStatus'); ", true);
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gridDeliveryStatus.DataSource = dt;
                gridDeliveryStatus.DataBind();
                int columncount = GridView1.Rows[0].Cells.Count;
                gridDeliveryStatus.Rows[0].Cells.Clear();
                gridDeliveryStatus.Rows[0].Cells.Add(new TableCell());
                gridDeliveryStatus.Rows[0].Cells[0].ColumnSpan = columncount;
                gridDeliveryStatus.Rows[0].Cells[0].Text = "No Records Found";
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Javascript", "Func('delivery','DeliveryStatus'); ", true);
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On BindgridDeliveryStatus: " + ex.Message + "')", true);
        }
    }

    protected void btnSearch1_Click(object sender, EventArgs e)
    {
        try
        {
            string status = "";
            if(ddldlvstatus.SelectedValue != null && ddldlvstatus.SelectedValue != "")
            {
                status = ddldlvstatus.SelectedItem.Text;
            }
            else
            {
                status = "";
            }
            string getsearch = " Select a.DeliveryId, d.Title, c.Fname+' '+c.Mname+' '+c.Lname as Assignto,CONVERT(VARCHAR(11), b.Estimateddate,113) as Estimateddate, a.DeliveryStatus,CONVERT(VARCHAR(11), b.Ordereddate,113) as Ordereddate from DeliveryStatus a" +
                           " join Delivery b on a.DeliveryId=b.DeliveryID" +
                           " join Employee c on b.Assignto=c.ID" +
                           " join Items d on b.Itemid=d.Id" +
                           " Where d.Title like '" + txtdlvProd.Text + "%' and c.Fname like '" + txtdlvAsgemp.Text + "%' and a.DeliveryStatus like '" + status + "%' ";

            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(getsearch);
            if (dt.Rows.Count > 0)
            {
                gridDeliveryStatus.DataSource = dt;
                gridDeliveryStatus.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Javascript", "Func('delivery','DeliveryStatus'); ", true);
                //return;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gridDeliveryStatus.DataSource = dt;
                gridDeliveryStatus.DataBind();
                int columncount = GridView1.Rows[0].Cells.Count;
                gridDeliveryStatus.Rows[0].Cells.Clear();
                gridDeliveryStatus.Rows[0].Cells.Add(new TableCell());
                gridDeliveryStatus.Rows[0].Cells[0].ColumnSpan = columncount;
                gridDeliveryStatus.Rows[0].Cells[0].Text = "No Records Found";

                //ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('No Records Found')", true);
                txtAssignto.Text = "";
                txtProduct.Text = "";
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Javascript", "Func('delivery','DeliveryStatus'); ", true);
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On btnSearch_Click: " + ex.Message + "')", true);
        }
        txtProduct.Focus();
    }

    protected void gridDeliveryStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindgridDeliveryStatus();
        gridDeliveryStatus.PageIndex = e.NewPageIndex;
        gridDeliveryStatus.DataBind();
    }

    protected void BindgridProductDelivery()
    {
        try
        {
            string Query = " Select a.DeliveryId, d.Title, c.Fname+' '+c.Mname+' '+c.Lname as Assignto, a.DeliveryStatus,  b.Addr1, e.Name as Delvstate, f.Name as Delvcity, b.Zipcode,CONVERT(VARCHAR(11), b.Ordereddate,113) as Ordereddate,CONVERT(VARCHAR(11), b.Estimateddate,113) as Estimateddate from DeliveryStatus a" +
                           " join Delivery b on a.DeliveryId=b.DeliveryID"+
                           " join Employee c on b.Assignto=c.ID"+
                           " join Items d on b.Itemid=d.Id"+
                           " join State e on b.State=e.StateId"+
                           " join City f on b.City=f.CityId";

            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(Query);
            if (dt.Rows.Count > 0)
            {
                gridProductdelivery.DataSource = dt;
                gridProductdelivery.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Javascript", "Func('prod','ProductDelivery'); ", true);
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gridProductdelivery.DataSource = dt;
                gridProductdelivery.DataBind();
                int columncount = GridView1.Rows[0].Cells.Count;
                gridProductdelivery.Rows[0].Cells.Clear();
                gridProductdelivery.Rows[0].Cells.Add(new TableCell());
                gridProductdelivery.Rows[0].Cells[0].ColumnSpan = columncount;
                gridProductdelivery.Rows[0].Cells[0].Text = "No Records Found";
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Javascript", "Func('prod','ProductDelivery'); ", true);
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On BindgridProductDelivery: " + ex.Message + "')", true);
        }
    }

    protected void btnSearch2_Click(object sender, EventArgs e)
    {
        try
        {
            string status = "";
            if (ddlprdlvstatus.SelectedValue != null && ddlprdlvstatus.SelectedValue != "")
            {
                status = ddlprdlvstatus.SelectedItem.Text;
            }
            else
            {
                status = "";
            }
            string getsearch = " Select a.DeliveryId, d.Title, c.Fname+' '+c.Mname+' '+c.Lname as Assignto, a.DeliveryStatus,  b.Addr1, e.Name as Delvstate, f.Name as Delvcity, b.Zipcode from DeliveryStatus a " +
                           " join Delivery b on a.DeliveryId=b.DeliveryID" +
                           " join Employee c on b.Assignto=c.ID" +
                           " join Items d on b.Itemid=d.Id" +
                           " join State e on b.State=e.StateId" +
                           " join City f on b.City=f.CityId"+
                           " Where d.Title like '" + txtprdlvProd.Text + "%' and c.Fname like '" + txtprdlvasnemp.Text + "%' and a.DeliveryStatus like '" + status + "%'";

            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(getsearch);
            if (dt.Rows.Count > 0)
            {
                gridProductdelivery.DataSource = dt;
                gridProductdelivery.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Javascript", "Func('prod','ProductDelivery'); ", true);
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gridProductdelivery.DataSource = dt;
                gridProductdelivery.DataBind();
                int columncount = GridView1.Rows[0].Cells.Count;
                gridProductdelivery.Rows[0].Cells.Clear();
                gridProductdelivery.Rows[0].Cells.Add(new TableCell());
                gridProductdelivery.Rows[0].Cells[0].ColumnSpan = columncount;
                gridProductdelivery.Rows[0].Cells[0].Text = "No Records Found";               
                txtAssignto.Text = "";
                txtProduct.Text = "";
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Javascript", "Func('prod','ProductDelivery'); ", true);
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On btnSearch_Click: " + ex.Message + "')", true);
        }
        txtProduct.Focus();
    }
    protected void gridProductdelivery_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindgridProductDelivery();
        gridProductdelivery.PageIndex = e.NewPageIndex;
        gridProductdelivery.DataBind();
    }
}