using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class Home : System.Web.UI.Page
{
    string Empid="";
    string[] Pages;
    protected void Page_Load(object sender, EventArgs e)
    {
       if (Convert.ToString(Session["EmpID"]) != null && Convert.ToString(Session["EmpID"]) != "")
        {        
            Empid = Session["EmpID"].ToString();            
        }
       loadrecord();
    }

    readonly PagedDataSource _pgsource = new PagedDataSource();
    int _firstIndex, _lastIndex;
    private int _pageSize = 10;

    private int CurrentPage
    {
        get
        {
            if (ViewState["CurrentPage"] == null)
            {
                return 0;
            }
            return ((int)ViewState["CurrentPage"]);
        }
        set
        {
            ViewState["CurrentPage"] = value;
        }
    }

    protected void loadrecord()
    {
        try
        {
            string SPname = "Sp_GetTaskNotification";
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcuteStoredProcedure(SPname);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count < 10)
                {
                    rptPaging.Visible = false;
                }
                _pgsource.DataSource = dt.DefaultView;
                _pgsource.AllowPaging = true;
                // Number of items to be displayed in the Repeater
                _pgsource.PageSize = _pageSize;
                _pgsource.CurrentPageIndex = CurrentPage;
                // Keep the Total pages in View State
                ViewState["TotalPages"] = _pgsource.PageCount;


                RepMenu.DataSource = _pgsource;
                RepMenu.DataBind();

                // Call the function to do paging
                HandlePaging();
            }
        }
        catch(Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On loadrecord: " + ex.Message + "')", true);
        }
    }

    private void HandlePaging()
    {
        var dt = new DataTable();
        dt.Columns.Add("PageIndex"); //Start from 0
        dt.Columns.Add("PageText"); //Start from 1

        _firstIndex = CurrentPage - 5;
        if (CurrentPage > 5)
            _lastIndex = CurrentPage + 5;
        else
            _lastIndex = 10;

        // Check last page is greater than total page then reduced it 
        // to total no. of page is last index
        if (_lastIndex > Convert.ToInt32(ViewState["TotalPages"]))
        {
            _lastIndex = Convert.ToInt32(ViewState["TotalPages"]);
            _firstIndex = _lastIndex - 10;
        }

        if (_firstIndex < 0)
            _firstIndex = 0;

        // Now creating page number based on above first and last page index
        for (var i = _firstIndex; i < _lastIndex; i++)
        {
            var dr = dt.NewRow();
            dr[0] = i;
            dr[1] = i + 1;
            dt.Rows.Add(dr);
        }

        rptPaging.DataSource = dt;
        rptPaging.DataBind();
    }


    protected void rptPaging_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (!e.CommandName.Equals("newPage")) return;
        CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
        loadrecord();
    }

    protected void rptPaging_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        var lnkPage = (LinkButton)e.Item.FindControl("lbPaging");
        if (lnkPage.CommandArgument != CurrentPage.ToString()) return;
        lnkPage.Enabled = false;
        lnkPage.BackColor = Color.FromName("rgba(192, 192, 192, 0.28);");
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        DateTime date ;
        DateTime.TryParse(Calendar1.SelectedDate.ToString(),out date);       

        string selecteddate = date.ToString("yyyy-MM-dd");
        string getselectedtask = "Select * from Task where Start_Date_Time='" + selecteddate + "'";
        DataBase DB = new DataBase();
        DataTable dt = DB.ExcutesQuery(getselectedtask);
        if (dt.Rows.Count > 0)
        {
            GridView1.Visible = true;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else
        {
            GridView1.Visible = false;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('No tasks')", true);
            return;
            //Label1.Text = "No tasks";
        }
        
    }
}