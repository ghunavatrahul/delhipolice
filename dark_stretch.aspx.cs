using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI.WebControls;

public partial class dark_stretch : System.Web.UI.Page
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


    protected void BindGrid()
    {
        try
        {

            string Query = "select sno as 'S.No',darkstrech as 'Dark Stretches',authorityconcerned as 'Authority concerned to whom letters sent',rectifybyauthority as 'Rectified by concerned authority',ifnotrectified as 'If not rectified, date of last reminder to concerned authority',picket as 'Strategy - Picket'," +
                           "patrolling as 'Strategy - Patrolling',target as 'Action Taken-66 DP Act - Target',taken66dpday as 'Action Taken-66 DP Act - Day',taken66dpweek as 'Action Taken-66 DP Act - Week',taken65dptarget as 'Action Taken-65 DP Act - Target',taken65dpday as 'Action Taken-65 DP Act - Day'," +
                           "taken65dpweek as 'Action Taken-65 DP Act - Week',takenstrangertarget as 'Action Taken-Stranger Roll - Target',takenstrangerday as 'Action Taken-Stranger Roll - Day',takenstrangerweek as 'Action Taken-Stranger Roll - Week',cctvgovtagencies as 'No. of CCTVs installed in Dark Stretches - Govt. Agencies'," +
                           "cctvmplad as 'No. of CCTVs installed in Dark Stretches - MPLAD',cctvothers as 'No. of CCTVs installed in Dark Stretches - Others'" +
                           "from FieldWorkMgt_DB.dbo.dark_stretch where ps_code = " + PSCode;
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