using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Map : System.Web.UI.Page
{
    string pickaddr = null;
    string deliveraddr = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Convert.ToString(Session["PickupAddr"]) != null && Convert.ToString(Session["DeliveryAddr"]) != null)
        //{
        //    pickaddr = Convert.ToString(Session["PickupAddr"]);
        //    deliveraddr = Convert.ToString(Session["DeliveryAddr"]);
        //}
        //start.Items.Add(new ListItem(pickaddr, pickaddr));
        //end.Items.Add(new ListItem(deliveraddr, deliveraddr));

        pickaddr=Request.QueryString["addr2"];
        deliveraddr = Request.QueryString["addr1"];

        start.Items.Add(new ListItem(pickaddr, pickaddr));
        end.Items.Add(new ListItem(deliveraddr, deliveraddr));
    }
}