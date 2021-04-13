using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PCRCallsEdit : System.Web.UI.Page
{
    string Employeeid;
    int PSCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["EmpID"]) != null && Convert.ToString(Session["EmpID"]) != "")
        {
            Employeeid = Convert.ToString(Session["EmpID"]);
            PSCode = Int32.Parse(Session["PSCode"].ToString());
        }
        if (!IsPostBack)
        {
            LoadCallData();
        }
    }
    public void LoadCallData()
    { 
        try
        {

            hfCallId.Value = Request.QueryString["CallId"];
            
            int callId = 0;
            int.TryParse(hfCallId.Value, out callId);

            string deployement = "select callId, s.headId, s.headName,  hotspot_name,sm.weekly_target,calls_recived_in_week, calls_recived_this_year, calls_recived_last_year, "+
                                " time_slot_identified, strategy, outcome from "+
                                " (select callId, s.headId, sm.headName, hotspot_name, calls_recived_in_week, calls_recived_this_year, calls_recived_last_year, "+
                                " time_slot_identified, strategy, outcome from "+
                                " (select callId, headId, hotspot_name, coalesce(calls_recived_in_week,0) as calls_recived_in_week, "+
                                " coalesce(calls_recived_this_year, 0) as calls_recived_this_year, coalesce(calls_recived_last_year, 0) as calls_recived_last_year, "+
                                " coalesce(time_slot_identified, '') as time_slot_identified, coalesce(strategy, '') as strategy, coalesce(outcome, '') as outcome from dbo.pcrCalls where callId = "+callId+")s left join "+
                                " (select headId, headName from dbo.pcrHeadType where ps_code in (0, "+PSCode+"))sm on s.headId = sm.headId)s left join "+
                                " (select headId, weekly_target from dbo.pcrCallTarget where ps_code = "+PSCode+")sm on s.headId = sm.headId";
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(deployement);
            if (dt.Rows.Count > 0)
            {
                hfHeadId.Value = Convert.ToString(dt.Rows[0]["headId"]);
                txtHeadName.Text = Convert.ToString(dt.Rows[0]["headName"]);
                txtHotSpotName.Text = Convert.ToString(dt.Rows[0]["hotspot_name"]);
                txtWeeklyTarget.Text = Convert.ToString(dt.Rows[0]["weekly_target"]);

                txtCallsRecivedInWeek.Text = Convert.ToString(dt.Rows[0]["calls_recived_in_week"]);
                txtCallsRecivedThisYear.Text = Convert.ToString(dt.Rows[0]["calls_recived_this_year"]);
                txtCallsRecivedPreviousYear.Text = Convert.ToString(dt.Rows[0]["calls_recived_last_year"]);

                txtTimeSlotIdentified.Text = Convert.ToString(dt.Rows[0]["time_slot_identified"]);
                txtStrategy.Text = Convert.ToString(dt.Rows[0]["strategy"]);
                txtOutCome.Text = Convert.ToString(dt.Rows[0]["outcome"]);
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On LoadRecord: " + ex.Message + "')", true);
        } 
    }
    
    protected void Submit(object sender, EventArgs e)
    {  }

    
    public void UpdatePCRCalls(int callId)
    {
        try
        {
            DataBase DB = new DataBase();
            string callRecivedInWeek = txtCallsRecivedInWeek.Text;
            string callReciveThisYear = txtCallsRecivedThisYear.Text;
            string callRecivedPreviousYear = txtCallsRecivedPreviousYear.Text;

            string timingSlot = txtTimeSlotIdentified.Text;
            string strategy = txtStrategy.Text;
            string outcome = txtOutCome.Text;


            string updateDeployement = "UPDATE dbo.pcrCalls SET calls_recived_in_week = "+callRecivedInWeek+", calls_recived_this_year = "+callReciveThisYear+", calls_recived_last_year = "+callRecivedPreviousYear+" " +
                                       " , time_slot_identified = '"+timingSlot+"', strategy = '"+strategy+"', outcome = '"+outcome+"' WHERE callId = "+ callId + "";

            string result = DB.UpdateData(updateDeployement);
            
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On UpdateDelivery: " + ex.Message + "')", true);
        }
    }
    
    

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int id = 0;
            int.TryParse(hfCallId.Value, out id);
            if (id > 0)
            {
                UpdatePCRCalls(id);
                Response.Redirect("PCRCalls.aspx");
            }
            else
            {
                Response.Redirect("PCRCalls.aspx");
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On btnSubmit_Click: " + ex.Message + "')", true);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("PCRCalls.aspx");  
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On btnCancel_Click: " + ex.Message + "')", true);
        }
    }

}