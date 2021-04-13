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

public partial class PCRCallsAccedentPronArea : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString);
    int PSCode;
    string user;
    protected void Page_Load(object sender, EventArgs e)
    {
        PSCode = Int32.Parse(Session["PSCode"].ToString());
        user = Session["user"].ToString();
        if (!Page.IsPostBack)
        {
            GridViewBind();

        }
    }
    private void GridViewBind()
    {
        string query = " SELECT callId, hotspot_name, intimation_to_traffic, cctv_installed, repair_potholes, reason_accedent, "+
                       " target_beat_officer, target_ato,  convert(varchar(10),created_on) as created_on, convert(varchar(10),updated_on) as updated_on, case when status = 1 then 'Active' else 'Inactive' end as status FROM dbo.pcrCallAccedentPronArea where ps_code = " + PSCode+"";
        gvListing.DataSource = new DataBase().ExcutesQuery(query);
        gvListing.DataBind();
        gvListing.PageSize = 10;
        pnlGrid.Visible = true;
        pnlAdd.Visible = false;
    }

    

    
    string Id = "0";
    

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
         {
            string hotspotName = txtHotSpotName.Text;
            string intemationToTraffic = ddlIntimationToTraffic.SelectedItem.Value;
            string cctvInstalled = txtCctvInstalled.Text;
            string potHoles = txtPitHoles.Text;
            string reasonAccedent = txtReasonAccedent.Text;
            string targetBeatStaff = txtTargetBeatStaff.Text;
            string targetATO = txtTargetATO.Text;
             
             string Query = "INSERT INTO dbo.pcrCallAccedentPronArea "+
                           " (ps_code, hotspot_name, intimation_to_traffic, cctv_installed, repair_potholes, reason_accedent, target_beat_officer, target_ato "+
                           ", createdby, created_on, updated_by, updated_on, status) values "+
                           " ("+PSCode+", '"+hotspotName+"', '"+ intemationToTraffic + "', '"+cctvInstalled+"', '"+potHoles+"', '"+reasonAccedent+"', '"+targetBeatStaff+"', '"+targetATO+"', "+
                           " '"+user+"', GETDATE(), null, null, 1)";
             int i = new DataBase().ExcuteQuery(Query);
            
           
             GridViewBind(); 
         }
         catch (Exception ex)
         {
             Response.Write(ex);
         }
         finally
         {
             ddlIntimationToTraffic.SelectedIndex = 0;
             txtHotSpotName.Text = "";
             txtCctvInstalled.Text = "";
             txtPitHoles.Text = "";
             txtReasonAccedent.Text = "";
             txtTargetBeatStaff.Text = "";
             txtTargetATO.Text = "";
             GridViewBind();

         }


    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ddlIntimationToTraffic.SelectedIndex = 0;
        txtHotSpotName.Text = "";
        txtCctvInstalled.Text = "";
        txtPitHoles.Text = "";
        txtReasonAccedent.Text = "";
        txtTargetBeatStaff.Text = "";
        txtTargetATO.Text = "";
        GridViewBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
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

    
}