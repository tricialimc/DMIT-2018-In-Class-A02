﻿using eRestaurant.Framework.BLL;
using eRestaurant.Framework.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Staff_SplitBill : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void SelectBill_Click(object sender, EventArgs e)
    {
        GetBill();
    }

    private void GetBill()
    {
        var controller = new WaiterController();
        var data = controller.GetBill(int.Parse(ActiveBills.SelectedValue));
        BillToSplit.Value = data.BillID.ToString();

        //Set original bill items
        OriginalBillItems.DataSource = data.Items;
        OriginalBillItems.DataBind();

        //Empty out other bill
        NewBillItems.DataSource = null;
        NewBillItems.DataBind();
    }

    protected void BillItems_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        e.Cancel = true; //to prevent any other processing in the Gridview's default Select handling

        GridView sendingGridView = sender as GridView; //notice the safe casting
        GridViewRow row = sendingGridView.Rows[e.NewSelectedIndex];
        
        //1) get the info from the row
        var qtyLabel = row.FindControl("Quantity") as Label;
        //              <asp:Label ID="Quantity"... />
        var nameLabel = row.FindControl("ItemName") as Label;
        var priceLabel = row.FindControl("Price") as Label;
        OrderItem itemToMove = new OrderItem()
        {
            ItemName = nameLabel.Text,
            Quantity = int.Parse(qtyLabel.Text),
            Price = decimal.Parse(priceLabel.Text)
        };
        //temp output
        MessageLabel.Text = "I want to move " + qtyLabel.Text + " " + nameLabel.Text + 
                            " items onto the other bill (Gridview) $" + priceLabel.Text + " each";

        //2) move it to the other gridview
        GridView targetGridView;
        if (sender == OriginalBillItems)
            targetGridView = NewBillItems;
        else
            targetGridView = OriginalBillItems;

        List<OrderItem> targetItems = new List<OrderItem>();
        foreach(GridViewRow targetRow in targetGridView.Rows)
        {
            qtyLabel = targetRow.FindControl("Quantity") as Label;
            nameLabel = targetRow.FindControl("ItemLabel") as Label;
            priceLabel = targetRow.FindControl("Price") as Label;
            targetItems.Add(new OrderItem()
                {
                    ItemName = nameLabel.Text,
                    Quantity = int.Parse(qtyLabel.Text),
                    Price = decimal.Parse(priceLabel.Text)
                });
        }
        targetItems.Add(itemToMove);
        targetGridView.DataSource = targetItems;
        targetGridView.DataBind();

        //3) take the row out of this list
        List<OrderItem> senderItems = new List<OrderItem>();
        for (int index = 0; index < sendingGridView.Rows.Count; index++)
        {
            if (index != e.NewSelectedIndex)
            {
                GridViewRow senderRow = sendingGridView.Rows[index];
                qtyLabel = senderRow.FindControl("Quantity") as Label;
                nameLabel = senderRow.FindControl("ItemLabel") as Label;
                priceLabel = senderRow.FindControl("Price") as Label;
                senderItems.Add(new OrderItem()
                {
                    ItemName = nameLabel.Text,
                    Quantity = int.Parse(qtyLabel.Text),
                    Price = decimal.Parse(priceLabel.Text)
                });
            }
        }
        sendingGridView.DataSource = senderItems;
        sendingGridView.DataBind();
    }

    protected void SplitBill_Click(object sender, EventArgs e)
    {
        //Get the original bill items
        List<OrderItem> originalItems = new List<OrderItem>();
        foreach(GridViewRow row in OriginalBillItems.Rows)
        {
            var qtyLabel = row.FindControl("Quantity") as Label;
            var nameLabel = row.FindControl("ItemName") as Label;
            var priceLabel = row.FindControl("Price") as Label;
            originalItems.Add(new OrderItem()
                {
                    ItemName = nameLabel.Text,
                    Quantity = int.Parse(qtyLabel.Text),
                    Price = decimal.Parse(priceLabel.Text)
                });
        }

        //Get the new bill items
        List<OrderItem> newBillItems = new List<OrderItem>();
        foreach(GridViewRow newBillrow in NewBillItems.Rows)
        {
            var qtyLabel = newBillrow.FindControl("Quantity") as Label;
            var nameLabel = newBillrow.FindControl("ItemName") as Label;
            var priceLabel = newBillrow.FindControl("Price") as Label;
            originalItems.Add(new OrderItem()
            {
                ItemName = nameLabel.Text,
                Quantity = int.Parse(qtyLabel.Text),
                Price = decimal.Parse(priceLabel.Text)
            });
        }
        
        //Call the BLL to split the bill
        int billId = int.Parse(BillToSplit.Value); // from our HiddenField
        WaiterController controller = new WaiterController();
        //controller.SplitBill.
    }
    
}