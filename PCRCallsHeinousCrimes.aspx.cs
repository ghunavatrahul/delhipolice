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

public partial class PCRCallsHeinousCrimes : System.Web.UI.Page
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
        string query = "select callId,s.headId,sm.headName,Beat_no,ddNoTime,place_Occurance,nameMobileIo,action_taken,remarks,status from " +
                       " (select callId, headId, Beat_no, dd_no + ' ' + convert(varchar(10), dd_time) as ddNoTime, place_Occurance, name_io + ', cell No-' + cellNumber_io as nameMobileIo, "+
                       " action_taken, remarks,status From dbo.pcrCalls_HeinousCrimes where ps_code = " + PSCode+")s left join "+
                       " (select headId, headName from dbo.pcrHeadType where ps_code in (0, "+PSCode+"))sm on s.headId = sm.headId";
        gvListing.DataSource = new DataBase().ExcutesQuery(query);
        gvListing.DataBind();
        gvListing.PageSize = 10;
        pnlGrid.Visible = true;
        pnlAdd.Visible = false;
    }

    

    
    string Id = "0";
    

    protected void btnSave_Click(object sender, EventArgs e)
    {
       /* 
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

       */
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        hdfCallId.Value = "";
        ddlHeadName.SelectedIndex = 0;
        txtBeatNo.Text = "";
        txtDDNumber.Text = "";
        txtDDTime.Text = "";
        txtPlaceOccurance.Text = "";
        txtNameIO.Text = "";
        txtCellNoIO.Text = "";
        txtCallBrifFacts.Text = "";
        txtActionTaken.Text = "";
        txtRemarks.Text = "";
        ddlStatus.SelectedIndex = 0;
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

    protected void BindHead()
    {
        string s = " select headId,headName from dbo.pcrHeadType where ps_code in (0," + PSCode + ") and headId!='1'";
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
    protected void gvListing_RowCommand(object sender, GridViewCommandEventArgs e)
    {
         try
         {
             if (e.CommandName == "Edits")
             {
                 ShowEdit();
                 Id = e.CommandArgument.ToString();
                 con.Open();
                string query = "select callId,s.headId,sm.headName,Beat_no,dd_no,dd_time,place_Occurance,call_brif_fact,name_io,cellNumber_io,action_taken,remarks,status from "+
                               " (select callId, headId, Beat_no, dd_no, dd_time, place_Occurance, call_brif_fact, name_io, cellNumber_io, "+
                               " action_taken, remarks, status From dbo.pcrCalls_HeinousCrimes where ps_code = "+PSCode+ " and callId = " + e.CommandArgument + ")s left join " +
                               " (select headId, headName from dbo.pcrHeadType where ps_code in (0, "+PSCode+"))sm on s.headId = sm.headId"; 

                 SqlCommand cmd = new SqlCommand(query, con);
                 SqlDataReader dr = cmd.ExecuteReader();
                 if (dr.HasRows)
                 {
                     dr.Read();
                    hdfCallId.Value = Convert.ToString(dr["callId"]);
                    ddlHeadName.SelectedValue = Convert.ToString(dr["headId"]);
                    txtBeatNo.Text = dr["Beat_no"].ToString();
                    txtDDNumber.Text = dr["dd_no"].ToString();
                    txtDDTime.Text = dr["dd_time"].ToString();
                    txtPlaceOccurance.Text = dr["place_Occurance"].ToString();
                    txtNameIO.Text = dr["name_io"].ToString();
                    txtCellNoIO.Text = dr["cellNumber_io"].ToString();
                    txtCallBrifFacts.Text = dr["call_brif_fact"].ToString();
                    txtActionTaken.Text = dr["action_taken"].ToString();
                    txtRemarks.Text = dr["remarks"].ToString();
                    ddlStatus.SelectedValue = Convert.ToString(dr["status"]);
                    dr.Close();
                 }

                 pnlGrid.Visible = false;
                 pnlAdd.Visible = true;
             }

         }
         catch (Exception ex)
         {
             ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On page')", true);
         } 

    }
    private void ShowEdit()
    {
        BindHead();
    }
}