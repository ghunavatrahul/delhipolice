using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI.WebControls;

public partial class Hotspots : System.Web.UI.Page
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
        Response.Redirect("Hotspots1.aspx");
    }
    
    protected void BindGrid()
    {
        try
        {

            string Query = "select hotspot_code,location_area,beat_number,division_beat_officer from FieldWorkMgt_DB.dbo.hotspot where ps_code=" + PSCode+ " order by beat_number";
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(Query);
            if (dt.Rows.Count > 0)
            {
                GridView3.DataSource = dt;
                GridView3.DataBind();
                
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