using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Data.SqlClient;
using System.Configuration; 

public partial class ManageProject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    protected void BindGrid()
    {
        try
        {
            string Query = "Select  ProjectId,Project_Name,Status, Convert(nvarchar(12), Due_Date, 101) as Due_Date  from Project ORDER BY Created_Date asc";
            DataBase DB = new DataBase();
            DataTable dt = DB.ExcutesQuery(Query);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
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
        catch (Exception ex)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On BindGrid: " + ex.Message + "')", true);
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
                    Label gvemp = e.Row.FindControl("gvemp") as Label;
                    DataTable dt = DB.ExcutesQuery(string.Format("Select b.Fname+' '+b.Mname+' '+b.Lname + ', ' from ProjectAssign_Emp a join Employee  b on a.EmpId=b.ID Where a.ProjectId='{0}' FOR XML PATH('')", Id));
                    string emp = null;
                    if (dt.Rows.Count > 0)
                    {
                        emp = dt.Rows[0][0].ToString();                       
                        emp = emp.TrimEnd(' ');
                        emp = emp.TrimEnd(',');
                    }
                    var text = emp.Split(',');
                    int more = text.Count();
                    string fname = "";
                    string lname = "";
                    if (more > 1)
                    {
                        for (int z = 0; z < more; z++)
                        {
                            if (z == 0)
                            {
                                int count = more - 1;
                                fname = text[z] + " + " + count + " more</b>";
                                gvemp.Text = fname;
                            }
                            else
                            {
                                lname += text[z] + ",";                               
                            }
                        }                        
                        lname = lname.TrimEnd(',');
                        gvemp.ToolTip = lname;
                    }
                    else
                    {
                        gvemp.Text = emp.Replace(", ", ",</br>");
                    }            
                    
                }
            }
        }
        catch (Exception ex)
        {
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On Employeebind in Gridview: " + ex.Message + "')", true);
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Deletes")
        {
            try
            {
                string id = e.CommandArgument.ToString();
                string Query = "delete FROM ProjectAssign_Emp where ProjectId='" + id + "'" + " " + "delete FROM Project where ProjectId='" + id + "'";
                DataBase DB = new DataBase();
                DB.DeleteData(Query);
                BindGrid();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "PopUp", "alert('Error On Delete: " + ex.Message + "')", true);
            }
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGrid();
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProjectAdd.aspx");
    }
    protected void btnImportCSV_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.HasFile)
            {
                string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);  //Get extension

                if (fileExt == ".csv")   //check to see if its a .csv file
                {
                    Random rand = new Random();
                    int uinq = rand.Next(1000, 9999);
                    string csv = DateTime.Now.Date.ToString("ddMM") + uinq + FileUpload1.FileName;
                    string filePath = Server.MapPath("~/FilesUpload/Project_CSV/") + csv;
                    FileUpload1.SaveAs(filePath);

                    DataTable dt = GetDataTabletFromCSVFile(filePath);
                    if (dt != null && dt.Rows.Count > 1)
                    {
                        using (SqlBulkCopy sbc = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString, SqlBulkCopyOptions.KeepIdentity))
                        {
                            sbc.DestinationTableName = "Project";
                            sbc.BatchSize = 5;
                            sbc.ColumnMappings.Add("Project Name", "Project_Name");
                            sbc.ColumnMappings.Add("Status", "Status");
                            sbc.ColumnMappings.Add("Start Date", "Start_Date");
                            sbc.ColumnMappings.Add("Due Date", "Due_Date");
                            sbc.WriteToServer(dt);
                        }
                    }
                    if (csv != "")
                    {
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                    }
                    BindGrid();
                }
            }
        }
        catch(Exception ex)
        {
            Response.Write(ex);
        }
    }
    public static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {            
            DataTable csvData = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;

                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }

                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        for (int i = 0; i < fieldData.Length; i++)
                        {                            
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
               
            }
            return csvData;
        }

    }
