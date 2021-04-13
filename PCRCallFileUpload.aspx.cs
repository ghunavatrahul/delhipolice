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

public partial class PCRCallFileUpload : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString);
    int PSCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        PSCode = Int32.Parse(Session["PSCode"].ToString());
        if (!Page.IsPostBack)
        {
            //GridViewBind();

        }
    }
    
    
    private void ShowEdit()
    {
    }
    string Id = "0";
    

    protected void btnSave_Click(object sender, EventArgs e)
    {  
       /* try
        {
            if (lblHeadId.Text == "")
            {
                string headName = txtHeadName.Text;
                string Query = "insert into dbo.pcrHeadType (headName,ps_code) values('"+headName+"',"+PSCode+")";
                int i = new DataBase().ExcuteQuery(Query);

            }
            else if (lblHeadId.Text != "")
            {
                string Query = "";
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
            txtHeadName.Text = "";
            lblHeadId.Text = "";

        }
        */
       
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
       /* txtHeadName.Text = "";
        lblHeadId.Text = "";
        pnlGrid.Visible = true;
        pnlAdd.Visible = false; */ 
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        /*txtHeadName.Text = "";
        lblHeadId.Text = "";
        pnlGrid.Visible = false;
        pnlAdd.Visible = true;
        pnlAdd.Enabled = true; */ 
        

    }

   

    protected void lnkpickdate_Click(object sender, EventArgs e)
    {
        datepicker.Visible = true;
    }
    protected void datepicker_SelectionChanged(object sender, EventArgs e)
    {
        //txtdtp.Text = datepicker.SelectedDate.ToLongDateString();
        txtdtp.Text = datepicker.SelectedDate.ToShortDateString();
        datepicker.Visible = false;
    }
}