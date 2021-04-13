using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI.WebControls;

public partial class target_on_gangs : System.Web.UI.Page
{
    string str = ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString;
    int PSCode;

    protected void Page_Load(object sender, EventArgs e)
    {
        PSCode = Int32.Parse(Session["PSCode"].ToString());
        TargetOnGangs();
        TargetCyberTeam();
        TargetTopFive();
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


    public void TargetOnGangs()
    {
        string Query = "select head as 'Head',gangsontarget as 'No. of Gangs on Target',arrestedduringweek as 'Arrested during week'," +
                       "recovery as 'Recovery',arresteduptodate as 'Arrested upto Date',gangslarge as 'No. of criminals/gangs at large'" +
                       "from FieldWorkMgt_DB.dbo.target_on_gangs where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    public void TargetCyberTeam()
    {
        string Query = "select cybercrimecomplains as 'No. of Cyber Complaint Received',complainspending as 'Complaints pending for enquiry'," +
                       "caseregistered as 'Case Registered',caseworkedout as 'Cases worked out',casePIovertwomonths as 'Cases PI over two months'," +
                       "criminaltarget as 'Criminals on Target'" +
                       "from FieldWorkMgt_DB.dbo.target_cyber_team where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }

    public void TargetTopFive()
    {
        string Query = "select sno as 'S.No',name as 'Name',fathername as 'Father Name',address as 'Address',status as 'Status'," +
                       "actiononweek as 'Action of Week'" +
                       "from FieldWorkMgt_DB.dbo.target_list_topfive  where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView3.DataSource = dt;
        GridView3.DataBind();
    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        TargetOnGangs();
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        TargetCyberTeam();
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataBind();
    }


    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        TargetTopFive();
        GridView3.PageIndex = e.NewPageIndex;
        GridView3.DataBind();
    }


    [WebMethod]
    public static string Task(string query)
    {
        return query;
    }



}