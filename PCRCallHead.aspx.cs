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

public partial class PCRCallHead : System.Web.UI.Page
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
        string query = " select s.headId,s.headName,coalesce(sm.record_count,0) as record_count from "+
                       " (select sm.headId, sm.headName from "+
                       " (select headId from dbo.pcrCallTarget where ps_code = "+PSCode+")s right join "+
                       " (select headId, headName from dbo.pcrHeadType where ps_code in (0,"+PSCode+"))sm on s.headId = sm.headId)s left join "+
                       " (select headId, count(*) as record_count from dbo.pcrCalls where ps_code = "+PSCode+" group by headId)sm on s.headId = sm.headId "+
                       " order by s.headId";
        gvListing.DataSource = new DataBase().ExcutesQuery(query);
        gvListing.DataBind();
        pnlGrid.Visible = true;
        pnlAdd.Visible = false;
    }
    
    private void ShowEdit()
    {
    }
    string Id = "0";
    

    protected void btnSave_Click(object sender, EventArgs e)
    {  
        try
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

       
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtHeadName.Text = "";
        lblHeadId.Text = "";
        pnlGrid.Visible = true;
        pnlAdd.Visible = false;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        txtHeadName.Text = "";
        lblHeadId.Text = "";
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
}