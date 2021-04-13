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

public partial class Delivery : System.Web.UI.Page
{
    string Employeeid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["EmpID"]) != null && Convert.ToString(Session["EmpID"]) != "")
        {
            Employeeid = Convert.ToString(Session["EmpID"]);
        }
        if (!IsPostBack)
        {
            Bindstate();
            BindDeliverystate();
            BindCityonload();
            BindDeliveryCityonload();
            BindWarehouse();
            LoadRecord();
        }
    }
   
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindCity();
    }
    protected void ddldeliverystate_SelectedIndexChanged(object sender, EventArgs e)
    {
       // BindDeliveryCity();
    }
  
    protected void Bindstate()
    {
        string s = "select * from FieldWorkMgt_DB.dbo.State where status='1'";
        DataBase db = new DataBase();
        DataTable tb = db.ExcutesQuery(s);
        if (tb.Rows.Count > 0)
        {
            ddlstate.DataSource = tb;
            ddlstate.DataValueField = "StateId";
            ddlstate.DataTextField = "Name";
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("Select State ...", ""));

            //ddldeliverystate.DataSource = tb;
            //ddldeliverystate.DataValueField = "StateId";
            //ddldeliverystate.DataTextField = "Name";
            //ddldeliverystate.DataBind();
            //ddldeliverystate.Items.Insert(0, new ListItem("Select State ...", ""));
        }
    }

   
    protected void BindDeliverystate()
    {
        string s = "select * from FieldWorkMgt_DB.dbo.State where status='1'";
        DataBase db = new DataBase();
        DataTable tb = db.ExcutesQuery(s);
        if (tb.Rows.Count > 0)
        {
            ddldeliverystate.DataSource = tb;
            ddldeliverystate.DataValueField = "StateId";
            ddldeliverystate.DataTextField = "Name";
            ddldeliverystate.DataBind();
            ddldeliverystate.Items.Insert(0, new ListItem("Select State ...", ""));
        }
    }

    protected void BindCityonload()
    {
        string s = "select * from FieldWorkMgt_DB.dbo.City where status='1'";
        DataBase db = new DataBase();
        DataTable tb = db.ExcutesQuery(s);
        ddlcity.DataSource = tb;
        ddlcity.DataValueField = "CityId";
        ddlcity.DataTextField = "Name";
        ddlcity.DataBind();
        ddlcity.Items.Insert(0, new ListItem("Select City ...", ""));

        //ddldeliverycity.DataSource = tb;
        //ddldeliverycity.DataValueField = "CityId";
        //ddldeliverycity.DataTextField = "Name";
        //ddldeliverycity.DataBind();
        //ddldeliverycity.Items.Insert(0, new ListItem("Select City ...", ""));

    }

    protected void BindDeliveryCityonload()
    {
        string s = "select * from FieldWorkMgt_DB.dbo.City where status='1' ";
        DataBase db = new DataBase();
        DataTable tb = db.ExcutesQuery(s);  

        ddldeliverycity.DataSource = tb;
        ddldeliverycity.DataValueField = "CityId";
        ddldeliverycity.DataTextField = "Name";
        ddldeliverycity.DataBind();
        ddldeliverycity.Items.Insert(0, new ListItem("Select City ...", ""));

    }
    protected void BindCity()
    {
        string s = "select * from FieldWorkMgt_DB.dbo.City where StateId='" + ddlstate.SelectedValue + "' and status='1'";
        DataBase db = new DataBase();
        DataTable tb = db.ExcutesQuery(s);
        ddlcity.DataSource = tb;
        ddlcity.DataValueField = "CityId";
        ddlcity.DataTextField = "Name";
        ddlcity.DataBind();
        ddlcity.Items.Insert(0, new ListItem("Select City ...", ""));

        //ddldeliverycity.DataSource = tb;
        //ddldeliverycity.DataValueField = "CityId";
        //ddldeliverycity.DataTextField = "Name";
        //ddldeliverycity.DataBind();
        //ddldeliverycity.Items.Insert(0, new ListItem("Select City ...", ""));

    }
    protected void BindDeliveryCity()
    {
        string s = "select * from FieldWorkMgt_DB.dbo.City where StateId='" + ddldeliverystate.SelectedValue + "'  and status='1'";
        DataBase db = new DataBase();
        DataTable tb = db.ExcutesQuery(s);      

        ddldeliverycity.DataSource = tb;
        ddldeliverycity.DataValueField = "CityId";
        ddldeliverycity.DataTextField = "Name";
        ddldeliverycity.DataBind();
        ddldeliverycity.Items.Insert(0, new ListItem("Select City ...", ""));

    }
    protected void BindWarehouse()
    {
        string s = "select * from FieldWorkMgt_DB.dbo.Warehouse where  status='1'";
        DataBase db = new DataBase();
        DataTable tb = db.ExcutesQuery(s);
        ddlwarehouse.DataSource = tb;
        ddlwarehouse.DataValueField = "WarehouseId";
        ddlwarehouse.DataTextField = "Fname";
        ddlwarehouse.DataBind();
        ddlwarehouse.Items.Insert(0,new ListItem("select Warehouse...",""));

    }

    [WebMethod]
    public static string[] GetCustomers(string prefix)
    {
        List<string> customers = new List<string>();
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT [CustomerID] ,Fname+' '+isnull(Mname,'')+' '+Lname as Name FROM [FieldWorkMgt_DB].[dbo].[Customer] where  Fname like @SearchText + '%' ";
                 cmd.Parameters.AddWithValue("@SearchText", prefix);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(string.Format("{0}-{1}", sdr["Name"], sdr["CustomerID"]));
                    }
                }
                conn.Close();
            }
        }
        return customers.ToArray();
    }


    [WebMethod]
    public static List<string> Getloc(string prefix)
    {
        List<string> Details=new List<string>();
        string customerId = prefix;
        if (customerId != null && customerId != "")
        {
            string getloc = "Select a.EmailID, a.PhoneNumber, b.Address1, b.Country,b.City,b.State, b.Zipcode " +
                            " from FieldWorkMgt_DB.dbo.Customer a" +
                            " join FieldWorkMgt_DB.dbo.Customer_Details b on a.CustomerID=b.CustomerID " +
                            " where a.CustomerID=" + customerId;
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(getloc);
            if (dt.Rows.Count > 0)
            {
                Details.Add(dt.Rows[0]["Address1"].ToString());
                Details.Add(dt.Rows[0]["Country"].ToString());
                Details.Add(dt.Rows[0]["City"].ToString());
                Details.Add(dt.Rows[0]["State"].ToString());
                Details.Add(dt.Rows[0]["Zipcode"].ToString());
                Details.Add(dt.Rows[0]["EmailID"].ToString());
                Details.Add(dt.Rows[0]["PhoneNumber"].ToString());
                
            }
        }
        return Details;
    }

    [WebMethod]
    public static List<string> GetPickuploc(string prefix)
    {
        List<string> Details = new List<string>();
        string VendorId = prefix;
        if (VendorId != null && VendorId != "")
        {
            //string getloc = "Select a.Quantity, b.VendorName,b.Address,b.Country,b.State,b.City,b.Pincode from Items a " +
            //                " join Vendor b on a.vendorId=b.VendorId"+
            //                " where a.Id=" + ItemId;
           // string getloc = "select b.Title,b.Quantity,a.Address,a.Country,a.State,a.City,a.Warehouse,a.Pincode from Vendor a join Items b on a.VendorId=b.VendorId where a.VendorId=" + VendorId;
            string getloc = "select b.Title,b.Quantity,a.Address,a.Country,w.State,w.City,a.Warehouse,a.Pincode from FieldWorkMgt_DB.dbo.Vendor a join FieldWorkMgt_DB.dbo.Warehouse w on a.Warehouse=w.WarehouseId join FieldWorkMgt_DB.dbo.Items b on a.VendorId=b.VendorId where a.VendorId=" + VendorId;

            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(getloc);
            if (dt.Rows.Count > 0)
            {
               
                Details.Add(dt.Rows[0]["Address"].ToString());
                Details.Add(dt.Rows[0]["Country"].ToString());
                Details.Add(dt.Rows[0]["State"].ToString());
                Details.Add(dt.Rows[0]["City"].ToString());
                Details.Add(dt.Rows[0]["Warehouse"].ToString());
                Details.Add(dt.Rows[0]["Pincode"].ToString());
                Details.Add(dt.Rows[0]["Title"].ToString());
                Details.Add(dt.Rows[0]["Quantity"].ToString());              
            }
        }
        return Details;
    }

    [WebMethod]
    public static List<city> GetCity(string prefix)
    {
        List<city> Details = new List<city>();
        string ItemId = prefix;
        if (ItemId != null && ItemId != "")
        {
            string getloc = "SELECT * FROM [FieldWorkMgt_DB].[dbo].[City] where  StateId = " + ItemId;
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(getloc);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    city _city = new city();
                    _city.cityid = Convert.ToInt32(dt.Rows[i]["CityId"]);
                    _city.name = Convert.ToString(dt.Rows[i]["Name"]);
                    //Details.Add(dt.Rows[0]["CityId"].ToString());
                    //Details.Add(dt.Rows[0]["Name"].ToString());   
                    Details.Insert(i, _city);
                }
               
            }
        }
        return Details;
    }

    [WebMethod]
    public static List<Deliverycity> GetDeliveryCity(string prefix)
    {
        List<Deliverycity> Details = new List<Deliverycity>();
        string ItemId = prefix;
        if (ItemId != null && ItemId != "")
        {
            string getloc = "SELECT * FROM [FieldWorkMgt_DB].[dbo].[City] where  StateId = " + ItemId;
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(getloc);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Deliverycity _city = new Deliverycity();
                    _city.cityid = Convert.ToInt32(dt.Rows[i]["CityId"]);
                    _city.name = Convert.ToString(dt.Rows[i]["Name"]);
                    //Details.Add(dt.Rows[0]["CityId"].ToString());
                    //Details.Add(dt.Rows[0]["Name"].ToString());   
                    Details.Insert(i, _city);
                }

            }
        }
        return Details;
    }
    public class Deliverycity
    {
        public int cityid { get; set; }
        public string name { get; set; }
    }
    public class city
    {
        public int cityid { get; set; }
        public string name { get; set; }
    }

    [WebMethod]
    public static string[] GetEmployee(string prefix)
    {
        List<string> customers = new List<string>();
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT [ID] ,Fname+' '+Mname+' '+Lname as Name FROM [FieldWorkMgt_DB].[dbo].[Employee] where  Fname like @SearchText + '%' ";
                cmd.Parameters.AddWithValue("@SearchText", prefix);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(string.Format("{0}-{1}", sdr["Name"], sdr["ID"]));
                    }
                }
                conn.Close();
            }
        }
        return customers.ToArray();
    }

    protected void Submit(object sender, EventArgs e)
    {
        string customerName = Request.Form[txtSearch.UniqueID];
        string customerId = Request.Form[hfCustomerId.UniqueID];
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + customerName + "\\nID: " + customerId + "');", true);
    }

    [WebMethod]
    public static string[] GetProducts(string prefix)
   {
        List<string> customers = new List<string>();
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
   //             cmd.CommandText = " select Id,Title from Items where  Title like @SearchText + '%' ";
                  cmd.CommandText = " select VendorId,VendorName from FieldWorkMgt_DB.dbo.Vendor where  VendorName like @SearchText + '%' ";
                  cmd.Parameters.AddWithValue("@SearchText", prefix);
                  cmd.Connection = conn;
                  conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(string.Format("{0}-{1}", sdr["VendorName"], sdr["VendorId"]));
                    }
                }
                conn.Close();
            }
        }
        return customers.ToArray();
    }

    [WebMethod]
    public static string[] GetCustomer5(string prefix)
    {
        Delivery delivery = new Delivery();
        List<string> customers = new List<string>();
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {

                //cmd.CommandText = "  select Id,Title from Items i join Vendor v on i.vendorId= v.VendorId where v.VendorName like @SearchText + '%'";

                cmd.CommandText = "  select Id,Title from FieldWorkMgt_DB.dbo.Items i where i.Title like  @SearchText + '%' ";
                cmd.Parameters.AddWithValue("@SearchText", prefix);              
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(string.Format("{0}-{1}", sdr["Title"], sdr["Id"]));
                    }
                }
                conn.Close();
            }
        }
        return customers.ToArray();
    }

    public void LoadRecord()
    {
        try
        {
            lblId.InnerText = Request.QueryString["DeliveryID"];
            int id = 0;
            int.TryParse(lblId.InnerText, out id);

            string getdelivery = "Select b.Fname+' '+b.Mname+' '+b.Lname as Custname, c.Title, d.Fname+' '+d.Mname+' '+d.Lname as empname, a.CustomerID, a.Itemid, a.Assignto, a.Addr1,a.Country,a.State,a.City,a.Zipcode,a.Priority,a.Ordereddate,a.Estimateddate,a.PickupAddr,a.PickCountry,a.Pickstate,a.Pickcity,a.PickZipcode,a.Vendorname,a.Quantity,a.Emailid,a.Phonenumber,e.DeliveryStatusValue from FieldWorkMgt_DB.dbo.Delivery a " +
                                    " join FieldWorkMgt_DB.dbo.Customer b on a.CustomerID=b.CustomerID" +
                                    " join FieldWorkMgt_DB.dbo.Items c on a.Itemid=c.Id" +
                                    " join FieldWorkMgt_DB.dbo.Employee d on a.Assignto=d.ID" +
                                    " join FieldWorkMgt_DB.dbo.DeliveryStatus e on a.DeliveryID=e.DeliveryId" +
                                    " Where a.DeliveryID='" + id + "'";
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(getdelivery);
            if (dt.Rows.Count > 0)
            {
                txtDelivery.Text = Convert.ToString(dt.Rows[0]["Addr1"]);
                txtadr2.Text = Convert.ToString(dt.Rows[0]["Country"]);
                //txtCity.Text = Convert.ToString(dt.Rows[0]["City"]);
                //txtState.Text = Convert.ToString(dt.Rows[0]["State"]);
                txtZipcode.Text = Convert.ToString(dt.Rows[0]["Zipcode"]);
                txtSearch.Text = Convert.ToString(dt.Rows[0]["Custname"]);
                txtProduct.Text = Convert.ToString(dt.Rows[0]["Title"]);
                txtEmployee.Text = Convert.ToString(dt.Rows[0]["empname"]);
                hfCustomerId.Value = Convert.ToString(dt.Rows[0]["CustomerID"]);
                hfProductId.Value = Convert.ToString(dt.Rows[0]["Itemid"]);
                hfempId.Value = Convert.ToString(dt.Rows[0]["Assignto"]);

                ddlPriority.Items.FindByText(Convert.ToString(dt.Rows[0]["Priority"])).Selected = true;
                DateTime startdate;
                DateTime.TryParse(Convert.ToString(dt.Rows[0]["Ordereddate"]), out startdate);
                txtstartdate.Text = startdate.ToString("dd/MM/yyyy");
                DateTime duedate;
                DateTime.TryParse(Convert.ToString(dt.Rows[0]["Estimateddate"]), out duedate);
                txtduedate.Text = duedate.ToString("dd/MM/yyyy");
                txtpick.Text = Convert.ToString(dt.Rows[0]["PickupAddr"]);
                txtpickaddr.Text = Convert.ToString(dt.Rows[0]["PickCountry"]);
                //txtpickstate.Text = Convert.ToString(dt.Rows[0]["Pickstate"]);
                //txtpickcity.Text = Convert.ToString(dt.Rows[0]["Pickcity"]);
                txtpickzipcode.Text = Convert.ToString(dt.Rows[0]["PickZipcode"]);
                txtVendor.Text = Convert.ToString(dt.Rows[0]["Vendorname"]);
                txtEmial.Text = Convert.ToString(dt.Rows[0]["Emailid"]);
                txtphone.Text = Convert.ToString(dt.Rows[0]["Phonenumber"]);
                txtQuantity.Text = Convert.ToString(dt.Rows[0]["Quantity"]);

                ddldeliverystate.SelectedValue = Convert.ToString(dt.Rows[0]["State"]);
                if (ddldeliverystate.SelectedValue != null && ddldeliverystate.SelectedValue != "")
                {
                    BindCity();
                }
                ddldeliverycity.SelectedValue = Convert.ToString(dt.Rows[0]["City"]);

                ddlstate.SelectedValue = Convert.ToString(dt.Rows[0]["Pickstate"]);
                if (ddlstate.SelectedValue != null && ddlstate.SelectedValue != "")
                {
                    BindCity();
                }
                ddlcity.SelectedValue = Convert.ToString(dt.Rows[0]["Pickcity"]);

                ddldeliverstatus.SelectedValue = Convert.ToString(dt.Rows[0]["DeliveryStatusValue"]);
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On LoadRecord: " + ex.Message + "')", true);
        }
    }

    public void UpdateDelivery(int DeliveryID)
    {
        try
        {
            string Custid = Request.Form[hfCustomerId.UniqueID];
            string Itemid = Request.Form[hfProductId.UniqueID];
            string Empid = Request.Form[hfempId.UniqueID];

            string addr = txtDelivery.Text;           
            string Country = txtadr2.Text;           
            //string city = txtCity.Text;
            //string state = txtState.Text;
            string zipcode = txtZipcode.Text;

            string priority = ddlPriority.SelectedItem.Text;
            string orderdate = null;
            DateTime _orderdate;
            if (txtstartdate.Text != null && txtstartdate.Text != "")
            {
                _orderdate = DateTime.ParseExact(txtstartdate.Text, "dd/MM/yyyy", null);
                //DateTime.TryParse(txtstartdate.Text,out _orderdate);
                orderdate = _orderdate.ToString("yyyy/MM/dd");
            }
            DateTime _estimateddate;
            string estimateddate = null;
            if (txtduedate.Text != null && txtduedate.Text != "")
            {
                _estimateddate = DateTime.ParseExact(txtduedate.Text, "dd/MM/yyyy", null);
                //DateTime.TryParse(txtduedate.Text, out _estimateddate);
                estimateddate = _estimateddate.ToString("yyyy/MM/dd");
            }
            string pickaddr = txtpick.Text;
            string pickcountry = txtpickaddr.Text;
            //string pickstate = txtpickstate.Text;
            //string pickcity = txtpickcity.Text;
            string pickzipcode = txtpickzipcode.Text;
            string vendorname = txtVendor.Text;
            string emailid = txtEmial.Text;
            string phone = txtphone.Text;
            decimal quant;
            decimal.TryParse(txtQuantity.Text, out quant);

            string state = ddldeliverystate.SelectedValue;
            string city = ddldeliverycity.SelectedValue;

            string pickstate = ddlstate.SelectedValue;
            string pickcity = ddlcity.SelectedValue;

            DataBase DB = new DataBase();            
            string updatedelivery = "Update FieldWorkMgt_DB.dbo.Delivery Set CustomerID='" + Custid + "', Itemid='" + Itemid + "', Assignto='" + Empid + "', Addr1='" + addr + "'" +
                                  " , Country='" + Country + "', State='" + state + "',City='" + city + "',Zipcode='" + zipcode + "' "+
                                  " , Assignby='" + Employeeid + "', Priority='" + priority + "',Ordereddate='" + orderdate + "',Estimateddate='" + estimateddate + "' " +
                                  " , PickupAddr='" + pickaddr + "', PickCountry='" + pickcountry + "', Pickstate='" + pickstate + "',Pickcity='" + pickcity + "',PickZipcode='" + pickzipcode + "' " +
                                  " , Vendorname='" + vendorname + "', Quantity='" + quant + "',Emailid='" + emailid + "',Phonenumber='" + phone + "' " +
                                  " Where DeliveryID='" + DeliveryID + "'";
            string result = DB.UpdateData(updatedelivery);
            if (result != null && result != "")
            {
                string updatedeliverystatus = "Update FieldWorkMgt_DB.dbo.DeliveryStatus Set DeliveryStatusValue='" + ddldeliverstatus.SelectedValue + "', DeliveryStatus='" + ddldeliverstatus.SelectedItem.Text + "' Where DeliveryID='" + DeliveryID + "'";
                string result1 = DB.UpdateData(updatedeliverystatus);
                if (result1 != null && result1 != "")
                {
                    txtDelivery.Text = "";
                    txtadr2.Text = "";
                    //txtCity.Text = "";
                    //txtState.Text = "";
                    txtZipcode.Text = "";
                    txtSearch.Text = "";
                    txtProduct.Text = "";
                    txtEmployee.Text = "";
                    ddlPriority.Text = "";
                    txtstartdate.Text = "";
                    txtduedate.Text = "";
                    txtpick.Text = "";
                    txtpickaddr.Text = "";
                    //txtpickstate.Text = "";
                    //txtpickcity.Text = "";
                    txtpickzipcode.Text = "";
                    txtVendor.Text = "";
                    txtEmial.Text = "";
                    txtphone.Text = "";
                    txtQuantity.Text = "";
                    ddlstate.SelectedIndex = -1;
                    ddlcity.SelectedIndex = -1;
                    ddldeliverystate.SelectedIndex = -1;
                    ddldeliverycity.SelectedIndex = -1;
                    ddldeliverstatus.SelectedIndex = -1;
                    Response.Redirect("Delivery1.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On UpdateDelivery: " + ex.Message + "')", true);
        }
    }
    public void InsertDelivery()
    {
        try
        {
            string Custid = Request.Form[hfCustomerId.UniqueID];
            string Itemid = Request.Form[hfProductId.UniqueID];
            string Empid = Request.Form[hfempId.UniqueID];

            string addr = txtDelivery.Text;           
            string address = txtadr2.Text;           
            //string city = txtCity.Text;
            //string state = txtState.Text;
            string zipcode = txtZipcode.Text;

            string priority = ddlPriority.SelectedItem.Text;
            string orderdate=null;
            DateTime _orderdate =new DateTime();
            if (txtstartdate.Text != null && txtstartdate.Text != "")
            {
                _orderdate=DateTime.ParseExact(txtstartdate.Text, "dd/MM/yyyy", null);
                //DateTime.TryParse(txtstartdate.Text,out _orderdate);
                orderdate = _orderdate.ToString("yyyy/MM/dd");
            }
            DateTime _estimateddate;
            string estimateddate=null;
            if (txtduedate.Text != null && txtduedate.Text != "")
            {
                _estimateddate = DateTime.ParseExact(txtduedate.Text, "dd/MM/yyyy", null);
                //DateTime.TryParse(txtduedate.Text, out _estimateddate);
                estimateddate = _estimateddate.ToString("yyyy/MM/dd");
            }
            string pickaddr = txtpick.Text;
            string pickcountry = txtpickaddr.Text;
            //string pickstate = txtpickstate.Text;
            //string pickcity = txtpickcity.Text;
            string pickzipcode = txtpickzipcode.Text;
            string vendorname = txtVendor.Text;
            string emailid = txtEmial.Text;
            string phone = txtphone.Text;
            decimal quant;
            decimal.TryParse(txtQuantity.Text, out quant);

            string pickstate = ddlstate.SelectedValue;
            string pickcity = ddlcity.SelectedValue;
            string state = ddldeliverystate.SelectedValue;
            string city = ddldeliverycity.SelectedValue;

            DataBase DB = new DataBase();
            string insertdeliveryr = "Insert into FieldWorkMgt_DB.dbo.Delivery(CustomerID, Itemid,Assignto,Addr1,Country,State,City,Zipcode,Assignby,Priority,Createddate,Ordereddate,Estimateddate,PickupAddr,PickCountry,Pickstate,Pickcity,PickZipcode,Vendorname,Quantity,Emailid,Phonenumber)Values" +
                                  "('" + Custid + "','" + Itemid + "','" + Empid + "','" + addr + "','" + address + "','" + state + "','" + city + "','" + zipcode +"'"+
                                  ",'" + Employeeid + "','" + priority + "',GetDate(),'" + orderdate + "','" + estimateddate + "','" + pickaddr + "','" + pickcountry + "','" + pickstate + "','" + pickcity + "','" + pickzipcode + "','" + vendorname + "','" + quant + "','" + emailid + "','" + phone + "') select SCOPE_IDENTITY()";
            int deliveryid = DB.ExcuteQuery(insertdeliveryr);
            if (deliveryid > 0)
            {
                string insertdeliverystatus = "Insert into FieldWorkMgt_DB.dbo.DeliveryStatus(DeliveryId,DeliveryStatusValue,DeliveryStatus)Values('" + deliveryid + "','" + ddldeliverstatus.SelectedValue + "','" + ddldeliverstatus.SelectedItem.Text + "') select SCOPE_IDENTITY()";
                int deliverystatusId = DB.ExcuteQuery(insertdeliverystatus);
                if (deliverystatusId > 0)
                {
                    txtDelivery.Text = "";
                    txtadr2.Text = "";
                    //txtCity.Text = "";
                    //txtState.Text = "";
                    txtZipcode.Text = "";
                    txtSearch.Text = "";
                    txtProduct.Text = "";
                    txtEmployee.Text = "";
                    ddlPriority.Text = "";
                    txtstartdate.Text = "";
                    txtduedate.Text = "";
                    txtpick.Text = "";
                    txtpickaddr.Text = "";
                    //txtpickstate.Text = "";
                    //txtpickcity.Text = "";
                    txtpickzipcode.Text = "";
                    txtVendor.Text = "";
                    txtEmial.Text = "";
                    txtphone.Text = "";
                    txtQuantity.Text = "";
                    ddlstate.SelectedIndex = -1;
                    ddlcity.SelectedIndex = -1;
                    ddldeliverystate.SelectedIndex = -1;
                    ddldeliverycity.SelectedIndex = -1;
                    ddldeliverstatus.SelectedIndex = -1;
                    Response.Redirect("Delivery1.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On InsertDelivery: " + ex.Message + "')", true);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int id = 0;
            int.TryParse(lblId.InnerText, out id);
            if (id > 0)
            {
                UpdateDelivery(id);
            }
            else
            {
                InsertDelivery();
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
            txtDelivery.Text = "";
            txtadr2.Text = "";
            //txtCity.Text = "";
            //txtState.Text = "";
            txtZipcode.Text = "";
            txtSearch.Text = "";
            txtProduct.Text = "";
            txtEmployee.Text = "";
            ddlPriority.Text = "";
            txtstartdate.Text = "";
            txtduedate.Text = "";
            txtpick.Text = "";
            txtpickaddr.Text = "";
            //txtpickstate.Text = "";
            //txtpickcity.Text = "";
            txtpickzipcode.Text = "";
            txtVendor.Text = "";
            txtEmial.Text = "";
            txtphone.Text = "";
            txtQuantity.Text = "";
            ddlstate.SelectedIndex = -1;
            ddlcity.SelectedIndex = -1;
            ddldeliverystate.SelectedIndex = -1;
            ddldeliverycity.SelectedIndex = -1;

            Response.Redirect("Delivery1.aspx");
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On btnCancel_Click: " + ex.Message + "')", true);
        }
    }

    protected void btnMap_Click(object sender, EventArgs e)
    {
        getaddr();
     
    }

    public string addr1 = null;
    public string addr2 = null;
    public void getaddr()
    {
        if ((txtDelivery.Text != null && txtDelivery.Text != "") && (txtpick.Text != null && txtDelivery.Text != ""))
        {
            //Session["DeliveryAddr"] = txtDelivery.Text + " " + txtState.Text + " " + txtCity.Text + " " + txtZipcode.Text;
            //Session["PickupAddr"] = txtpick.Text + " " + txtpickstate.Text + " " + txtpickcity.Text + " " + txtpickzipcode.Text;
            ////string deliveryaddr = txtDelivery.Text + " " + txtState.Text + " " + txtCity.Text + "" + txtZipcode.Text;
            //string pickupaddr = txtpick.Text + " " + txtpickstate.Text + " " + txtpickcity.Text + "" + txtpickzipcode.Text;

            //Session["DeliveryAddr"] =  txtState.Text + ", " + txtCity.Text ;
            //Session["PickupAddr"] = ddl.Text + ", " + txtpickcity.Text ;
            addr1 = ddldeliverystate.SelectedItem.Text + ", " + ddldeliverycity.SelectedItem.Text;
            addr2 = ddlstate.SelectedItem.Text + ", " + ddlcity.SelectedItem.Text;
        }
    }

   
}