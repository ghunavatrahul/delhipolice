using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI.WebControls;

public partial class disposal_inquest : System.Web.UI.Page
{
    string str = ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString;
    int PSCode;

    protected void Page_Load(object sender, EventArgs e)
    {
        PSCode = Int32.Parse(Session["PSCode"].ToString());
        DisposalTotal();
        DisposalToday();
        DisposalPeriodWise();
        DisposalInvestigation();
        DisposalMonitoring();
        DisposalMud();
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


    public void DisposalTotal()
    {
        string Query = "select head as 'HEAD',totalpicase as 'Total no. of PI Cases as on 01-01-2021'," +
                       "addedpicase as 'Added PI Cases (from 01-01-2021 to update)',disposalofpi as 'Disposal of PI Cases (from 01-01-2021 to update)'," +
                       "addedduringday as 'Added during Day',disposedday as 'Disposed during Day'," +
                       "totalpi as 'Total PI Cases (Upto date)',targetto as 'Target to be achieved by 28.2.2021'," +
                       "targettoachive as 'Target to be achieved by 31.3.2021'" +
                       "from FieldWorkMgt_DB.dbo.disposal_total where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    public void DisposalToday()
    {
        string Query = "select sno as 'S.NO',firno as 'FIR No.',date as 'Date'," +
                       "undersection as 'Under Section',rcno as 'RC No.',challan as 'Challan/ Charge-Sheet'," +
                       "untraced as 'Untraced',cancelled as 'Cancelled',transferred as 'Transferred'" +
                       "from FieldWorkMgt_DB.dbo.disposed_today where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }

    public void DisposalPeriodWise()
    {
        string Query = "select period as 'Period',totalpicase as 'Total no. of PI Cases as on 01-01-2021'," +
                       "addedpi as 'Added PI Cases (from 01-01-2021 to update)',disposedofpi as 'Disposal of PI Cases (from 01-01-2021 to update)'," +
                       "addedduringday as 'Added during Day',disposedday as 'Disposed during Day'," +
                      "totalpi as 'Total PI Cases (Upto date) ',target as 'Target to be achieved by 28.2.2021',targetto as 'Target to be achieved by 31.3.2021'" +
                      "from FieldWorkMgt_DB.dbo.disposal_periodwise where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView3.DataSource = dt;
        GridView3.DataBind();
    }

    public void DisposalInvestigation()
    {
        string Query = "select head as 'HEAD ',totalpi as 'Total no. of PI Cases as on 01-01-2021'," +
                       "addedpi as 'Added PI Cases (from 01-01-2021 to update)',disposalpi as 'Disposal of PI Cases (from 01-01-2021 to update)'," +
                       "addedduringday as 'Added during Day',disposalday as 'Disposed during Day'," +
                       "totalpicase as 'Total PI Cases (Upto date)',piover as 'PI over 60 Days'," +
                       "target as 'Target to be achieved by 28.2.2021',tagettoachived as 'Target to be achieved by 31.3.2021'" +
                       "from FieldWorkMgt_DB.dbo.disposal_investigation where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView4.DataSource = dt;
        GridView4.DataBind();
    }

    public void DisposalMonitoring()
    {
        string Query = "select sno as 'S No.',deatilsofcase as 'Details of Case'," +
                       "nameofcourt as 'Name of Court',statusreport as 'Status report to be filed or not',datehearing as 'Date of Hearing'," +
                       "inspname as 'Name of Insp. Who will attend the Court with IO',note as 'Note, ,the court matter must be attended through VC room in PS'" +
                       "from FieldWorkMgt_DB.dbo.disposal_monitoring where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView5.DataSource = dt;
        GridView5.DataBind();
    }

    public void DisposalMud()
    {
        string Query = "select totalmud as 'Total no. of Mud as on 01-01-2021',addedmud as 'Added Muds (from 01-01-2021 to update)'," +
                       "disposalmud as 'Disposal of Muds  (from 01-01-2021 to update)',addedday as 'Added during Day'," +
                       "disposedday as 'Disposed during Day',totalmuds as 'Total Muds (Uptodate)',target as 'Target to be achieved by 28.2.2021 ',targettobe as 'Target to be achieved by 31.3.2021'" +
                       "from FieldWorkMgt_DB.dbo.disposal_mud where ps_code=" + PSCode;
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
        DisposalTotal();
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DisposalToday();
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataBind();
    }


    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DisposalPeriodWise();
        GridView3.PageIndex = e.NewPageIndex;
        GridView3.DataBind();
    }

    protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DisposalInvestigation();
        GridView4.PageIndex = e.NewPageIndex;
        GridView4.DataBind();
    }

    protected void GridView5_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DisposalMonitoring();
        GridView5.PageIndex = e.NewPageIndex;
        GridView5.DataBind();
    }

    protected void GridView6_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DisposalMud();
        GridView6.PageIndex = e.NewPageIndex;
        GridView6.DataBind();
    }

    [WebMethod]
    public static string Task(string query)
    {
        return query;
    }



}