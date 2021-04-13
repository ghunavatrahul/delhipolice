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
using Microsoft.VisualBasic.FileIO;

public partial class ItemsAdd : System.Web.UI.Page
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

        try
        {
            string Query = "select a.Quantity,a.ID,a.Title,a.image,a.price,a.discount,a.Description, d.VendorName,'1'as dependancy from items a left outer join Vendor d on isnull(a.vendorId,0)=d.VendorId where a.id in(select Itemid from Delivery) union select a.Quantity,a.ID,a.Title,a.image,a.price,a.discount,a.Description, d.VendorName,'0'as dependancy from items a left outer join Vendor d on isnull(a.vendorId,0)=d.VendorId where a.id not in(select Itemid from Delivery) and a.status='true' order by a.ID desc";
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(Query);
            if (dt.Rows.Count > 0)
            {
                gvListing.DataSource = dt;
                gvListing.DataBind();
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
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On BindGrid: " + ex.Message + "')", true);
        }

        //gvListing.DataSource = new DataBase().ExcutesQuery("select a.ID,a.Title,a.image,a.price,a.discount,a.Description,b.Fname+' '+b.Lname as Name,c.Fname+' '+c.Lname as custName, d.VendorName from items a join Employee b on a.empId=b.ID join Customer c on a.custId=c.CustomerID join Vendor d on a.vendorId=d.VendorId  where a.status='true'");
        //gvListing.DataSource = new DataBase().ExcutesQuery("select a.ID,a.Title,a.image,a.price,a.discount,a.Description, d.VendorName from items a  join Vendor d on a.vendorId=d.VendorId  where a.status='true'");
        //gvListing.DataBind();
        pnlGrid.Visible = true;
        pnlAdd.Visible = false;
    }

    protected void gvListing_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewBind();
        gvListing.PageIndex = e.NewPageIndex;
        gvListing.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {

            string getsearch = "select * from view_serchderoduct where status='true' and VendorName like'" + txtVendorname.Text.Trim() + "%' and Title like '" + txtTitlenm.Text.Trim() + "%' ";

            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(getsearch);
            if (dt.Rows.Count > 0)
            {
                gvListing.DataSource = dt;
                gvListing.DataBind();
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

                ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('No Records Found')", true);
                txtVendorname.Text = "";
                txtTitlenm.Text = "";              
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On btnSearch_Click: " + ex.Message + "')", true);
        }
        txtTitlenm.Focus();
    }

    protected void gvListing_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edits")
            {
                ShowEdit();
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from items where ID='" + e.CommandArgument + "' ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    lblCatId.Text = e.CommandArgument.ToString();
                    lblbackImge.Text = dr["image"].ToString();
                    txtTitle.Text = dr["Title"].ToString();
                    txtprice.Text = dr["price"].ToString();
                    txtDiscount.Text = dr["discount"].ToString();
                    txtDescription.Text = dr["Description"].ToString();
                    ddlCategory.SelectedItem.Value = Convert.ToString(dr["category"]);
                    txtquantity.Text = Convert.ToString(dr["Quantity"]);
                    //ddlEmployeeId.Text = dr["empId"].ToString();
                    //ddlCustomerName.Text = dr["custId"].ToString();
                    ddlVendorName.Text = dr["vendorId"].ToString();
                    //chkActive.Checked = (Convert.ToInt32(dr["ActiveFL"]) == 1 ? true : false);
                    //lblMsg.Visible = false;
                    dr.Close();
                }
                pnlGrid.Visible = false;
                pnlAdd.Visible = true;
            }
            if (e.CommandName == "Deletes")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from items where ID='" + e.CommandArgument + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    if (File.Exists(Server.MapPath("~/images/item/") + dr["image"].ToString()))
                    {
                        File.Delete(Server.MapPath("~/images/item/") + dr["image"].ToString());
                    }
                }
                dr.Close();
                string Query = "Delete from items where ID='" + e.CommandArgument + "' ";

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
            Response.Write(ex);
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On page')", true);
        }
    }

    private void ShowEdit()
    {
        //BindEmployee();
        BindVendor();
        BindCategory(); 
    }
    protected void BindCategory()
    {
        string s = "select * from Category where status='1'";
        DataBase db = new DataBase();
        DataTable tb = db.ExcutesQuery(s);
        if (tb.Rows.Count > 0)
        {
            ddlCategory.DataSource = tb;
            ddlCategory.DataValueField = "Id";
            ddlCategory.DataTextField = "name";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("Select Category ...", ""));
        }
    }
    protected void BindVendor()
    {
        string s = "select * from vendor where status='true'";
        DataBase db = new DataBase();
        DataTable tb = db.ExcutesQuery(s);
        if (tb.Rows.Count > 0)
        {
            ddlVendorName.DataSource = tb;
            ddlVendorName.DataValueField = "VendorId";
            ddlVendorName.DataTextField = "VendorName";
            ddlVendorName.DataBind();
            ddlVendorName.Items.Insert(0, new ListItem("Select Vendor ...", ""));
        }     
    }

    //protected void BindCustomer()
    //{
    //    string s = "select * from customer";
    //    DataBase db = new DataBase();
    //    DataTable tb = db.ExcutesQuery(s);
    //    if (tb.Rows.Count > 0)
    //    {
    //        ddlCustomerName.DataSource = tb;
    //        ddlCustomerName.DataValueField = "CustomerID";
    //        ddlCustomerName.DataTextField = "Fname";
    //        ddlCustomerName.DataBind();
    //    }
    //}
   


    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string PostImage = "";
            Random rand = new Random();
            int uinq = rand.Next(1000, 9999);
            if (FLupload.HasFile)
            {

                PostImage = DateTime.Now.Date.ToString("ddMM") + uinq + FLupload.FileName;
                FLupload.SaveAs(Server.MapPath("~/images/item/") + PostImage);

                if (lblbackImge.Text != "")
                {
                    if (File.Exists(Server.MapPath("~/images/item/") + lblbackImge.Text))
                    {
                        File.Delete(Server.MapPath("~/images/item/") + lblbackImge.Text);
                    }
                }
            }
            else
            {
                PostImage = lblbackImge.Text;

                //ClientScript.RegisterClientScriptBlock(this.GetType(), "pop", "alert('Please select small and Big Images');", true);
                //return;

            }
            if (lblCatId.Text == "")
            {
                //string Query = "Insert Into Items (Title,Description,vendorId,empId,custId,category,Quantity,price,discount,image,Status) values ('" + txtTitle.Text.Replace("'", "''") + "','" + txtDescription.Text.Replace("'", "''") + "','" + ddlVendorName.SelectedValue + "','" + ddlEmployeeId.SelectedValue + "','" + ddlCustomerName.SelectedValue + "','" + ddlCategory.SelectedValue + "','" + txtquantity.Text.Replace("'", "''") + "','" + txtprice.Text + "','" + txtDiscount.Text + "','" + PostImage + "','true')";
                string Query = "Insert Into Items (Title,Description,vendorId,category,price,Quantity,image,Created_Date,Status) values"+
                    "('" + txtTitle.Text.Replace("'", "''") + "','" + txtDescription.Text.Replace("'", "''") + "','" + ddlVendorName.SelectedValue + "',"+
                "'" + ddlCategory.SelectedValue + "','" + txtprice.Text + "','" + txtquantity.Text.Replace("'", "''") + "','" + PostImage + "',GetDate(),'true')";
                int i=new DataBase().ExcuteQuery(Query);
                
            }
            else if (lblCatId.Text != "")
            {
                string Query = " Update items set " +
                                       " Image = '" + PostImage + "'," +
                                        " Title = '" + txtTitle.Text.Replace("'", "''") + "'," +
                                        " price = '" + txtprice.Text.Replace("'", "''") + "'," +
                                        //" discount = '" + txtDiscount.Text.Replace("'", "''") + "'," +
                                        " description = '" + txtDescription.Text.Replace("'", "''") + "'," +
                                        //" custId = '" + ddlCustomerName.SelectedValue.Replace("'", "''") + "'," +
                                        //" empId = '" + ddlEmployeeId.SelectedValue.Replace("'", "''") + "'," +
                                           " Quantity = '" + txtquantity.Text.Replace("'", "''") + "'," +
                                          " vendorId = '" + ddlVendorName.SelectedValue.Replace("'", "''") + "'," +
                                          " category = '" +ddlCategory.SelectedValue.Replace("'", "''") + "'" +
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
            txtDescription.Text = "";
            txtDiscount.Text = "";
            txtprice.Text = "";
            txtquantity.Text = "";
            txtTitle.Text = "";
            ddlCategory.SelectedIndex = -1;
            ddlVendorName.SelectedIndex = -1;
            lblCatId.Text = "";
            lblbackImge.Text = "";
        }
        //string cs = ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString;
        //SqlConnection con = new SqlConnection(cs);
        //string ca="insert into Items(Title,Descriptio,vendorName,empId,customerName,category,price,discount,imageData) values('"+txtProducttitle.Text+"','"++"')"
        //SqlCommand cmd=new SqlCommand()
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlGrid.Visible = true;
        pnlAdd.Visible = false;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ShowEdit();
        pnlGrid.Visible = false;
        pnlAdd.Visible = true;
    }

    protected void btnImportCSV_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.HasFile)
            {
                string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);  //Get extension

                if (fileExt == ".csv")   //check to see if its a .csv file
                {
                    Random rand = new Random();
                    int uinq = rand.Next(1000, 9999);
                    string csv = DateTime.Now.Date.ToString("ddMM") + uinq + FileUpload1.FileName;
                    string filePath = Server.MapPath("~/FilesUpload/Project_CSV/") + csv;
                    FileUpload1.SaveAs(filePath);

                    DataTable dt = GetDataTabletFromCSVFile(filePath);
                    if (dt != null && dt.Rows.Count > 1)
                    {
                        using (SqlBulkCopy sbc = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString, SqlBulkCopyOptions.KeepIdentity))
                        {
                            sbc.DestinationTableName = "Items";
                            sbc.BatchSize = 5;
                            sbc.ColumnMappings.Add("Title", "Title");
                            sbc.ColumnMappings.Add("Description", "Description");
                            sbc.ColumnMappings.Add("Status", "Status");
                            sbc.ColumnMappings.Add("Price", "price");
                            sbc.ColumnMappings.Add("Quantity", "Quantity");
                            
                            //sbc.ColumnMappings.Add("'"+GetDate()+"'", "Created_Date");
                            sbc.WriteToServer(dt);
                        }
                    }
                    if (csv != "")
                    {
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                    }
                    GridViewBind();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
    }
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvListing.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
        GridViewBind();
    }
    public static DataTable GetDataTabletFromCSVFile(string csv_file_path)
    {
        DataTable csvData = new DataTable();
        try
        {
            using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
            {
                csvReader.SetDelimiters(new string[] { "," });
                csvReader.HasFieldsEnclosedInQuotes = true;

                string[] colFields = csvReader.ReadFields();
                foreach (string column in colFields)
                {
                    DataColumn datecolumn = new DataColumn(column);
                    datecolumn.AllowDBNull = true;
                    csvData.Columns.Add(datecolumn);
                }

                while (!csvReader.EndOfData)
                {
                    string[] fieldData = csvReader.ReadFields();
                    for (int i = 0; i < fieldData.Length; i++)
                    {
                        if (fieldData[i] == "")
                        {
                            fieldData[i] = null;
                        }
                    }
                    csvData.Rows.Add(fieldData);
                }
            }
        }
        catch (Exception ex)
        {

        }
        return csvData;
    }

}