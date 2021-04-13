using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI.WebControls;

public partial class criminal_arrest : System.Web.UI.Page
{
    string str = ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString;
    int PSCode;

    protected void Page_Load(object sender, EventArgs e)
    {
        PSCode = Int32.Parse(Session["PSCode"].ToString());
        //ManpowerStatics();
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    /*protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manpower1.aspx");
    }
    public void ManpowerStatics()
    {
        string Query = "select mtype as 'Manpower Type',Inspector,si as 'SI',asi as ASI,hcs as 'HCs',cts as 'CTs',Total from  FieldWorkMgt_DB.dbo.ps_manpower_statics where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
   */


    protected void BindGrid()
    {
        try
        {

            string Query = "select criminals as 'Criminals',caseregister as 'No. of Cases registered',numofaccuseinvolved as 'No. of accused involved as per content of FIR'," +
                           "target as 'Target',weektotal as 'Arrested in Week- Total',weekrecovery as 'Arrested in Week - Recovery'," +
                           "weeknovice as 'Arrested in Week - Novice',weekpi as 'Arrested in Week - P.I',weekfollowup as 'Arrested in Week - Follow-Up'," +
                           "weekreceiver as 'Arrested in Week - Received',uptodatetotal as 'Upto Date Arrested - Total',uptodaterecovery as 'Upto Date Arrested - Recovery'," +
                           "uptodatenovice as 'Upto Date Arrested - Novice',uptodatepi as 'Upto Date Arrested - P.I',uptodatefollowup as 'Upto Date Arrested - Follow-Up'," +
                           "uptodatereceive as 'Upto Date Arrested - Receive',targetgiven as 'Target Given',targetachived as 'Target- Achived'," +
                           "targetnextweek as 'Target- for next Week'" +
                           "from FieldWorkMgt_DB.dbo.criminal_arrest where ps_code = " + PSCode;
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