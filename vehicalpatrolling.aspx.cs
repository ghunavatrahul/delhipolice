using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI.WebControls;

public partial class vehicalpatrolling : System.Web.UI.Page
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
        Response.Redirect("vehicalpatrolling.aspx");
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

            string Query = "select  vehical_area as 'Area/Stretch covered by the Vehicle',vehicle_type as 'Type of Vehicle (ERV/QRT/M.Cycles)', "+
                           "  registration_no as 'Registration No. of Vehicle',is_gps_enable as 'Whether GPS enabled or not',staffdeployed as 'Staff deployed', "+
                           "  timing as 'Timings',numberofkm as 'No. of Kms. During patrolling',numbvehiclechecked as 'No. of Vehicle Checked Today', "+
                           "  dpactsixfive as '65 DP Act Today',dpactsixsix as '66 DP Act Today', exciseactfourezeroa as '40-A Excise Act Today', "+
                           " informationsheet as 'Information Sheet Issused Today',tintedglass as 'Tinted Glass Today',detection as 'Detection' "+
                           "  from [FieldWorkMgt_DB].dbo.vehiclepatrolling where ps_code = " + PSCode;
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