using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class PicketDetails : System.Web.UI.Page
{
    string str = ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString;
    int PSCode;

    protected void Page_Load(object sender, EventArgs e)
    {
        PSCode = Int32.Parse(Session["PSCode"].ToString());
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("Pickets1.aspx");
    }
    
    protected void BindGrid()
    {
        try
        {

            string Query = "select p.picket_id, p.picket_name, p.picket_type, ps.ps_name, p.timing, p.vehiscanAppDailyTarge, " +
                           " p.dailyTarget66DPAct, p.strangerRollIssuedDailyTarget, p.dailyTarget65DPAct " +
                           " from FieldWorkMgt_DB.dbo.picket_details p left join FieldWorkMgt_DB.dbo.Police_Station ps on p.ps_code = ps.ps_code "+
                           " where p.ps_code = "+PSCode+"";
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(Query);
            if (dt.Rows.Count > 0)
            {
                GridView3.DataSource = dt;
                GridView3.DataBind();
                ViewState["dirState"] = dt;
                ViewState["sortdr"] = "Asc";

            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GridView3.DataSource = dt;
                GridView3.DataBind();
                int columncount = GridView3.Rows[0].Cells.Count;
                GridView3.Rows[0].Cells.Clear();
                GridView3.Rows[0].Cells.Add(new TableCell());
                GridView3.Rows[0].Cells[0].ColumnSpan = columncount;
                GridView3.Rows[0].Cells[0].Text = "No Records Found";
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On BindGrid: " + ex.Message + "')", true);
        }
    }

    protected void OnDataBound(object sender, EventArgs e)
    {
        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        TableHeaderCell cell;

        cell = new TableHeaderCell();
        cell.Text = "";
        cell.ColumnSpan = 5;  
        row.Controls.Add(cell);

        cell = new TableHeaderCell();
        cell.ColumnSpan = 4;
        cell.Attributes.Add("style", "text-align:center !important;");
        cell.Text = "Daily Target";
        row.Controls.Add(cell);

        cell = new TableHeaderCell();
        cell.ColumnSpan = 1;
        cell.Text = "";
        cell.Attributes.Add("style", "text-align:center !important;");
        row.Controls.Add(cell);

        row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
        GridView3.HeaderRow.Parent.Controls.AddAt(0, row);
    }
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Deletes")
        {
            try
            {
                string id = e.CommandArgument.ToString();
                string Query = "delete FROM FieldWorkMgt_DB.dbo.hotspot where hotspot_code=" + id ;
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

    protected void GridView3_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtrslt = (DataTable)ViewState["dirState"];
        if (dtrslt.Rows.Count > 0)
        {
            if (Convert.ToString(ViewState["sortdr"]) == "Asc")
            {
                dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                ViewState["sortdr"] = "Desc";
            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                ViewState["sortdr"] = "Asc";
            }
            GridView3.DataSource = dtrslt;
            GridView3.DataBind();


        }

    }

    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGrid();
        GridView3.PageIndex = e.NewPageIndex;
        GridView3.DataBind();
    }

    

    
    [WebMethod]
    public static string Task(string query)
    {
        return query;
    }


    
}