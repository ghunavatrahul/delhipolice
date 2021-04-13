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

public partial class Category : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GridViewBind();

        }
    }
    private void GridViewBind()
    {
        gvListing.DataSource = new DataBase().ExcutesQuery("select *,'1'as parent from Category where parentCategory<>0 union select *,'0'as parent from Category where parentCategory=0 order by ID desc");
        gvListing.DataBind();
        pnlGrid.Visible = true;
        pnlAdd.Visible = false;
    }
    protected void gvListing_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {


            if (e.CommandName == "Edits")
            {

                Id = e.CommandArgument.ToString();
                ShowEdit();
                con.Open();

                SqlCommand cmd = new SqlCommand("select * from category where ID='" + e.CommandArgument + "' ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    lblCatId.Text = e.CommandArgument.ToString();
                    txtCategoryname.Text = dr["name"].ToString();
                    if (Convert.ToString(dr["parentCategory"]) != "0")
                    {
                        ddlParentcategory.SelectedValue = Convert.ToString(dr["parentCategory"]);
                    }

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
                //Label parentcatid = e.Row.FindControl("lblparentCategory") as Label;
                //string parentcatid = 
                con.Open();
                string Query = "Delete from category where ID='" + e.CommandArgument + "' ";

                SqlCommand cmdDelete = new SqlCommand(Query, con);
                cmdDelete.ExecuteReader();
                con.Close();
                //lblMsg.Text = "Record Successfully Deleted !";
                //lblMsg.Visible = true;
                GridViewBind();
            }
        }
        catch (Exception ex)
        {
            //Response.Write(ex);
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On page')", true);
        }

    }
    private void ShowEdit()
    {

        BindCategory();
    }
    string Id = "0";
    protected void BindCategory()
    {
        string s = "select * from category where parentCategory=0 and status=1 and Id!=" + Id;
        DataBase db = new DataBase();
        DataTable tb = db.ExcutesQuery(s);
        ddlParentcategory.Items.Clear();
        if (tb.Rows.Count > 0)
        {
            ddlParentcategory.DataSource = tb;
            ddlParentcategory.DataValueField = "Id";
            ddlParentcategory.DataTextField = "name";
            ddlParentcategory.DataBind();
            ddlParentcategory.Items.Insert(0, new ListItem("--Select Category", " "));
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (lblCatId.Text == "")
            {

                string Query = "Insert Into Category (name,parentCategory,status) values ('" + txtCategoryname.Text.Replace("'", "''") + "','" + ddlParentcategory.SelectedValue + "','" + (chkActive.Checked == true ? 1 : 0) + "')";
                int i = new DataBase().ExcuteQuery(Query);

            }
            else if (lblCatId.Text != "")
            {
                string Query = " Update Category set " +

                                        " name = '" + txtCategoryname.Text.Replace("'", "''") + "'," +
                                        " Parentcategory = '" + ddlParentcategory.SelectedValue.Replace("'", "''") + "'," +
                                         " Status = '" + (chkActive.Checked == true ? 1 : 0) + "'" +
                                   " where ID='" + lblCatId.Text + "'";
                int i = new DataBase().ExcuteQuery(Query);
            }
            GridViewBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex);
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On page')", true);
        }
        finally
        {
            txtCategoryname.Text = "";
            lblCatId.Text = "";

        }
        //string cs = ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString;
        //SqlConnection con = new SqlConnection(cs);
        //string ca="insert into Items(Title,Descriptio,vendorName,empId,customerName,category,price,discount,imageData) values('"+txtProducttitle.Text+"','"++"')"
        //SqlCommand cmd=new SqlCommand()
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtCategoryname.Text = "";
        lblCatId.Text = "";
        pnlGrid.Visible = true;
        pnlAdd.Visible = false;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ShowEdit();
        txtCategoryname.Text = "";
        lblCatId.Text = "";
        pnlGrid.Visible = false;
        pnlAdd.Visible = true;

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

    protected void txtCategoryname_TextChanged(object sender, EventArgs e)
    {

    }
}