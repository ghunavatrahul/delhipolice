using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI.WebControls;

public partial class arrest_monitor : System.Web.UI.Page
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
        Response.Redirect("Manpower1.aspx");
    }


    protected void BindGrid()
    {
        try
        {

            string Query = "select sno as 'S.No',detailofperson as 'Details of Person arrested (Name, Father Name Address)'," +
                           "sexandage as 'Sex and Age',detailsofcase as 'Details of Case, (FIR No., Date, U/S, PS)'," +
                           "crimehead as 'Crime Head',arrestingofficer as 'Name of Arresting Officer'," +
                           "previousinvolment as 'No of Preivous Involvement',residentoptions as 'Resident (PS/ North/ Others)'," +
                           "homepsareeste as 'Name of Home PS of arrestee',bcornot as 'BC or Not',dossierpreparedornot as 'Dossier preapred or not, if yes (Dossier No.)'," +
                           "jailrelease as 'If jail release, then details of case and date of release',recovery as 'Recovery',"+
                           "followup as 'Follow up (Yes or No)',arrestedby as 'Arrested By (Picket, Patrolling, Crack Team, Spl. Staff, Jaguar, Beat Staff)'," +
                           "wantedleftover as 'Whether Wanted, Left Over',leftovercriminal as 'Details of left over criminal in this case'," +
                           "receiverofstolen as 'Receiver of stolen property',ifruffian as 'If Ruffian, whether name added in Rough Register'" +
                           "from FieldWorkMgt_DB.dbo.arrest_monitor where ps_code = " + PSCode;
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


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGrid();
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }




    [WebMethod]
    public static string Task(string query)
    {
        return query;
    }



}