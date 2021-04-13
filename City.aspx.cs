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


public partial class City : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString);
    DataBase obj = new DataBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGrid();
            //GridViewBind();
        }
    }

    protected void FillGrid()
    {
        try
        {
            string Query = "select s.Name as statename,CityId,s.StateId,c.Name,c.status from City c join State s on s.StateId=c.StateId order by CityId desc";
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

    private void GridViewBind()
    {       
        gvListing.DataSource = new DataBase().ExcutesQuery("select s.Name as statename,CityId,s.StateId,c.Name,c.status from City c join State s on s.StateId=c.StateId order by CityId desc");
        gvListing.DataBind();
        pnlGrid.Visible = true;
        pnlAdd.Visible = false;
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
            ShowEdit();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from City where CityId='" + e.CommandArgument + "' ", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                lblCatId.Text = e.CommandArgument.ToString();
                txtcityname.Text = dr["Name"].ToString();
                ddlstate.SelectedValue = dr["StateId"].ToString();
                //txtStatus.Text = dr["status"].ToString();               
                chkActive.Checked = (Convert.ToInt32(dr["status"]) == 1 ? true : false);
                //lblMsg.Visible = false;
                dr.Close();
            }
            pnlGrid.Visible = false;
            pnlAdd.Visible = true;
        }

        if (e.CommandName == "Deletes")
        {
            con.Open();
            string Query = "Delete from City where CityId='" + e.CommandArgument + "' ";

            SqlCommand cmdDelete = new SqlCommand(Query, con);
            cmdDelete.ExecuteReader();
            con.Close();
            FillGrid();
        }
    }
    private void ShowEdit()
    {

        BindCategory();
    }
    string Id = "0";
    protected void BindCategory()
    {
        string s = "select * from State where status=1";
        DataBase db = new DataBase();
        DataTable tb = db.ExcutesQuery(s);
        ddlstate.Items.Clear();
        if (tb.Rows.Count > 0)
        {
            
            ddlstate.DataSource = tb;
            ddlstate.DataValueField = "StateId";
            ddlstate.DataTextField = "Name";
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("--Select State--", " "));
        }
    }


   

   

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (lblCatId.Text == "")
            {

                string Query = "Insert Into City (StateId,Name,status) values ('" + ddlstate.SelectedValue + "','" + txtcityname.Text.Replace("'", "''") + "','" + (chkActive.Checked == true ? 1 : 0) + "')";
                int i = new DataBase().ExcuteQuery(Query);
            }
            else if (lblCatId.Text != "")
            {
                string Query = " Update City set " +
                                        " StateId = '" + ddlstate.SelectedValue.Replace("'", "''") + "'," +
                                        " Name = '" + txtcityname.Text.Replace("'", "''") + "'," +
                                         " Status = '" + (chkActive.Checked == true ? 1 : 0) + "'" +
                                   " where CityId='" + lblCatId.Text + "'";
                int i = new DataBase().ExcuteQuery(Query);
            }         
            FillGrid();
        }
        catch (Exception ex)
        {
            Response.Write(ex);
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On page')", true);
        }
        finally
        {
            txtcityname.Text = "";
            lblCatId.Text = "";

        }     
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtcityname.Text = "";
        lblCatId.Text = "";
        pnlGrid.Visible = true;
        pnlAdd.Visible = false;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ShowEdit();
        txtcityname.Text = "";
        lblCatId.Text = "";
        pnlGrid.Visible = false;
        pnlAdd.Visible = true;
    }
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
       gvListing.PageSize= Convert.ToInt32(ddlPageSize.SelectedValue);
       FillGrid();
    }
   
    //protected void gvListing_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        Button btn_check = (e.Row.FindControl("btnDelete") as Button);
    //        Label lbl_id = (e.Row.FindControl("lbl") as Label);
    //        int a = Convert.ToInt32(lbl_id.Text);

    //        DataTable chk = obj.dependacy(a);
    //        if (chk.Rows.Count > 0)
    //        {
    //            btn_check.Visible=false;
    //        }
    //        else
    //        {
    //            btn_check.Visible=true;
    //        }

    //    }

    //}
    //protected void gvListing_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    gvListing.EditIndex = -1;
    //}
   
}