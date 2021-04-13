using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI.WebControls;

public partial class pandemic_covid : System.Web.UI.Page
{
    string str = ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString;
    int PSCode;

    protected void Page_Load(object sender, EventArgs e)
    {
        PSCode = Int32.Parse(Session["PSCode"].ToString());
        PandemicMonitoring();
        Covid();
    }
    
    public void PandemicMonitoring()
    {
        string Query = "select mask as 'Today - No. of Challan - Mask',spiting as 'Today - No. of Challan - Spitting',socialdistancing as 'Today - No. of Challan - Social Distancing',totalchallan as 'Today - No. of Challan - Total Challan',"+
                       "uptomask as 'Upto date No. of Challan - Mask',uptospitting as 'Upto date No. of Challan - Spitting',uptosocialdistancing as 'Upto date No. of Challan - Social Distancing',uptototalchallan as 'Upto date No. of Challan - Total Challan',"+
                       "actiontoday as 'Action taken u/s 188 IPC - Today',actionupto as 'Action taken u/s 188 IPC - Upto Date',challanbookissued as 'No. of Challan Book - Issued',challanbookstock as 'No. of Challan Book - In Stock',"+
                       "challanamountcollected as 'Challan Amount  - Collected',challanamountdeposited as 'Challan Amount  - Deposited',yetodeposited as 'yet to be deposited'"+
                       "from FieldWorkMgt_DB.dbo.pandemic_monitoring where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    public void Covid()
    {
        string Query = "select importantplaces as 'Name of important Temples/Market places',meetingheld as 'Meeting held with Priest/MWA',gathering as 'Gathering',staffdeployed as 'Details of Staff Deployed',"+
                       "posterpasted as 'No.of Poster Pasted',announcmentdone as 'No.of times Announment Done',maskprevious as 'Mask Previous Day Total',maskpresent as 'Mask 18.2.2021'," +
                       "maskuptodate as 'Mask up to date',socialdistanceprevious as 'Social Distancing Previous Day Total',socialdistancepresent as 'Social Distancing 18.2.2021'," +
                       "socialdistanceupto as 'Social Distancing up to date',spittingprevious as 'Spitting Previous Day Total',spittingpresent as 'Spitting 18.2.2021',spittingupto as 'Spitting up to date',us66dpprevious as 'Articles Deposit u/s 66 DP Act Previous day Total',us66dppresent as 'Articles Deposit u/s 66 DP Act 18.2.2021'," +
                       "us66dpupto as 'Articles Deposit u/s 66 DP Act Upto Date',persons65dpprevious as 'Persons Detained u/s 65 DP Act Previous day Total',person65dppresent as 'Persons Detained u/s 65 DP Act 18.2.2021'," +
                       "person65dpupto as 'Persons Detained u/s 65 DP Act Upto Date',maskdistributedprevious as 'No.of Mask distributed Previous Day Total',maskdistributedpresent as 'No.of Mask distributed 18.2.2021'," +
                       "maskdistributedupto as 'No.of Mask distributed Upto Date',anyother as 'Any Other Action',covidchallanprevious as 'Covid Challan done by Inspector Previous Day Total',covidchallanpresent as 'Covid Challan done by Inspector Present Day',covidchallanupto as 'Covid Challan done by Inspector Upto Date'" +
                       "from FieldWorkMgt_DB.dbo.pandemic_covid where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        PandemicMonitoring();
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Covid();
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataBind();
    }

    
    [WebMethod]
    public static string Task(string query)
    {
        return query;
    }

}