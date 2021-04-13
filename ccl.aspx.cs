using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI.WebControls;

public partial class ccl : System.Web.UI.Page
{
    string str = ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString;
    int PSCode;

    protected void Page_Load(object sender, EventArgs e)
    {
        PSCode = Int32.Parse(Session["PSCode"].ToString());
        Ccl();
        TotalCcl();
    }
    
    public void Ccl()
    {
        string Query = "select year as 'Year',henous as 'Heinous',nonhenious as 'Non-Heinous',total as 'Total'," +
                       "cclcontacted as 'CCL Contacted',cclyetcontacted as 'CCL Yet to be contacted'," +
                       "targetccl as 'TARGET on CCL, who turned Major and found involved in Crime'" +
                       "from FieldWorkMgt_DB.dbo.ccl where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    public void TotalCcl()
    {
        string Query = "select totalccl as 'Total CCL',vocationaltarget as 'Target',vocationaldone as 'Done',yuvatarget as 'Target'," +
                       "yuvadone as 'Done',sporttarget as 'Target',sportdone as 'Done',jobtarget as 'Target',jobdone as 'Done'," +
                       "counsellingtarget as 'Target',counsellingdone as 'Done'" +
                       "from FieldWorkMgt_DB.dbo.ccl_total where ps_code=" + PSCode;
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
        Ccl();
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        TotalCcl();
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataBind();
    }

    
    [WebMethod]
    public static string Task(string query)
    {
        return query;
    }

}