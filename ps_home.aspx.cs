using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI.WebControls;

public partial class ps_home : System.Web.UI.Page
{
    string str = ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString;
    int PSCode;

    protected void Page_Load(object sender, EventArgs e)
    {
        PSCode = Int32.Parse(Session["PSCode"].ToString());
        PsataGlance();
        DetailsDivisionBeat();
    }
    
    public void PsataGlance()
    {
        string Query = "select Point,Details from FieldWorkMgt_DB.dbo.ps_ata_glance where ps_code="+PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    public void DetailsDivisionBeat()
    {
        string Query = "select division as Division,division_officer as 'Division Officer',replace(beat_officer,'\\n','  ') as 'Beat Officer' from FieldWorkMgt_DB.dbo.manpower_division_beat where ps_code="+PSCode;
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
        PsataGlance();
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DetailsDivisionBeat();
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataBind();
    }

    
    [WebMethod]
    public static string Task(string query)
    {
        return query;
    }

}