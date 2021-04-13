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

public partial class PCRCallsTarget1 : System.Web.UI.Page
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
            LoadWeeklyTarget();
        }
    }
    public void LoadWeeklyTarget()
    {
        try
        {
            hfId.Value = Request.QueryString["id"];
            hfHeadId.Value = Request.QueryString["headId"];
            int id = 0;
            int.TryParse(hfId.Value, out id);
            int headId = 0;
            int.TryParse(hfHeadId.Value, out headId);
            string deployement = "";
            if (id != 0)
                deployement = "select coalesce(s.id,0) as id,sm.headId, sm.headName,coalesce(s.weekly_target,'') as weekly_target from " +
                              " (select headId, weekly_target, id from dbo.pcrCallTarget where ps_code = " + PSCode + ")s right join " +
                              " (select headId, headName from dbo.pcrHeadType where ps_code in (0, " + PSCode + ") and headId = " + headId + ")sm on s.headId = sm.headId " +
                              " where id = " + id + " ";
            else
                deployement = "select headName,'' as weekly_target  from dbo.pcrHeadType where ps_code=" + PSCode+" and headId="+headId+""; 
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(deployement);
            if (dt.Rows.Count > 0)
            {
                txtHeadName.Text = Convert.ToString(dt.Rows[0]["headName"]);
                txtWeeklyTarget.Text = Convert.ToString(dt.Rows[0]["weekly_target"]);
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On LoadRecord: " + ex.Message + "')", true);
        }
    }
    

    
    public void UpdateTarget(int id)
    {
       try
        {
            DataBase DB = new DataBase();
            string weeklyTarget = txtWeeklyTarget.Text;
            string updateDeployement = "update FieldWorkMgt_DB.dbo.pcrCallTarget set weekly_target='"+weeklyTarget+"' where id="+id+" and ps_code="+PSCode+"";
            string result = DB.UpdateData(updateDeployement);
            
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On UpdateDelivery: " + ex.Message + "')", true);
        } 
    }
    
    public void InsertTarget()
    {
        try
        {
            string headId = hfHeadId.Value;
            string weeklyTarget = txtWeeklyTarget.Text;
            DataBase DB = new DataBase();
            string insertdeliveryr = "INSERT INTO FieldWorkMgt_DB.dbo.pcrCallTarget (ps_code, headId, weekly_target) VALUES ("+PSCode+","+headId+",'"+ weeklyTarget + "')";

             int deliveryid = DB.ExcuteQuery(insertdeliveryr);
             if (deliveryid > 0)
             {
                 Response.Redirect("Hotspots.aspx");
             }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On InsertDelivery: " + ex.InnerException+ "')", true);
        } 
    }
    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {   try
        {
            int id = 0;
            int.TryParse(hfId.Value, out id);
            if (id > 0)
            {
                UpdateTarget(id);
                Response.Redirect("PCRCallsTarget.aspx");
            }
            else
            {
                InsertTarget();
                Response.Redirect("PCRCallsTarget.aspx");
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
           Response.Redirect("PCRCallsTarget.aspx");  
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On btnCancel_Click: " + ex.Message + "')", true);
        }
    }

}