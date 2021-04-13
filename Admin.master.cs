using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Admin : System.Web.UI.MasterPage
{
    string Empid = "";
    string roleid = "";
    string rolename = "";
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (Convert.ToString(Session["EmpID"]) != null && Convert.ToString(Session["EmpID"]) != "")
        {
            Empid = Convert.ToString(Session["EmpID"]);
            roleid = Convert.ToString(Session["RoleID"]);
            rolename = Convert.ToString(Session["RoleName"]);
        }       
        else
        {
           Response.Redirect("index.aspx");
        }

        if (!Page.IsPostBack)
        {            
            loadrecord();
            Loadpages();
            LoadRoles();
        }

        if (Convert.ToBoolean(Session["flag"]) == true)
        {
            CheckingURL();
        }
    }

    protected void loadrecord()
    {
        string getEmp = "Select * from FieldWorkMgt_DB.dbo.Employee where ID='" + Empid + "'";
        DataBase DB = new DataBase();
        DataTable dt = DB.ExcutesQuery(getEmp);
        if (dt.Rows.Count > 0)
        {
            string name = dt.Rows[0]["Fname"].ToString() + " " + dt.Rows[0]["Mname"].ToString() + " " + dt.Rows[0]["Lname"].ToString() + "<br/> <p id='showrole' style='margin-top: -4px;float: right;font-size: 10px;'>" + Convert.ToString(Session["RoleName"]) + "</p>";
            lblname.Text = name;
            lblname1.Text = name;         
            //lblrole.Text = rolename;
        }

    }

    protected void Loadpages()
    {
        string getPages = "select distinct emp.emp_id, rol.Page, pg.Page_Name, pg.Name, pg.Priority from FieldWorkMgt_DB.dbo.Employee_Role emp " +
                            " Left outer join FieldWorkMgt_DB.dbo.Role_Access_Page rol on emp.role_id=rol.role_id " +
                            " Left Outer join FieldWorkMgt_DB.dbo.Page pg on rol.Page=pg.Page_ID where pg.Status!=0 and emp.emp_id='" + Empid + "' and emp.role_id='" + Convert.ToString(Session["RoleID"]) + "'  order by pg.Priority";
        DataBase DB = new DataBase();
        DataTable dt = DB.ExcutesQuery(getPages);
        if (dt.Rows.Count > 0)
        {
            RepMenu.DataSource = dt;
            RepMenu.DataBind();           
        }       
    }

    protected void LoadRoles()
    {
        string getRoles = "Select emp.role_id, emp.emp_id,rol.role_name from FieldWorkMgt_DB.dbo.Employee_Role emp " +
                           " Left outer join FieldWorkMgt_DB.dbo.Role rol on emp.role_id=rol.role_id where emp.emp_id='" + Empid + "' ";

        DataBase DB = new DataBase();
        DataTable dt = DB.ExcutesQuery(getRoles);
        if (dt.Rows.Count > 0)
        {
            RepRole.DataSource = dt;
            RepRole.DataBind();
        }   
    }

    protected void CheckingURL()
    {
        Session["flag"] = false;
        //string url = HttpContext.Current.Request.Url.AbsoluteUri;
        string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
        string sRet = oInfo.Name;
        string[] pagename = sRet.Split('.');
        if (Empid != null || Empid != "")
        {
            string getPages = "select distinct emp.emp_id, rol.Page from FieldWorkMgt_DB.dbo.Employee_Role emp " +
                              "Left outer joinFieldWorkMgt_DB.dbo. Role_Access_Page rol on emp.role_id=rol.role_id where emp.emp_id='" + Empid + "' and rol.Page='" + pagename[0] + "'";
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(getPages);
            if (dt.Rows.Count > 0)
            {
                Response.Redirect("" + pagename[0] + ".aspx");
            }
            else
            {
                Response.Redirect("PS_home.aspx");
            }
        }
        else
        {
            Response.Redirect("index.aspx");
        }
    }

    //public string LabelValue
    //{
    //    get { return this.lblname.Text; }
    //    set { this.lblname.Text = value; }
    //}

    //public string LabelValue1
    //{
    //    get { return this.lblname1.Text; }
    //    set { this.lblname1.Text = value; }
    //}

    protected void btnsignout_Click(object sender, EventArgs e)
    {
        Session["EmpID"] = "";
        Response.Redirect("index.aspx");
    }

    protected void btnprofile_Click(object sender, EventArgs e)
    {
        Session["EmpID"] = Empid;
        Response.Redirect("EmployeeProfile.aspx");
    }

    protected void btnChangepsswd_Click(object sender, EventArgs e)
    {
        Session["EmpID"] = Empid;
        Response.Redirect("ChangePassword.aspx");
    }

    protected void RepRole_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "role")
        {
            string role = e.CommandArgument.ToString();
            string getrole = "select * from FieldWorkMgt_DB.dbo.Role where role_name='" + role + "'";
            DataBase Db = new DataBase();
            DataTable dt = Db.ExcutesQuery(getrole);
            if (dt.Rows.Count > 0)
            {
                Session["RoleName"] = Convert.ToString(dt.Rows[0]["role_name"]);
                Session["RoleID"] = Convert.ToString(dt.Rows[0]["role_id"]);
                loadrecord();
                Loadpages();
                LoadRoles();
				Response.Redirect("Home.aspx");
            }
        }
    }

    protected void RepMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label lbladmin = e.Item.FindControl("lblID") as Label;
        Repeater Repmenu1 = e.Item.FindControl("Repmenu1") as Repeater;

        string getadminpage = "Select a.ID,a.Name,a.Page_name from FieldWorkMgt_DB.dbo.Childpage a join FieldWorkMgt_DB.dbo.Page b on a.Parent_PageId = b.Page_ID where a.Status='true' and a.Parent_PageId = '" + lbladmin.Text + "'";
        DataBase Db = new DataBase();
        DataTable dt = Db.ExcutesQuery(getadminpage);
        if (dt.Rows.Count > 0)
        {
            Repmenu1.DataSource = dt;
            Repmenu1.DataBind();
        }
    }
}
