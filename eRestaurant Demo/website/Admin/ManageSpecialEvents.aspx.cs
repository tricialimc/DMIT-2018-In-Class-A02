using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ManageSpecialEvents : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ProcessExceptions(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if(e.Exception != null)
        {
            //Message User Control is to centralize all error handling
            //This will show the Error messages of the attributes within the Entities
            MessageUserControl.HandleDataBoundException(e);
            // We can display a message.
            //MessageLabel.Text = "Unable to process the request.";
            // Prevent the error from being handled by the ObjectDataSource control itself
            //e.ExceptionHandled = true; // I've dealt with the problem
        }
    }
}