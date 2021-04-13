using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI.WebControls;

public partial class disposal_of_complaints : System.Web.UI.Page
{
    string str = ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString;
    int PSCode;

    protected void Page_Load(object sender, EventArgs e)
    {
        PSCode = Int32.Parse(Session["PSCode"].ToString());
        DisposalOfComplaints();
        FeedBack();
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




    public void DisposalOfComplaints()
    {
        string Query = "select head as 'Head',complaintspending as 'Total no. of Complaints pending as on 01-01-2021'," +
                           "addedupdate as 'Added (from 01-01-2021 to update)',disposalupdate as 'Disposal (from 01-01-2021 to update)'," +
                           "addedduringday as 'Added during Day',disposedduringday as 'Disposed during Day',total as 'Total'," +
                           "targetachivedby15221 as 'Target to be achieved by 15.2.21 ',targetachivedby30221 as 'Target to be achieved by 30.2.21'" +
                           "from FieldWorkMgt_DB.dbo.disposalofcomplaints where ps_code = " + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }


    public void FeedBack()
    {
        string Query = "select totalcomplaints as 'Total No. of Complainant visited police station',totalfeedbackform as 'Total No. of Feedback Form sent'," +
                           "targetforweek as 'Target for week',totalfeedback as 'Total No. of Feedback Forms received Back'," +
                           "feedbackverygood as 'Very Good',feedbackgood as 'Good',feedbacksatisfactory as 'Satisfactory',feedbackpoor as 'Poor'" +
                           "from FieldWorkMgt_DB.dbo.disposalofcomplaintsfeedback where ps_code = " + PSCode;
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
        DisposalOfComplaints();
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        FeedBack();
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataBind();
    }



    [WebMethod]
    public static string Task(string query)
    {
        return query;
    }



}