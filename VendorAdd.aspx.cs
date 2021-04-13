using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VendorAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Bindstate();
            LoadRecord();
        }
    }
    protected void Bindstate()
    {
        string s = "select * from State where status='1'";
        DataBase db = new DataBase();
        DataTable tb = db.ExcutesQuery(s);
        if (tb.Rows.Count > 0)
        {
            ddlstate.DataSource = tb;
            ddlstate.DataValueField = "StateId";
            ddlstate.DataTextField = "Name";
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("Select State ...", ""));
        }
    }

    protected void BindCity()
    {
        string s = "select * from City where StateId='" + ddlstate.SelectedValue + "' and status='1'";
        DataBase db = new DataBase();
        DataTable tb = db.ExcutesQuery(s);
        ddlcity.DataSource = tb;
        ddlcity.DataValueField = "CityId";
        ddlcity.DataTextField = "Name";
        ddlcity.DataBind();
        ddlcity.Items.Insert(0, new ListItem("Select City ...", ""));

    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCity();
    }
    public void LoadRecord()
    {
        try
        {
            lblId.InnerText = Request.QueryString["VendorId"];
            int id = 0;
            int.TryParse(lblId.InnerText, out id);

            string getVendor = "Select * from Vendor Where VendorId='" + id + "'";
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(getVendor);
            if (dt.Rows.Count > 0)
            {
                txtVendorname.Text = Convert.ToString(dt.Rows[0]["VendorName"]);
                txtVendortype.Text = Convert.ToString(dt.Rows[0]["VendorType"]);
                txtCompanyname.Text = Convert.ToString(dt.Rows[0]["CompanyName"]);
                txtEmailid.Text = Convert.ToString(dt.Rows[0]["EmailID"]);
                txtPhoneNumber.Text = Convert.ToString(dt.Rows[0]["Mobile"]);
                txtPannumber.Text = Convert.ToString(dt.Rows[0]["PanNumber"]);
                txtAddress.Text = Convert.ToString(dt.Rows[0]["Address"]);
                txtCountry.Text = Convert.ToString(dt.Rows[0]["Country"]);
                //txtCity.Text = Convert.ToString(dt.Rows[0]["City"]);
                //txtState.Text = Convert.ToString(dt.Rows[0]["State"]);
                txtPincode.Text = Convert.ToString(dt.Rows[0]["Pincode"]);
                bool status = false;
                bool.TryParse(Convert.ToString(dt.Rows[0]["status"]), out status);
                chkActive.Checked = status;
                
                ddlstate.SelectedValue = Convert.ToString(dt.Rows[0]["State"]);
                if(ddlstate.SelectedValue!=null && ddlstate.SelectedValue!="")
                {
                    BindCity();
                }
                ddlcity.SelectedValue = Convert.ToString(dt.Rows[0]["City"]);
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On LoadRecord: " + ex.Message + "')", true);
        }
    }

    public void UpdateVendor(int vendorid)
    {
        try
        {
            string VendorName = txtVendorname.Text;
            string Vendortype = txtVendortype.Text;
            string companyname = txtCompanyname.Text;
            string emailid = txtEmailid.Text;
            string mobile = txtPhoneNumber.Text;
            string panno = txtPannumber.Text;
            string address = txtAddress.Text;
            string country = txtCountry.Text;
            //string city = txtCity.Text;
            //string state = txtState.Text;
            string pincode = txtPincode.Text;
            bool status = false;
            if (chkActive.Checked)
                status = true;
            else
                status = false;

            string city = ddlcity.SelectedValue;
            string state = ddlstate.SelectedValue;

            DataBase DB = new DataBase();
            string updateVendor = "Update Vendor Set VendorName='" + VendorName + "', Status='" + status + "', CompanyName='" + companyname + "', PanNumber='" + panno + "'" +
                                  " , Mobile='" + mobile + "', EmailID='" + emailid + "',Address='" + address + "',Country='" + country + "',State='" + state + "'"+
                                  ", City='" + city + "', Pincode='" + pincode + "', VendorType='" + Vendortype + "' Where VendorId='" + vendorid + "'";
            string result = DB.UpdateData(updateVendor);
            if (result != null && result != "")
            {
                txtVendorname.Text = "";
                txtVendortype.Text = "";
                txtCompanyname.Text = "";
                txtEmailid.Text = "";
                txtPhoneNumber.Text = "";
                txtPannumber.Text = "";
                txtAddress.Text = "";
                txtCountry.Text = "";
                //txtCity.Text = "";
                //txtState.Text = "";
                ddlcity.SelectedIndex = -1;
                ddlstate.SelectedIndex = -1;
                txtPincode.Text = "";
                chkActive.Checked = false;
                Response.Redirect("Vendor.aspx");
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On UpdateVendor: " + ex.Message + "')", true);
        }
    }

    public void InsertVendor()
    {
        try
        {
            string VendorName = txtVendorname.Text;
            string Vendortype = txtVendortype.Text;
            string companyname = txtCompanyname.Text;
            string emailid = txtEmailid.Text;
            string mobile = txtPhoneNumber.Text;
            string panno = txtPannumber.Text;
            string address = txtAddress.Text;
            string country = txtCountry.Text;
            //string city = txtCity.Text;
            //string state = txtState.Text;
            string pincode = txtPincode.Text;
            bool status = false;
            if (chkActive.Checked)
                status = true;
            else
                status = false;

            string city = ddlcity.SelectedValue;
            string state = ddlstate.SelectedValue;

            DataBase DB = new DataBase();
            string insertVendor = "Insert into Vendor(VendorName, CreatedDate,Status,CompanyName,PanNumber,Mobile,EmailID,Address,Country,State,City,Pincode,VendorType)Values" +
                                  "('" + VendorName + "',GETDATE() ,'" + status + "','" + companyname + "','" + panno + "','" + mobile + "','" + emailid + "','" + address + "'" +
                                  ",'" + country + "','" + state + "','" + city + "','" + pincode + "','" + Vendortype + "') select SCOPE_IDENTITY()";
            int vendoridid = DB.ExcuteQuery(insertVendor);
            if (vendoridid > 0)
            {
                txtVendorname.Text = "";
                txtVendortype.Text = "";
                txtCompanyname.Text = "";
                txtEmailid.Text = "";
                txtPhoneNumber.Text = "";
                txtPannumber.Text = "";
                txtAddress.Text = "";
                txtCountry.Text = "";
                //txtCity.Text = "";
                //txtState.Text = "";
                ddlcity.SelectedIndex = -1;
                ddlstate.SelectedIndex = -1;
                txtPincode.Text = "";
                chkActive.Checked = false;
                Response.Redirect("Vendor.aspx");
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On InsertVendor: " + ex.Message + "')", true);
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int vendorid = 0;
            int.TryParse(lblId.InnerText,out vendorid);
            if (vendorid > 0)
            {
                UpdateVendor(vendorid);
            }
            else
            {
                InsertVendor();
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
            txtVendorname.Text = "";
            txtVendortype.Text = "";
            txtCompanyname.Text = "";
            txtEmailid.Text = "";
            txtPhoneNumber.Text = "";
            txtPannumber.Text = "";
            txtAddress.Text = "";
            txtCountry.Text = "";
            //txtCity.Text = "";
            //txtState.Text = "";
            txtPincode.Text = "";
            chkActive.Checked = false;

            ddlcity.SelectedIndex = -1;
            ddlstate.SelectedIndex = -1;

            Response.Redirect("Vendor.aspx");
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On btnSubmit_Click: " + ex.Message + "')", true);
        }
    }
}