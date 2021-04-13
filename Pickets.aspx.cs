using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class Pickets : System.Web.UI.Page
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

            string Query = "SELECT picket_id,p.picket_type,location,timing,vehiscanAppDailyTarge,vehiscanApp2Wheelers,vehiscanApp4Wheelers "+
                           ", vehiscanAppBusTSR, dailyTarget66DPAct, action66DPAct, strangerRollIssuedDailyTarget, strangerRollIssuedAction "+
                           " , dailyTarget65DPAct, action65DPAct, detailsOfDetectionIfAny FROM FieldWorkMgt_DB.dbo.pickets p join "+
                           " FieldWorkMgt_DB.dbo.picket_order po on p.picket_type = po.picket_type where p.ps_code = "+PSCode+" "+
                           " order by po.picket_order, p.picket_id";
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
        cell.ColumnSpan = 4;  
        row.Controls.Add(cell);

        cell = new TableHeaderCell();
        cell.ColumnSpan = 4;
        cell.Attributes.Add("style", "text-align:center !important;");
        cell.Text = "No. of vehicle checked using Vehiscan App";
        row.Controls.Add(cell);

        cell = new TableHeaderCell();
        cell.ColumnSpan = 2;
        cell.Text = "No. of vehicle impounded  u/s 66 DP Act";
        cell.Attributes.Add("style", "text-align:center !important;");
        row.Controls.Add(cell);

        cell = new TableHeaderCell();
        cell.ColumnSpan = 2;
        cell.Text = "No. of Stranger Roll issued";
        cell.Attributes.Add("style", "text-align:center !important;");
        row.Controls.Add(cell);

        cell = new TableHeaderCell();
        cell.ColumnSpan = 2;
        cell.Text = "Action under 65 DP Act";
        cell.Attributes.Add("style", "text-align:center !important;");
        row.Controls.Add(cell);

        cell = new TableHeaderCell();
        cell.ColumnSpan = 1;
        cell.Text = "";
        row.Controls.Add(cell);

        cell = new TableHeaderCell();
        cell.ColumnSpan = 1;
        cell.Text = "";
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