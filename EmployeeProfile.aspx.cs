using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EmployeeProfile : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["EmpID"]) != null && Convert.ToString(Session["EmpID"]) != "")
        {
            lblId.InnerText = Convert.ToString(Session["EmpID"]);
        }

        if (!IsPostBack)
        {
            loadRecord();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string addr1 = txtAddress1.Text;
            string addr2 = txtAddress2.Text;
            string city = txtCity.Text;
            string state = txtState.Text;
            string zipcode = txtZipcode.Text;
            string phone = txtPhoneNumber.Text;
            string date = DateTime.Now.ToString("yyyy-MM-dd h:mm tt");
            int empid = 0;
            int.TryParse(lblId.InnerText, out empid);

            DataBase DB = new DataBase();

            string getaddr = "Select * from EmployeeAddress where emp_id='" + empid + "'";
            DataTable dt = DB.ExcutesQuery(getaddr);
            if (dt.Rows.Count > 0)
            {
                string UptEMP = "Update Employee Set Fname='" + txtFirstname.Text + "', Mname='" + txtMiddlename.Text + "', Lname='" + txtLastname.Text + "', PhoneNO='" + txtPhoneNumber.Text + "' Where ID='" + empid + "'";
                DB.UpdateData(UptEMP);

                int addrid = 0;
                int.TryParse(dt.Rows[0]["ID"].ToString(), out addrid);
                string Updtaddr = "Update EmployeeAddress Set Address1='" + addr1 + "',Address2='" + addr2 + "',City='" + city + "',State='" + state + "',Zipcode='" + zipcode + "',PhoneNo='" + phone + "',date_updated='" + date + "' " +
                                  "where emp_id='" + empid + "' and ID='" + addrid + "'";
                DB.UpdateData(Updtaddr);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert(Updated)", true);
            }
            else
            {
                string UptEMP = "Update Employee Set Fname='" + txtFirstname.Text + "', Mname='" + txtMiddlename.Text + "', Lname='" + txtLastname.Text + "', PhoneNO='" + txtPhoneNumber.Text + "' Where ID='" + empid + "'";
                DB.UpdateData(UptEMP);

                string Insrtaddr = "Insert into EmployeeAddress(emp_id,Address1,Address2,City,State,Zipcode,PhoneNo,date_updated)Values" +
                               "('" + empid + "','" + addr1 + "','" + addr2 + "','" + city + "','" + state + "','" + zipcode + "','" + phone + "','" + date + "')  select SCOPE_IDENTITY()";
                int empaddrid = DB.ExcuteQuery(Insrtaddr);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert(Updated)", true);
            }
        }
        catch(Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On btnSubmit_Click: " + ex.Message + "')", true);
        }
    }

    protected void loadRecord()
    {
        try
        {
            int empid = 0;
            int.TryParse(lblId.InnerText, out empid);
            string getempdetail = "Select * from Employee a left outer join EmployeeAddress b on a.ID=b.emp_id  where a.ID='" + empid + "'";
            string getrecord = "Select * from EmployeeAddress where emp_id='" + empid + "'";
            DataBase DB = new DataBase();
            DataTable _dt = DB.ExcutesQuery(getempdetail);
            if (_dt.Rows.Count > 0)
            {
                txtFirstname.Text = Convert.ToString(_dt.Rows[0]["Fname"]);
                txtMiddlename.Text = Convert.ToString(_dt.Rows[0]["Mname"]);
                txtLastname.Text = Convert.ToString(_dt.Rows[0]["Lname"]);
                txtEmailid.Text = Convert.ToString(_dt.Rows[0]["EmailID"]);
                txtPhoneNumber.Text = Convert.ToString(_dt.Rows[0]["PhoneNO"]);
            //}
            //DataTable dt = DB.ExcutesQuery(getrecord);
            //if (dt.Rows.Count > 0)
            //{
                txtAddress1.Text = Convert.ToString(_dt.Rows[0]["Address1"]);
                txtAddress2.Text = Convert.ToString(_dt.Rows[0]["Address2"]);
                txtCity.Text = Convert.ToString(_dt.Rows[0]["City"]);
                txtState.Text = Convert.ToString(_dt.Rows[0]["State"]);
                txtZipcode.Text = Convert.ToString(_dt.Rows[0]["Zipcode"]);
                //txtPhoneNumber.Text = Convert.ToString(_dt.Rows[0]["PhoneNo"]);
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On loadRecord: " + ex.Message + "')", true);
        }
    }
}