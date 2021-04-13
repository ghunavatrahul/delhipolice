using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Page : System.Web.UI.Page
{
    string Empid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmpID"].ToString() != null || Session["EmpID"].ToString() != "")
        {
            Empid = Session["EmpID"].ToString();
        }
        //loadrecord();
    }

    //protected void loadrecord()
    //{
    //    string query = "Select * from Employee where ID='" + Empid + "'";
    //    DataBase DB = new DataBase();
    //    DataTable dt = DB.ExcutesQuery(query);
    //    if (dt.Rows.Count > 0)
    //    {
    //        string name = dt.Rows[0]["Fname"].ToString() + " " + dt.Rows[0]["Mname"].ToString() + " " + dt.Rows[0]["Lname"].ToString();
    //        ((Admin_Admin)this.Master).LabelValue = name;
    //        ((Admin_Admin)this.Master).LabelValue1 = name;
    //    }
    //}

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            bool active = false;
            bool.TryParse(chkActive.Checked.ToString(),out active);
            string query = "Insert into Page(Name,EmpId,Status)Values('" + txtName.Text + "','" + Empid + "','" + active + "')  Select SCOPE_IDENTITY()";
            DataBase DB = new DataBase();
            int id = DB.ExcuteQuery(query);
            if (id > 0)
            {
                txtName.Text = "";
                chkActive.Checked = false;
                ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Successfully Inserted')", true);
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On Submit')", true);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            lblId.InnerText = "";
            txtName.Text = "";
            chkActive.Checked = false;
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On Cancel')", true);
        }
    }
}