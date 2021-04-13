using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerAdd : System.Web.UI.Page
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
            lblId.InnerText = Request.QueryString["CustomerID"];
            int id = 0;
            int.TryParse(lblId.InnerText, out id);
            string getCustomer = "Select * from Customer a left outer join Customer_Details b on a.CustomerID=b.CustomerID Where a.CustomerID='" + id + "'";
            //string getCustomer = "Select * from Customer Where CustomerID='" + id + "'";
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(getCustomer);
            if (dt.Rows.Count > 0)
            {
                txtFirstname.Text = Convert.ToString(dt.Rows[0]["Fname"]);
                txtMiddlename.Text = Convert.ToString(dt.Rows[0]["Mname"]);
                txtLastname.Text = Convert.ToString(dt.Rows[0]["Lname"]);
                txtEmailid.Text = Convert.ToString(dt.Rows[0]["EmailID"]);
                txtPhoneNumber.Text = Convert.ToString(dt.Rows[0]["PhoneNumber"]);
                //txtPassword.TextMode = TextBoxMode.SingleLine;
                //txtPassword.Text = Convert.ToString(dt.Rows[0]["Password"]);
                //txtConfirmPassword.TextMode = TextBoxMode.SingleLine;
                //txtConfirmPassword.Text = Convert.ToString(dt.Rows[0]["Password"]);
               
                bool status = false;
                bool.TryParse(Convert.ToString(dt.Rows[0]["Status"]), out status);
                chkActive.Checked = status;

                txtAddress1.Text = Convert.ToString(dt.Rows[0]["Address1"]);
                //txtAddress2.Text = Convert.ToString(dt.Rows[0]["Country"]);
                //txtCity.Text = Convert.ToString(dt.Rows[0]["City"]);
                //txtState.Text = Convert.ToString(dt.Rows[0]["State"]);
                txtZipcode.Text = Convert.ToString(dt.Rows[0]["Zipcode"]);

                ddlcountry.SelectedValue = Convert.ToString(dt.Rows[0]["Country"]);
                if (ddlcountry.SelectedValue != null && ddlcountry.SelectedValue != "")
                {
                    Bindstate();
                }
                ddlstate.SelectedValue = Convert.ToString(dt.Rows[0]["State"]);
                if(ddlstate.SelectedValue != null && ddlstate.SelectedValue!="")
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
    

   

    public void UpdateCustomer(int custid)
    {
        try
        {
            string FName = txtFirstname.Text;
            string MName = txtMiddlename.Text;
            string LName = txtLastname.Text;
            string emailid = txtEmailid.Text;
            string mobile = txtPhoneNumber.Text;
            //string pswd = txtPassword.Text;
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
            string Updatecustomer = "Update Customer Set Fname='" + FName + "', Mname='" + MName + "', Lname='" + LName + "', EmailID='" + emailid + "', PhoneNumber='" + mobile + "', Status='" + status + "'  Where CustomerID='" + custid + "'";
            string result = DB.UpdateData(Updatecustomer);
            if (result != null && result != "")
            {
                string Updatecustomerdetail = "Update Customer_Details Set Address1='" + addr + "', Country='" + Country + "', City='" + city + "', State='" + state + "', Zipcode='" + zipcode + "', date_updated=GETDATE()  Where CustomerID='" + custid + "'";
                string result1 = DB.UpdateData(Updatecustomerdetail);
                if (result1 != null && result1 != "")
                {
                    txtFirstname.Text = "";
                    txtMiddlename.Text = "";
                    txtLastname.Text = "";
                    txtEmailid.Text = "";
                    txtPhoneNumber.Text = "";               
                    chkActive.Checked = false;
                    Response.Redirect("Customer.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On UpdateCustomer: " + ex.Message + "')", true);
        }
    }
    public void InsertCustomer()
    {
        try
        {
            string FName = txtFirstname.Text;
            string MName = txtMiddlename.Text;
            string LName = txtLastname.Text;           
            string emailid = txtEmailid.Text;
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

            string checkdupEmail = "Select EmailID from Customer Where EmailID='" + emailid+"'";
            DataTable _dt = DB.ExcutesQuery(checkdupEmail);
            if (!(_dt.Rows.Count > 0))
            {
                string insertcustomer = "Insert into Customer(Fname, Mname,Lname,EmailID,PhoneNumber,CreatedDate,Status)Values" +
                                      "('" + FName + "','" + MName + "' ,'" + LName + "','" + emailid + "','" + mobile + "',GETDATE(),'" + status + "') select SCOPE_IDENTITY()";
                int custid = DB.ExcuteQuery(insertcustomer);
                if (custid > 0)
                {
                    string insrtcustdetail = "Insert into Customer_Details(CustomerID, Address1,Country,City,State,Zipcode,date_updated)Values" +
                                      "('" + custid + "','" + addr + "' ,'" + country + "','" + city + "','" + state + "','" + zipcode + "',GETDATE()) select SCOPE_IDENTITY()";
                    int custdetailid = DB.ExcuteQuery(insrtcustdetail);
                    if (custdetailid > 0)
                    {
                        txtFirstname.Text = "";
                        txtMiddlename.Text = "";
                        txtLastname.Text = "";
                        txtEmailid.Text = "";
                        txtPhoneNumber.Text = "";
                        chkActive.Checked = false;
                        Response.Redirect("Customer.aspx");
                    }
                }
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Email Id Exists')", true);
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On InsertCustomer: " + ex.Message + "')", true);
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int custid = 0;
            int.TryParse(lblId.InnerText, out custid);
            if(custid>0)
            {
                UpdateCustomer(custid);
            }
            else
            {
                InsertCustomer();
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
            txtMiddlename.Text = "";
            txtLastname.Text = "";
            txtEmailid.Text = "";
            txtPhoneNumber.Text = "";
            chkActive.Checked = false;
            Response.Redirect("Customer.aspx");
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