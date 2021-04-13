using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI.WebControls;

public partial class surveillance_target : System.Web.UI.Page
{
    string str = ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString;
    int PSCode;

    protected void Page_Load(object sender, EventArgs e)
    {
        PSCode = Int32.Parse(Session["PSCode"].ToString());
        Bcs();
        JailBailReleased();
        Ruffians();
        Externment();
        HistorySheet();
        Dossier();
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


    public void Bcs()
    {
        string Query = "select totalbcs as 'Total No. of BCs',activebcs as 'Active BCs'," +
                       "targetbcchecking as 'Target of BC Checking',bccheckedday as 'BC Checked during the Day'," +
                       "absentbcs as 'Absent BCs',target as 'Target',activebcarrested as 'No. of active BC arrested'" +
                       "from FieldWorkMgt_DB.dbo.surveillance_bcs where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    public void JailBailReleased()
    {
        string Query = "select years as 'Year',totalbailreleased as 'Total No. of Jail-Bail released Criminals'," +
                       "target as 'Target',verified as 'Verified',foundpresent as 'Found Present'," +
                       "foundabsent as 'Found Absent/Left the address',addressnotverified as 'Address not verified'" +
                       "from FieldWorkMgt_DB.dbo.surveillance_jailbail where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }

    public void Ruffians()
    {
        string Query = "select year as 'Year',totalruffians as 'Total No. of Ruffians/ Budding Criminals Identified'," +
                       "targetforvisitday as 'Target for Vigil during Day',targetforvisitweek as 'Target for Vigil during Week'," +
                       "nameroughregister as 'Name added in Rough Register',verified as 'Verified',foundpresent as 'Found Present'" +
                       "from FieldWorkMgt_DB.dbo.surveillance_ruffians where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView3.DataSource = dt;
        GridView3.DataBind();
    }

    public void Externment()
    {
        string Query = "select targetexternment as 'Target for opening of Externment',numbexternment as 'No. of Externment Proposal initiated'," +
                       "beingprepared as 'No. of Externment Proposal being prepared',criminalexterned as 'No. of crimnals Externed'," +
                       "checkingexternnedcriminal as 'Checking of Externned Criminals',action as 'Action on Externed Criminal found Violating the Orders and residing in the area/Delhi'" +
                       "from FieldWorkMgt_DB.dbo.surveillance_externment where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView4.DataSource = dt;
        GridView4.DataBind();
    }

    public void HistorySheet()
    {
        string Query = "select target as 'Target for opening of History Sheet',historysheetopened as 'No. of History Sheet Opened'," +
                       "historysheetyettoopened as 'No. of History Sheet Yet to be Opened',targetpersonalfile as 'Target for Personal File'," +
                       "personalfileprepared as 'No. of Personal File prepared',personalfileyettoopened as 'No of Personal File yet to be opened'" +
                       "from FieldWorkMgt_DB.dbo.surveillance_history where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView5.DataSource = dt;
        GridView5.DataBind();
    }

    public void Dossier()
    {
        string Query = "select newdossier as 'No. of New Dossier Prepared',dossierupdated as 'No. of Dossier Updated'," +
                       "target as 'TARGET - No. of Dossier to be checked by ATO',dossiertobechecked as 'Dossier  checked by ATO'," +
                       "targetsho as 'TARGET - No. of Dossier to be checked by SHO',dossiersho as 'Dossier  checked by SHO'" +
                       "from FieldWorkMgt_DB.dbo.surveillance_dossier where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView6.DataSource = dt;
        GridView6.DataBind();
    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Bcs();
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        JailBailReleased();
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataBind();
    }


    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Ruffians();
        GridView3.PageIndex = e.NewPageIndex;
        GridView3.DataBind();
    }

    protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Externment();
        GridView4.PageIndex = e.NewPageIndex;
        GridView4.DataBind();
    }

    protected void GridView5_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        HistorySheet();
        GridView5.PageIndex = e.NewPageIndex;
        GridView5.DataBind();
    }

    protected void GridView6_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Dossier();
        GridView6.PageIndex = e.NewPageIndex;
        GridView6.DataBind();
    }

    [WebMethod]
    public static string Task(string query)
    {
        return query;
    }



}