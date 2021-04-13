
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


public class DataBase
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FieldWorkMgt_DBConnectionString"].ConnectionString);

    public DataTable ExcuteStoredProcedure(string SP)
    {
        DataTable dt = new DataTable();
        con.Open();
        SqlCommand cmd = new SqlCommand(SP, con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        sda.Fill(dt);
        con.Close();

        return dt;
    }

    public int ExcuteQuery(string Query)
    {
        int id = 0;
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(Query, con);
            id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();            
        }
        catch(Exception ex)
        {
            
        }
        return id;
    }

    public DataTable ExcutesQuery(string Query)
    {
        DataTable dt = new DataTable();
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(Query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            con.Close();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public void DeleteData(string Query)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand(Query, con);
        int id=cmd.ExecuteNonQuery();
        con.Close();         
    }

    public string UpdateData(string Query)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand(Query, con);
        string result= cmd.ExecuteNonQuery().ToString();
        con.Close();
        return result;
    }

    public string InsertEmployeedetails(empDetails empDetails, string StoredProcedure)
    {
        string Result="";
        try
        {            
            SqlCommand cmd = new SqlCommand(StoredProcedure, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", empDetails.id);
            cmd.Parameters.AddWithValue("@Fname", empDetails.Fname);
            cmd.Parameters.AddWithValue("@Mname", empDetails.Mname);
            cmd.Parameters.AddWithValue("@Lname", empDetails.Lname);
            cmd.Parameters.AddWithValue("@EmailID", empDetails.email);
            cmd.Parameters.AddWithValue("@PhoneNO", empDetails.phone);
            cmd.Parameters.AddWithValue("@isActive", empDetails.Active);
            cmd.Parameters.AddWithValue("@password", empDetails.Password);
            cmd.Parameters.AddWithValue("@date_updated", empDetails.dateupdated);            

            con.Open();
            if (empDetails.id > 0)//Update Case
            {
                int id = cmd.ExecuteNonQuery();

                string query = "Delete from Employee_Role where emp_id='" + empDetails.id + "'";
                SqlCommand cmd3 = new SqlCommand(query, con);
                cmd3.ExecuteNonQuery();

                for (int i = 0; i < empDetails.Roles.Length; i++)
                {
                    string Query = "Insert into Employee_Role(emp_id,role_id)values('" + empDetails.id + "','" + empDetails.Roles[i] + "')  select SCOPE_IDENTITY()";
                    SqlCommand cmd1 = new SqlCommand(Query, con);
                    int emprole = Convert.ToInt32(cmd1.ExecuteScalar());
                    if (emprole > 0)
                    {
                        Result = "Success";
                    }
                }

            }
            else //Insert Case
            {
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                if (id > 0)
                {
                    for (int i = 0; i < empDetails.Roles.Length; i++)
                    {
                        string Query = "Insert into Employee_Role(emp_id,role_id)values('" + id + "','" + empDetails.Roles[i] + "')  select SCOPE_IDENTITY()";
                        SqlCommand cmd1 = new SqlCommand(Query, con);
                        int emprole = Convert.ToInt32(cmd1.ExecuteScalar());
                        if (emprole > 0)
                        {
                            Result = "Success";
                        }
                    }
                }
            }

            con.Close();
        }
        catch(Exception ex)
        {
            Result = "Error: "+ex.Message;
            
        }

        return Result;
    }

    public int InsertTaskdetails(TaskDetails _taskDetails)
    {
        int taskid=0;
        string Result = "";
        try
        {
            SqlCommand cmd = new SqlCommand("sp_InsertTaskDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TaskTitle", _taskDetails.tasktitle);
            cmd.Parameters.AddWithValue("@Assignedby", _taskDetails.assignby);
            cmd.Parameters.AddWithValue("@TaskPriority", _taskDetails.priority);
            cmd.Parameters.AddWithValue("@Description", _taskDetails.description);
            cmd.Parameters.AddWithValue("@Attachment", _taskDetails.attachments);
            cmd.Parameters.AddWithValue("@status", _taskDetails.status);
            cmd.Parameters.AddWithValue("@Projectstatus", _taskDetails.projectstatus);
            if (_taskDetails.startdate == DateTime.MinValue)
            {
                cmd.Parameters.AddWithValue("@Start_Date_Time", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Start_Date_Time", _taskDetails.startdate);
            }
            if (_taskDetails.duedate == DateTime.MinValue)
            {
                cmd.Parameters.AddWithValue("@Due_Date_Time", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Due_Date_Time", _taskDetails.duedate);
            }
            cmd.Parameters.AddWithValue("@Attachmentsfile", _taskDetails.attachment);
            cmd.Parameters.AddWithValue("@ProjectId", _taskDetails.ProjectId);
            con.Open();
            taskid = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            //if (taskid > 0)
            //{
            //    Result = "Success";
            //}
        }
        catch (Exception ex)
        {

        }
        return taskid;
    }

    public string UpdateTaskdetails(TaskDetails _taskDetails)
    {
        string Result = "";
        try
        {
            SqlCommand cmd = new SqlCommand("sp_UpdateTaskDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@taskID", _taskDetails.taskid);
            cmd.Parameters.AddWithValue("@TaskTitle", _taskDetails.tasktitle);
            cmd.Parameters.AddWithValue("@Assignedby", _taskDetails.assignby);
            cmd.Parameters.AddWithValue("@TaskPriority", _taskDetails.priority);
            cmd.Parameters.AddWithValue("@Description", _taskDetails.description);
            cmd.Parameters.AddWithValue("@Attachment", _taskDetails.attachments);
            cmd.Parameters.AddWithValue("@status", _taskDetails.status);
            cmd.Parameters.AddWithValue("@Projectstatus", _taskDetails.projectstatus);
            cmd.Parameters.AddWithValue("@Start_Date_Time", _taskDetails.startdate);
            cmd.Parameters.AddWithValue("@Due_Date_Time", _taskDetails.duedate);

            con.Open();
            int taskid = cmd.ExecuteNonQuery();
            con.Close();
            if (taskid > 0)
            {
                Result = "Success";
            }
        }
        catch (Exception ex)
        {

        }
        return Result;
    }
    public DataTable dependacy(int a)
    {

        DataTable dt = new DataTable();
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("dependancy_tblstate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@state_id", a);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            con.Close();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable vendordependacy(int a)
    {

        DataTable dt = new DataTable();
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("dependancy_tblvendor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@vendor_id", a);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            con.Close();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable rolldependacy(int a)
    {

        DataTable dt = new DataTable();
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("dependancy_tblstate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@state_id", a);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            con.Close();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
}
