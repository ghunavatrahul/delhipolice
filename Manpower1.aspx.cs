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

public partial class Manpower1 : System.Web.UI.Page
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
            LoadDeployement();
        }
    }
    public void LoadDeployement()
    {
        try
        {
            lblId.InnerText = Request.QueryString["DeploymentId"];
            
            int id = 0;
            int.TryParse(lblId.InnerText, out id);

            string deployement = "select deployment_id,mud_static_duty ,COALESCE(us,0,0,'') as us,COALESCE(hc,0,0,'') as HC,COALESCE(ct,0,0,'') as CT, pattern_timing " +
                        " from FieldWorkMgt_DB.dbo.Manpower_Deployment where ps_code = "+PSCode+" and deployment_id = " + id;
            System.Console.WriteLine(deployement);


            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(deployement);
            if (dt.Rows.Count > 0)
            {
                hfDeploymentId.Value = Convert.ToString(dt.Rows[0]["deployment_id"]);
                txtModStaticDuty.Text = Convert.ToString(dt.Rows[0]["mud_static_duty"]);
                txtPatternTiming.Text = Convert.ToString(dt.Rows[0]["pattern_timing"]);
                txtUS.Text = Convert.ToString(dt.Rows[0]["us"]);
                txtHC.Text = Convert.ToString(dt.Rows[0]["HC"]);
                txtCT.Text = Convert.ToString(dt.Rows[0]["CT"]);
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
        try
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
        }
    }
    
    public void InsertDeployment()
    {
        //string insertdeliveryr = "";
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
        }
    }
    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
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
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Manpower.aspx");  
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On btnCancel_Click: " + ex.Message + "')", true);
        }
    }

}