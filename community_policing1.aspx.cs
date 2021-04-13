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

public partial class bcs1 : System.Web.UI.Page
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
            LoadBcs();
        }
    }
    public void LoadBcs()
    {
        try
        {
            hfHotSpotCode.Value = Request.QueryString["BeatId"];
            int id = 0;
            int.TryParse(hfHotSpotCode.Value, out id);

            string deployement = "select * from FieldWorkMgt_DB.dbo.bcs where ps_code="+PSCode+ " and beat_id=" + id;
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(deployement);
            if (dt.Rows.Count > 0)
            {
                txtBeat.Text = Convert.ToString(dt.Rows[0]["beat"]);
                txtTotalBcs.Text = Convert.ToString(dt.Rows[0]["totalbcs"]);
                txtBeatNo.Text = Convert.ToString(dt.Rows[0]["beat_number"]);
            
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On LoadRecord: " + ex.Message + "')", true);
        }
    }
    

    
    public void UpdateHotspots(int hotspot_id)
    {
        try
        {
            DataBase DB = new DataBase();
            string locationArea = txtLocationArea.Text;
            string divisionBeatOfficer = txtDivisionBeatOfficer.Text;
            int beatNumber = Int32.Parse(txtBeatNo.Text);
            string updateDeployement = "UPDATE FieldWorkMgt_DB.dbo.bcs SET location_area = '" + locationArea+"',beat_number = "+beatNumber+",division_beat_officer = '"+divisionBeatOfficer+"' " +
                                       " WHERE beat_id = " + hotspot_id + " and ps_code = "+PSCode+"";
            string result = DB.UpdateData(updateDeployement);
            
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On UpdateDelivery: " + ex.Message + "')", true);
        }
    }
    
    public void InsertDeployment()
    {
        //string insertdeliveryr = "";
        try
        {
            string location_area = txtLocationArea.Text;
             string division_beat_officer = txtDivisionBeatOfficer.Text;
             string beat_number = txtBeatNo.Text;
             DataBase DB = new DataBase();
             string insertdeliveryr = "INSERT INTO FieldWorkMgt_DB.dbo.bcs (ps_code,location_area,beat_number,division_beat_officer) "+
                                      "  VALUES ("+PSCode+", '"+location_area+"',"+beat_number+",'"+division_beat_officer+"')";

             int deliveryid = DB.ExcuteQuery(insertdeliveryr);
             if (deliveryid > 0)
             {
                 Response.Redirect("bcs.aspx");
             }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On InsertDelivery: " + ex.InnerException+ "')", true);
        }
    }
    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int id = 0;
            int.TryParse(hfHotSpotCode.Value, out id);
            if (id > 0)
            {
                UpdateHotspots(id);
                Response.Redirect("bcs.aspx");
            }
            else
            {
                InsertDeployment();
                Response.Redirect("bcs.aspx");
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
           Response.Redirect("bcs.aspx");  
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On btnCancel_Click: " + ex.Message + "')", true);
        }
    }

}