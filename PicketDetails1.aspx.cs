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

public partial class PicketDetails1 : System.Web.UI.Page
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
            BindPicketType();
            LoadPicket();
        }
    }

    protected void BindPicketType()
    {
        string s = "select id,picket_type from dbo.picket_order  union " +
                   " select 999 as id,'Add New Type' as picket_type order by id ";
        DataBase db = new DataBase();
        DataTable tb = db.ExcutesQuery(s);
        ddlPicketType.Items.Clear();
        if (tb.Rows.Count > 0)
        {
            ddlPicketType.DataSource = tb;
            ddlPicketType.DataValueField = "id";
            ddlPicketType.DataTextField = "picket_type";
            ddlPicketType.DataBind();
            ddlPicketType.Items.Insert(0, new ListItem("--Select Picket Type", " "));
        }
    }

    public void LoadPicket()
    {
        try
        {
            lblId.InnerText = Request.QueryString["picketCode"];
            
            int id = 0;
            int.TryParse(lblId.InnerText, out id);

            string deployement = "select * from FieldWorkMgt_DB.dbo.pickets where ps_code="+PSCode+" and picket_id=" + id;
            System.Console.WriteLine(deployement);


            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(deployement);
            if (dt.Rows.Count > 0)
            {
                hfPicketId.Value = Convert.ToString(dt.Rows[0]["picket_id"]);
                txtPicketType.Text = Convert.ToString(dt.Rows[0]["picket_type"]);
                txtLocation.Text = Convert.ToString(dt.Rows[0]["location"]);
                txtTiming.Text = Convert.ToString(dt.Rows[0]["timing"]);

                txtVehiscanAppDailyTarget.Text = Convert.ToString(dt.Rows[0]["vehiscanAppDailyTarge"]);
                txtVehiscanApp2Wheelers.Text = Convert.ToString(dt.Rows[0]["vehiscanApp2Wheelers"]);
                txtVehiscanApp4Wheelers.Text = Convert.ToString(dt.Rows[0]["vehiscanApp4Wheelers"]);
                txtVehiscanAppBusTSR.Text = Convert.ToString(dt.Rows[0]["vehiscanAppBusTSR"]);

                txt66DPActDailyTarget.Text = Convert.ToString(dt.Rows[0]["dailyTarget66DPAct"]);
                txt66DPActAction.Text = Convert.ToString(dt.Rows[0]["action66DPAct"]);

                txtStrangerRollIssuedDailyTarget.Text = Convert.ToString(dt.Rows[0]["strangerRollIssuedDailyTarget"]);
                txtStrangerRollIssuedAction.Text = Convert.ToString(dt.Rows[0]["strangerRollIssuedAction"]);

                txt65DPActDailyTarget.Text = Convert.ToString(dt.Rows[0]["dailyTarget65DPAct"]);
                txt65DPActAction.Text = Convert.ToString(dt.Rows[0]["action65DPAct"]);

                txtDetailDetection.Text = Convert.ToString(dt.Rows[0]["detailsOfDetectionIfAny"]);
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On LoadRecord: " + ex.Message + "')", true);
        }
    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void ddldeliverystate_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void Submit(object sender, EventArgs e)
    {  }

    
    public void UpdateDEployment(int deployment_id)
    {
        /*try
        {
            DataBase DB = new DataBase();
            string mud_static_duty = txtModStaticDuty.Text;
            string pattern_timing = txtPatternTiming.Text;
            int us = Int32.Parse(txtUS.Text);
            int hc = Int32.Parse(txtHC.Text);
            int ct = Int32.Parse(txtCT.Text);

            string updateDeployement = "UPDATE FieldWorkMgt_DB.dbo.Manpower_Deployment SET mud_static_duty = '" + mud_static_duty + "' ,us = '" + us + "' " +
                                       " , hc = '" + hc + "', ct = '" + ct + "', pattern_timing = '" + pattern_timing + "', update_date = getdate() " +
                                       "WHERE deployment_id = '"+ deployment_id + "'";

            string result = DB.UpdateData(updateDeployement);
            
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On UpdateDelivery: " + ex.Message + "')", true);
        }*/
    }
    
    public void InsertDeployment()
    {
        /*
        try
        {
            string mud_static_duty = txtModStaticDuty.Text;
            string pattern_timing = txtPatternTiming.Text;
            string us = txtUS.Text;
            string hc = txtHC.Text;
            string ct = txtCT.Text;
            DataBase DB = new DataBase();
            //string insertdeliveryr = "INSERT INTO FieldWorkMgt_DB.dbo.Manpower_Deployment(ps_code, mud_static_duty, us, hc, ct, pattern_timing,insert_date,update_date)"
            //                         + "VALUES('"+PSCode+"','"+mud_static_duty+"','"+us+"','"+hc+"','"+ct+"','"+pattern_timing+ "'GETDATE(),GETDATE()) ";
            string insert1 = "insert into FieldWorkMgt_DB.dbo.Manpower_Deployment (ps_code, mud_static_duty, us, hc, ct,pattern_timing,insert_date,update_date) " +
                             "values('" + PSCode + "', '" + mud_static_duty + "', '" + us + "', '" + hc + "', '" + ct + "', '" + pattern_timing + "', GETDATE(), GETDATE())";

            int deliveryid = DB.ExcuteQuery(insert1);
            if (deliveryid > 0)
            {
                Response.Redirect("Manpower.aspx");
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On InsertDelivery: " + ex.InnerException+ "')", true);
        */
    }
    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        /*try
        {
            int id = 0;
            int.TryParse(hfDeploymentId.Value, out id);
            if (id > 0)
            {
                UpdateDEployment(id);
                Response.Redirect("Manpower.aspx");
            }
            else
            {
                InsertDeployment();
                Response.Redirect("Manpower.aspx");
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On btnSubmit_Click: " + ex.Message + "')", true);
*/    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Pickets.aspx");  
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On btnCancel_Click: " + ex.Message + "')", true);
        }
    }

}