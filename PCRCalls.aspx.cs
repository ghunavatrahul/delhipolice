using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class PCRCalls : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString);
    int PSCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        PSCode = Int32.Parse(Session["PSCode"].ToString());
        if (!Page.IsPostBack)
        {
            GridViewBind();

        }
    }
    private void GridViewBind()
    {
        string query = " select callId, s.headId, s.headName,  hotspot_name,sm.weekly_target,calls_recived_in_week, calls_recived_this_year, calls_recived_last_year, "+
                       "  time_slot_identified, strategy, outcome from "+
                       "  (select callId, s.headId, sm.headName, hotspot_name, calls_recived_in_week, calls_recived_this_year, calls_recived_last_year, "+
                       "  time_slot_identified, strategy, outcome from "+
                       "  (SELECT callId, headId, hotspot_name, coalesce(calls_recived_in_week,0) as calls_recived_in_week, "+
                       "  coalesce(calls_recived_this_year, 0) as calls_recived_this_year, coalesce(calls_recived_last_year, 0) as calls_recived_last_year, "+
                       "  coalesce(time_slot_identified, '') as time_slot_identified, coalesce(strategy, '') as strategy, coalesce(outcome, '') as outcome "+
                       "  FROM dbo.pcrCalls where ps_code = "+PSCode+")s left join "+
                       "  (select headId, headName from dbo.pcrHeadType where ps_code in (0, "+PSCode+"))sm on s.headId = sm.headId)s left join "+
                       "  (select headId, weekly_target from dbo.pcrCallTarget where ps_code = "+PSCode+")sm on s.headId = sm.headId";
        gvListing.DataSource = new DataBase().ExcutesQuery(query);
        gvListing.DataBind();
        gvListing.PageSize = 10;
        pnlGrid.Visible = true;
        pnlAdd.Visible = false;
    }

    protected void BindHead()
    {
        string s = " select headId,headName from dbo.pcrHeadType where ps_code in (0,"+PSCode+")";
        DataBase db = new DataBase();
        DataTable tb = db.ExcutesQuery(s);
        ddlHeadName.Items.Clear();
        if (tb.Rows.Count > 0)
        {
            ddlHeadName.DataSource = tb;
            ddlHeadName.DataValueField = "headId";
            ddlHeadName.DataTextField = "headName";
            ddlHeadName.DataBind();
            ddlHeadName.Items.Insert(0, new ListItem("--Select Head/Section", " "));
        }
    }

    private void ShowEdit()
    {
        BindHead();
    }
    string Id = "0";
    

    protected void btnSave_Click(object sender, EventArgs e)
    {  
       try
        {
            if (ddlHeadName.SelectedItem.Value != "")
            {
                string headId = ddlHeadName.SelectedItem.Value;
                string hotspotName = txtHotSpotName.Text;
                string callInThisWeek = txtCallsRecivedInWeek.Text;
                string callThisYear = txtCallsRecivedThisYear.Text;
                string callPreviousYear = txtCallsRecivedPreviousYear.Text;
                string timeSlot = txtTimeSlotIdentified.Text;
                string strategy = txtStrategy.Text;
                string outcom = txtOutCome.Text;
                string Query = "INSERT INTO dbo.pcrCalls (headId, ps_code, hotspot_name, calls_recived_in_week, calls_recived_this_year, calls_recived_last_year "+
                               " , time_slot_identified, strategy, outcome) VALUES("+headId+", "+PSCode+", '"+hotspotName+"', "+callInThisWeek+", "+callThisYear+", "+callPreviousYear+", '"+timeSlot+"', '"+strategy+"', '"+outcom+"')";
                int i = new DataBase().ExcuteQuery(Query);

            }
            GridViewBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
        finally
        {
            ddlHeadName.SelectedIndex = 0;
            txtHotSpotName.Text = "";
            txtWeeklyTarget.Text = "";
            txtCallsRecivedInWeek.Text = "0";
            txtCallsRecivedThisYear.Text = "0";
            txtCallsRecivedPreviousYear.Text = "0";
            txtTimeSlotIdentified.Text = "";
            txtStrategy.Text = "";
            txtOutCome.Text = "";

        }
        
       
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
       /* txtHeadName.Text = "";
        lblHeadId.Text = "";
        pnlGrid.Visible = true;
        pnlAdd.Visible = false;*/
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ShowEdit();
        pnlGrid.Visible = false;
        pnlAdd.Visible = true;
        pnlAdd.Enabled = true;
        

    }

    protected void gvListing_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewBind();
        gvListing.PageIndex = e.NewPageIndex;
        gvListing.DataBind();
    }
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvListing.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
        GridViewBind();
    }

    protected void txtHeadName_TextChanged(object sender, EventArgs e)
    {
        
    }

    protected void ddlHeadName_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        string headId = ddlHeadName.SelectedItem.Value;
        string s = " select coalesce(weekly_target,'NOT Available') as weekly_target from dbo.pcrCallTarget where ps_code="+PSCode+" and headId ="+ headId + "";
        DataBase db = new DataBase();
        DataTable tb = db.ExcutesQuery(s);
        if (tb.Rows.Count > 0)
        {
            txtWeeklyTarget.Text = Convert.ToString(tb.Rows[0]["weekly_target"]);
        }
        else
            txtWeeklyTarget.Text = "Target for This head is not set, Please set a target..!";
    }
}