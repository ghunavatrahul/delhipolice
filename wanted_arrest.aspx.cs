using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI.WebControls;

public partial class wanted_arrest : System.Web.UI.Page
{
    string str = ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString;
    int PSCode;

    protected void Page_Load(object sender, EventArgs e)
    {
        PSCode = Int32.Parse(Session["PSCode"].ToString());
        CriminalToBeArrest();
        CriminalArrested();
        BcArrested();
        JailBail();
        ProClaimed();
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


    public void CriminalToBeArrest()
    {
        string Query = "select sno as 'S No.',detailsofperson as 'Details of Person wanted (Name, Father Name Address'," +
                       "detalisofcase as 'Details of Case, (FIR No., Date, U/S, PS) in which wanted',coacussedarrested as 'Whether co-accused arrested or not'," +
                       "effortstoarrest as 'Efforts made to arrest'" +
                       "from FieldWorkMgt_DB.dbo.wanted_leftover where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    public void CriminalArrested()
    {
        string Query = "select sno as 'S.NO',detailsofwanted as 'DETAILS OF WANTED CRIMINALS (NAME,PARETAGE AND ADDRESS)'," +
                       "detailsofcase as 'DETAILS OF CASE IN WHICH WANTED (FIR NO, DATE, UNDER SECTION)'," +
                       "policestation as 'Police Station',arrestdate as 'Arrest date'" +
                       "from FieldWorkMgt_DB.dbo.wanted_arrested where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }

    public void BcArrested()
    {
        string Query = "select sno as 'S.No',dateofhead as 'Date & head in which BCs declared'," +
                       "bcname as 'NAME OF BC',actiontaken as 'Action taken (FIR no., Kalandra & any other)'," +
                       "arrestdate as 'Date of arrest',us as 'U/S'" +
                       "from FieldWorkMgt_DB.dbo.wamted_bcn where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView3.DataSource = dt;
        GridView3.DataBind();
    }

    public void JailBail()
    {
        string Query = "select sno as 'S.No',name as 'NAME',parentage as 'Parentage'," +
                       "address as 'Address',jailreleasedate as 'Jail release Date'," +
                       "firnumb as 'FIR No. & DD No.',us as 'U/S'" +
                       "from FieldWorkMgt_DB.dbo.wanted_bail where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView4.DataSource = dt;
        GridView4.DataBind();
    }

    public void ProClaimed()
    {
        string Query = "select sno as 'S.No',detailofperson as 'Details of Person arrested (Name, Father Name Address'," +
                       "detailofcase as 'Details of Case, (FIR No., Date, U/S, PS)',recovery as 'Recovery',previousinvolment as 'No of Preivous Involvement'" +
                       "from FieldWorkMgt_DB.dbo.wanted_proclaimed where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView5.DataSource = dt;
        GridView5.DataBind();
    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        CriminalToBeArrest();
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        CriminalArrested();
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataBind();
    }


    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BcArrested();
        GridView3.PageIndex = e.NewPageIndex;
        GridView3.DataBind();
    }

    protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        JailBail();
        GridView4.PageIndex = e.NewPageIndex;
        GridView4.DataBind();
    }

    protected void GridView5_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        ProClaimed();
        GridView5.PageIndex = e.NewPageIndex;
        GridView5.DataBind();
    }

    [WebMethod]
    public static string Task(string query)
    {
        return query;
    }



}