using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Attendance : System.Web.UI.Page
{
    SqlConnection conec = new SqlConnection(ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString);
    string role = "";
    string Empid = "";
    string Year = "";

    string gridcondition = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["EmpID"]) != null || Convert.ToString(Session["EmpID"]) != "")
        {
            Empid = Convert.ToString(Session["EmpID"]);

        }
        if (!Page.IsPostBack)
        {
            year();
            gridcondition = "where year(b.Adate) = '" + Year + "'";
            GridViewBind();
           

        }
    }
    private void GridViewBind()
    {
        string Query = "select a.ID, a.Fname,a.Mname,a.Lname ,convert(char(8), Intime, 108) as Intime,convert(char(8), Outtime, 108) as Outtime, CONVERT(VARCHAR(11), b.Adate,113) as Adate, Convert(varchar, b.outtime -b.Intime, 108) as aHours  from Employee a join Attendance b on a.ID=b.Empid " + gridcondition + "";
        DataBase DB = new DataBase();
        DataTable dt = DB.ExcutesQuery(Query);
        if (dt.Rows.Count > 0)
        {
            Gdv_Attendance.DataSource = dt;
            Gdv_Attendance.DataBind();
        }
        else
        {
            dt.Rows.Add(dt.NewRow());
            Gdv_Attendance.DataSource = dt;
            Gdv_Attendance.DataBind();
            int columncount = Gdv_Attendance.Rows[0].Cells.Count;
            Gdv_Attendance.Rows[0].Cells.Clear();
            Gdv_Attendance.Rows[0].Cells.Add(new TableCell());
            Gdv_Attendance.Rows[0].Cells[0].ColumnSpan = columncount;
            Gdv_Attendance.Rows[0].Cells[0].Text = "No Records Found";
        }

    }
    private void monnth ()
    {

        string Query = "select  month(Adate) as atmonth from Attendance  where year(Adate)='"+ddlyear.SelectedItem.Text.Trim()+"' group by month(Adate) ";
        DataBase DB = new DataBase();
        DataTable dt = DB.ExcutesQuery(Query);
        if (dt.Rows.Count > 0)
        {
           ddlyear.DataSource = dt;
            Gdv_Attendance.DataBind();
        }
        else
        {
            dt.Rows.Add(dt.NewRow());
            Gdv_Attendance.DataSource = dt;
            Gdv_Attendance.DataBind();
            int columncount = Gdv_Attendance.Rows[0].Cells.Count;
            Gdv_Attendance.Rows[0].Cells.Clear();
            Gdv_Attendance.Rows[0].Cells.Add(new TableCell());
            Gdv_Attendance.Rows[0].Cells[0].ColumnSpan = columncount;
            Gdv_Attendance.Rows[0].Cells[0].Text = "No Records Found";
        }

    }
    private void year()
    {
        //Gdv_Attendance.
        string Query = "select top 1 year(Adate) as atyear from Attendance";
        DataBase DB = new DataBase();
        DataTable dt = DB.ExcutesQuery(Query);
        if (dt.Rows.Count > 0)
        {
            
            DataRow dr;
            dr = dt.NewRow();
            ddlyear.DataSource = dt;
            // ddlyear.DataValueField = "Id";
            Year = Convert.ToString(dt.Rows[0]["atyear"]);
            ddlyear.DataTextField = "atyear";
            ddlyear.DataBind();
            ddlyear.Items.Insert(0, new ListItem("--Select Year--", " "));
          
           
        }
        else
        {
            //dt.Rows.Add(dt.NewRow());
            //Gdv_Attendance.DataSource = dt;
            //Gdv_Attendance.DataBind();
            //int columncount = Gdv_Attendance.Rows[0].Cells.Count;
            //Gdv_Attendance.Rows[0].Cells.Clear();
            //Gdv_Attendance.Rows[0].Cells.Add(new TableCell());
            //Gdv_Attendance.Rows[0].Cells[0].ColumnSpan = columncount;
            //Gdv_Attendance.Rows[0].Cells[0].Text = "No Records Found";
        }

    }
    private void date()
    {

        string Query = "select a.ID, a.Fname+' '+a.Mname+' '+a.Lname as Empname , b.Intime,b.Outtime, b.Adate,Convert(varchar, b.outtime -b.Intime, 108) as aHours from Employee a join Attendance b on a.ID=b.Empid where a.Id='" + Empid + "'";
        DataBase DB = new DataBase();
        DataTable dt = DB.ExcutesQuery(Query);
        if (dt.Rows.Count > 0)
        {
            //Gdv_Attendance.DataSource = dt;
            //Gdv_Attendance.DataBind();
        }
        else
        {
            //dt.Rows.Add(dt.NewRow());
            //Gdv_Attendance.DataSource = dt;
            //Gdv_Attendance.DataBind();
            //int columncount = Gdv_Attendance.Rows[0].Cells.Count;
            //Gdv_Attendance.Rows[0].Cells.Clear();
            //Gdv_Attendance.Rows[0].Cells.Add(new TableCell());
            //Gdv_Attendance.Rows[0].Cells[0].ColumnSpan = columncount;
            //Gdv_Attendance.Rows[0].Cells[0].Text = "No Records Found";
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlyear.SelectedIndex==0 || ddlmonth.SelectedIndex== 0)
        {
             // ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            // Response.Write("<script>alert('Please fill any search fields!')</script>");
            //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "Please fill any search fields!", false);
        }
        else
        { 
        Year = ddlyear.SelectedItem.Text.ToString();
        gridcondition = "where year(b.Adate) = '" + Year + "' and month(b.Adate)='" + ddlmonth.SelectedValue.ToString() + "'";
        GridViewBind();
        }
    }

    protected void ddlmonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        
       
    }



    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {

       // monnth();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    //protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Gdv_Attendance.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
    //    GridViewBind();
    //}
}