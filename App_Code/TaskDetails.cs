using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TaskDetails
{
    public int taskid { get; set; }
    public int assignby { get; set; }
    public string description { get; set; }
    public string tasktitle { get; set; }
    public string priority { get; set; }
    public string attachments { get; set; }
    public string projectstatus { get; set; }    
    public bool status { get; set; }
    public DateTime startdate { get; set; }
    public DateTime duedate { get; set; }
    public byte[] attachment {get; set; }

    public string ProjectId { get; set; }
}
