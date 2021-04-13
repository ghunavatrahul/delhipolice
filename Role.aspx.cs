using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

public partial class Role : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //BindPage();
            FillGrid();
        }
    }
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
        FillGrid();
    }

    protected void FillGrid()
    {
        try
        {
            string Query = "Select * from Role";
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(Query);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                GridView1.SelectedIndex = -1;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GridView1.DataSource = dt;
                GridView1.DataBind();
                int columncount = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                GridView1.Rows[0].Cells[0].Text = "No Records Found";
            }
        }
        catch(Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error on FillGrid: " + ex.Message + "')", true);
        }
    }
      

    //protected void btnSave_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string roleid = lblId.InnerText;
    //        int _roleid = 0;
    //        int.TryParse(roleid,out _roleid);
    //        string Roles = txtRolename.Text;
    //        bool status=chkStatus.Checked;
    //        string selectedValues = string.Empty;
    //        foreach (ListItem li in lstBoxTest.Items)
    //        {
    //            if (li.Selected == true)
    //            {
    //                selectedValues += li.Value + ",";
    //            }
    //        }
    //        selectedValues = selectedValues.TrimEnd(',');
    //        string[] page = selectedValues.Split(',');
    //        DataBase DB = new DataBase();
    //        if (_roleid > 0)
    //        {
    //            string Query = "Update Role Set role_name = '" + Roles + "', status = '" + status + "' Where role_id = '" + _roleid + "' ";
    //            string result = DB.UpdateData(Query);
    //            string query = "Delete from Role_Access_Page where role_id='" + _roleid + "'";
    //            DB.DeleteData(query);  
    //            for (int i = 0; i < page.Length; i++)
    //            {
    //                string Query1 = "Insert into Role_Access_Page(role_id,Page)values('" + _roleid + "','" + page[i] + "')  select SCOPE_IDENTITY()";
                    
    //                int emprole = DB.ExcuteQuery(Query1); 
    //                if (emprole > 0)
    //                {
    //                   string Result = "Success";
    //                }
    //            }
    //            lblId.InnerText = "";
    //            txtRolename.Text = "";
    //            chkStatus.Checked = false;
    //            lstBoxTest.SelectedIndex = -1;
    //            FillGrid();
    //        }
    //        else
    //        {
    //            string Query = "Insert into Role(role_name,status)Values('" + Roles + "','" + status + "')  select SCOPE_IDENTITY() ";
               
    //            int id = DB.ExcuteQuery(Query);
    //            if (id > 0)
    //            {
    //                for (int i = 0; i < page.Length; i++)
    //                {
    //                    string Query1 = "Insert into Role_Access_Page(role_id,Page)Values('" + id + "','" + page[i] + "') select SCOPE_IDENTITY() ";
    //                    int ids = DB.ExcuteQuery(Query1);
    //                }
    //                lblId.InnerText = "";
    //                txtRolename.Text = "";
    //                chkStatus.Checked = false;
    //                lstBoxTest.SelectedIndex = -1;
    //                FillGrid();
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('" + ex + "')", true);
    //    }
    //}

    //protected void btnCancel_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        lblId.InnerText = "";
    //        txtRolename.Text = "";
    //        chkStatus.Checked = false;
    //        lstBoxTest.SelectedIndex = -1;
    //        FillGrid();
    //    }
    //    catch (Exception ex)
    //    {
    //        ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('" + ex + "')", true);
    //    }
    //}

    protected void btnAddRole_Click(object sender, EventArgs e)
    {
        Response.Redirect("RoleAdd.aspx");
    }

    //protected void BindPage()
    //{
    //    try
    //    {
    //        String rootPath = Server.MapPath("~");
    //        string Folder = rootPath;
    //        DirectoryInfo d = new DirectoryInfo(Folder);
    //        FileInfo[] Files = d.GetFiles("*.aspx");
    //        foreach (FileInfo file in Files)
    //        {
    //            int index = file.Name.IndexOf('.');
    //            string filename = file.Name.Remove(index);
    //            lstBoxTest.Items.Add(filename);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('" + ex + "')", true);
    //    }
    //}

    //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        int selectedIndex = GridView1.SelectedIndex;
    //        string _id = GridView1.DataKeys[selectedIndex].Value.ToString();
    //        Session["ID"] = _id;
    //        Response.Redirect("RoleAdd.aspx");
    //        //lblId.InnerText = _id;
    //        //int id = 0;
    //        //int.TryParse(_id, out id);

    //        //string Query = "Select rol.role_id,rol.role_name,rol.status,page.Page from Role rol "+
    //        //                "Left join Role_Access_Page page on rol.role_id=page.role_id "+
    //        //                "Where rol.role_id='" + id + "'";

    //        //DataBase DB = new DataBase();
    //        //DataTable dt = DB.ExcutesQuery(Query);
    //        //if (dt.Rows.Count > 0)
    //        //{
    //        //    txtRolename.Text = dt.Rows[0]["role_name"].ToString();              

    //        //    bool active = false;
    //        //    bool.TryParse(dt.Rows[0]["status"].ToString(), out active);
    //        //    chkStatus.Checked = active;
    //        //    for (int i = 0; i < dt.Rows.Count; i++)
    //        //    {
    //        //        string page = dt.Rows[i]["Page"].ToString();
    //        //        if (page == null && page == "")
    //        //        {
    //        //            lstBoxTest.SelectedIndex = -1;
    //        //        }
    //        //        else
    //        //        {
    //        //            lstBoxTest.Items.FindByValue(page).Selected = true;
    //        //        }
    //        //    }
    //        //}
    //    }
    //    catch (Exception ex)
    //    {
    //        ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error : '" + ex + "'')", true);
    //    }
    //}
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        FillGrid();
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Deletes")
        {
            try
            {
                string roleid = e.CommandArgument.ToString();
                string Query = "delete FROM Employee_Role where role_id='" + roleid + "' " + " delete FROM Role_Access_Page where role_id='" + roleid + "' " + "delete FROM Role where role_id='" + roleid + "' ";
                DataBase DB = new DataBase();
                DB.DeleteData(Query);
                FillGrid();
            }

            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On Delete: " + ex.Message + "')", true);

            }
        }
    }

    protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataBase DB = new DataBase();
                string Id = GridView1.DataKeys[e.Row.RowIndex].Value.ToString();
                if (Id != null && Id != "")
                {
                    Label gvpages = e.Row.FindControl("gvpages") as Label;
                    DataTable dt = DB.ExcutesQuery(string.Format("Select c.Page_Name + ', ' from Role a join Role_Access_Page b on a.role_id=b.role_id join Page c on b.Page=c.Page_ID where a.role_id='{0}' FOR XML PATH('')", Id));
                    string pages = null;
                    if (dt.Rows.Count > 0)
                    {
                        pages = dt.Rows[0][0].ToString();
                        pages = pages.TrimEnd(' ');
                        pages = pages.TrimEnd(',');
                    }
                    //gvpages.Text = pages.Replace(", ", ",</br>");

                    var text = pages.Split(',');
                    int more = text.Count();
                    string fpage = "";
                    string opage = "";
                    if (more > 1)
                    {
                        for (int z = 0; z < more; z++)
                        {
                            if (z == 0)
                            {
                                int count = more - 1;
                                fpage = text[z] + " + " + count + " more</b>";
                                gvpages.Text = fpage;
                            }
                            else
                            {
                                opage += text[z] + ",";
                                //gvassignto.ToolTip = lname;
                            }
                        }
                        //Label lblassignto = e.Row.FindControl("lblassignto") as Label;
                        opage = opage.TrimEnd(',');
                        gvpages.ToolTip = opage;
                    }
                    else
                    {
                        gvpages.Text = pages.Replace(", ", ",</br>");
                    } 
                }
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On Rolesbind in Gridview: " + ex.Message + "')", true);
        }
    }
}