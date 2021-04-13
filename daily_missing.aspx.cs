using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI.WebControls;

public partial class daily_missing : System.Web.UI.Page
{
    string str = ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString;
    int PSCode;

    protected void Page_Load(object sender, EventArgs e)
    {
        PSCode = Int32.Parse(Session["PSCode"].ToString());
        MissingMonitoring();
        DailyChild();
        DailyReport();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("daily_missing1.aspx");
    }

    protected void btnAdd1_Click(object sender, EventArgs e)
    {
        Response.Redirect("daily_missing2.aspx");
    }

    protected void btnAdd2_Click(object sender, EventArgs e)
    {
        Response.Redirect("daily_missing3.aspx");
    }



    public void MissingMonitoring()
    {
        string Query = "select beat_id,ddnopcrcall,ddentry,total,traced,caseregister,pending,reasonofpending from FieldWorkMgt_DB.dbo.daily_missing_monitoring where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    public void DailyChild()
    {
        string Query = "select beat_id,pcrmale as 'PCR Call Male',pcrfemale as 'PCR Call Female',ddmale as 'DD Entry Male',ddfemale as 'DD Entry Female',totalmale as 'Total Male'," +
                       "totalfemale as 'Total Female',tracedmale as 'Traced Male',tracedfemale as 'Traced Female',casemale as 'Case Register Male',casefemale as 'Case Register Female'," +
                       "pendingmale as 'Pending Male',pendingfemale as 'Pending Female',reasonmale as 'Reason Male',reasonfemale as 'Reason Female'" +
                       "from FieldWorkMgt_DB.dbo.daily_missing_child where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }


    public void DailyReport()
    {
        string Query = "select beat_id,childreportedmale as 'Child Reported Male',childreportedfemale as 'Child Reported Female',childreporttotal as 'Child Reported Total'," +
                       "childtracedmale as 'Child Traced Male',childtracedfemale as 'Child Traced Female',childtracedtotal as 'Child Traced Total',totalmissingmale as 'Total Missing Male'," +
                       "totalmissingfemale as 'Total Missing Female',totaltracedmale as 'Total Traced Male',totaltracedfemale as 'Total Traced Female',untraced as 'Untraced',missinguploadzipnet as 'Whether Missing Uploaded on Zip Net'," +
                       "tracinguploadzipnet as 'Whether tracing Uploaded on Zip Net',guidlinesfollowed as 'Whether guidelines laid down in SO and SOP followed',nearbyhospital as 'Nearby Hospitals /crowded places searched',effortmade as 'Efforte Made to Trace the victim'" +
                       "from FieldWorkMgt_DB.dbo.daili_missing_report where ps_code=" + PSCode;
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView3.DataSource = dt;
        GridView3.DataBind();
    }




    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Deletes")
        {
            try
            {
                string id = e.CommandArgument.ToString();
                string Query = "delete FROM FieldWorkMgt_DB.dbo.daily_missing_monitoring where beat_id=" + id;
                DataBase DB = new DataBase();
                DB.DeleteData(Query);
                MissingMonitoring();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On Delete: " + ex.Message + "')", true);
            }
        }
    }


    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Deletes")
        {
            try
            {
                string id = e.CommandArgument.ToString();
                string Query = "delete FROM FieldWorkMgt_DB.dbo.daily_missing_child where beat_id=" + id;
                DataBase DB = new DataBase();
                DB.DeleteData(Query);
                DailyChild();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On Delete: " + ex.Message + "')", true);
            }
        }
    }


    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Deletes")
        {
            try
            {
                string id = e.CommandArgument.ToString();
                string Query = "delete FROM FieldWorkMgt_DB.dbo.daili_missing_report where beat_id=" + id;
                DataBase DB = new DataBase();
                DB.DeleteData(Query);
                DailyReport();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On Delete: " + ex.Message + "')", true);
            }
        }
    }




    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        MissingMonitoring();
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DailyChild();
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataBind();
    }

    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DailyReport();
        GridView3.PageIndex = e.NewPageIndex;
        GridView3.DataBind();
    }


    [WebMethod]
    public static string Task(string query)
    {
        return query;
    }

}