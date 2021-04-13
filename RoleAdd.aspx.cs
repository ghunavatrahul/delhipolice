using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class RoleAdd : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindPage();
            Loadrecord();
        }
    }

    protected void BindPage()
    {
        try
        {
            //String rootPath = Server.MapPath("~");
            //string Folder = rootPath;
            //DirectoryInfo d = new DirectoryInfo(Folder);
            //FileInfo[] Files = d.GetFiles("*.aspx");
            //foreach (FileInfo file in Files)
            //{
            //    int index = file.Name.IndexOf('.');
            //    string filename = file.Name.Remove(index);
            //    lstBoxTest.Items.Add(filename);
            //}

            //string getpage = "Select * from Page where Status='true'";
            string getpage = "Select * from Page where Status='true' and Priority <> '0' order by Priority";
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(getpage);
            lstBoxTest.DataSource = dt;
            lstBoxTest.DataTextField = "Page_Name";
            lstBoxTest.DataValueField = "Page_ID";
            lstBoxTest.DataBind();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error on BindPage: " + ex.Message + "')", true);
        }
    }

    protected void Loadrecord()
    {
        try
        {
            lblId.InnerText = Request.QueryString["ID"];
            //lblId.InnerText = Convert.ToString(Session["ID"]);
            int id = 0;
            int.TryParse(lblId.InnerText, out id);

            string Query = "Select rol.role_id,rol.role_name,rol.status,page.Page from Role rol " +
                            "Left join Role_Access_Page page on rol.role_id=page.role_id " +
                            "Where rol.role_id='" + id + "'";

            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(Query);
            if (dt.Rows.Count > 0)
            {
                txtRolename.Text = dt.Rows[0]["role_name"].ToString();

                bool active = false;
                bool.TryParse(dt.Rows[0]["status"].ToString(), out active);
                chkStatus.Checked = active;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string page = dt.Rows[i]["Page"].ToString();
                    if (page == null || page == "")
                    {
                        lstBoxTest.SelectedIndex = -1;
                    }
                    else
                    {
                        lstBoxTest.Items.FindByValue(page).Selected = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error on Loadrecord: " + ex.Message + "')", true);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            lblId.InnerText = "";
            txtRolename.Text = "";
            chkStatus.Checked = false;
            lstBoxTest.SelectedIndex = -1;
            Session["ID"] = "0";
            Response.Redirect("Role.aspx");
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error on btnCancel_Click: " + ex.Message + "')", true);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string roleid = lblId.InnerText;
            int _roleid = 0;
            int.TryParse(roleid, out _roleid);
            string Roles = txtRolename.Text;
            bool status = chkStatus.Checked;
            string selectedValues = string.Empty;
            foreach (ListItem li in lstBoxTest.Items)
            {
                if (li.Selected == true)
                {
                    selectedValues += li.Value + ",";
                }
            }
            selectedValues = selectedValues.TrimEnd(',');
            string[] page = selectedValues.Split(',');
            DataBase DB = new DataBase();
            if (_roleid > 0)
            {
                string Query = "Update Role Set role_name = '" + Roles + "', status = '" + status + "' Where role_id = '" + _roleid + "' ";
                string result = DB.UpdateData(Query);
                string query = "Delete from Role_Access_Page where role_id='" + _roleid + "'";
                DB.DeleteData(query);
                for (int i = 0; i < page.Length; i++)
                {
                    string Query1 = "Insert into Role_Access_Page(role_id,Page)values('" + _roleid + "','" + page[i] + "')  select SCOPE_IDENTITY()";

                    int emprole = DB.ExcuteQuery(Query1);
                    if (emprole > 0)
                    {
                        string Result = "Success";
                    }
                }
                lblId.InnerText = "";
                txtRolename.Text = "";
                chkStatus.Checked = false;
                lstBoxTest.SelectedIndex = -1;
                Session["ID"] = "0";
                Response.Redirect("Role.aspx");
            }
            else
            {
                string Query = "Insert into Role(role_name,status)Values('" + Roles + "','" + status + "')  select SCOPE_IDENTITY() ";

                int id = DB.ExcuteQuery(Query);
                if (id > 0)
                {
                    for (int i = 0; i < page.Length; i++)
                    {
                        string Query1 = "Insert into Role_Access_Page(role_id,Page)Values('" + id + "','" + page[i] + "') select SCOPE_IDENTITY() ";
                        int ids = DB.ExcuteQuery(Query1);
                    }
                    lblId.InnerText = "";
                    txtRolename.Text = "";
                    chkStatus.Checked = false;
                    lstBoxTest.SelectedIndex = -1;
                    Session["ID"] = "0";
                    Response.Redirect("Role.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error on btnSave_Click: " + ex.Message + "')", true);
        }
    }
}