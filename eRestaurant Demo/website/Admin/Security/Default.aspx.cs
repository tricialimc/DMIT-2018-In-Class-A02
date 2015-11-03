﻿using eRestaurant.Framework.BLL.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Security_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            DataBindUserList();
            DataBindRoleList();
        }
    }
    private void DataBindRoleList()
    {
        //Populate the roles info
        RolesListView.DataSource = new RoleManager().Roles.ToList();
        RolesListView.DataBind();
    }

    protected void RolesListView_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if(e.CommandName == "AddDefaultRoles")
        {
            var controller = new RoleManager();
            controller.AddDefaultRoles();
            DataBindRoleList();
        }
    }

    private void DataBindUserList()
    {
        //Populate the users info
        UserListView.DataSource = new UserManager().Users.ToList();
        UserListView.DataBind();
    }
    protected void UserListView_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if(e.CommandName == "AddDefaultUsers")
        {
            var controller = new UserManager();
            controller.AddDefaultUsers();
            DataBindUserList(); //Refresh the data in the listview
        }
    }
}