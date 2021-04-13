using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sample : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridview1();
        }
    }

    protected void BindGridview1()
    {
        try
        {
            string Query = "Select a.DeliveryID, g.Title, b.Fname+' '+b.Mname+' '+b.Lname as Assignto, a.Addr1, c.Name as Delvstate, d.Name as Delvcity, a.Zipcode, a.PickupAddr, e.Name as PickState, f.Name as PickCity, a.PickZipcode " +
                           " from Delivery a" +
                           " join Employee b on a.Assignto=b.ID" +
                           " join State c on a.State=c.StateId" +
                           " join City d on a.City=d.CityId" +
                           " join State e on a.Pickstate=e.StateId" +
                           " join City f on a.Pickcity=f.CityId" +
                           " join Items g on a.Itemid=g.Id";

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

            string getsearch = " Select a.DeliveryID, g.Title, b.Fname+' '+b.Mname+' '+b.Lname as Assignto, a.Addr1, c.Name as Delvstate, d.Name as Delvcity, a.Zipcode, a.PickupAddr, e.Name as PickState, f.Name as PickCity, a.PickZipcode " +
                               " from Delivery a" +
                               " join Employee b on a.Assignto=b.ID" +
                               " join State c on a.State=c.StateId" +
                               " join City d on a.City=d.CityId" +
                               " join State e on a.Pickstate=e.StateId" +
                               " join City f on a.Pickcity=f.CityId" +
                               " join Items g on a.Itemid=g.Id where Fname like '" + txtAssignto.Text + "%' and Title like '" + txtProduct.Text + "%'";

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
}