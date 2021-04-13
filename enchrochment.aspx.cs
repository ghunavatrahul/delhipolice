using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI.WebControls;

public partial class enchrochment : System.Web.UI.Page
{
    string str = ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString;
    int PSCode;

    protected void Page_Load(object sender, EventArgs e)
    {
        PSCode = Int32.Parse(Session["PSCode"].ToString());
        Enchrochment();
        EnchrochmentTwo();
    }
    
    public void Enchrochment()
    {
        string Query = "select sno as 'S No',place as 'Place of where Encroachment removal programe conducted'," +
                       "time as 'Time of Encroachment removal',withwhom as 'With whom agency Encroachment Removal programme conducted'," +
                       "articles as 'Articles deposits',anyother as 'Any other action'," +
                       "target as 'Target for Todays Encroachment Removal Action'" +
                       "from FieldWorkMgt_DB.dbo.enchroachment where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    public void EnchrochmentTwo()
    {
        string Query = "select focusposint as 'Focus point',strategy as 'Strategy',given as 'Given',achieved as 'Achieved'" +
                       "from FieldWorkMgt_DB.dbo.enchroachmenttwo where ps_code=" + PSCode;
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
        Enchrochment();
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        EnchrochmentTwo();
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataBind();
    }

    
    [WebMethod]
    public static string Task(string query)
    {
        return query;
    }

}