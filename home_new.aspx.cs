using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI.WebControls;

public partial class home_new : System.Web.UI.Page
{
    string str = ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        totproducts();
        totcustomers();
        totvendors();
        totdeliveries();
        DeliveryStatus();
        productbind();
        taskbind();
    }

    public void totproducts()
    {
        string Query = "select count(*) AS Id from FieldWorkMgt_DB.dbo.items";
        Console.Out.WriteLine(str);
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            totproduct.Text = Convert.ToString(dt.Rows[0]["Id"]);
        }
        con.Close();
    }
    public void totcustomers()
    {
        string Query = "select count(*) AS Id from FieldWorkMgt_DB.dbo.Customer";
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            totcustomer.Text = Convert.ToString(dt.Rows[0]["Id"]);
        }
        con.Close();
    }
    public void totdeliveries()
    {
        string Query = "select count(*) AS Id from FieldWorkMgt_DB.dbo.Delivery";
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            totdelivery.Text = Convert.ToString(dt.Rows[0]["Id"]);
        }
        con.Close();
    }
    public void totvendors()
    {
        string Query = "select count(*) AS Id from FieldWorkMgt_DB.dbo.Vendor";
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        while (dr.Read())
        {
            totvendor.Text = Convert.ToString(dt.Rows[0]["Id"]);
        }
        con.Close();
    }
    public void DeliveryStatus()
    {
        string Query = "select a.DeliveryID, c.Title, b.Deliverystatus AS [Delivery Status], d.Fname+' '+d.Mname+' '+d.Lname AS [Assign To]   from FieldWorkMgt_DB.dbo.Delivery a " +
                                    "join FieldWorkMgt_DB.dbo.Employee d on a.Assignto=d.ID " +
                                    "join FieldWorkMgt_DB.dbo.deliveryStatus b on a.deliveryID=b.deliveryId " +
                                    "join FieldWorkMgt_DB.dbo.Items c on a.Itemid=c.Id";
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DeliveryStatus();
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }
    public void productbind()
    {
        string Query = "select top 3 title, [Description], [image] from FieldWorkMgt_DB.dbo.items ORDER BY [Created_Date] DESC";
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }
    public void taskbind()
    {
        string Query = "Select TaskID, TaskTitle,CONVERT(VARCHAR(11), Due_Date_Time,113) as Due_Date_Time,TaskPriority,status from FieldWorkMgt_DB.dbo.Task join FieldWorkMgt_DB.dbo.Employee on Task.Assignedby=Employee.ID Order by CONVERT(DateTime, Due_Date_Time,101) asc";
        SqlConnection con = new SqlConnection(str);
        SqlCommand com = new SqlCommand(Query, con);
        SqlDataAdapter sda = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        RepToDo.DataSource = dt;
        RepToDo.DataBind();
    }
    [WebMethod]
    public static string Task(string query)
    {
        return query;
    }

}