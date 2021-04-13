using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WareHouseAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bindcounter();
            LoadRecord();
        }
    }
    public void LoadRecord()
    {
        try
        {
            lblId.InnerText = Request.QueryString["WarehouseID"];
            int id = 0;
            int.TryParse(lblId.InnerText, out id);
            string getCustomer = "Select * from Warehouse Where WarehouseId='" + id + "'";
            //string getCustomer = "Select * from Customer Where CustomerID='" + id + "'";
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(getCustomer);
            if (dt.Rows.Count > 0)
            {
                txtFirstname.Text = Convert.ToString(dt.Rows[0]["Fname"]);              
                txtPhoneNumber.Text = Convert.ToString(dt.Rows[0]["PhoneNumber"]);
                bool status = false;
                bool.TryParse(Convert.ToString(dt.Rows[0]["Status"]), out status);
                chkActive.Checked = status;
                string ss = dt.Rows[0]["Address1"].ToString();
                txtAddress1.Text = ss;
                
                txtZipcode.Text = Convert.ToString(dt.Rows[0]["Zipcode"]);

                ddlcountry.SelectedValue = Convert.ToString(dt.Rows[0]["Country"]);
                if (ddlcountry.SelectedValue != null && ddlcountry.SelectedValue != "")
                {
                    Bindstate();
                }
                ddlstate.SelectedValue = Convert.ToString(dt.Rows[0]["State"]);
                if (ddlstate.SelectedValue != null && ddlstate.SelectedValue != "")
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

    protected void Bindcounter()
    {
        string s = "select * from Country where status='true'";
        DataBase db = new DataBase();
        DataTable tb = db.ExcutesQuery(s);
        if (tb.Rows.Count > 0)
        {
            ddlcountry.DataSource = tb;
            ddlcountry.DataValueField = "CountryId";
            ddlcountry.DataTextField = "Name";
            ddlcountry.DataBind();
            ddlcountry.Items.Insert(0, new ListItem("Select Country ...", ""));
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
    //string getcity = "select * from City";

    //DataTable tb1 = db.ExcutesQuery(getcity);
    //if (tb1.Rows.Count > 0)
    //{
    //    ddlcity.DataSource = tb1;
    //    ddlcity.DataValueField = "CityId";
    //    ddlcity.DataTextField = "Name";
    //    ddlcity.DataBind();
    //    ddlcity.Items.Insert(0, new ListItem("Select City ...", ""));
    //}




    public void UpdateWarehouse(int custid)
    {
        try
        {
            string FName = txtFirstname.Text;
            string mobile = txtPhoneNumber.Text;          
            bool status = false;
            if (chkActive.Checked)
                status = true;
            else
                status = false;

            string addr = txtAddress1.Text;
           
            
            //string Country = txtAddress2.Text;
            //string state = txtState.Text;
            //string city = txtCity.Text;
            string zipcode = txtZipcode.Text;
            string Country = ddlcountry.SelectedValue;
            string state = ddlstate.SelectedValue;
            string city = ddlcity.SelectedValue;

            DataBase DB = new DataBase();
            string Updatewarehouse = "Update Warehouse Set Fname='" + FName + "',  PhoneNumber='" + mobile + "',Address1='" + addr + "', Country='" + Country + "',  City='" + city + "', State='" + state + "', Zipcode='" + zipcode + "', Status='" + status + "'  Where WarehouseId='" + custid + "'";
            string result = DB.UpdateData(Updatewarehouse);

            if (result != null && result != "")
                {
                    txtFirstname.Text = "";
                    txtAddress1.Text = "";
                    txtPhoneNumber.Text = "";                 
                    chkActive.Checked = false;
                    Response.Redirect("WareHouse.aspx");
                    //Response.Redirect("WareHouse.aspx");
                }
            
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On UpdateCustomer: " + ex.Message + "')", true);
        }
    }
    public void InsertWarehouse()
    {
        try
        {
            string FName = txtFirstname.Text.Trim();       
            string mobile = txtPhoneNumber.Text;          
            bool status = false;
            if (chkActive.Checked)
                status = true;
            else
                status = false;

            string addr = txtAddress1.Text;
            //string country = txtAddress2.Text;
            //string state = txtState.Text;
            //string city = txtCity.Text;
            string zipcode = txtZipcode.Text;
            string country = ddlcountry.SelectedValue;
            string state = ddlstate.SelectedValue;
            string city = ddlcity.SelectedValue;

            DataBase DB = new DataBase();

            //string checkdupEmail = "Select EmailID from Warehouse Where EmailID='" + emailid + "'";
            //DataTable _dt = DB.ExcutesQuery(checkdupEmail);
            //if (!(_dt.Rows.Count > 0))
            //{
                string insertcustomer = "Insert into Warehouse(Fname,PhoneNumber,Address1,Country,State,city,Zipcode,Status)Values" +
                                      "('" + FName + "','" + mobile + "','" + addr + "','" + country + "','" + state + "','" + city + "','" + zipcode + "','" + status + "') select SCOPE_IDENTITY()";
                int custid = DB.ExcuteQuery(insertcustomer);

                if (custid > 0)
                    {
                        Response.Redirect("WareHouse.aspx");
                    }
                
            //}
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Email Id Exists')", true);
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On InsertWarehouse: " + ex.Message + "')", true);
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int custid = 0;
            int.TryParse(lblId.InnerText, out custid);
            if (custid > 0)
            {
                UpdateWarehouse(custid);
            }
            else
            {
                InsertWarehouse();
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
            txtFirstname.Text = "";          
           
            txtPhoneNumber.Text = "";        
            chkActive.Checked = false;
            Response.Redirect("WareHouse.aspx");
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On btnSubmit_Click: " + ex.Message + "')", true);
        }
    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCity();
    }
    protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bindstate();
    }
}