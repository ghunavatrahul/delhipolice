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

public partial class State : System.Web.UI.Page
{
   
         SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString);

         DataBase obj = new DataBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGrid();
            Bindcounty();
           // GridViewBind();
        }
    }
    private void GridViewBind()
    {
        gvListing.DataSource = new DataBase().ExcutesQuery("select s.Name,s.stateid,s.status,c.Name as countryname,s.dependancy from view_statedependancy s join Country c on s.CountryID=c.CountryID order by s.StateId desc");
        gvListing.DataBind();
        pnlGrid.Visible = true;
        pnlAdd.Visible = false;
    }
    protected void FillGrid()
    {
        try
        {
            string Query = "select s.Name,s.stateid,s.status,c.Name as countryname,s.dependancy from view_statedependancy s join Country c on s.CountryID=c.CountryID order by s.StateId desc";
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(Query);
            if (dt.Rows.Count > 0)
            {
                gvListing.DataSource = dt;
                gvListing.DataBind();
                gvListing.SelectedIndex = -1;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvListing.DataSource = dt;
                gvListing.DataBind();
                int columncount = gvListing.Rows[0].Cells.Count;
                gvListing.Rows[0].Cells.Clear();
                gvListing.Rows[0].Cells.Add(new TableCell());
                gvListing.Rows[0].Cells[0].ColumnSpan = columncount;
                gvListing.Rows[0].Cells[0].Text = "No Records Found";
            }
            pnlGrid.Visible = true;
            pnlAdd.Visible = false;
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error on FillGrid: " + ex.Message + "')", true);
        }
    }
    protected void gvListing_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        FillGrid();
        //GridViewBind();
        gvListing.PageIndex = e.NewPageIndex;
        gvListing.DataBind();
    }
    protected void gvListing_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edits")
        {           
            Id = e.CommandArgument.ToString();
           // ShowEdit();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from State where StateId='" + e.CommandArgument + "' ", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                lblCatId.Text = e.CommandArgument.ToString();
                ddlcountry.SelectedValue = (dr["CountryID"]).ToString();
                txtStatename.Text = (dr["Name"]).ToString();                           
                chkActive.Checked = (Convert.ToInt32(dr["status"]) == 1 ? true : false);
                dr.Close();
            }           
            pnlGrid.Visible = false;
            pnlAdd.Visible = true;
        }
        if (e.CommandName == "Deletes")
        {
            con.Open();
            string Query = "Delete from State where StateId='" + e.CommandArgument + "' ";
            SqlCommand cmdDelete = new SqlCommand(Query, con);
            cmdDelete.ExecuteReader();
            con.Close();           
            FillGrid();
        }
    }
   
    string Id = "0";
  

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {           
            if (lblCatId.Text == "")
            {

                string Query = "Insert Into State (CountryID,Name,status) values ('" + 1 + "','" + txtStatename.Text.Replace("'", "''") + "','" + (chkActive.Checked == true ? 1 : 0) + "')";
                int i = new DataBase().ExcuteQuery(Query);

            }
            else if (lblCatId.Text != "")
            {
                string Query = " Update State set " +

                                        " CountryID = '" + ddlcountry.SelectedValue.Replace("'", "''") + "'," +
                                        " Name = '" + txtStatename.Text.Replace("'", "''") + "'," +
                                         " Status = '" + (chkActive.Checked == true ? 1 : 0) + "'" +
                                   " where StateId='" + lblCatId.Text + "'";
                int i = new DataBase().ExcuteQuery(Query);
            }
           
            FillGrid();
        }
        catch (Exception ex)
        {
            Response.Write(ex);
           
        }
        finally
        {
          
            lblCatId.Text = "";
            txtStatename.Text = "";
           
        }
        
    }
    protected void btnCancel_Click1(object sender, EventArgs e)
    {
        lblCatId.Text = "";
        pnlGrid.Visible = true;
        pnlAdd.Visible = false;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {     
       
        lblCatId.Text = "";
        pnlGrid.Visible = false;
        pnlAdd.Visible = true;        
    }
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvListing.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
        FillGrid();
    }
    //protected void gvListing_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        LinkButton btn_check = (e.Row.FindControl("btnDelete") as LinkButton);

    //        Label lbl_id = (e.Row.FindControl("lbl") as Label);
    //        int a = Convert.ToInt32(lbl_id.Text);

    //        DataTable chk = obj.dependacy(a);
    //        if (chk.Rows.Count > 0)
    //        {
    //            btn_check.Enabled = false;
    //            btn_check.ToolTip = "This is used any where";
    //        }
    //        else
    //        {
    //            btn_check.Enabled = true;
    //            btn_check.ToolTip = "Delete";
    //        }

    //    }
    //}
    //protected void gvListing_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    gvListing.EditIndex = -1;
    //}
    protected void Bindcounty()
    {
        string s = "select * from Country where status='true'";
        DataBase db = new DataBase();
        DataTable tb = db.ExcutesQuery(s);
        ddlcountry.Items.Clear();
        if (tb.Rows.Count > 0)
        {

            ddlcountry.DataSource = tb;
            ddlcountry.DataValueField = "CountryId";
            ddlcountry.DataTextField = "Name";
            ddlcountry.DataBind();
            ddlcountry.Items.Insert(0, new ListItem("--Select Country--", " "));
        }
    }

   
}
